/*
PoL - The polyhedral card game simulator
Copyright (C) 2011 Andrea Biagini

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
*/

using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

using PoL.Services;
using PoL.Logic.Views;
using PoL.Common;
using PoL.Models.GameStarters;
using Communication;
using Patterns.MVC;
using Patterns;
using System.Collections.Specialized;
using Patterns.Command;
using PoL.Logic.Commands.GameStarters;
using PoL.Models;
using PoL.Models.Game;
using System.IO;
using System.ComponentModel;
using System.Threading;

namespace PoL.Logic.Controllers.GameStarters
{
  public class ServerStarterController : BaseController<ServerStarterModel, IServerStarterView>
  {
    NetCommandHandler<IGameStarterModel> netCommandHandler;
    ServicesProvider servicesProvider;
    ServerListener listener;
    PlayerInfo serverPlayer;
    GameStartMode startMode;
    ServerStartNewGameModel newGameData;
    ServerStartSavedGameModel savedGameData;
    BackgroundWorker worker = new BackgroundWorker();

    public ServerStarterController(NetCommandHandler<IGameStarterModel> netCommandHandler, 
      ServerStarterModel serverStarter, ServerListener listener, IServerStarterView serverStarterView,
      PlayerInfo serverPlayer, ServicesProvider servicesProvider, GameStartMode startMode,
      ServerStartNewGameModel newGameData, ServerStartSavedGameModel savedGameData)
      : base(netCommandHandler.BaseCommandHandler, serverStarter, serverStarterView)
    {
      serverStarterView.RegisterController(this);
      this.netCommandHandler = netCommandHandler;
      this.servicesProvider = servicesProvider;

      this.serverPlayer = serverPlayer;
      this.startMode = startMode;
      this.newGameData = newGameData;
      this.savedGameData = savedGameData;

      this.listener = listener;
      this.listener.PlayerConnected += new Action<object, ServiceNetClient, PlayerAccountData>(listener_PlayerConnected);
      this.listener.PlayerDisconnected += new Action<object, ServiceNetClient, PlayerInfo>(listener_PlayerDisconnected);

      serverStarter.Console.Messages.CollectionChanged += new NotifyCollectionChangedEventHandler(Messages_CollectionChanged);
      serverStarter.Started += new Action<object>(serverStarter_Started);

      serverStarter.Players.CollectionChanged += new NotifyCollectionChangedEventHandler(Players_CollectionChanged);

      View.SetState(ServerStarterState.Waiting);

      PlayerAccountData player = new PlayerAccountData()
      {
        Info = serverPlayer,
        Deck = startMode == GameStartMode.NewGame ? newGameData.Deck : null,
        Password = startMode == GameStartMode.NewGame ? newGameData.Password : savedGameData.Password
      };
      Model.Players.Add(player);

      worker.WorkerSupportsCancellation = true;
      worker.DoWork += delegate(object sender, DoWorkEventArgs e)
      {
        View.SetIP(Net.GetPublicIP());
      };
      worker.RunWorkerAsync();
    }

    void Ip_Changed(object sender, ChangedEventArgs<IPAddress> e)
    {
      View.SetIP(e.NewValue);
    }

    void serverStarter_Started(object obj)
    {
      worker.CancelAsync();
      View.ViewResult = ViewResult.Ok;
      View.Close();
    }

    void listener_PlayerConnected(object sender, ServiceNetClient client, PlayerAccountData connectedPlayer)
    {
      netCommandHandler.AddChannel(client, connectedPlayer.Info.NickName);

      List<PlayerAccountData> players = Model.Players.ToList();
      players.Add(connectedPlayer);

      UpdatePlayerList(players, connectedPlayer.Info, true);
    }

    void listener_PlayerDisconnected(object sender, ServiceNetClient client, PlayerInfo player)
    {
      //netCommandHandler.RemoveClient(client);

      List<PlayerAccountData> players = Model.Players.ToList();
      players.Remove(players.Single(e => e.Info.NickName == player.NickName));

      UpdatePlayerList(players, player, false);
    }

    void UpdatePlayerList(List<PlayerAccountData> allPlayers, PlayerInfo connectedPlayer, bool connected)
    {
      UpdatePlayerListCommand cmd = new UpdatePlayerListCommand(Model);
      cmd.Arguments = new UpdatePlayerListArguments() 
      { 
        AllPlayers = allPlayers, 
        ConnectedPlayer = connectedPlayer, 
        Connected = connected 
      };
      netCommandHandler.Execute(cmd);
    }

    void Players_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      ObservableCollection<PlayerAccountData> players = (ObservableCollection<PlayerAccountData>)sender;
      switch(e.Action)
      {
        case NotifyCollectionChangedAction.Add:
          PlayerAccountData ply = (PlayerAccountData)e.NewItems[0];
          View.AddPlayer(ply.Info);
          if(players.Count > 1)
            View.SetState(ServerStarterState.CanStart);
          else
            View.SetState(ServerStarterState.Waiting);
          break;
        case NotifyCollectionChangedAction.Reset:
          View.ClearPlayers();
          break;
      }
    }

    void Messages_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      switch(e.Action)
      {
        case NotifyCollectionChangedAction.Add:
          View.AddConsoleMessage((TextMessage)e.NewItems[0]);
          break;
      }
    }

    bool TryLoadGame(out GameModel gameModel)
    {
      bool loaded = false;
      gameModel = null;

      CryptoDataSaver gameSaver = new CryptoDataSaver(Model.Players.Select(e => e.Password).ToList());
      try
      {
        gameSaver.Load(savedGameData.SaveId, out gameModel);
        loaded = true;
      }
      catch {}
      return loaded;
    }

    public void Chat()
    {
      ChatCommand cmd = new ChatCommand(Model);
      cmd.Arguments = new ChatArguments() { Text = View.ConsoleText };
      netCommandHandler.Execute(cmd);

      View.ConsoleText = string.Empty;
    }

    public void StartGame()
    {
      GameModel game = null;

      bool start = true;
      if(startMode == GameStartMode.SavedGame)
      {
        start = false;
        if(!TryLoadGame(out game))
        {
          Model.Console.WriteLine(MessageCategory.Warning, servicesProvider.SystemStringsService.GetString(
            "NEW_SERVER_GAME_DIALOG", "MSG_GAMELOADFAILED_CANNOTLOAD"));
        }
        else if(game.Players.Count != Model.Players.Count)
        {
          Model.Console.WriteLine(MessageCategory.Warning, servicesProvider.SystemStringsService.GetString(
            "NEW_SERVER_GAME_DIALOG", "MSG_GAMELOADFAILED_DIFFERENTPLAYERSCOUNT").Replace("#amount#", game.Players.Count.ToString()));
        }
        else if(game.Players.Cast<PlayerModel>().Select(e => e.Info.NickName).Intersect(
          Model.Players.Select(e => e.Info.NickName)).Count() != Model.Players.Count)
        {
          Model.Console.WriteLine(MessageCategory.Warning, servicesProvider.SystemStringsService.GetString(
            "NEW_SERVER_GAME_DIALOG", "MSG_GAMELOADFAILED_DIFFERENTNICKNAMES"));
        }
        else
          start = true;
      }

      if(start)
      {
        StartGameCommand cmd = new StartGameCommand(Model);
        cmd.Arguments = new StartGameArguments() { SavedGame = game };
        netCommandHandler.Execute(cmd);
      }
    }
  }
}
