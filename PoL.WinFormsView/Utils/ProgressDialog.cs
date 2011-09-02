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

namespace PoL.WinFormsView.Utils
{
  public partial class ProgressDialog : Form
  {
    public ProgressDialog()
    {
      InitializeComponent();
    }

    public string ProgressMessage
    {
      get { return lblMessage.Text; }
      set { lblMessage.Text = value; }
    }

    public int ProgressMin
    {
      get { return progBar.Minimum; }
      set { progBar.Minimum = value; }
    }

    public int ProgressMax
    {
      get { return progBar.Maximum; }
      set { progBar.Maximum = value; }
    }

    public int ProgressStep
    {
      get { return progBar.Step; }
      set { progBar.Step = value; }
    }

    public int ProgressValue
    {
      get { return progBar.Value; }
      set { progBar.Value = value; }
    }

    public void ProgressPerformStep()
    {
      progBar.PerformStep();
    }
  }
}
