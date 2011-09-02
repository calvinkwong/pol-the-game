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

namespace PoL.WinFormsView.Game
{
  public partial class LookupView : Form, ILocalizable
  {
    Rectangle dragBoxFromMouseDown;
    LookupRules rules; 
    SectorItem sectorItem;
    bool readOnly;
    string sectorKey;
    string playerKey;

    public bool IsClosing { get; set; }

    public LookupView(LookupRules rules, bool readOnly, SectorItem sectorItem, string sectorKey, string playerKey)
    {
      InitializeComponent();

      this.rules = rules;
      this.readOnly = readOnly;
      this.sectorItem = sectorItem;
      this.sectorKey = sectorKey;
      this.playerKey = playerKey;

      cardList.MouseDown += new MouseEventHandler(list_MouseDown);
      cardList.MouseMove += new MouseEventHandler(list_MouseMove);
      cardList.MouseUp += new MouseEventHandler(list_MouseUp);
      cardList.SelectedIndexChanged += new EventHandler(cardList_SelectedIndexChanged);
      cardList.DragOver += new DragEventHandler(cardList_DragOver);
      cardList.DragDrop += new DragEventHandler(cardList_DragDrop);
      sortedCardList.MouseDown += new MouseEventHandler(list_MouseDown);
      sortedCardList.MouseMove += new MouseEventHandler(list_MouseMove);
      sortedCardList.MouseUp += new MouseEventHandler(list_MouseUp);
      sortedCardList.OrderList(0);

      btnUp.Enabled = !readOnly;
      btnDown.Enabled = !readOnly;
      btnBottom.Enabled = !readOnly;
      btnSort.Enabled = rules.Style == LookupStyle.All;

      btnSort.Click += new EventHandler(btnSort_Click);
      btnUp.Click += new EventHandler(btnUp_Click);
      btnDown.Click += new EventHandler(btnDown_Click);
      btnBottom.Click += new EventHandler(btnBottom_Click);

      txtQuickSearch.TextChanged += new EventHandler(txtQuickSearch_TextChanged);

      string title = string.Empty;
      switch(rules.Style)
      {
        case LookupStyle.KeepVisibleTop:
        case LookupStyle.Top:
          title = string.Concat(sectorItem.Name, " (" , rules.Amount, ")");
          break;
        case LookupStyle.All:
          title = sectorItem.Name;
          break;
      }
      this.Text = title;

      Localize();
    }

    public LookupRules LookupRules
    {
      get { return rules; }
    }

    public SectorItem SectorItem
    {
      get { return sectorItem; }
    }

    public string SectorKey
    {
      get { return sectorKey; }
    }

    public string PlayerKey
    {
      get { return playerKey; }
    }

