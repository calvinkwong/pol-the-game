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
using System.Linq;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

using PoL.Logic.Controllers;
using PoL.Common;
using PoL.Logic.Views;
using PoL.WinFormsView.Utils;
using PoL.Services;
using PoL.Services.DataEntities;
using PoL.Logic;
using Patterns.MVC;
using PoL.WinFormsView.Properties;
using PoL.Configuration;

namespace PoL.WinFormsView.DeckEditor
{
	public partial class DeckEditorView : WinFormsView, IDeckEditorView, ILocalizable
	{
    DeckEditorController controller;

    Rectangle dragBoxFromMouseDown;
    Point screenOffset;

    string deckTitle = string.Empty;
    string sideboardTitle = string.Empty;
    string searchParametersTitle = string.Empty;

    SearchParametersView searchParametersView = new SearchParametersView();

    public DeckEditorView()
		{
			InitializeComponent();

      cardPreview.BackgroundImage = Program.LogicHandler.ServicesProvider.ImagesService.GetCardBack(CardStyleBehaviorsService.BEHAVIORS_LARGE);

      PrepareList(listMain);
      PrepareList(listSideboard);
      PrepareList(listArchive);

      listMain.OrderList(0);
      listSideboard.OrderList(0);
      listArchive.OrderingRequested += new Action<object, OrderCriteria>(listArchive_OrderingRequested);

      listArchive.DoubleClick += new EventHandler(listArchive_DoubleClick);
      listMain.DoubleClick += new EventHandler(listCard_DoubleClick);
      listSideboard.DoubleClick += new EventHandler(listSideboard_DoubleClick);

      btnSave.Click += delegate(object sender, EventArgs e)
      {
        controller.Save();
      };
      btnSaveExit.Click += delegate(object sender, EventArgs e)
      {
        if(controller.Save())
        {
          this.DialogResult = DialogResult.OK;
          this.Close();
        }
      };
      btnExit.Click += delegate(object sender, EventArgs e)
      {
        this.Close();
      };

      // toolbars
      
      // Archive
      txtArchiveQuickSearch.TextChanged += delegate(object sender, EventArgs e)
      {
        controller.QuickSearch(DeckEditorListContext.Archive);
      };
      btnSearchParameters.Click += delegate(object sender, EventArgs e)
      {
        searchParametersView.Show(this);
      };
      btnSearchToMain.Click += delegate(object sender, EventArgs e)
      {
        MoveListElement(DeckEditorListContext.Archive, DeckEditorListContext.Main, -1);
      };
      btnSearchToSide.Click += delegate(object sender, EventArgs e)
      {
        MoveListElement(DeckEditorListContext.Archive, DeckEditorListContext.Sideboard, -1);
      };

      // Main
      txtMainQuickSearch.TextChanged += delegate(object sender, EventArgs e)
      {
        controller.QuickSearch(DeckEditorListContext.Main);
      };
      btnDuplicateMain.Click += delegate(object sender, EventArgs e)
      {
        MoveListElement(DeckEditorListContext.Main, DeckEditorListContext.Main, -1);
      };
      btnMainToSide.Click += delegate(object sender, EventArgs e)
      {
        MoveListElement(DeckEditorListContext.Main, DeckEditorListContext.Sideboard, -1);
      };
      btnRemoveMain.Click += delegate(object sender, EventArgs e)
      {
        MoveListElement(DeckEditorListContext.Main, DeckEditorListContext.Archive, -1);
      };
      btnClearMain.Click += delegate(object sender, EventArgs e)
      {
        controller.ClearList(DeckEditorListContext.Main);
      };

      // Sideboard
      txtSideQuickSearch.TextChanged += delegate(object sender, EventArgs e)
      {
        controller.QuickSearch(DeckEditorListContext.Sideboard);
      };
      btnDuplicateSide.Click += delegate(object sender, EventArgs e)
      {
        MoveListElement(DeckEditorListContext.Sideboard, DeckEditorListContext.Sideboard, -1);
      };
      btnSideToMain.Click += delegate(object sender, EventArgs e)
      {
        MoveListElement(DeckEditorListContext.Sideboard, DeckEditorListContext.Main, -1);
      };
      btnRemoveSide.Click += delegate(object sender, EventArgs e)
      {
        MoveListElement(DeckEditorListContext.Sideboard, DeckEditorListContext.Archive, -1);
      };
      btnClearSide.Click += delegate(object sender, EventArgs e)
      {
        controller.ClearList(DeckEditorListContext.Sideboard);
      };

      btnOrientation.Click += new EventHandler(btnOrientation_Click);

      txtArchiveQuickSearch.GotFocus += new EventHandler(txtQuickSearch_GotFocus);
      txtArchiveQuickSearch.Leave += new EventHandler(txtQuickSearch_Leave);
      txtArchiveQuickSearch.MouseUp += new MouseEventHandler(txtQuickSearch_MouseUp);
      txtMainQuickSearch.GotFocus += new EventHandler(txtQuickSearch_GotFocus);
      txtMainQuickSearch.Leave += new EventHandler(txtQuickSearch_Leave);
      txtMainQuickSearch.MouseUp += new MouseEventHandler(txtQuickSearch_MouseUp);
      txtSideQuickSearch.GotFocus += new EventHandler(txtQuickSearch_GotFocus);
      txtSideQuickSearch.Leave += new EventHandler(txtQuickSearch_Leave);
      txtSideQuickSearch.MouseUp += new MouseEventHandler(txtQuickSearch_MouseUp);

      SetOrientation();

      Localize();
    }

