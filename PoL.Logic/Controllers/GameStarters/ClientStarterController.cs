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

using PoL.Services;
using PoL.Logic.Views;
using PoL.Common;
using PoL.Models.GameStarters;
using Communication;
using Patterns.MVC;
using Patterns.ComponentModel;
using PoL.Configuration;
using System.Collections.Specialized;
using PoL.Logic.Commands.GameStarters;
using Patterns.Command;
using PoL.Models;

namespace PoL.Logic.Controllers.GameStarters
{
  public class ClientStarterController : BaseController<ClientStarterModel, IClientStarterView>
  {
    ServicesProvider servicesProvider;
    ClientConnector connector;
    ClientInitializationModel initData;
    NetCommandHandler<IGameStarterModel> netCommandHandler;

    public ClientStarterController(NetCommandHandler<IGameStarterModel> netCommandHandler,
      ClientStarterModel clientStarterModel, ClientConnector connector, IClientStarterView clientStarterView, ServicesProvider servicesProvider, 
      ClientInitializationModel initData)
      : base(netCommandHandler.BaseCommandHandler, clientStarterModel, clientStarterView)
    {
      clientStarterView.RegisterController(this);
      this.netCommandHandler = netCommandHandler;
      this.initData = initData;
      this.servicesProvider = servicesProvider;
      this.connector = connector;
      this.connector.Disconnected += new Action<object, ServiceNetClient>(connector_Disconnected);

      clientStarterModel.Started += new Action<object>(clientStarterModel_Started);
      clientStarterModel.Console.Messages.CollectionChanged += new CollectionChangedEventHandler(Messages_CollectionChanged);
      clientStarterModel.Players.CollectionChanged += new CollectionChangedEventHandler(Players_CollectionChanged);

      ResetView();
    }

    void clientStarterModel_Started(object sender)
    {
      View.ViewResult = ViewResult.Ok;
      View.Close();
    }

    void connector_Disconnected(object sender, ServiceNetClient client)
    {
      ResetView();
      Model.Console.WriteLine(MessageCategory.Warning, "Server has disconnected.");
    }

    void Players_CollectionChanged(object sender, CollectionChangedEventArgs e)
    {
      switch(e.Action)
      {
        case CollectionChangedAction.Add:
          PlayerAccountData ply = (PlayerAccountData)e.NewItems[0];
          View.AddPlayer(ply.Info);
          break;
        case CollectionChangedAction.Reset:
          View.ClearPlayers();
          break;
      }
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

    void ResetView()
    {
      View.ClearPlayers();
    }

    public void Chat()
    {
      ChatCommand cmd = new ChatCommand(Model);
      cmd.Arguments = new ChatArguments() { Text = View.ConsoleText };
      netCommandHandler.Execute(cmd);

      View.ConsoleText = string.Empty;
    }
  }
}
