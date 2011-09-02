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
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PoL.Services.DataEntities;
using System.ComponentModel;
using Patterns;

namespace PoL.WinFormsView.Utils
{
  class CardListView : ListView, ILocalizable
  {
    private ImageList headerImages;
    private System.ComponentModel.IContainer components;
    private ColumnHeader colName = new ColumnHeader();
    private ColumnHeader colCount = new ColumnHeader();
    private ColumnHeader colType = new ColumnHeader();
    private ColumnHeader colCost = new ColumnHeader();
    private ColumnHeader colCharacteristics = new ColumnHeader();
    private ColumnHeader colRarity = new ColumnHeader();
    private ColumnHeader colColor = new ColumnHeader();
    private ColumnHeader colEdition = new ColumnHeader();
    private ColumnHeader colText = new ColumnHeader();
    private ColumnHeader colFlavorText = new ColumnHeader();
    private ColumnHeader colArtist = new ColumnHeader();
    CardListBehavior behavior = CardListBehavior.EditorDeck;
    List<CardItem> dataSource;
    OrderField currentOrderField = OrderField.None;
    bool orderAscending = true;
    
    public event Action<object, OrderCriteria> OrderingRequested;

    public CardListView()
    {
      InitializeComponent();

      this.SmallImageList = headerImages;

      colName.Width = 180;
      colCount.Width = 30;
      colCharacteristics.Width = 40;
      colEdition.Width = 40;
      colColor.Width = 50;
      colRarity.Width = 40;
      colType.Width = 120;
      colText.Width = 200;
      colFlavorText.Width = 200;
      colArtist.Width = 180;

      this.DoubleBuffered = true;

      ApplyBehavior();
    }

    public void MoveItem(ListViewItem item, int newIndex)
    {
      this.BeginUpdate();
      try
      {
        object cache;
        for(int i = 0; i < item.SubItems.Count; i++)
        {
          cache = this.Items[newIndex].SubItems[i].Text;
          this.Items[newIndex].SubItems[i].Text = item.SubItems[i].Text;
          item.SubItems[i].Text = cache.ToString();
        }
        cache = this.Items[newIndex].Tag;
        this.Items[newIndex].Tag = item.Tag;
        item.Tag = cache;
        cache = this.Items[newIndex].Name;
        this.Items[newIndex].Name = item.Name;
        item.Name = cache.ToString();
        this.Items[newIndex].Selected = true;
        item.Selected = false;
      }
      finally
      {
        this.EndUpdate();
      }
    }

    ListViewColumnSorter GetColumnSorter()
    {
      List<OrderType> orderTypes = new List<OrderType>();
      foreach(ColumnHeader col in Columns)
      {
        if(col.Equals(colName))
          orderTypes.Add(OrderType.Text);
        if(col.Equals(colCount))
          orderTypes.Add(OrderType.Numeric);
        if(col.Equals(colType))
          orderTypes.Add(OrderType.Text);
        if(col.Equals(colCost))
          orderTypes.Add(OrderType.Cost);
        if(col.Equals(colCharacteristics))
          orderTypes.Add(OrderType.Text);
        if(col.Equals(colRarity))
          orderTypes.Add(OrderType.Text);
        if(col.Equals(colColor))
          orderTypes.Add(OrderType.Text);
        if(col.Equals(colEdition))
          orderTypes.Add(OrderType.Text);
        if(col.Equals(colText))
          orderTypes.Add(OrderType.Text);
        if(col.Equals(colFlavorText))
          orderTypes.Add(OrderType.Text);
        if(col.Equals(colArtist))
          orderTypes.Add(OrderType.Text);
      }
      return new ListViewColumnSorter(orderTypes.ToArray());
    }

