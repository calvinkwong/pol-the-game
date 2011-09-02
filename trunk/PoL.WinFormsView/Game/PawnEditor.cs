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

namespace PoL.WinFormsView.Game
{
  public partial class PawnEditor : Form, ILocalizable
  {
    public int Amount = 0;
    public string NewName = string.Empty;
    public string NewType = string.Empty;
    public string NewText = string.Empty;
    public string NewCharacteristics = string.Empty;

    public PawnEditor(string name, string type, string text, string characteristics)
    {
      InitializeComponent();

      txtName.Text = text;
      txtType.Text = type;
      txtText.Text = text;
      txtCharacteristics.Text = characteristics;

      this.DialogResult = DialogResult.Cancel;

      this.btnCancel.Click += new EventHandler(mBtnCancel_Click);
      this.btnOk.Click += new EventHandler(mBtnOk_Click);

      Localize();

      this.Load += new EventHandler(TokenDialog_Load);
    }

    public void Localize()
    {
      lblTitle.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("PAWN_DIALOG", "TITLE");
      lblName.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("PAWN_DIALOG", "NAME");
      lblType.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("PAWN_DIALOG", "TYPE");
      lblText.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("PAWN_DIALOG", "TEXT");
      lblCharacteristics.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("PAWN_DIALOG", "CHARACTERISTICS");
      btnOk.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("PAWN_DIALOG", "OK");
      btnCancel.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("PAWN_DIALOG", "CANCEL");
    }

    void TokenDialog_Load(object sender, EventArgs e)
    {
      txtName.Focus();
      txtName.SelectAll();
    }

    private void mBtnOk_Click(object sender, EventArgs e)
    {
      if(txtName.Text.Trim().Length > 0)
      {
        this.NewName = txtName.Text;
        this.NewType = txtType.Text;
        this.NewText = txtText.Text;
        this.NewCharacteristics = txtCharacteristics.Text;
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }

    private void mBtnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
