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
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PoL.WinFormsView.Utils;
using PoL.Common;
using PoL.WinFormsView.Properties;
using PoL.Services;
using PoL.Services.DataEntities;
using System.Diagnostics;
using PoL.Logic.Views;
using PoL.Logic.Controllers;

namespace PoL.WinFormsView.Game
{
  public partial class SimpleSectorView : UserControl, ISectorView
  {
    Rectangle dragBoxFromMouseDown;
    List<CardView> cardViews = new List<CardView>();

    public SimpleSectorView()
    {
      InitializeComponent();
      this.AllowDrop = true;

      ShowCardCount();

      AttachSubControlsMouseEvents(this.Controls);
    }

    void AttachSubControlsMouseEvents(ControlCollection controls)
    {
      foreach(Control ctrl in controls)
      {
        ctrl.MouseDown += new MouseEventHandler(ctrl_MouseDown);
        ctrl.MouseUp += new MouseEventHandler(ctrl_MouseUp);
        ctrl.MouseMove += new MouseEventHandler(ctrl_MouseMove);
        ctrl.MouseDoubleClick += new MouseEventHandler(ctrl_MouseDoubleClick);
        AttachSubControlsMouseEvents(ctrl.Controls);
      }
    }

    void ctrl_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      try
      {
        OnMouseDoubleClick(e);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void ctrl_MouseMove(object sender, MouseEventArgs e)
    {
      try
      {
        OnMouseMove(e);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void ctrl_MouseUp(object sender, MouseEventArgs e)
    {
      try
      {
        OnMouseUp(e);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void ctrl_MouseDown(object sender, MouseEventArgs e)
    {
      try
      {
        OnMouseDown(e);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    #region ISectorView Members

    public List<CardView> CardViews
    {
      get { return cardViews; }
    }

    public string SectorKey
    {
      get { return this.Name; }
      set { this.Name = value; }
    }

    public string PlayerKey
    {
      get { return ((Control)GameViewHelper.FindParentPlayerView(this) ?? (Control)GameViewHelper.FindParentPlayerStatusView(this)).Name; }
    }

    public Control CardContainer
    {
      get { return this; }
    }

    public SectorItem SectorItem { get; set; }

    public void AddCards(Dictionary<string, CardViewItem> cardViewItems)
    {
      foreach(var entry in cardViewItems)
      {
        CardView cardView = new CardView();
        cardView.Visible = false;
        this.Controls.Add(cardView);
        cardView.Name = entry.Key;
        cardView.SetCard(entry.Value);
        if(entry.Value.Index > -1 && (entry.Value.Index < cardViews.Count))
        {
          this.Controls.SetChildIndex(cardView, (entry.Value.Index));
          cardViews.Insert(entry.Value.Index, cardView);
        }
        else
          cardViews.Add(cardView);
      }
      ShowCardCount();
    }

    public void RemoveCard(string key)
    {
      cardViews.Remove((CardView)Controls.Find(key, true).First());
      this.Controls.RemoveByKey(key);
      ShowCardCount();
    }

    public void ClearCards()
    {
      foreach(CardView cardView in cardViews)
        Controls.Remove(cardView);
      cardViews.Clear();
      ShowCardCount();
    }

    public void MoveCard(string key, int newIndex)
    {
      CardView cardView = (CardView)Controls.Find(key, true).First();
      cardViews.Remove(cardView);
      cardViews.Insert(newIndex, cardView);
      Controls.SetChildIndex(cardView, newIndex);
    }

    public void SetDescription(string description)
    {
      toolTip.SetToolTip(picSector, description);
      toolTip.SetToolTip(lblCounter, description);
    }

    #endregion

    public void SetImage(Image image)
    {
      picSector.BackgroundImage = image;
    }

    public void SetLookupPlayers(List<string> players)
    {
      if(players.Count > 0)
      {
        picSector.Image = Resources.pixel_eye;
        toolTip.SetToolTip(picSector, string.Join(", ", players.ToArray()));
      }
      else
      {
        picSector.Image = null;
        toolTip.SetToolTip(picSector, string.Empty);
      }
    }

    void ShowCardCount()
    {
      lblCounter.Text = cardViews.Count.ToString();
    }

    GameView GameView
    {
      get { return (GameView)FindForm(); }
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
            GameView.Controller.MoveCards(data.CardViews.Select(c => c.Name).ToList(), this.SectorItem.Code,
              Enumerable.Repeat(CardPosition.Zero, data.CardViews.Count).ToList(), null);
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
        if(drgevent.Data.GetDataPresent(typeof(DragDropData)))
        {
          DragDropData data = (DragDropData)drgevent.Data.GetData(typeof(DragDropData));
          ISectorView sectorView = GameViewHelper.FindParentSectorView(data.CardViews.First());
          if(sectorView.SectorKey != this.Name)
          {
            if(data.CardViews.All(c => this.PlayerKey == c.CardViewItem.OwnerPlayerKey))
              drgevent.Effect = DragDropEffects.Move;
            else
              drgevent.Effect = DragDropEffects.None;
          }
          else
            drgevent.Effect = DragDropEffects.None;
        }
        else
          drgevent.Effect = DragDropEffects.None;

        base.OnDragOver(drgevent);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      try
      {
        Size dragSize = SystemInformation.DragSize;
        dragBoxFromMouseDown = new Rectangle(
          new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize
          );

        base.OnMouseDown(e);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      try
      {
        if((e.Button & MouseButtons.Left) == MouseButtons.Left)
          dragBoxFromMouseDown = Rectangle.Empty;

        base.OnMouseUp(e);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      try
      {
        if(GameView.SectorActionsAbilitations[this.Name][SectorActions.MoveCards])
        {
          if((e.Button & MouseButtons.Left) == MouseButtons.Left)
          {
            if(dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
            {
              Point cursorPosition = PointToClient(Cursor.Position);
              DragDropEffects dropEffect = DoDragDrop(
                new DragDropData(cardViews.First()), DragDropEffects.Copy | DragDropEffects.Move);
            }
          }
        }

        base.OnMouseMove(e);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }
  }
}
