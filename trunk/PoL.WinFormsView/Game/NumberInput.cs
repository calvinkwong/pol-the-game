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
  public partial class NumberInput : Form, ILocalizable
  {
    public int SelectedValue = 1;
    
    bool allowNegative;

    public NumberInput()
    {
      InitializeComponent();

      this.DialogResult = DialogResult.Cancel;

      this.btnCancel.Click += new EventHandler(btnCancel_Click);
      this.btnOk.Click += new EventHandler(btnOk_Click);

      Localize();

      this.Load += new EventHandler(TokenDialog_Load);

      btn1.Tag = 1;
      btn1.Click += new EventHandler(btn_Click);
      btn2.Tag = 2;
      btn2.Click += new EventHandler(btn_Click);
      btn3.Tag = 3;
      btn3.Click += new EventHandler(btn_Click);
      btn4.Tag = 4;
      btn4.Click += new EventHandler(btn_Click);
      btn5.Tag = 5;
      btn5.Click += new EventHandler(btn_Click);
      btn6.Tag = 6;
      btn6.Click += new EventHandler(btn_Click);
      btn7.Tag = 7;
      btn7.Click += new EventHandler(btn_Click);
      btn8.Tag = 8;
      btn8.Click += new EventHandler(btn_Click);
      btn9.Tag = 9;
      btn9.Click += new EventHandler(btn_Click);
      btn10.Tag = 10;
      btn10.Click += new EventHandler(btn_Click);

      btn1n.Tag = -1;
      btn1n.Click += new EventHandler(btn_Click);
      btn2n.Tag = -2;
      btn2n.Click += new EventHandler(btn_Click);
      btn3n.Tag = -3;
      btn3n.Click += new EventHandler(btn_Click);
      btn4n.Tag = -4;
      btn4n.Click += new EventHandler(btn_Click);
      btn5n.Tag = -5;
      btn5n.Click += new EventHandler(btn_Click);
      btn6n.Tag = -6;
      btn6n.Click += new EventHandler(btn_Click);
      btn7n.Tag = -7;
      btn7n.Click += new EventHandler(btn_Click);
      btn8n.Tag = -8;
      btn8n.Click += new EventHandler(btn_Click);
      btn9n.Tag = -9;
      btn9n.Click += new EventHandler(btn_Click);
      btn10n.Tag = -10;
      btn10n.Click += new EventHandler(btn_Click);

      this.AllowNegative = false;

    }

    protected override void OnLoad(EventArgs e)
    {
      numValue.Select();
      numValue.Select(0, numValue.Value.ToString().Length);
      base.OnLoad(e);
    }

    public bool AllowNegative
    {
      get { return allowNegative; }
      set
      {
        allowNegative = value;
        pnlNegativeNumbers.Enabled = allowNegative;
        numValue.Minimum = allowNegative ? -100 : 0;
      }
    }

    void btn_Click(object sender, EventArgs e)
    {
      this.SelectedValue = (int)((Button)sender).Tag;

      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    public void Localize()
    {
      this.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("NUMBER_DIALOG", "TITLE");
      lblValue.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("NUMBER_DIALOG", "VALUE");
      btnOk.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("NUMBER_DIALOG", "OK");
      btnCancel.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("NUMBER_DIALOG", "CANCEL");
    }

    void TokenDialog_Load(object sender, EventArgs e)
    {
      numValue.Focus();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if(numValue.Value != 0)
      {
        this.SelectedValue = (int)numValue.Value;

        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
