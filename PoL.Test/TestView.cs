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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PoL.Services;
using PoL.Logic.Controllers;
using PoL.Models.GameStarters;
using PoL.Common;
using PoL.Models;
using PoL.Logic;
using PoL.WinFormsView;
using System.Net;
using System.Threading;
using PoL.Services.DataEntities;
using PoL.Models.Game;
using Communication;
using Patterns;
using PoL.Logic.Controllers.GameStarters;
using PoL.Test.Properties;
using PoL.Logic.Commands.Game;

namespace PoL.Test
{
  public partial class TestView : Form
  {
    LogicHandler logicStarter;

    ClientStarterModel clientStarter1;
    ClientConnector connector1;
    DeckItem clientDeck1;
    PlayerInfo clientPlayer1;

    ClientStarterModel clientStarter2;
    ClientConnector connector2;
    DeckItem clientDeck2;
    PlayerInfo clientPlayer2;

    PlayerInfo serverPlayer;
    DeckItem serverDeck;

    const int PORT = 8668;
    int playerCounter = 0;

    public TestView()
    {
      InitializeComponent();
      logicStarter = new LogicHandler(new WinFormsViewFactory());

      clientPlayer1 = CreatePlayerInfo("ClientPlayer1");
      clientDeck1 = logicStarter.ServicesProvider.DecksService.LoadDeck("Reali", "Samurai");
      clientDeck1.MainCards.Shuffle();
      clientStarter1 = new ClientStarterModel(clientPlayer1, clientDeck1, logicStarter.ServicesProvider);
      clientStarter1.Started += new Action<object>(clientStarter1_Started);
      connector1 = new ClientConnector(clientPlayer1, logicStarter.ServicesProvider);

      clientPlayer2 = CreatePlayerInfo("ClientPlayer2");
      clientDeck2 = logicStarter.ServicesProvider.DecksService.LoadDeck("Reali", "Samurai");
      clientDeck2.MainCards.Shuffle();
      clientStarter2 = new ClientStarterModel(clientPlayer2, clientDeck2, logicStarter.ServicesProvider);
      clientStarter2.Started += new Action<object>(clientStarter2_Started);
      connector2 = new ClientConnector(clientPlayer2, logicStarter.ServicesProvider);

      serverPlayer = CreatePlayerInfo("ServerPlayer");
      serverDeck = logicStarter.ServicesProvider.DecksService.LoadDeck("Reali", "Samurai");
      serverDeck.MainCards.Shuffle();
    }

    PlayerInfo CreatePlayerInfo(string playerName)
    {
      return new PlayerInfo(playerName, "Message of " + playerName + "!", Resources.Avatar);
    }

    ServerData opponentData1;
    ServerData opponentData2;
    private void btnStart_Click(object sender, EventArgs e)
    {
      playerCounter = 0;
      ServerStarterModel serverStarter = new ServerStarterModel(serverPlayer);
      ServerListener listener = new ServerListener(serverPlayer, logicStarter.ServicesProvider, PORT);
      listener.PlayerConnected += new Action<object, ServiceNetClient, PlayerAccountData>(listener_PlayerConnected);
      listener.Start(false, serverDeck, GameStartMode.NewGame);

      Thread.Sleep(100);

      string errorMessage;
      connector1.Connect(IPAddress.Loopback, PORT, string.Empty, GameStartMode.NewGame, clientDeck1, out errorMessage, out opponentData1);
      connector2.Connect(IPAddress.Loopback, PORT, string.Empty, GameStartMode.NewGame, clientDeck2, out errorMessage, out opponentData2);
    }

    void clientStarter1_Started(object sender)
    {
      if(opponentData1 != null)
      {
        PlayerInfo[] players = new PlayerInfo[] { clientPlayer1, clientPlayer2, serverPlayer };
        DeckItem[] decks = new DeckItem[] { clientDeck1, clientDeck2, serverDeck };

        StartGame(Enumerable.Repeat(new PlayerConnection() { NetClient = opponentData1.Channel }, 1).ToList(), players.ToList(), decks.ToList(),
          new string[] { string.Empty, string.Empty, string.Empty }, GameType.Client, false);
      }
    }