    public void Localize()
    {
      colName.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CARD_LIST", "NAME");
      colCount.Text = string.Empty;
      colType.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CARD_LIST", "TYPE");
      colCost.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CARD_LIST", "COST");
      colCharacteristics.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CARD_LIST", "CHARACTERISTICS");
      colRarity.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CARD_LIST", "RARITY");
      colColor.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CARD_LIST", "COLOR");
      colEdition.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CARD_LIST", "EDITION");
      colText.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CARD_LIST", "TEXT");
      colFlavorText.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CARD_LIST", "FLAVORTEXT");
      colArtist.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CARD_LIST", "ARTIST");
    }

    [Browsable(false)]
    public List<CardItem> DataSource
    {
      get { return dataSource; }
      set
      {
        dataSource = value;
        if(dataSource != null)
          this.VirtualListSize = dataSource.Count;
        else
          this.VirtualListSize = 0;
        this.Refresh();
      }
    }

    public void AddCardItem(CardItem card)
    {
      AddCardItem(card, false, -1);
    }

    public void AddCardItem(CardItem card, int index)
    {
      AddCardItem(card, false, index);
    }

    public void AddCardItem(CardItem card, bool hidden, int index)
    {
      if(index > -1 && index < this.Items.Count)
        this.Items.Insert(index, CreateCardItem(card, hidden));
      else
        this.Items.Add(CreateCardItem(card, hidden));
    }

    public void UpdateCardItem(CardItem card)
    {
      ListViewItem item = this.Items.Find(card.UniqueID, false).First();
      CardListItemData data = (CardListItemData)item.Tag;
      FillCardItem(item, card, 1, data.Hidden);
    }

    public void UpdateCardItem(CardItem card, int count)
    {
      ListViewItem item = this.Items.Find(card.UniqueID, false).First();
      CardListItemData data = (CardListItemData)item.Tag;
      FillCardItem(item, card, count, data.Hidden);
    }

    [Browsable(true)]
    [DefaultValue(CardListBehavior.EditorDeck)]
    public CardListBehavior Behavior
    {
      get { return behavior; }
      set 
      {
        behavior = value;
        ApplyBehavior();
      }
    }

    void ApplyBehavior()
    {
      this.Columns.Clear();
      switch(behavior)
      {
        case CardListBehavior.EditorDeck:
          this.Columns.Add(colName);
          this.Columns.Add(colCount);
          this.Columns.Add(colType);
          this.Columns.Add(colCost);
          this.Columns.Add(colCharacteristics);
          this.Columns.Add(colRarity);
          this.Columns.Add(colColor);
          this.Columns.Add(colEdition);
          this.Columns.Add(colText);
          this.Columns.Add(colFlavorText);
          this.Columns.Add(colArtist);
          break;
        case CardListBehavior.EditorArchive:
          this.Columns.Add(colName);
          this.Columns.Add(colType);
          this.Columns.Add(colCost);
          this.Columns.Add(colCharacteristics);
          this.Columns.Add(colRarity);
          this.Columns.Add(colColor);
          this.Columns.Add(colEdition);
          this.Columns.Add(colText);
          this.Columns.Add(colFlavorText);
          this.Columns.Add(colArtist);
          break;
        case CardListBehavior.DeckRoom:
          this.Columns.Add(colName);
          this.Columns.Add(colCount);
          this.Columns.Add(colType);
          this.Columns.Add(colCost);
          this.Columns.Add(colCharacteristics);
          this.Columns.Add(colRarity);
          this.Columns.Add(colColor);
          this.Columns.Add(colEdition);
          this.Columns.Add(colText);
          this.Columns.Add(colFlavorText);
          this.Columns.Add(colArtist);
          break;
        case CardListBehavior.Game:
        case CardListBehavior.GameSorted:
          this.Columns.Add(colName);
          this.Columns.Add(colType);
          this.Columns.Add(colCost);
          break;
      }
      if(behavior != CardListBehavior.EditorArchive)
      {
        this.VirtualMode = false;
        this.ListViewItemSorter = GetColumnSorter();
      }
      else
      {
        this.VirtualListSize = 0;
        this.VirtualMode = true;
        //this.ListViewItemSorter = null;
      }
    }

