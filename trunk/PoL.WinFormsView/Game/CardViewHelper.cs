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
using PoL.Logic.Controllers;
using System.Windows.Forms;
using System.Drawing;
using PoL.WinFormsView.Utils;
using PoL.Common;

namespace PoL.WinFormsView.Game
{
  public class CardViewHelper
  {
    ISectorView sectorView;
    Cursor defaultCursor;
    Cursor dragCursor;
    Rectangle dragBoxFromMouseDown;
    TransparentLabel pnlSelectionBox;
    bool supportSelectionBox;

    public CardViewHelper(ISectorView sectorView, bool supportSelectionBox)
    {
      this.sectorView = sectorView;
      this.supportSelectionBox = supportSelectionBox;

      sectorView.CardContainer.GiveFeedback += new GiveFeedbackEventHandler(sectorView_GiveFeedback);
      sectorView.CardContainer.Click += new EventHandler(sectorView_Click);
      sectorView.CardContainer.MouseDown += new MouseEventHandler(sectorView_MouseDown);
      sectorView.CardContainer.MouseUp += new MouseEventHandler(sectorView_MouseUp);
      sectorView.CardContainer.MouseMove += new MouseEventHandler(sectorView_MouseMove);

      if(supportSelectionBox)
      {
        pnlSelectionBox = new TransparentLabel();
        pnlSelectionBox.Visible = false;
        pnlSelectionBox.BorderStyle = BorderStyle.FixedSingle;
        sectorView.CardContainer.Controls.Add(pnlSelectionBox);
      }
    }

    GameView GameView
    {
      get { return (GameView)((Control)sectorView).FindForm(); }
    }

