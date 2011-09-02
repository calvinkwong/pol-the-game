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
using System.Linq;
using System.Text;
using Patterns.MVC;
using PoL.Logic.Views;
using PoL.Services;
using Patterns.Command;
using PoL.Models.GameRestarters;
using PoL.Logic.Commands.GameRestarters;
using Patterns;
using System.Collections.Specialized;
using PoL.Models;
using PoL.Common;

namespace PoL.Logic.Controllers
{
  public class ServerRestarterController : BaseController<ServerRestarterModel, IServerRestarterView>
  {
    ServicesProvider servicesProvider;
    NetCommandHandler<IGameRestarterModel> commandHandler;

    public event SideboardingEditorRequestEventHandler SideboardingEditorRequest;

    public ServerRestarterController(NetCommandHandler<IGameRestarterModel> commandHandler, ServerRestarterModel model,
      List<PoL.Models.PlayerAccountData> players, IServerRestarterView view, ServicesProvider servicesProvider)
      : base(model, view)
    {
      view.RegisterController(this);
      this.commandHandler = commandHandler;
      this.servicesProvider = servicesProvider;
      this.commandHandler.ClientDisconnected += new Action<string>(commandHandler_ClientDisconnected);

      foreach(var player in players)
      {
        var playerModel = new PlayerModel(player.Info, player.Deck);
        playerModel.Ready.Changed += new EventHandler<Patterns.ChangedEventArgs<bool>>(PlayerReady_Changed);
        playerModel.Deck.Changed += new EventHandler<Patterns.ChangedEventArgs<DeckItem>>(PlayerDeck_Changed);
        model.Players.Add(playerModel);
        view.AddPlayer(player.Info);
        view.SetPlayerReadyState(player.Info, false);
      }

      model.Started += new Action<object>(model_Started);
      model.Players.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Players_CollectionChanged);
      model.Console.Messages.CollectionChanged += new NotifyCollectionChangedEventHandler(Messages_CollectionChanged);

      View.EnableSideboarding(true);
      View.EnableStart(false);
      view.SetReadyState(false);
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

    void Players_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
      switch(e.Action)
      { 
        case NotifyCollectionChangedAction.Add:
          View.AddPlayer(((PlayerModel)e.NewItems[0]).Player);
          break;
        case NotifyCollectionChangedAction.Remove:
          View.RemovePlayer(((PlayerModel)e.OldItems[0]).Player);
          break;
        case NotifyCollectionChangedAction.Reset:
          View.ClearPlayers();
          break;
      }
    }

    void commandHandler_ClientDisconnected(string name)
    {
      UpdatePlayerListCommand cmd = new UpdatePlayerListCommand(Model);
      cmd.Arguments = new UpdatePlayerListArguments()
      {
        Players = Model.Players.Cast<PlayerModel>().Where(e => e.Key == name).Select(e => new PlayerAccountData()
        {
          Info = e.Player,
          Deck = e.Deck.Value,
          Ready = false,
        }).ToList(),
        Connected = false
      };
      commandHandler.Execute(cmd);
    }

    void model_Started(object obj)
    {
      View.ViewResult = ViewResult.Ok;
      View.Close();
    }

    void PlayerDeck_Changed(object sender, Patterns.ChangedEventArgs<DeckItem> e)
    {
    }

    void PlayerReady_Changed(object sender, Patterns.ChangedEventArgs<bool> e)
    {
      ObservableProperty<bool, PlayerModel> ready = (ObservableProperty<bool, PlayerModel>)sender;
      View.SetPlayerReadyState(ready.Owner.Player, ready.Value);
      View.EnableSideboarding(!Model.Players.Cast<PlayerModel>().First().Ready.Value);
      View.EnableStart(Model.Players.Cast<PlayerModel>().All(p => p.Ready.Value));
      if(ready.Owner.Player.NickName == Model.Players.First().Key)
        View.SetReadyState(ready.Value);
    }

    public void StartGame()
    {
      StartGameCommand cmd = new StartGameCommand(Model);
      commandHandler.Execute(cmd);
    }

    public void SetReadyState()
    {
      SetReadyStateCommand cmd = new SetReadyStateCommand(Model);
      commandHandler.Execute(cmd);
    }

    public void Chat()
    {
      ChatCommand cmd = new ChatCommand(Model);
      cmd.Arguments = new ChatArguments() { Text = View.ConsoleText };
      commandHandler.Execute(cmd);

      View.ConsoleText = string.Empty;
    }
 
    public void DoSideboarding()
    {
      SideboardingEditorRequestEventArgs args = new SideboardingEditorRequestEventArgs(false, (DeckItem)((PlayerModel)Model.Players.First()).Deck.Value.Clone());
      OnSideboardingEditorRequest(args);
      if(!args.Cancel)
      {
        SetDeckCommand cmd = new SetDeckCommand(Model);
        cmd.Arguments = new SetDeckArguments() { Deck = args.Deck };
        commandHandler.Execute(cmd);
      }
    }

    protected virtual void OnSideboardingEditorRequest(SideboardingEditorRequestEventArgs args)
    {
      if(SideboardingEditorRequest != null)
        SideboardingEditorRequest(this, args);
    }
  }

  public delegate void SideboardingEditorRequestEventHandler(object sender, SideboardingEditorRequestEventArgs args);

  public class SideboardingEditorRequestEventArgs : EventArgs
  {
    public bool Cancel { get; set; }
    public DeckItem Deck { get; set; }

    public SideboardingEditorRequestEventArgs(bool cancel, DeckItem deck)
    {
      this.Cancel = cancel;
      this.Deck = deck;
    }
  }
}