    protected override void OnRetrieveVirtualItem(RetrieveVirtualItemEventArgs e)
    {
      e.Item = CreateCardItem(dataSource[e.ItemIndex], false);
    }

    protected override void OnSearchForVirtualItem(SearchForVirtualItemEventArgs e)
    {
      e.Index = dataSource.FindIndex(e.StartIndex, c => c.Name.StartsWith(e.Text, StringComparison.OrdinalIgnoreCase));
    }

    protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
    {
      e.DrawDefault = true;
      base.OnDrawColumnHeader(e);
    }

    protected override void OnColumnClick(ColumnClickEventArgs e)
    {
      Cursor currentCursor = Cursor.Current;
      Cursor.Current = Cursors.WaitCursor;
      try
      {
        OrderList(e.Column);
      }
      finally
      {
        Cursor.Current = currentCursor;
      }
      base.OnColumnClick(e);
    }

    protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
    {
      e.DrawDefault = false;
      if(this.Columns[e.ColumnIndex].Equals(colCost))
      {
        e.DrawBackground();
        CardListItemData data = (CardListItemData)e.Item.Tag;
        if(!data.Hidden)
          CardCostUtils.DrawCardCost(e.Graphics, e.Bounds, data.CardItem.Cost);
      }
      else if(this.Columns[e.ColumnIndex].Equals(colEdition))
      {
        e.DrawBackground();
        CardListItemData data = (CardListItemData)e.Item.Tag;
        e.Graphics.DrawImage(Program.LogicHandler.ServicesProvider.ImagesService.GetCardSet(data.CardItem.SetCode, data.CardItem.RarityCode), e.Bounds.X, e.Bounds.Y, 14, 14);
      }
      else if(this.Columns[e.ColumnIndex].Equals(colColor))
      {
        e.DrawBackground();
        CardListItemData data = (CardListItemData)e.Item.Tag;
        e.Graphics.DrawImage(Program.LogicHandler.ServicesProvider.ImagesService.GetCardSymbol(data.CardItem.ColorCode), e.Bounds.X, e.Bounds.Y, 12, 12);
      }
      else
        e.DrawDefault = true;

      base.OnDrawSubItem(e);
    }

    public void OrderList(int column)
    {
      bool ascending = false;
      if(behavior == CardListBehavior.EditorArchive)
      {
        OrderField field = OrderField.None;
        if(this.Columns[column].Equals(colName))
          field = OrderField.Name;
        if(this.Columns[column].Equals(colType))
          field = OrderField.Type;
        if(this.Columns[column].Equals(colCost))
          field = OrderField.Cost;
        if(this.Columns[column].Equals(colCharacteristics))
          field = OrderField.Characteristics;
        if(this.Columns[column].Equals(colRarity))
          field = OrderField.Rarity;
        if(this.Columns[column].Equals(colColor))
          field = OrderField.Color;
        if(this.Columns[column].Equals(colEdition))
          field = OrderField.Set;
        if(this.Columns[column].Equals(colText))
          field = OrderField.Text;
        if(this.Columns[column].Equals(colFlavorText))
          field = OrderField.FlavorText;
        if(this.Columns[column].Equals(colArtist))
          field = OrderField.Artist;

        if(field == currentOrderField)
          ascending = !orderAscending;
        else
          ascending = true;
        
        OrderCriteria criteria = new OrderCriteria() { Field = field, Ascending = ascending };
        OnOrderingRequested(criteria);
        //SortableList list = new SortableList(new CardItemComparer(criteria), this.dataSource.Count);
        //list.AddRange(this.dataSource);
        //this.dataSource.Clear();
        //foreach(var item in list)
        //  this.dataSource.Add((CardItem)item);
        currentOrderField = field;
        orderAscending = ascending;
      }
      else
      {
        ListViewColumnSorter columnSorter = (ListViewColumnSorter)this.ListViewItemSorter;
        if(column == columnSorter.SortColumn)
        {
          if(columnSorter.Order == SortOrder.Ascending)
            columnSorter.Order = SortOrder.Descending;
          else
            columnSorter.Order = SortOrder.Ascending;
        }
        else
        {
          columnSorter.SortColumn = column;
          columnSorter.Order = SortOrder.Ascending;
        }
        ascending = columnSorter.Order == SortOrder.Ascending;
        Sort();
      }
      for(int i = 0; i < Columns.Count; i++)
      {
        if(i == column)
          Columns[i].ImageKey = ascending ? "ASC" : "DESC";
        else
          Columns[i].ImageKey = "NONE";
      }
      this.Refresh();
    }

