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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PoL.WinFormsView.Game
{
  public partial class NumCounterView : UserControl
  {
    int counterValue;
    string counterName;

    public NumCounterView()
    {
      InitializeComponent();

      lblValue.MouseDown += new MouseEventHandler(lblValue_MouseDown);
    }

    void lblValue_MouseDown(object sender, MouseEventArgs e)
    {
      try
      {
        if(e.Button == MouseButtons.Left)
          ((GameView)this.FindForm()).Controller.SetNumCounterValue(this.Name, this.counterValue + 1);
        else if(e.Button == MouseButtons.Right)
          ((GameView)this.FindForm()).Controller.SetNumCounterValue(this.Name, this.counterValue - 1);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    GameView GameView
    {
      get { return (GameView)FindForm(); }
    }

    public string CounterName
    {
      get { return counterName; }
      set
      {
        counterName = value;
        toolTip.SetToolTip(lblValue, counterName);
        toolTip.SetToolTip(picNumCounter, counterName);
      }
    }

    public int CounterValue
    {
      get { return counterValue; }
      set
      {
        counterValue = value;
        lblValue.Text = value.ToString();
      }
    }

    public void SetImage(Image image)
    {
      picNumCounter.BackgroundImage = image;
    }
  }
}
