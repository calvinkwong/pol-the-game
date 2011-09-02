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

using PoL.Common;
using PoL.WinFormsView.Utils;
using PoL.Services;
using PoL.Services.DataEntities;
using PoL.Logic.Views;
using PoL.Logic.Controllers;

namespace PoL.WinFormsView.Game
{
  public partial class CollapsableFlowSectorView : CollapsablePanel, ISectorView, ILocalizable
  {
    CardViewHelper cardViewHelper;

    public CollapsableFlowSectorView()
    {
      InitializeComponent();

      cardViewHelper = new CardViewHelper(this, false);

      Localize();
    }

    public void Localize()
    {
      foreach(var card in this.CardViews)
      {
        if(card.ContextMenuStrip.Tag != null && card.ContextMenuStrip.Tag is ILocalizable)
          ((ILocalizable)card.ContextMenuStrip.Tag).Localize();
      }
    }

    #region ISectorView Members

    public List<CardView> CardViews
    {
      get { return CardContainer.Controls.OfType<CardView>().ToList(); }
    }

    public string PlayerKey
    {
      get { return ((Control)GameViewHelper.FindParentPlayerView(this) ?? (Control)GameViewHelper.FindParentPlayerStatusView(this)).Name; }
    }

    public string SectorKey
    {
      get { return this.Name; }
      set { this.Name = value; }
    }

    public SectorItem SectorItem { get; set; }

    public void AddCards(Dictionary<string, CardViewItem> cardViewItems)
    {
      foreach(var entry in cardViewItems)
      {
        CardView cardView = new CardView();
        cardView.DoubleClick += new EventHandler(cardView_DoubleClick);
        cardView.Name = entry.Key;
        cardView.Visible = false;
        CardContainer.Controls.Add(cardView);
        cardView.SetCard(entry.Value);
        cardView.Visible = true;

        CardMenuContainer menu = new CardMenuContainer();
        menu.CardView = cardView;
        menu.SectorView = this;
        cardView.ContextMenuStrip = menu.InnerMenu;

        cardViewHelper.AddCard(cardView, cardView.ContextMenuStrip);

        if(entry.Value.Index > -1 && entry.Value.Index < CardViews.Count)
          CardContainer.Controls.SetChildIndex(cardView, entry.Value.Index);
      }
      AdjustPanelExpansion();
    }

    void cardView_DoubleClick(object sender, EventArgs e)
    {
      try
      {
        CardView cardView = (CardView)sender;
        if(GameView.SectorActionsAbilitations[SectorKey][SectorActions.MoveCardsToDefaultSector])
        {
          CardVisibility? visibility = null;
          if(Control.ModifierKeys == Keys.Shift)
            visibility = CardVisibility.Hidden;
          else if(Control.ModifierKeys == Keys.Control)
            visibility = CardVisibility.Private;
          GameViewHelper.RaiseMoveCards(GameView, Enumerable.Repeat(cardView, 1).ToList(), SectorItem.DefaultTarget, visibility);
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    public void RemoveCard(string key)
    {
      CardView cardView = (CardView)CardContainer.Controls.Find(key, true).First();
      RemoveCard(cardView);
    }

    public void RemoveCard(CardView cardView)
    {
      cardView.DoubleClick -= new EventHandler(cardView_DoubleClick);

      cardViewHelper.RemoveCard(cardView, cardView.ContextMenuStrip);

      CardContainer.Controls.Remove(cardView);

      AdjustPanelExpansion();
    }

    public void ClearCards()
    {
      while(CardViews.Count > 0)
        RemoveCard(CardViews.First());
    }

    public void MoveCard(string key, int newIndex)
    {
      CardView cardView = (CardView)CardContainer.Controls.Find(key, true).First();
      CardContainer.Controls.SetChildIndex(cardView, newIndex);
    }

    public void SetDescription(string description)
    {
    }

    #endregion

    public Control CardContainer
    {
      get { return pnl; }
    }

    GameView GameView
    {
      get { return (GameView)FindForm(); }
    }

    void AdjustPanelExpansion()
    {
      Size cardSize = new Size(
        CardMetricsService.CardRect(CardStyleBehaviorsService.BEHAVIORS_SMALL).Size.Width + (CardView.BORDER_SIZE*2)
        , CardMetricsService.CardRect(CardStyleBehaviorsService.BEHAVIORS_SMALL).Size.Height + (CardView.BORDER_SIZE*2)
        );
      int cardPerLine = pnl.ClientRectangle.Width / (cardSize.Width + pnl.Margin.Left + pnl.Margin.Right);
      if(cardPerLine > 0)
      {
        double lines = 1;
        if(CardContainer.Controls.Count > 0)
          lines = CardContainer.Controls.Count / (double)cardPerLine;
        if((lines % 1) != 0)
          lines++;
        this.FullExpandedSize = (cardSize.Height + pnl.Margin.Top + pnl.Margin.Bottom) * (int)lines;
      }
    }

    protected override void OnResize(EventArgs e)
    {
      try
      {
        base.OnResize(e);

        if(pnl != null && !this.Animating)
          AdjustPanelExpansion();
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    protected override void OnDragDrop(DragEventArgs drgevent)
    {
      try
      {
        if(drgevent.Data.GetDataPresent(typeof(DragDropData)))
        {
          DragDropData data = (DragDropData)drgevent.Data.GetData(typeof(DragDropData));
          if(drgevent.Effect == DragDropEffects.Move || drgevent.Effect == DragDropEffects.Copy)
          {
            string dragSourceSectorKey = GameViewHelper.FindParentSectorView(data.CardViews.First()).SectorKey;
            int index = CardContainer.Controls.Count; // start at end of hand in case of card addition (from other sector)
            if(dragSourceSectorKey == this.Name)
              index--; // is a card movement into this sector, start at last card position
            Control ctrl = pnl.GetChildAtPoint(pnl.PointToClient(Cursor.Position));
            if(ctrl != null)
              index = pnl.Controls.GetChildIndex(ctrl);

            GameView.Controller.MoveCards(data.CardViews.Select(c => c.Name).ToList(), this.SectorItem.Code,
              Enumerable.Repeat(new CardPosition(0, 0, index), data.CardViews.Count).ToList(), null);
          }
        }

        base.OnDragDrop(drgevent);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    protected override void OnDragOver(DragEventArgs drgevent)
    {
      try
      {
        base.OnDragOver(drgevent);

        if(drgevent.Data.GetDataPresent(typeof(DragDropData)))
        {
          DragDropData data = (DragDropData)drgevent.Data.GetData(typeof(DragDropData));
          CardView cardView = data.CardViews.First();
          if(data.CardViews.All(c => this.PlayerKey == c.CardViewItem.OwnerPlayerKey))
            drgevent.Effect = DragDropEffects.Copy;
          else
            drgevent.Effect = DragDropEffects.None;
        }
        else
          drgevent.Effect = DragDropEffects.None;
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }
  }
}
