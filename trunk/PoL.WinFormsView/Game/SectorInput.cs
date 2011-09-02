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
using PoL.Services.DataEntities;

namespace PoL.WinFormsView.Game
{
  public partial class SectorInput : Form, ILocalizable
  {
    public string SelectedSectorCode = string.Empty;

    public SectorInput(List<SectorStructure> sectors)
    {
      InitializeComponent();

      foreach(var sector in sectors)
      {
        Button btn = new Button();
        btn.Click += new EventHandler(btn_Click);
        btn.TextImageRelation = TextImageRelation.ImageAboveText;
        btn.Image = Program.LogicHandler.ServicesProvider.ImagesService.GetSectorBackground(sector.Item.Code);
        btn.FlatStyle = FlatStyle.Flat;
        btn.BackColor = Color.Transparent;
        btn.Text = sector.Item.Name;
        btn.Tag = sector.Item.Code;
        btn.Width = (int)(pnlSectorList.Width * 0.9);
        btn.Height = 55;
        btn.AutoEllipsis = true;
        pnlSectorList.Controls.Add(btn);
      }

      this.btnCancel.Click += new EventHandler(btnCancel_Click);

      Localize();
    }

    void btn_Click(object sender, EventArgs e)
    {
      this.SelectedSectorCode = ((Button)sender).Tag.ToString();
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    public void Localize()
    {
      this.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("SECTORS_DIALOG", "TITLE");
      btnCancel.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("SECTORS_DIALOG", "CANCEL");
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
