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
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PoL.WinFormsView.Properties;
using PoL.Services.DataEntities;
using PoL.Configuration;

namespace PoL.WinFormsView
{
  public partial class MainMenu: Form, ILocalizable
  {
    public MainMenu()
    {
      InitializeComponent();
      this.Icon = Resources.Logo;
      this.Text = Application.ProductName + " v." + Application.ProductVersion;

      btnStartSolitaire.Click += new EventHandler(btnStartSolitaire_Click);
      btnHostGame.Click += new EventHandler(btnHostGame_Click);
      btnConnectGame.Click += new EventHandler(btnConnectGame_Click);
      btnConnectServer.Click += new EventHandler(btnConnectServer_Click);
      btnDeckEditor.Click += new EventHandler(btnDeckEditor_Click);
      btnOptions.Click += new EventHandler(btnOptions_Click);
      btnQuit.Click += new EventHandler(btnQuit_Click);
      btnChat.Click += new EventHandler(btnChat_Click);

      Localize();
    }

    public void Localize()
    {
      lblCurrentGame.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("START_MENU", "CURRENT_GAME");
      lblCurrentGame.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("START_MENU", "CURRENT_GAME_DESC");
      btnStartSolitaire.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("START_MENU", "SOLITAIRE");
      btnStartSolitaire.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("START_MENU", "SOLITAIRE_DESC");
      btnHostGame.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("START_MENU", "HOST_GAME");
      btnHostGame.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("START_MENU", "HOST_GAME_DESC");
      btnConnectGame.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("START_MENU", "CONNECT_TO");
      btnConnectGame.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("START_MENU", "CONNECT_TO_DESC");
      btnDeckEditor.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("START_MENU", "DECK_EDITOR");
      btnDeckEditor.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("START_MENU", "DECK_EDITOR_DESC");
      btnChat.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("START_MENU", "CHAT");
      btnChat.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("START_MENU", "CHAT_DESC");
      btnOptions.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("START_MENU", "OPTIONS");
      btnOptions.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("START_MENU", "OPTIONS_DESC");
      btnQuit.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("START_MENU", "QUIT");
      btnQuit.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("START_MENU", "QUIT_DESC");

      lblCurrentGame.Text = Program.LogicHandler.GameItem.Name;
    }

    void btnChat_Click(object sender, EventArgs e)
    {
      try
      {
        System.Diagnostics.Process.Start(SettingsManager.Settings.ChatUri);
      }
      catch(Exception ex)
      {
        Program.ExceptionBox(this, ex);
      }
    }

    void btnOptions_Click(object sender, EventArgs e)
    {
      this.Visible = false;
      try
      {
        Program.LogicHandler.ShowOptions();
      }
      catch(Exception ex)
      {
        Program.ExceptionBox(this, ex);
      }
      finally
      {
        this.Visible = true;
        this.Activate();
      }
    }

    void btnDeckEditor_Click(object sender, EventArgs e)
    {
      this.Visible = false;
      try
      {
        Program.LogicHandler.ShowDeckEditor();
      }
      catch(Exception ex)
      {
        Program.ExceptionBox(this, ex);
      }
      finally
      {
        this.Visible = true;
        this.Activate();
      }
    }

    void btnConnectGame_Click(object sender, EventArgs e)
    {
      this.Visible = false;
      try
      {
        new JoinGameMenu().ShowDialog(this);
      }
      catch(Exception ex)
      {
        Program.ExceptionBox(this, ex);
      }
      finally
      {
        this.Visible = true;
        this.Activate();
      }
    }

    void btnConnectServer_Click(object sender, EventArgs e)
    {
      this.Visible = false;
      try
      {
        Program.LogicHandler.ConnectToServer();
      }
      catch(Exception ex)
      {
        Program.ExceptionBox(this, ex);
      }
      finally
      {
        this.Visible = true;
        this.Activate();
      }
    }

    void btnHostGame_Click(object sender, EventArgs e)
    {
      this.Visible = false;
      try
      {
        new StartGameMenu().ShowDialog(this);
      }
      catch(Exception ex)
      {
        Program.ExceptionBox(this, ex);
      }
      finally
      {
        this.Visible = true;
        this.Activate();
      }
    }

    void btnStartSolitaire_Click(object sender, EventArgs e)
    {
      this.Visible = false;
      try
      {
        Program.LogicHandler.StartSolitaire();
      }
      catch(Exception ex)
      {
        Program.ExceptionBox(this, ex);
      }
      finally
      {
        this.Visible = true;
        this.Activate();
      }
    }

    private void btnQuit_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
