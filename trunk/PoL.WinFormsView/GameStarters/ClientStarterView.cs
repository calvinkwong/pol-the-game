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
using PoL.Services;
using Patterns.MVC;
using PoL.Common;
using PoL.Logic.Controllers.GameStarters;
using PoL.WinFormsView.Utils;

namespace PoL.WinFormsView.GameStarters
{
  public partial class ClientStarterView : WinFormsView, IClientStarterView, ILocalizable
  {
    ClientStarterController controller;

    public ClientStarterView()
    {
      InitializeComponent();
      this.DialogResult = DialogResult.Cancel;

      btnCancel.Click += new EventHandler(btnCancel_Click);

      Localize();
    }

    void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    public ClientStarterController Controller
    {
      get { return controller; }
    }

    public void Localize()
    {
      this.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("NEW_CLIENT_GAME_DIALOG", "TITLE");
      lblPlayers.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("NEW_CLIENT_GAME_DIALOG", "PLAYER_LIST");
      lblPlayers.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("NEW_CLIENT_GAME_DIALOG", "PLAYER_LIST_DESC");
      lblConsoleTitle.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("NEW_CLIENT_GAME_DIALOG", "CHAT");
      lblConsoleTitle.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("NEW_CLIENT_GAME_DIALOG", "CHAT_DESC");
      btnCancel.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("NEW_CLIENT_GAME_DIALOG", "CANCEL");

      consoleView.Localize();
    }

    #region IView<ClientStarterController> Membri di

    public void RegisterController(ClientStarterController controller)
    {
      this.controller = controller;
    }

    #endregion

    #region IClientStarterView Membri di

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

    #endregion
  }
}