    protected virtual void OnOrderingRequested(OrderCriteria orderCriteria)
    {
      if(OrderingRequested != null)
        OrderingRequested(this, orderCriteria);
    }

    ListViewItem CreateCardItem(CardItem cardItem, bool hidden)
    {
      ListViewItem cardListItem = new ListViewItem();
      FillCardItem(cardListItem, cardItem, 1, hidden);
      return cardListItem;
    }

    void FillCardItem(ListViewItem item, CardItem card, int count, bool hidden)
    {
      if(item.SubItems.Count != Columns.Count)
      {
        item.SubItems.Clear();
        for(int i = 0; i < Columns.Count; i++)
          item.SubItems.Add(new ListViewItem.ListViewSubItem());
      }

      item.Name = card.UniqueID;
      item.Tag = new CardListItemData() { CardItem = card, Hidden = hidden, Count = count };
      
      foreach(ColumnHeader col in Columns)
      {
        if(col.Equals(colName))
          item.Text = hidden ? "???" : card.Name;
        if(col.Equals(colCount))
          item.SubItems[col.Index].Text = count.ToString();
        if(col.Equals(colType))
          item.SubItems[col.Index].Text = hidden ? "???" : card.Type;
        if(col.Equals(colCost))
          item.SubItems[col.Index].Text = hidden ? "???" : card.Cost;
        if(col.Equals(colCharacteristics))
          item.SubItems[col.Index].Text = hidden ? "???" : card.Characteristics;
        if(col.Equals(colRarity))
          item.SubItems[col.Index].Text = hidden ? "???" : card.RarityCode;
        if(col.Equals(colColor))
          item.SubItems[col.Index].Text = hidden ? "???" : card.ColorCode;
        if(col.Equals(colEdition))
          item.SubItems[col.Index].Text = hidden ? "???" : card.SetCode;
        if(col.Equals(colText))
          item.SubItems[col.Index].Text = hidden ? "???" : card.Text;
        if(col.Equals(colFlavorText))
          item.SubItems[col.Index].Text = hidden ? "???" : card.FlavorText;
        if(col.Equals(colArtist))
          item.SubItems[col.Index].Text = hidden ? "???" : card.Artist;
      }
    }

    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardListView));
      this.headerImages = new System.Windows.Forms.ImageList(this.components);
      this.SuspendLayout();
      // 
      // headerImages
      // 
      this.headerImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("headerImages.ImageStream")));
      this.headerImages.TransparentColor = System.Drawing.Color.Transparent;
      this.headerImages.Images.SetKeyName(0, "ASC");
      this.headerImages.Images.SetKeyName(1, "DESC");
      this.headerImages.Images.SetKeyName(2, "NONE");
      // 
      // CardListView
      // 
      this.GridLines = true;
      this.HideSelection = false;
      this.OwnerDraw = true;
      this.ShowItemToolTips = true;
      this.View = System.Windows.Forms.View.Details;
      this.ResumeLayout(false);

    }
  }

  class CardListItemData
  {
    public CardItem CardItem { get; set; }
    public int Count { get; set; }
    public bool Hidden { get; set; }
  }

  public enum CardListBehavior
  {
    Game,
    GameSorted,
    EditorDeck,
    EditorArchive,
    DeckRoom
  }
}