    void clientStarter2_Started(object sender)
    {
      if(opponentData2 != null)
      {
        PlayerInfo[] players = new PlayerInfo[] { clientPlayer2, clientPlayer1, serverPlayer };
        DeckItem[] decks = new DeckItem[] { clientDeck2, clientDeck1, serverDeck };

        StartGame(Enumerable.Repeat(new PlayerConnection() { NetClient = opponentData2.Channel }, 1).ToList(), players.ToList(), decks.ToList(), 
          new string[] { string.Empty, string.Empty, string.Empty}, GameType.Client, false);
      }
    }

    void listener_PlayerConnected(object sender, ServiceNetClient client, PlayerAccountData connectedPlayer)
    {
      if(++playerCounter < 2)
        return;

      if(InvokeRequired)
        Invoke(new Action<object, ServiceNetClient, PlayerAccountData>(listener_PlayerConnected), sender, client, connectedPlayer);
      else
      {
        ServerListener listener = (ServerListener)sender;
        if(listener.PlayerConnections != null)
        {
          listener.Dispose();
          clientStarter1.Start(null);
          clientStarter2.Start(null);

          PlayerInfo[] players = new PlayerInfo[] { serverPlayer, clientPlayer2, clientPlayer1 };
          DeckItem[] decks = new DeckItem[] { serverDeck, clientDeck2, clientDeck1 };
          Thread.Sleep(1000);
          StartGame(listener.PlayerConnections, players.ToList(), decks.ToList(),
            new string[] { string.Empty, string.Empty, string.Empty }, GameType.Host, false);
        }
      }
    }

    void StartGame(List<PlayerConnection> connections, List<PlayerInfo> players, List<DeckItem> decks, 
      string[] passwords, GameType gameType, bool modal)
    {
      List<PlayerAccountData> allPlayers = new List<PlayerAccountData>();
      for(int i = 0; i < players.Count; i++)
        allPlayers.Add(new PlayerAccountData() { Info = players[i], Password = passwords[i], Deck = decks[i] });

      var gameModel = new GameModel(logicStarter.GameItem);
      var gameView = logicStarter.ViewFactory.CreateGameView();
      
      //using(GameCommandHandler gameCommandHandler = new GameCommandHandler(gameModel, allPlayers.First().Player.UniqueID))
      //{
      GameCommandHandler gameCommandHandler = new GameCommandHandler(gameModel, allPlayers.First().Info.NickName, logicStarter.ServicesProvider);
      
      for(int i = 0; i < connections.Count; i++)
          gameCommandHandler.AddChannel(connections[i].NetClient, players[i + 1].NickName);
        var gameController = new GameController(gameCommandHandler, gameModel, gameView, allPlayers, gameType, logicStarter.ServicesProvider, true);
        gameController.ShowOptionsRequested += new EventHandler(gameController_ShowOptionsRequested);
        if(modal)
          gameView.ShowModal();
        else
          gameView.Show();
      //}
    }

    public void gameController_ShowOptionsRequested(object sender, EventArgs e)
    {
      var optionsView = logicStarter.ViewFactory.CreateOptionsView();
      OptionsController optionsController = new OptionsController(optionsView, true, logicStarter.ServicesProvider);
      optionsView.ShowModal();
    } 

    private void btnStartSolitaire_Click(object sender, EventArgs e)
    {
      PlayerInfo[] players = new PlayerInfo[] { serverPlayer, clientPlayer2, clientPlayer1 };
      DeckItem[] decks = new DeckItem[] { serverDeck, clientDeck2, clientDeck1 };

      StartGame(new List<PlayerConnection>(), players.ToList(), decks.ToList(),
        new string[] { string.Empty, string.Empty, string.Empty }, GameType.Solitaire, true);
    }
  }
}
