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
  public partial class TokenEditor : Form, ILocalizable
  {
    public int TokenAmount = 1;
    public string TokenText = string.Empty;
    public TokenColor TokenColor = TokenColor.Red;

    public TokenEditor(string text, int amount, TokenColor color)
    {
      InitializeComponent();

      txtText.Text = text;
      numAmount.Value = amount;
      rbRed.Checked = color == TokenColor.Red;
      rbBlue.Checked = color == TokenColor.Blue;
      rbAzure.Checked = color == TokenColor.Azure;
      rbGreen.Checked = color == TokenColor.Green;
      rbYellow.Checked = color == TokenColor.Yellow;
      rbPurple.Checked = color == TokenColor.Purple;

      this.DialogResult = DialogResult.Cancel;

      this.btnCancel.Click += new EventHandler(btnCancel_Click);
      this.btnOk.Click += new EventHandler(btnOk_Click);

      Localize();

      this.Load += new EventHandler(TokenDialog_Load);
    }

    public void Localize()
    {
      lblTitle.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("TOKEN_DIALOG", "TITLE");
      lblText.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("TOKEN_DIALOG", "TEXT");
      lblAmount.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("TOKEN_DIALOG", "AMOUNT");
      lblColor.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("TOKEN_DIALOG", "COLOR");
      btnOk.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("TOKEN_DIALOG", "OK");
      btnCancel.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("TOKEN_DIALOG", "CANCEL");
    }

    void TokenDialog_Load(object sender, EventArgs e)
    {
      txtText.Focus();
      txtText.SelectAll();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      this.TokenText = txtText.Text;
      this.TokenAmount = (int)numAmount.Value;

      if(rbRed.Checked)
        this.TokenColor = TokenColor.Red;
      if(rbBlue.Checked)
        this.TokenColor = TokenColor.Blue;
      if(rbAzure.Checked)
        this.TokenColor = TokenColor.Azure;
      if(rbGreen.Checked)
        this.TokenColor = TokenColor.Green;
      if(rbPurple.Checked)
        this.TokenColor = TokenColor.Purple;
      if(rbYellow.Checked)
        this.TokenColor = TokenColor.Yellow;

      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
