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

using PoL.WinFormsView.Properties;
using PoL.Common;

namespace PoL.WinFormsView
{
  public partial class JoinGameMenu : Form, ILocalizable
  {
    public JoinGameMenu()
    {
      InitializeComponent();
      this.Icon = Resources.Logo;
      this.Text = Application.ProductName + " v." + Application.ProductVersion;

      btnNewGame.Click += new EventHandler(btnNewGame_Click);
      btnSavedGame.Click += new EventHandler(btnSavedGame_Click);
      btnQuit.Click += new EventHandler(btnQuit_Click);
     
      Localize();
    }

    public void Localize()
    {
      btnTitle.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("JOIN_GAME_MENU", "TITLE");
      btnTitle.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("JOIN_GAME_MENU", "TITLE_DESC");
      btnNewGame.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("JOIN_GAME_MENU", "NEW_GAME");
      btnNewGame.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("JOIN_GAME_MENU", "NEW_GAME_DESC");
      btnSavedGame.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("JOIN_GAME_MENU", "SAVED_GAME");
      btnSavedGame.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("JOIN_GAME_MENU", "SAVED_GAME_DESC");
      btnQuit.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("JOIN_GAME_MENU", "QUIT");
      btnQuit.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("JOIN_GAME_MENU", "QUIT_DESC");
    }

    void btnSavedGame_Click(object sender, EventArgs e)
    {
      this.Visible = false;
      try
      {
        Program.LogicHandler.StartClientGame(GameStartMode.SavedGame);
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

    void btnNewGame_Click(object sender, EventArgs e)
    {
      this.Visible = false;
      try
      {
        Program.LogicHandler.StartClientGame(GameStartMode.NewGame);
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

    void btnQuit_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
