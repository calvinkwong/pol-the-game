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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace PoL.WinFormsView.Utils
{
  public class TransparentLabel : Panel
  {
    public TransparentLabel()
    {
      SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      SetStyle(ControlStyles.Opaque, true);
      this.BackColor = Color.Transparent;
    }

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams cp = base.CreateParams;
        cp.ExStyle |= 0x20;
        return cp;
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      //e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), 
      //  new PointF(0, 0));
      //e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black), 2), this.Bounds);
      base.OnPaint(e);
    }

    //protected override void OnTextChanged(EventArgs e)
    //{
    //  this.Hide();
    //  this.Show();
    //  base.OnTextChanged(e);
    //}
  }
}
