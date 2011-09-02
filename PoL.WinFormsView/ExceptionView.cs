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

namespace PoL.WinFormsView
{
  public partial class ExceptionView : Form
  {
    public ExceptionView(string message, Exception ex)
    {
      InitializeComponent();

      this.Text = Application.ProductName + " - v." + Application.ProductVersion;

      if(!string.IsNullOrEmpty(message))
        lblTitle.Text = message;

      StringBuilder str = new StringBuilder();
      Exception currentException = ex;
      while(currentException != null)
      {
        if(str.Length > 0)
        {
          str.Append(Environment.NewLine);
          str.Append("****");
          str.Append("****");
          str.Append(Environment.NewLine);
        }
        str.Append(currentException.Message);
        str.Append(Environment.NewLine);
        str.Append(currentException.StackTrace);
        currentException = currentException.InnerException;
      }
      txtError.Text = str.ToString();

      btnOk.Click += new EventHandler(btnOk_Click);
    }

    void btnOk_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