    void sectorView_MouseUp(object sender, MouseEventArgs e)
    {
      try
      {
        if(supportSelectionBox)
        {
          if((e.Button & MouseButtons.Left) == MouseButtons.Left)
          {
            dragBoxFromMouseDown = Rectangle.Empty;
            pnlSelectionBox.Visible = false;
          }
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void sectorView_MouseMove(object sender, MouseEventArgs e)
    {
      try
      {
        if(supportSelectionBox)
        {
          if((e.Button & MouseButtons.Left) == MouseButtons.Left)
          {
            if(dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
            {
              pnlSelectionBox.Visible = true;
              Rectangle actualSelectionBounds = pnlSelectionBox.Bounds;
              Point cursorPosition = ((Control)sectorView).PointToClient(Cursor.Position);

              int x = cursorPosition.X - (dragBoxFromMouseDown.X + (dragBoxFromMouseDown.Width / 2));
              actualSelectionBounds.Width = Math.Abs(x);
              if(x < 0)
                actualSelectionBounds.X = cursorPosition.X;
              int y = cursorPosition.Y - (dragBoxFromMouseDown.Y + (dragBoxFromMouseDown.Height / 2));
              actualSelectionBounds.Height = Math.Abs(y);
              if(y < 0)
                actualSelectionBounds.Y = cursorPosition.Y;
              pnlSelectionBox.Bounds = actualSelectionBounds;

              foreach(CardView cardView in sectorView.CardViews)
                cardView.Selected = actualSelectionBounds.IntersectsWith(cardView.Bounds);
            }
          }
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void sectorView_MouseDown(object sender, MouseEventArgs e)
    {
      try
      {
        if(supportSelectionBox)
        {
          Size dragSize = SystemInformation.DragSize;
          dragBoxFromMouseDown = new Rectangle(
            new Point(e.X - (dragSize.Width / 2)
            , e.Y - (dragSize.Height / 2)), dragSize
            );
          pnlSelectionBox.Bounds = dragBoxFromMouseDown;
          pnlSelectionBox.BringToFront();
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void sectorView_Click(object sender, EventArgs e)
    {
      if(!supportSelectionBox || !pnlSelectionBox.Visible)
        foreach(CardView cardView in sectorView.CardViews)
          cardView.Selected = false;
    }

    void sectorView_GiveFeedback(object sender, GiveFeedbackEventArgs gfbevent)
    {
      try
      {
        if((gfbevent.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
        {
          if(!Patterns.Utils.IsMono)
          {
            gfbevent.UseDefaultCursors = false;
            Cursor.Current = dragCursor;
          }
          else
            gfbevent.UseDefaultCursors = true;
        }
        else if((gfbevent.Effect & DragDropEffects.Move) == DragDropEffects.Move)
        {
          gfbevent.UseDefaultCursors = true;
        }
        else
          Cursor.Current = Cursors.No;
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    public void AddCard(CardView cardView, ContextMenuStrip menu)
    {
      cardView.MouseDown += new MouseEventHandler(cardView_MouseDown);
      cardView.MouseUp += new MouseEventHandler(cardView_MouseUp);
      cardView.MouseMove += new MouseEventHandler(cardView_MouseMove);
      cardView.Click += new EventHandler(cardView_Click);
      menu.Opened += new EventHandler(menu_Opened);
    }

    public void RemoveCard(CardView cardView, ContextMenuStrip menu)
    {
      cardView.MouseDown -= new MouseEventHandler(cardView_MouseDown);
      cardView.MouseUp -= new MouseEventHandler(cardView_MouseUp);
      cardView.MouseMove -= new MouseEventHandler(cardView_MouseMove);
      cardView.Click -= new EventHandler(cardView_Click);
      menu.Opened -= new EventHandler(menu_Opened);
    }

    void SelectExclusiveCard(CardView cardView)
    {
      foreach(var c in sectorView.CardViews)
      {
        if(c.Equals(cardView))
        {
          if(!c.Selected)
            c.Selected = true;
        }
        else
        {
          if(c.Selected)
            c.Selected = false;
        }
      }
    }

    void ExecuteCustomDragDrop(CardView cardView)
    {
      try
      {
        string sectorKey = sectorView.SectorKey;
        if(GameView.SectorActionsAbilitations[sectorKey][SectorActions.MoveCards])
        {
          if(!cardView.Selected)
            SelectExclusiveCard(cardView);
          var selectedCards = sectorView.CardViews.Where(e => e.Selected).ToList();
          if(selectedCards.Count > 0)
          {
            defaultCursor = Cursor.Current;
            if(!Patterns.Utils.IsMono)
            {
              int x = selectedCards.Min(e => e.Left);
              int w = selectedCards.Max(e => e.Right) - x;
              int y = selectedCards.Min(e => e.Top);
              int h = selectedCards.Max(e => e.Bottom) - y;
              using(Bitmap thisBmp = new Bitmap(w, h))
              {
                foreach(var c in selectedCards.Reverse<CardView>())
                {
                  var rect = c.Bounds;
                  rect.Offset(-x, -y);
                  c.DrawToBitmap(thisBmp, rect);
                }
                using(Bitmap bmp = CursorCreator.CreateOpaqueBitmap(thisBmp, 0.8f))
                {
                  Point hotSpot = sectorView.CardContainer.PointToClient(Cursor.Position);
                  hotSpot.Offset(-x, -y);
                  dragCursor = CursorCreator.CreateCursor(bmp, hotSpot);
                }
              }
            }
            try
            {
              Point cursorPositionOnCard = cardView.PointToClient(Cursor.Position);
              DragDropData data = new DragDropData(selectedCards, cursorPositionOnCard, cardView);
              DragDropEffects dropEffect = sectorView.CardContainer.DoDragDrop(
                data, DragDropEffects.Move | DragDropEffects.Copy);
            }
            finally
            {
              if(dragCursor != null)
                dragCursor.Dispose();
            }
          }
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void cardView_MouseMove(object sender, MouseEventArgs e)
    {
      try
      {
        if((e.Button & MouseButtons.Left) == MouseButtons.Left)
        {
          if(dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
          {            
            CardView cardView = (CardView)sender;
            ExecuteCustomDragDrop(cardView);
          }
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void cardView_MouseUp(object sender, MouseEventArgs e)
    {
      try
      {
        if((e.Button & MouseButtons.Left) == MouseButtons.Left)
        {
          dragBoxFromMouseDown = Rectangle.Empty;
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void cardView_MouseDown(object sender, MouseEventArgs e)
    {
      try
      {
        if((e.Button & MouseButtons.Left) == MouseButtons.Left)
        {
          Size dragSize = SystemInformation.DragSize;
          dragBoxFromMouseDown = new Rectangle(
            new Point(e.X - (dragSize.Width / 2)
            , e.Y - (dragSize.Height / 2)), dragSize
            );
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void cardView_Click(object sender, EventArgs e)
    {
      try
      {
        CardView cardView = ((CardView)sender);
        HandleClick(cardView, true);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menu_Opened(object sender, EventArgs e)
    {
      try
      {
        ContextMenuStrip menu = (ContextMenuStrip)sender;
        CardView cardView = (CardView)menu.SourceControl;
        HandleClick(cardView, false);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void HandleClick(CardView cardView, bool isStandardClick)
    {
      if(GameView.SectorActionsAbilitations[sectorView.SectorKey][SectorActions.MoveCards])
      {
        if(Control.ModifierKeys == Keys.Control)
        {
          cardView.Selected = !cardView.Selected;
        }
        else
        {
          bool bringToFront = false;
          if(isStandardClick)
          {
            SelectExclusiveCard(cardView);
            bringToFront = true;
          }
          else
          {
            if(!cardView.Selected)
            {
              SelectExclusiveCard(cardView);
              bringToFront = true;
            }
          }
          if(bringToFront && sectorView is StaticFreeSectorView)
          {
            GameView.Controller.MoveCards(Enumerable.Repeat(cardView.Name, 1).ToList(), sectorView.SectorItem.Code, sectorView.PlayerKey,
              Enumerable.Repeat(new CardPosition(cardView.Position.X, cardView.Position.Y, 0), 1).ToList(), null);
          }
        }
      }
    }
  }
}