    void listArchive_OrderingRequested(object sender, OrderCriteria orderCriteria)
    {
      controller.Order(orderCriteria);
    }

    void listSideboard_DoubleClick(object sender, EventArgs e)
    {
      MoveListElement(DeckEditorListContext.Sideboard, DeckEditorListContext.Sideboard, -1);
    }

    void listCard_DoubleClick(object sender, EventArgs e)
    {
      MoveListElement(DeckEditorListContext.Main, DeckEditorListContext.Main, -1);
    }

    void listArchive_DoubleClick(object sender, EventArgs e)
    {
      if(Control.ModifierKeys == Keys.Control)
        MoveListElement(DeckEditorListContext.Archive, DeckEditorListContext.Sideboard, -1);
      else
        MoveListElement(DeckEditorListContext.Archive, DeckEditorListContext.Main, -1);
    }

    bool alreadyFocused;
    void txtQuickSearch_MouseUp(object sender, MouseEventArgs e)
    {
      if(!alreadyFocused && ((TextBox)sender).SelectionLength == 0)
      {
        alreadyFocused = true;
        ((TextBox)sender).SelectAll();
      }
    }
    void txtQuickSearch_Leave(object sender, EventArgs e)
    {
      alreadyFocused = false;
    }
    void txtQuickSearch_GotFocus(object sender, EventArgs e)
    {
      if(MouseButtons == MouseButtons.None)
      {
        ((TextBox)sender).SelectAll();
        alreadyFocused = true;
      }
    }

    void btnOrientation_Click(object sender, EventArgs e)
    {
      SettingsManager.Settings.DeckEditorOrientation = 
        SettingsManager.Settings.DeckEditorOrientation == DeckEditorOrientation.Horizontal ? 
        DeckEditorOrientation.Vertical : DeckEditorOrientation.Horizontal;
      SettingsManager.Save();
      SetOrientation();
    }

    void SetOrientation()
    {
      if(SettingsManager.Settings.DeckEditorOrientation == DeckEditorOrientation.Horizontal)
      {
        mainSplitContainer.Orientation = Orientation.Horizontal;
        deckSplitContainer.Orientation = Orientation.Vertical;
        mainSplitContainer.SplitterDistance = (int)(mainSplitContainer.Height * 0.5);
        deckSplitContainer.SplitterDistance = (int)(deckSplitContainer.Width * 0.5);
        btnSearchToMain.Image = Resources.down1;
        btnSearchToSide.Image = Resources.bottom;
        btnMainToSide.Image = Resources.forward1;
        btnSideToMain.Image = Resources.go_previous;
      }
      else
      {
        mainSplitContainer.Orientation = Orientation.Vertical;
        deckSplitContainer.Orientation = Orientation.Horizontal;
        mainSplitContainer.SplitterDistance = (int)(mainSplitContainer.Width * 0.5);
        deckSplitContainer.SplitterDistance = (int)(deckSplitContainer.Height * 0.5);
        btnSearchToMain.Image = Resources.forward1;
        btnSearchToSide.Image = Resources.finish1;
        btnMainToSide.Image = Resources.down1;
        btnSideToMain.Image = Resources.go_up1;
      }
    }