    void btnSort_Click(object sender, EventArgs e)
    {
      try
      {
        btnUp.Enabled = !btnSort.Checked;
        btnDown.Enabled = !btnSort.Checked;
        btnBottom.Enabled = !btnSort.Checked;
        txtQuickSearch.Enabled = !btnSort.Checked;
        if(btnSort.Checked)
        {
          sortedCardList.Show();
          cardList.Hide();
        }
        else
        {
          cardList.Show();
          sortedCardList.Hide();
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void txtQuickSearch_TextChanged(object sender, EventArgs e)
    {
      try
      {
        if(cardList.Items.Count > 0 && txtQuickSearch.Text.Trim().Length > 0)
        {
          cardList.SelectedIndices.Clear();
          ListViewItem item = cardList.FindItemWithText(txtQuickSearch.Text, false, 0, true);
          if(item != null)
          {
            item.Selected = true;
            cardList.EnsureVisible(item.Index);
          }
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    GameView GameView
    {
      get { return (GameView)this.Owner; }
    }

    void btnBottom_Click(object sender, EventArgs e)
    {
      try
      {
        SortedDictionary<int, ListViewItem> items = new SortedDictionary<int, ListViewItem>();
        foreach(ListViewItem item in cardList.SelectedItems)
          items.Add(item.Index, item);
        if(items.Count > 0)
        {
          List<string> cardKeys = new List<string>();
          List<CardPosition> cardPositions = new List<CardPosition>();
          int i = (GameView.Controls.Find(sectorKey, true).First() as ISectorView).CardViews.Count - 1;
          foreach(ListViewItem item in items.Values.Reverse())
          {
            cardKeys.Add(item.Name);
            cardPositions.Add(new CardPosition(0, 0, i--));
          }
          GameView.Controller.MoveCards(cardKeys, sectorItem.Code, cardPositions, null);
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void btnDown_Click(object sender, EventArgs e)
    {
      try
      {
        SortedDictionary<int, ListViewItem> items = new SortedDictionary<int, ListViewItem>();
        foreach(ListViewItem item in cardList.SelectedItems)
          items.Add(item.Index, item);
        if(items.Count > 0 && items.Keys.Last() < cardList.Items.Count - 1)
        {
          List<string> cardKeys = new List<string>();
          List<CardPosition> cardPositions = new List<CardPosition>();
          foreach(ListViewItem item in items.Values.Reverse())
          {
            cardKeys.Add(item.Name);
            cardPositions.Add(new CardPosition(0, 0, item.Index + 1));
          }
          GameView.Controller.MoveCards(cardKeys, sectorItem.Code, cardPositions, null);
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void btnUp_Click(object sender, EventArgs e)
    {
      try
      {
        SortedDictionary<int, ListViewItem> items = new SortedDictionary<int, ListViewItem>();
        foreach(ListViewItem item in cardList.SelectedItems)
          items.Add(item.Index, item);
        if(items.Count > 0 && items.Keys.First() > 0)
        {
          List<string> cardKeys = new List<string>();
          List<CardPosition> cardPositions = new List<CardPosition>();
          foreach(ListViewItem item in items.Values)
          {
            cardKeys.Add(item.Name);
            cardPositions.Add(new CardPosition(0, 0, item.Index - 1));
          }
          GameView.Controller.MoveCards(cardKeys, sectorItem.Code, cardPositions, null);
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void cardList_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        if(cardList.SelectedItems.Count > 0)
        {
          CardListItemData data = (CardListItemData)cardList.SelectedItems[0].Tag;
          if(!data.Hidden)
            GameView.ShowCardMagnification(data.CardItem);
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    public void Localize()
    {
      lblSearch.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("GAME", "SEARCH");
      btnDown.ToolTipText = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("GAME", "MOVE_DOWN");
      btnUp.ToolTipText = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("GAME", "MOVE_UP");
      btnBottom.ToolTipText = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("GAME", "MOVE_BOTTOM");
      btnSort.ToolTipText = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("GAME", "ENABLE_LIST_SORTING");
      cardList.Localize();
      sortedCardList.Localize();
    }

    public void AddCard(string cardKey, CardItem cardItem, int index)
    {
      AddCard(cardKey, false, cardItem, index);
    }

    public void AddCard(string cardKey, bool hidden, CardItem cardItem, int index)
    {
      cardList.AddCardItem(cardItem, hidden, index);
      sortedCardList.AddCardItem(cardItem, hidden, index);
    }

    public void RemoveCard(string cardKey)
    {
      cardList.Items.RemoveByKey(cardKey);
      sortedCardList.Items.RemoveByKey(cardKey);
    }

    public void UpdateCard(string cardKey, CardItem cardItem)
    {
      cardList.UpdateCardItem(cardItem);
      sortedCardList.UpdateCardItem(cardItem);
    }

    public void ClearCards()
    {
      cardList.Items.Clear();
      sortedCardList.Items.Clear();
    }

    public void MoveCard(string cardKey, int newIndex)
    {
      ListViewItem item = cardList.Items.Find(cardKey, true).First();
      cardList.MoveItem(item, newIndex);
    }

    void list_MouseUp(object sender, MouseEventArgs e)
    {
      try
      {
        if((e.Button & MouseButtons.Left) == MouseButtons.Left)
          dragBoxFromMouseDown = Rectangle.Empty;
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    private void list_MouseMove(object sender, MouseEventArgs e)
    {
      try
      {
        if(readOnly)
          return;
        if((e.Button & MouseButtons.Left) == MouseButtons.Left)
        {
          if(dragBoxFromMouseDown != Rectangle.Empty &&
              !dragBoxFromMouseDown.Contains(e.X, e.Y))
          {
            ListView list = (ListView)sender;
            List<CardView> cardViews = new List<CardView>();
            foreach(ListViewItem item in list.SelectedItems)
              cardViews.Add((CardView)GameView.Controls.Find(item.Name, true).First());
            DragDropEffects dropEffect = DoDragDrop(new DragDropData(cardViews), DragDropEffects.Copy);
          }
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    private void list_MouseDown(object sender, MouseEventArgs e)
    {
      try
      {
        Size dragSize = SystemInformation.DragSize;
        dragBoxFromMouseDown = new Rectangle(
          new Point(e.X - (dragSize.Width / 2)
          , e.Y - (dragSize.Height / 2)), dragSize
          );
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void cardList_DragOver(object sender, DragEventArgs e)
    {
      try
      {
        e.Effect = DragDropEffects.None;
        if(readOnly)
          return;

        if(e.Data.GetDataPresent(typeof(DragDropData)))
        {
          DragDropData data = (DragDropData)e.Data.GetData(typeof(DragDropData));
          string sectorKey = GameViewHelper.FindParentSectorView(data.CardViews.First()).SectorKey;
          if(sectorKey == this.Name)
            e.Effect = DragDropEffects.Copy;
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void cardList_DragDrop(object sender, DragEventArgs e)
    {
      try
      {
        DragDropData data = (DragDropData)e.Data.GetData(typeof(DragDropData));
        if(e.Effect == DragDropEffects.Copy)
        {
          Point cursorPosition = cardList.PointToClient(Cursor.Position);
          ListViewItem item = cardList.GetItemAt(cursorPosition.X, cursorPosition.Y);
          if(item != null)
          {
            int index = item.Index;
            GameView.Controller.MoveCards(data.CardViews.Select(c => c.Name).ToList(), sectorItem.Code,
              Enumerable.Repeat(new CardPosition(0, 0, index), 1).ToList(), null);
          }
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
      base.OnFormClosed(e);
      IsClosing = true;
      GameView.Controller.CloseSectorLookup(this.Name);
    }
  }
}
