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
  public partial class LobbyView : WinFormsView, ILobbyView, ILocalizable
  {
    LobbyController controller;

    public LobbyView()
    {      
      InitializeComponent();
      
      Localize();
    }

    public void Localize()
    {
      this.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CLIENT_INITIALIZATION_DIALOG", "TITLE");
    }

    void btnOk_Click(object sender, EventArgs e)
    {
      Cursor currentCursor = Cursor.Current;
      Cursor.Current = Cursors.WaitCursor;
      try
      {
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

    public void RegisterController(LobbyController controller)
    {
      this.controller = controller;
    }
  }
}