    public void Localize()
    {
      this.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "TITLE");
      lblArchiveQuickSearch.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "SEARCH");
      lblMainQuickSearch.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "SEARCH");
      lblSideQuickSearch.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "SEARCH");
      btnSearchParameters.ToolTipText = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "SEARCH");
      btnSearchToMain.ToolTipText = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "MOVE_TO_MAIN") + " (Enter)";
      btnSearchToSide.ToolTipText = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "MOVE_TO_SIDE") + " (CTRL Enter)";
      btnDuplicateMain.ToolTipText = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "DUPLICATE") + " (Enter)";
      btnRemoveMain.ToolTipText = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "REMOVE") + " (Del)";
      btnMainToSide.ToolTipText = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "MOVE_TO_SIDE");
      btnClearMain.ToolTipText = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "RESET_LIST");
      btnDuplicateSide.ToolTipText = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "DUPLICATE") + " (Enter)";
      btnRemoveSide.ToolTipText = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "REMOVE") + " (Del)";
      btnSideToMain.ToolTipText = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "MOVE_TO_MAIN");
      btnClearSide.ToolTipText = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "RESET_LIST");
      lblArchive.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "SEARCH_RESULT");
      lblMain.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "MAIN_CARDS");
      lblSide.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "SIDEBOARD_CARDS");
      lblOtherInfo.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "OTHER_INFO");
      lblOtherInfo.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "OTHER_INFO_DESC");
      lblName.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "NAME");
      lblCategory.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "CATEGORY");
      btnSave.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "SAVE");
      btnSaveExit.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "SAVE_AND_EXIT");
      btnExit.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "EXIT");
      btnOrientation.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "ORIENTATION"); 
      listMain.Localize();
      listSideboard.Localize();
      listArchive.Localize();
    }

    void PrepareList(CardListView list)
    {
      list.SelectedIndexChanged += new EventHandler(list_SelectionChanged);
      list.MouseDown += new MouseEventHandler(list_MouseDown);
      list.MouseMove += new MouseEventHandler(list_MouseMove);
      list.MouseUp += new MouseEventHandler(list_MouseUp);
      list.DragDrop += new DragEventHandler(list_DragDrop);
      list.DragOver += new DragEventHandler(list_DragOver); 
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      switch(e.KeyCode)
      {
        case Keys.Delete:
          if(listMain.Focused || txtMainQuickSearch.Focused)
            MoveListElement(DeckEditorListContext.Main, DeckEditorListContext.Archive, -1);
          else if(listSideboard.Focused || txtSideQuickSearch.Focused)
            MoveListElement(DeckEditorListContext.Sideboard, DeckEditorListContext.Archive, -1);
          break;
        case Keys.Enter:
          if(listArchive.Focused || txtArchiveQuickSearch.Focused)
          {
            if(e.Control)
              MoveListElement(DeckEditorListContext.Archive, DeckEditorListContext.Sideboard, -1);
            else
              MoveListElement(DeckEditorListContext.Archive, DeckEditorListContext.Main, -1);
          }
          else if(listMain.Focused || txtMainQuickSearch.Focused)
            MoveListElement(DeckEditorListContext.Main, DeckEditorListContext.Main, -1);
          else if(listSideboard.Focused || txtSideQuickSearch.Focused)
            MoveListElement(DeckEditorListContext.Sideboard, DeckEditorListContext.Sideboard, -1);
          break;
        case Keys.Down:
        case Keys.Up:
          if(txtArchiveQuickSearch.Focused)
          {
            int index = 0;
            if(listArchive.SelectedIndices.Count > 0)
            {
              index = listArchive.SelectedIndices[0] + (e.KeyCode == Keys.Down ? 1 : -1);
              index = Math.Min(Math.Max(0, index), listArchive.DataSource.Count - 1);
            }
            listArchive.SelectedIndices.Clear();
            listArchive.EnsureVisible(index);
            ListViewItem item = listArchive.FindItemWithText(listArchive.DataSource[index].Name, false, index);
            item.Selected = true;
          }
          else if(txtMainQuickSearch.Focused || txtSideQuickSearch.Focused)
          {
            ListView list = txtMainQuickSearch.Focused ? listMain : listSideboard;
            int index = 0;
            if(list.SelectedIndices.Count > 0)
            {
              index = list.SelectedIndices[0] + (e.KeyCode == Keys.Down ? 1 : -1);
              index = Math.Min(Math.Max(0, index), list.Items.Count - 1);
            }
            list.SelectedIndices.Clear();
            list.EnsureVisible(index);
            list.Items[index].Selected = true;
          }
          break;
      }
    }

    #region IDeckEditorView Members

    Cursor currentCursor = Cursors.Default;
    public void BeginLoad()
    {
      listMain.BeginUpdate();
      listSideboard.BeginUpdate();
      listArchive.BeginUpdate();
      searchParametersView.BeginLoad();
      currentCursor = Cursor.Current;
      Cursor.Current = Cursors.WaitCursor;
    }

    public void EndLoad()
    {
      listMain.EndUpdate();
      listSideboard.EndUpdate();
      listArchive.EndUpdate();
      searchParametersView.EndLoad();
      Cursor.Current = currentCursor;
    }

    public void SetDeckSize(int mainSize, int sideboardSize)
    {
      lblSideCount.Text = "(" + sideboardSize.ToString() + ")";
      lblMainCount.Text = "(" + mainSize.ToString() + ")";
    }

    public void SetSearchResult(List<CardItem> searchResult)
    {
      try
      {
        listArchive.DataSource = searchResult;
      }
      finally
      {
        lblArchiveCount.Text = "(" + searchResult.Count.ToString() + ")";
      }
    }

    public void SetSets(List<GameSetItem> sets)
    {
      searchParametersView.SetSets(sets);
    }

    public void SetColors(List<BaseItem> colors)
    {
      searchParametersView.SetColors(colors);
    }

    public void SetRarities(List<BaseItem> rarities)
    {
      searchParametersView.SetRarities(rarities);
    }

    public void SetTypes(List<CardTypeItem> types)
    {
      searchParametersView.SetTypes(types);
    }

    public void SetDecksCategories(IEnumerable<string> decksCategories)
    {
      foreach(string cat in decksCategories)
        mCbDeckCategory.Items.Add(cat);
    }

    public void AddMainCard(CardItem card)
    {
      listMain.AddCardItem(card);
    }

    public void SetMainCardCount(CardItem card, int count)
    {
      listMain.UpdateCardItem(card, count);
    }

    public void RemoveMainCard(CardItem card)
    {
      listMain.Items.RemoveByKey(card.UniqueID);
    }

    public void AddSideboardCard(CardItem card)
    {
      listSideboard.AddCardItem(card);
    }

    public void SetSideboardCardCount(CardItem card, int count)
    {
      listSideboard.UpdateCardItem(card, count);
    }

    public void RemoveSideboardCard(CardItem card)
    {
      listSideboard.Items.RemoveByKey(card.UniqueID);
    }

    public void ClearList(DeckEditorListContext listContext)
    {
      switch(listContext)
      {
        case DeckEditorListContext.Main:
          listMain.Items.Clear();
          break;
        case DeckEditorListContext.Sideboard:
          listSideboard.Items.Clear();
          break;
      }
    }

    public string DeckName
    {
      get { return txtDeckName.Text; }
      set { txtDeckName.Text = value; }
    }

    public string DeckCategory
    {
      get { return mCbDeckCategory.Text; }
      set { mCbDeckCategory.Text = value; }
    }

    public string GetQuickSearchText(DeckEditorListContext listContext)
    {
      string text = string.Empty;
      switch(listContext)
      {
        case DeckEditorListContext.Sideboard: text = txtSideQuickSearch.Text; break;
        case DeckEditorListContext.Main: text = txtMainQuickSearch.Text; break;
        default: text = txtArchiveQuickSearch.Text; break;
      }
      return text;
    }

    public void SelectCard(DeckEditorListContext listContext, CardItem card)
    {
      CardListView list = null;
      switch(listContext)
      {
        case DeckEditorListContext.Sideboard: list = listSideboard; break;
        case DeckEditorListContext.Main: list = listMain; break;
        case DeckEditorListContext.Archive: list = listArchive; break;
      }
      list.SelectedIndices.Clear();
      if(card != null)
      {
        ListViewItem item = null;
        if(list.VirtualMode)
          item = list.FindItemWithText(card.Name);
        else
          item = list.Items.Find(card.UniqueID, false).Single();
        item.Selected = true;
        list.EnsureVisible(item.Index);
      }
    }

    #endregion

    #region IView<DeckEditorController> Members

    public void RegisterController(DeckEditorController controller)
    {
      this.controller = controller;
      searchParametersView.SetController(controller);
    }

    #endregion

    void list_MouseUp(object sender, MouseEventArgs e)
    {
      if((e.Button & MouseButtons.Left) == MouseButtons.Left)
        dragBoxFromMouseDown = Rectangle.Empty;
    }

    private void list_DragOver(object sender, DragEventArgs e)
    {
      if(e.Data.GetDataPresent(typeof(DragDropData)))
      {
        DragDropData data = (DragDropData)e.Data.GetData(typeof(DragDropData));
        DeckEditorListContext contextFrom = data.ListContext;
        DeckEditorListContext contextTo = DeckEditorListContext.Main;
        if(sender.Equals(listSideboard))
          contextTo = DeckEditorListContext.Sideboard;
        else if(sender.Equals(listArchive))
          contextTo = DeckEditorListContext.Archive;
        if(contextFrom != contextTo)
          e.Effect = DragDropEffects.Move;
        else
          e.Effect = DragDropEffects.None;
      }
      else
        e.Effect = DragDropEffects.None;
    }

    private void list_DragDrop(object sender, DragEventArgs e)
    {
      if(e.Data.GetDataPresent(typeof(DragDropData))
        && e.Effect == DragDropEffects.Move)
      {
        DragDropData data = (DragDropData)e.Data.GetData(typeof(DragDropData));
        DeckEditorListContext contextTo = DeckEditorListContext.Main;
        if(sender.Equals(listSideboard))
          contextTo = DeckEditorListContext.Sideboard;
        else if(sender.Equals(listArchive))
          contextTo = DeckEditorListContext.Archive;

        Point cursorPosition = PointToClient(Cursor.Position);
        int index = -1;

        ListView list = (ListView)sender;
        index = list.Items.Count;
        ListViewItem item = list.GetItemAt(cursorPosition.X, cursorPosition.Y);
        if(item != null)
          index = item.Index;
        MoveListElement(data.ListContext, contextTo, index);
      }
    }

    private void list_MouseMove(object sender, MouseEventArgs e)
    {
      if((e.Button & MouseButtons.Left) == MouseButtons.Left)
      {
        if(dragBoxFromMouseDown != Rectangle.Empty &&
            !dragBoxFromMouseDown.Contains(e.X, e.Y))
        {
          screenOffset = SystemInformation.WorkingArea.Location;
          DeckEditorListContext contextFrom = DeckEditorListContext.Main;
          if(sender.Equals(listSideboard))
            contextFrom = DeckEditorListContext.Sideboard;
          else if(sender.Equals(listArchive))
            contextFrom = DeckEditorListContext.Archive;
          DragDropEffects dropEffect = DoDragDrop(new DragDropData(contextFrom), DragDropEffects.Move);
        }
      }
    }

    private void list_MouseDown(object sender, MouseEventArgs e)
    {
      Size dragSize = SystemInformation.DragSize;
      dragBoxFromMouseDown = new Rectangle(
        new Point(e.X - (dragSize.Width / 2)
        , e.Y - (dragSize.Height / 2)), dragSize
        );
    }

    void list_SelectionChanged(object sender, EventArgs e)
		{
      CardItem card = null;
      CardListView list = (CardListView)sender;
      if(list.SelectedIndices.Count > 0)
      {
        if(list.VirtualMode)
        {
          List<CardItem> cards = list.DataSource;
          card = cards[list.SelectedIndices[list.SelectedIndices.Count - 1]];
        }
        else
        {
          CardListItemData data = (CardListItemData)list.SelectedItems[list.SelectedItems.Count - 1].Tag;
          card = data.CardItem;
        }
      }
      if(card != null)
        cardPreview.Image = CardDrawer.Draw(card, CardStyleBehaviorsService.BEHAVIORS_LARGE);
    }

    void MoveListElement(DeckEditorListContext contextFrom, DeckEditorListContext contextTo, int index)
		{
      List<CardItem> cards = new List<CardItem>();

      CardListView listViewFrom = null;
      switch(contextFrom)
      {
        case DeckEditorListContext.Main: listViewFrom = listMain; break;
        case DeckEditorListContext.Sideboard: listViewFrom = listSideboard; break;
        case DeckEditorListContext.Archive: listViewFrom = listArchive; break;
      }
      if(listViewFrom.VirtualMode)
      {
        for(int i = 0; i < listViewFrom.SelectedIndices.Count; i++)
          cards.Add(listViewFrom.DataSource[listViewFrom.SelectedIndices[i]]);
      }
      else
      {
        foreach(ListViewItem item in listViewFrom.SelectedItems)
          cards.Add(((CardListItemData)item.Tag).CardItem);
      }

      foreach(CardItem card in cards)
        controller.MoveCard(contextFrom, contextTo, card, index);
    }
  }
}