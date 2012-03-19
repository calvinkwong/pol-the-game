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
using PoL.Models.GameRestarters;
using Patterns.Command;
using Patterns.ComponentModel;
using Patterns;
using PoL.Logic.Commands.GameRestarters;
using PoL.Common;
using System.Collections.Specialized;

namespace PoL.Logic.Controllers
{
  public class ClientRestarterController : BaseController<ClientRestarterModel, IClientRestarterView>
  {
    ServicesProvider servicesProvider;
    NetCommandHandler<IGameRestarterModel> commandHandler;

    public event SideboardingEditorRequestEventHandler SideboardingEditorRequest;

    public ClientRestarterController(NetCommandHandler<IGameRestarterModel> commandHandler, ClientRestarterModel model,
      List<PoL.Models.PlayerAccountData> players, IClientRestarterView view, ServicesProvider servicesProvider)
      : base(model, view)
    {
      view.RegisterController(this);

      this.servicesProvider = servicesProvider;
      this.commandHandler = commandHandler;

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
      model.Players.CollectionChanged += new CollectionChangedEventHandler(Players_CollectionChanged);
      model.Console.Messages.CollectionChanged += new CollectionChangedEventHandler(Messages_CollectionChanged);

      View.EnableSideboarding(true);
      view.SetReadyState(false);
    }

    void Messages_CollectionChanged(object sender, CollectionChangedEventArgs e)
    {
      switch(e.Action)
      {
        case CollectionChangedAction.Add:
          View.AddConsoleMessage((TextMessage)e.NewItems[0]);
          break;
      }
    }

    void Players_CollectionChanged(object sender, CollectionChangedEventArgs e)
    {
      switch(e.Action)
      {
        case CollectionChangedAction.Add:
          View.AddPlayer(((PlayerModel)e.NewItems[0]).Player);
          break;
        case CollectionChangedAction.Remove:
          View.RemovePlayer(((PlayerModel)e.OldItems[0]).Player);
          break;
        case CollectionChangedAction.Reset:
          View.ClearPlayers();
          break;
      }
    }

    void commandHandler_ClientDisconnected(string name)
    {
      Model.Console.WriteLine(MessageCategory.Warning, "Server has disconnected.");
      View.ClearPlayers();
      View.EnableSideboarding(false);
      View.SetReadyState(false);
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
      if(ready.Owner.Player.NickName == Model.Players.First().Key)
        View.SetReadyState(ready.Value);
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
}
