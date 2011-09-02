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
using PoL.Common;

namespace PoL.WinFormsView.Game
{
  public partial class PlayerInput : Form, ILocalizable
  {
    public string SelectedPlayerKey = string.Empty;

    public PlayerInput(List<PlayerStructure> players)
    {
      InitializeComponent();

      foreach(var player in players)
      {
        Button btn = new Button();
        btn.Click += new EventHandler(btn_Click);
        btn.TextImageRelation = TextImageRelation.ImageAboveText;
        if(player.Item.Picture != null)
          btn.Image = new Bitmap(player.Item.Picture, new Size(32, 32));
        btn.FlatStyle = FlatStyle.Flat;
        btn.BackColor = Color.Transparent;
        btn.Text = player.Item.NickName;
        btn.Tag = player.PlayerKey;
        btn.Width = (int)(pnlPlayerList.Width * 0.8);
        btn.Height = 65;
        btn.AutoEllipsis = true;
        pnlPlayerList.Controls.Add(btn);
      }

      this.btnCancel.Click += new EventHandler(btnCancel_Click);

      Localize();
    }

    public void Localize()
    {
      this.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("PLAYERS_DIALOG", "TITLE");
      btnCancel.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("PLAYERS_DIALOG", "CANCEL");
    }

    void btn_Click(object sender, EventArgs e)
    {
      this.SelectedPlayerKey = ((Button)sender).Tag.ToString();
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
