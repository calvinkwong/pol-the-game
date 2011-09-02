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

using PoL.Services.DataEntities;
using PoL.Common;
using System.Collections;
using PoL.WinFormsView.Utils;
using PoL.Logic.Views;
using PoL.Services;

namespace PoL.WinFormsView.Game
{
  public partial class CardDisplayView : Form, ILocalizable
  {
    public const int MAX_CARDS_IN_LINE = 6;

    public bool IsClosing { get; set; }

    public CardDisplayView()
    {
      InitializeComponent();

      Localize();
    }

    public void AddCards(List<CardItem> cards)
    {
      foreach(var card in cards)
      {
        PictureBox pic = new PictureBox();
        var img = CardDrawer.Draw(card, CardStyleBehaviorsService.BEHAVIORS_SMALL);
        pic.Size = img.Size;
        pic.BackgroundImageLayout = ImageLayout.Center;
        pic.BackgroundImage = img;
        pic.Tag = card;
        pic.MouseHover += new EventHandler(pic_MouseHover);
        pnlCards.Controls.Add(pic);
      }

      if(pnlCards.Controls.Count > 0)
      {
        var control = pnlCards.Controls[0];
        this.ClientSize = new System.Drawing.Size((control.Width + control.Margin.Horizontal) * Math.Min(cards.Count, MAX_CARDS_IN_LINE),
          (control.Height + control.Margin.Vertical) * (cards.Count / MAX_CARDS_IN_LINE + 1));
      }
    }

    public void ClearCards()
    {
      pnlCards.Controls.Clear();
    }

    void pic_MouseHover(object sender, EventArgs e)
    {
      GameView.ShowCardMagnification((CardItem)((Control)sender).Tag);
    }

    public void Localize()
    {
    }

    GameView GameView
    {
      get { return (GameView)this.Owner; }
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
      base.OnFormClosed(e);
      IsClosing = true;
      GameView.Controller.CloseCardDisplay();
    }
  }
}
