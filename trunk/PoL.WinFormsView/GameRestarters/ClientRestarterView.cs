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
using System.Linq;
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
using PoL.WinFormsView.Utils;
using PoL.WinFormsView.Properties;

namespace PoL.WinFormsView.GameRestarters
{
  public partial class ClientRestarterView : WinFormsView, IClientRestarterView, ILocalizable
  {
    ClientRestarterController controller;
    bool ready;

    public ClientRestarterView()
    {
      InitializeComponent();
      this.DialogResult = DialogResult.Cancel;

      btnCancel.Click += new EventHandler(btnCancel_Click);
      btnSideboarding.Click += new EventHandler(btnSideboarding_Click);
      btnReady.Click += new EventHandler(btnReady_Click);

      Localize();
    }

    void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    void btnReady_Click(object sender, EventArgs e)
    {
      try
      {
        controller.SetReadyState();
      }
      catch(Exception ex)
      {
        Program.ExceptionBox(this, ex);
      }
    }

    void btnSideboarding_Click(object sender, EventArgs e)
    {
      try
      {
        controller.DoSideboarding();
      }
      catch(Exception ex)
      {
        Program.ExceptionBox(this, ex);
      }
    }

    public ClientRestarterController Controller
    {
      get { return controller; }
    }

    public void Localize()
    {
      this.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CLIENT_RESTARTGAME_DIALOG", "TITLE");
      lblPlayers.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CLIENT_RESTARTGAME_DIALOG", "PLAYER_LIST");
      lblPlayers.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CLIENT_RESTARTGAME_DIALOG", "PLAYER_LIST_DESC");
      lblConsoleTitle.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CLIENT_RESTARTGAME_DIALOG", "CHAT");
      lblConsoleTitle.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CLIENT_RESTARTGAME_DIALOG", "CHAT_DESC");
      btnCancel.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CLIENT_RESTARTGAME_DIALOG", "CANCEL");
      btnSideboarding.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CLIENT_RESTARTGAME_DIALOG", "SIDEBOARDING");
      btnReady.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CLIENT_RESTARTGAME_DIALOG", ready ? "NOT_READY" : "READY");
      consoleView.Localize();
    }

    #region IView<ClientRestarterController> Membri di

    public void RegisterController(ClientRestarterController controller)
    {
      this.controller = controller;
    }

    #endregion

    #region IClientRestarterView Membri di

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
        playerItem.Name = player.NickName;
        listPlayers.Controls.Add(playerItem);
      }
    }

    public void RemovePlayer(PlayerInfo player)
    {
      if(InvokeRequired)
        Invoke(new Action<PlayerInfo>(RemovePlayer), player);
      else
      {
        listPlayers.Controls.RemoveByKey(player.NickName);
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

    public void SetReadyState(bool ready)
    {
      if(InvokeRequired)
        Invoke(new Action<bool>(SetReadyState), ready);
      else
      {
        this.ready = ready;
        btnReady.Image = ready ? Resources.button_red_small : Resources.button_green_small;
        Localize();
      }
    }

    public void SetPlayerReadyState(PlayerInfo player, bool ready)
    {
      if(InvokeRequired)
        Invoke(new Action<PlayerInfo, bool>(SetPlayerReadyState), player, ready);
      else
      {
        listPlayers.Controls.Find(player.NickName, true).Cast<PlayerListItem>().First().ReadyState = ready ? PlayerReadyState.Ready : PlayerReadyState.NotReady;
      }
    }

    public void EnableSideboarding(bool enable)
    {
      if(InvokeRequired)
        Invoke(new Action<bool>(EnableSideboarding), enable);
      else
      {
        btnSideboarding.Enabled = enable;
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