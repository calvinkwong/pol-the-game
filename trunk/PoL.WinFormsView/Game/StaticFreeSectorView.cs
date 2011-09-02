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
using PoL.Services;
using PoL.Services.DataEntities;
using PoL.WinFormsView.Properties;
using PoL.WinFormsView.Utils;
using PoL.Logic.Views;

namespace PoL.WinFormsView.Game
{
  public partial class StaticFreeSectorView : UserControl, ISectorView, ILocalizable
  {
    CardViewHelper cardViewHelper;

    public StaticFreeSectorView()
    {
      InitializeComponent();
      this.AllowDrop = true;

      cardViewHelper = new CardViewHelper(this, true);
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
        
        cardView.Visible = false;
        CardContainer.Controls.Add(cardView);
        cardView.Name = entry.Key;
        cardView.SetCard(entry.Value);
        cardView.Visible = true;

        CardMenuContainer menu = new CardMenuContainer();
        menu.CardView = cardView;
        menu.SectorView = this;
        cardView.ContextMenuStrip = menu.InnerMenu;

        cardViewHelper.AddCard(cardView, menu.InnerMenu);

        if(entry.Value.Index > -1 && entry.Value.Index < CardViews.Count)
          CardContainer.Controls.SetChildIndex(cardView, entry.Value.Index);
      }
    }

    public void RemoveCard(string key)
    {
      CardView cardView = (CardView)CardContainer.Controls.Find(key, true).First();
      RemoveCard(cardView);
    }

    public void RemoveCard(CardView cardView)
    {
      cardViewHelper.RemoveCard(cardView, cardView.ContextMenuStrip);

      CardContainer.Controls.Remove(cardView);
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
      get { return this; }
    }

    GameView GameView
    {
      get { return (GameView)FindForm(); }
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);

      foreach(var card in CardViews)
        card.SetPosition(card.Position);
    }

    protected override void OnDragDrop(DragEventArgs drgevent)
    {
      try
      {
        base.OnDragDrop(drgevent);

        DragDropData data = (DragDropData)drgevent.Data.GetData(typeof(DragDropData));
        if(drgevent.Effect == DragDropEffects.Move || drgevent.Effect == DragDropEffects.Copy)
        {
          ISectorView dragSourceSectorView = GameViewHelper.FindParentSectorView(data.CardViews.First());
          CardVisibility? visibility = null;
          if(dragSourceSectorView.SectorKey != this.Name)
          {
            if(Control.ModifierKeys == Keys.Shift)
              visibility = CardVisibility.Hidden;
            if(Control.ModifierKeys == Keys.Control)
              visibility = CardVisibility.Private;
          }

          Point currentCursorPosition = CardContainer.PointToClient(Cursor.Position);
          bool proceed = true;
          List<CardPosition> cardPositions = new List<CardPosition>();

          if(dragSourceSectorView is StaticFreeSectorView || dragSourceSectorView is CollapsableFlowSectorView)
            currentCursorPosition.Offset(-data.CursorOffset.X, -data.CursorOffset.Y);

          if(dragSourceSectorView is StaticFreeSectorView)
          {
            Point distance = new Point(currentCursorPosition.X - data.DraggedCardView.Location.X,
              currentCursorPosition.Y - data.DraggedCardView.Location.Y);
            for(int i = 0; i < data.CardViews.Count; i++)
            {
              CardView cardView = data.CardViews[i];
              Point desiredPosition = new Point(cardView.Location.X + distance.X, cardView.Location.Y + distance.Y);
              List<PointF> normalizedPoints;
              if(TryGetValidCardPositions(desiredPosition, 1, data.CardViews, out normalizedPoints))
                cardPositions.Add(new CardPosition(normalizedPoints.First().X, normalizedPoints.First().Y, i));
              else
              {
                proceed = false;
                break;
              }
            }
          }
          else
          {
            List<PointF> normalizedPoints;
            if(TryGetValidCardPositions(currentCursorPosition, data.CardViews.Count, data.CardViews, out normalizedPoints))
              cardPositions.AddRange(normalizedPoints.Select((p, i) => new CardPosition(p.X, p.Y, i)));
            else
              proceed = false;
          }
          if(proceed)
          {
            GameView.Controller.MoveCards(data.CardViews.Select(c => c.Name).ToList(), this.SectorItem.Code, 
              this.PlayerKey, cardPositions, visibility);
          }
        }
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
          //DragDropData data = (DragDropData)drgevent.Data.GetData(typeof(DragDropData));
          //if(data.SectorKey != this.Name)
          //  drgevent.Effect = DragDropEffects.Move;
          //else
          //  drgevent.Effect = DragDropEffects.None;
          drgevent.Effect = DragDropEffects.Copy;
        }
        else
          drgevent.Effect = DragDropEffects.None;
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    public bool TryGetValidCardPositions(Point startPosition, int positionAmount, List<CardView> excludedCardViews, out List<PointF> normalizedPoints)
    {
      normalizedPoints = new List<PointF>();

      Rectangle cardRect = CardMetricsService.CardRect(CardStyleBehaviorsService.BEHAVIORS_SMALL);
      cardRect.Offset(startPosition);

      bool valid = true;
      for(int i = 0; i < Math.Max(1, positionAmount) && valid; i++)
      {
        bool checkPosition = true;
        while(checkPosition)
        {
          checkPosition = false;
          foreach(Control ctrl in this.Controls.OfType<CardView>().Where(e => !excludedCardViews.Contains(e) && !checkPosition))
          {
            Rectangle intersection = Rectangle.Intersect(cardRect, ctrl.Bounds);
            if(intersection.Height * intersection.Width >= ((cardRect.Height * cardRect.Width) * 0.8))
            {
              // overlapped card, try next position
              cardRect.Location = new Point(ctrl.Bounds.Left + (int)(cardRect.Height * 0.15), ctrl.Bounds.Top + (int)(cardRect.Height * 0.15));
              checkPosition = true;
            }
          }
        }

        valid = this.Bounds.Contains(cardRect);
        if(valid)
          //normalizedPoints.Add(cardRect.Location);
          normalizedPoints.Add(new PointF(cardRect.Location.X / (float)this.ClientSize.Width, cardRect.Location.Y / (float)this.ClientSize.Height));

        cardRect.Location = new Point(cardRect.Left + (int)(cardRect.Height * 0.15), cardRect.Top + (int)(cardRect.Height * 0.15));
      }

      if(!valid)
        normalizedPoints.Clear();

      return valid;
    }
  }
}
