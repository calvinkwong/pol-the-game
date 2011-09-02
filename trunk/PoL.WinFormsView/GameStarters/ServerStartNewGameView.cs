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

using PoL.Logic.Views;
using PoL.Common;
using PoL.Logic.Controllers.GameStarters;
using PoL.Services;

namespace PoL.WinFormsView.GameStarters
{
  public partial class ServerStartNewGameView : WinFormsView, IServerStartNewGameView, ILocalizable
  {
    ServerStartNewGameController controller;

    public ServerStartNewGameView()
    {
      InitializeComponent();

      btnBrowseDecks.Click += new EventHandler(btnBrowseDecks_Click);
      btnOk.Click += new EventHandler(btnOk_Click);
      btnCancel.Click += new EventHandler(btnCancel_Click);

      Localize();
    }

    public void Localize()
    {
      this.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("SERVER_NEWGAME_DIALOG", "TITLE");
      lblDeck.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("SERVER_NEWGAME_DIALOG", "CURRENT_DECK");
      txtDeckName.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("SERVER_NEWGAME_DIALOG", "CHOOSE_DECK");
      lblPassword.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("SERVER_NEWGAME_DIALOG", "PASSWORD");
      btnOk.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("SERVER_NEWGAME_DIALOG", "OK");
      btnCancel.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("SERVER_NEWGAME_DIALOG", "CANCEL");
    }

    public ServerStartNewGameController Controller
    {
      get { return controller; }
    }

    public void SetDeckName(string deckName)
    {
      txtDeckName.Text = deckName;
    }

    void btnBrowseDecks_Click(object sender, EventArgs e)
    {
      try
      {
        controller.LoadDeck();
      }
      catch(Exception ex)
      {
        Program.ExceptionBox(this, ex);
      }
    }

    void btnOk_Click(object sender, EventArgs e)
    {
      try
      {
        controller.Finish();
      }
      catch(Exception ex)
      {
        Program.ExceptionBox(this, ex);
      }
    }

    void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    #region IServerInitializationView Members

    public string Password
    {
      get { return txtPassword.Text; }
    }

    #endregion

    #region IView<ServerInitializationController> Members

    public void RegisterController(ServerStartNewGameController controller)
    {
      this.controller = controller;
    }

    #endregion
  }
}
