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
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using PoL.Logic.Controllers;
using PoL.Logic.Views;
using PoL.WinFormsView;
using PoL.Services;
using Patterns.MVC;
using PoL.Common;
using PoL.Logic.Controllers.GameStarters;
using PoL.WinFormsView.Utils;

namespace PoL.WinFormsView.GameStarters
{
  public partial class ServerStarterView : WinFormsView, IServerStarterView, ILocalizable
  {
    ServerStarterController controller;
    ServerStarterState state;

    public ServerStarterView()
    {
      InitializeComponent();

      btnStart.Click += new EventHandler(btnStart_Click);
      btnCancel.Click += new EventHandler(btnCancel_Click);

      Localize();
    }
    
    public ServerStarterController Controller
    {
      get { return controller; }
    }

    void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    void btnStart_Click(object sender, EventArgs e)
    {
      try
      {
        controller.StartGame();
      }
      catch(Exception ex)
      {
        Program.ExceptionBox(this, ex);
      }
    }

    public void Localize()
    {
      this.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("NEW_SERVER_GAME_DIALOG", "TITLE");
      lblPlayers.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("NEW_SERVER_GAME_DIALOG", "PLAYER_LIST");
      lblPlayers.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("NEW_SERVER_GAME_DIALOG", "PLAYER_LIST_DESC");
      lblConsoleTitle.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("NEW_SERVER_GAME_DIALOG", "CHAT");
      lblConsoleTitle.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("NEW_SERVER_GAME_DIALOG", "CHAT_DESC");
      btnCancel.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("NEW_SERVER_GAME_DIALOG", "CANCEL");
      btnStart.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("NEW_SERVER_GAME_DIALOG", "START");
      lblYourIP.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("NEW_SERVER_GAME_DIALOG", "YOUR_IP");

      consoleView.Localize();
    }

    #region IServerStarterView Members

    public void SetState(ServerStarterState state)
    {
      if(InvokeRequired)
        Invoke(new Action<ServerStarterState>(SetState), state);
      else
      {
        this.state = state;
        btnStart.Enabled = state != ServerStarterState.Waiting;
        Localize();
      }
    }

    public void AddConsoleMessage(TextMessage message)
    {
      if(InvokeRequired)
        Invoke(new Action<TextMessage>(AddConsoleMessage), message);
      else
      {
        consoleView.AddMessage(message);
      }
    }

    public void AddPlayer(PlayerInfo player)
    {
      if(InvokeRequired)
        Invoke(new Action<PlayerInfo>(AddPlayer), player);
      else
      {
        PlayerListItem playerItem = new PlayerListItem();
        playerItem.Player = player;
        listPlayers.Controls.Add(playerItem);
      }
    }

    public void ClearPlayers()
    {
      if(InvokeRequired)
        Invoke(new Action(ClearPlayers));
      else
      {
        listPlayers.Controls.Clear();
      }
    }

    public string ConsoleText
    {
      get { return consoleView.CurrentText; }
      set { consoleView.CurrentText = value; }
    }

    public void SetIP(IPAddress ipAddress)
    {
      if(InvokeRequired)
        Invoke(new Action<IPAddress>(SetIP), ipAddress);
      else
      {
        txtIpAddress.Text = ipAddress.ToString();
        consoleView.FocusOnInput();
      }
    }

    #endregion

    #region IView<ServerStarterController> Members

    public void RegisterController(ServerStarterController controller)
    {
      this.controller = controller;
    }

    #endregion
  }
}