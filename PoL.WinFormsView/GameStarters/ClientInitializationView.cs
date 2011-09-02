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
using PoL.Logic.Controllers.GameStarters;
using PoL.Common;

namespace PoL.WinFormsView.GameStarters
{
  public partial class ClientInitializationView : WinFormsView, IClientInitializationView, ILocalizable
  {
    ClientInitializationController controller;
    GameStartMode startMode;

    public ClientInitializationView(GameStartMode startMode)
    {      
      InitializeComponent();
      
      this.startMode = startMode;
      pnlDeck.Visible = startMode == GameStartMode.NewGame;

      btnBrowseDecks.Click += new EventHandler(btnBrowseDecks_Click);
      btnOk.Click += new EventHandler(btnOk_Click);
      btnCancel.Click += new EventHandler(btnCancel_Click);

      Localize();
    }

    public void Localize()
    {
      this.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CLIENT_INITIALIZATION_DIALOG", "TITLE");
      lblDeck.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CLIENT_INITIALIZATION_DIALOG", "CURRENT_DECK");
      txtDeckName.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CLIENT_INITIALIZATION_DIALOG", "CHOOSE_DECK");
      lblPassword.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CLIENT_INITIALIZATION_DIALOG", "PASSWORD");
      lblServerIP.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CLIENT_INITIALIZATION_DIALOG", "SERVER_IP");
      lblServerPort.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CLIENT_INITIALIZATION_DIALOG", "SERVER_PORT");
      btnOk.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CLIENT_INITIALIZATION_DIALOG", "OK");
      btnCancel.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CLIENT_INITIALIZATION_DIALOG", "CANCEL");
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
      Cursor currentCursor = Cursor.Current;
      Cursor.Current = Cursors.WaitCursor;
      try
      {
        controller.Finish();
      }
      catch(Exception ex)
      {
        Program.ExceptionBox(this, ex);
      }
      finally
      {
        Cursor.Current = currentCursor;
      }
    }

    void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    #region IClientInitializationView Members

    public GameStartMode StartMode
    {
      get { return startMode; }
    }

    public string Address
    {
      get { return txtClientIP.Text; }
      set { txtClientIP.Text = value; }
    }

    public int Port
    {
      get { return (int)numPort.Value; }
      set { numPort.Value = value; }
    }

    public string Password
    {
      get { return txtPassword.Text; }
    }

    #endregion

    #region IView<ClientInitializationController> Members

    public void RegisterController(ClientInitializationController controller)
    {
      this.controller = controller;
    }

    #endregion
  }
}
