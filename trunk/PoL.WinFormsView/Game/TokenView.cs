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
using PoL.WinFormsView.Properties;
using PoL.Common;

namespace PoL.WinFormsView.Game
{
  public partial class TokenView : UserControl
  {
    TokenColor tokenColor;
    int tokenAmount;
    string tokenText;

    public TokenView()
    {
      InitializeComponent();

      lblAmount.DoubleClick += new EventHandler(lblAmount_DoubleClick);
    }

    GameView GameView
    {
      get { return (GameView)FindForm(); }
    }

    void lblAmount_DoubleClick(object sender, EventArgs e)
    {
      try
      {
        OnDoubleClick(e);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    public int TokenAmount
    {
      get { return tokenAmount; }
      set
      {
        tokenAmount = value;
        lblAmount.Text = value.ToString();
      }
    }

    public string TokenText
    {
      get { return tokenText; }
      set
      {
        tokenText = value;
        toolTip.SetToolTip(lblAmount, tokenText);
      }
    }

    public TokenColor TokenColor
    {
      get { return tokenColor; }
      set
      {
        tokenColor = value;
        switch(tokenColor)
        {
          case TokenColor.Azure:
            this.BackgroundImage = Resources.button_seagreen_small;
            break;
          case TokenColor.Blue:
            this.BackgroundImage = Resources.button_blue_small;
            break;
          case TokenColor.Green:
            this.BackgroundImage = Resources.button_green_small;
            break;
          case TokenColor.Purple:
            this.BackgroundImage = Resources.button_purple_small;
            break;
          case TokenColor.Red:
            this.BackgroundImage = Resources.button_red_small;
            break;
          case TokenColor.Yellow:
            this.BackgroundImage = Resources.button_yellow_small;
            break;
        }
        SetFontColor();
      }
    }
    
    void SetFontColor()
    {
      switch(tokenColor)
      {
        case TokenColor.Azure:
        case TokenColor.Green:
        case TokenColor.Yellow:
          lblAmount.ForeColor = Color.Black;
          break;
        case TokenColor.Purple:
        case TokenColor.Blue:
        case TokenColor.Red:
          lblAmount.ForeColor = Color.White;
          break;
      }
    }
  }
}
