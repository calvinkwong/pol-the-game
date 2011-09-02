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
using PoL.WinFormsView.DeckEditor;

namespace PoL.WinFormsView.SideboardingEditor
{
	public partial class SideboardingEditorView : WinFormsView, ISideboardingEditorView, ILocalizable
	{
    SideboardingEditorController controller;

    Rectangle dragBoxFromMouseDown;
    Point screenOffset;

    string deckTitle = string.Empty;
    string sideboardTitle = string.Empty;
    string searchParametersTitle = string.Empty;

    public SideboardingEditorView()
		{
			InitializeComponent();

      cardPreview.BackgroundImage = Program.LogicHandler.ServicesProvider.ImagesService.GetCardBack(CardStyleBehaviorsService.BEHAVIORS_LARGE);

      PrepareList(listMain);
      PrepareList(listSideboard);

      listMain.OrderList(0);
      listSideboard.OrderList(0);

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

      // Main
      txtMainQuickSearch.TextChanged += delegate(object sender, EventArgs e)
      {
        controller.QuickSearch(SideboardingEditorListContext.Main);
      };
      btnMainToSide.Click += delegate(object sender, EventArgs e)
      {
        MoveListElement(SideboardingEditorListContext.Main, SideboardingEditorListContext.Sideboard, -1);
      };
      btnExchangeMainSide.Click += delegate(object sender, EventArgs e)
      {
        ExchangeListElements();
      };

      // Sideboard
      txtSideQuickSearch.TextChanged += delegate(object sender, EventArgs e)
      {
        controller.QuickSearch(SideboardingEditorListContext.Sideboard);
      };
      btnSideToMain.Click += delegate(object sender, EventArgs e)
      {
        MoveListElement(SideboardingEditorListContext.Sideboard, SideboardingEditorListContext.Main, -1);
      };
      btnExchangeSideMain.Click += delegate(object sender, EventArgs e)
      {
        ExchangeListElements();
      };

      btnOrientation.Click += new EventHandler(btnOrientation_Click);

      txtMainQuickSearch.GotFocus += new EventHandler(txtQuickSearch_GotFocus);
      txtMainQuickSearch.Leave += new EventHandler(txtQuickSearch_Leave);
      txtMainQuickSearch.MouseUp += new MouseEventHandler(txtQuickSearch_MouseUp);
      txtSideQuickSearch.GotFocus += new EventHandler(txtQuickSearch_GotFocus);
      txtSideQuickSearch.Leave += new EventHandler(txtQuickSearch_Leave);
      txtSideQuickSearch.MouseUp += new MouseEventHandler(txtQuickSearch_MouseUp);

      SetOrientation();

      Localize();
    }

    void listSideboard_DoubleClick(object sender, EventArgs e)
    {
      MoveListElement(SideboardingEditorListContext.Sideboard, SideboardingEditorListContext.Main, -1);
    }

    void listCard_DoubleClick(object sender, EventArgs e)
    {
      MoveListElement(SideboardingEditorListContext.Main, SideboardingEditorListContext.Sideboard, -1);
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
        deckSplitContainer.Orientation = Orientation.Vertical;
        deckSplitContainer.SplitterDistance = (int)(deckSplitContainer.Width * 0.5);
        btnMainToSide.Image = Resources.forward1;
        btnSideToMain.Image = Resources.go_previous;
        btnExchangeMainSide.Image = Resources.stock_horz_arrows;
        btnExchangeSideMain.Image = Resources.stock_horz_arrows;
      }
      else
      {
        deckSplitContainer.Orientation = Orientation.Horizontal;
        deckSplitContainer.SplitterDistance = (int)(deckSplitContainer.Height * 0.5);
        btnMainToSide.Image = Resources.down1;
        btnSideToMain.Image = Resources.go_up1;
        btnExchangeMainSide.Image = Resources.stock_vert_arrows;
        btnExchangeSideMain.Image = Resources.stock_vert_arrows;
      }
    }

    public void Localize()
    {
      this.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "TITLE");
      lblMainQuickSearch.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "SEARCH");
      lblSideQuickSearch.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "SEARCH");
      btnMainToSide.ToolTipText = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "MOVE_TO_SIDE");
      btnSideToMain.ToolTipText = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "MOVE_TO_MAIN");
      btnExchangeMainSide.ToolTipText = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "EXCHANGE") + " (CTRL E)";
      btnExchangeSideMain.ToolTipText = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "EXCHANGE") + " (CTRL E)";
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
            MoveListElement(SideboardingEditorListContext.Main, SideboardingEditorListContext.Sideboard, -1);
          else if(listSideboard.Focused || txtSideQuickSearch.Focused)
            MoveListElement(SideboardingEditorListContext.Sideboard, SideboardingEditorListContext.Main, -1);
          break;
        case Keys.Enter:
          if(listMain.Focused || txtMainQuickSearch.Focused)
            MoveListElement(SideboardingEditorListContext.Main, SideboardingEditorListContext.Sideboard, -1);
          else if(listSideboard.Focused || txtSideQuickSearch.Focused)
            MoveListElement(SideboardingEditorListContext.Sideboard, SideboardingEditorListContext.Main, -1);
          break;
        case Keys.Down:
        case Keys.Up:
          if(txtMainQuickSearch.Focused || txtSideQuickSearch.Focused)
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
        case Keys.E:
          if(e.Control)
            ExchangeListElements();
          break;
      }
    }

    #region ISideboardingEditorView Members

    Cursor currentCursor = Cursors.Default;
    public void BeginLoad()
    {
      listMain.BeginUpdate();
      listSideboard.BeginUpdate();
      currentCursor = Cursor.Current;
      Cursor.Current = Cursors.WaitCursor;
    }

    public void EndLoad()
    {
      listMain.EndUpdate();
      listSideboard.EndUpdate();
      Cursor.Current = currentCursor;
    }

    public void SetDeckSize(int mainSize, int sideboardSize)
    {
      lblSideCount.Text = "(" + sideboardSize.ToString() + ")";
      lblMainCount.Text = "(" + mainSize.ToString() + ")";
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

    public string DeckName
    {
      get { return txtDeckName.Text; }
      set { txtDeckName.Text = value; }
    }

    public string DeckCategory
    {
      get { return txtCategory.Text; }
      set { txtCategory.Text = value; }
    }

    public string GetQuickSearchText(SideboardingEditorListContext listContext)
    {
      string text = string.Empty;
      switch(listContext)
      {
        case SideboardingEditorListContext.Sideboard: text = txtSideQuickSearch.Text; break;
        case SideboardingEditorListContext.Main: text = txtMainQuickSearch.Text; break;
      }
      return text;
    }

    public void SelectCard(SideboardingEditorListContext listContext, CardItem card)
    {
      CardListView list = null;
      switch(listContext)
      {
        case SideboardingEditorListContext.Sideboard: list = listSideboard; break;
        case SideboardingEditorListContext.Main: list = listMain; break;
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

    public void RegisterController(SideboardingEditorController controller)
    {
      this.controller = controller;
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
        SideboardingEditorListContext contextFrom = data.ListContext;
        SideboardingEditorListContext contextTo = SideboardingEditorListContext.Main;
        if(sender.Equals(listSideboard))
          contextTo = SideboardingEditorListContext.Sideboard;
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
        SideboardingEditorListContext contextTo = SideboardingEditorListContext.Main;
        if(sender.Equals(listSideboard))
          contextTo = SideboardingEditorListContext.Sideboard;

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
          SideboardingEditorListContext contextFrom = SideboardingEditorListContext.Main;
          if(sender.Equals(listSideboard))
            contextFrom = SideboardingEditorListContext.Sideboard;
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

    void ExchangeListElements()
    {
      if(listMain.SelectedIndices.Count > 0 && listSideboard.SelectedIndices.Count > 0)
      {
        int mainIndex = listMain.SelectedIndices[0];
        int sideIndex = listSideboard.SelectedIndices[0];
        CardItem mainCard = ((CardListItemData)listMain.Items[mainIndex].Tag).CardItem;
        CardItem sideCard = ((CardListItemData)listSideboard.Items[sideIndex].Tag).CardItem;
        controller.MoveCard(SideboardingEditorListContext.Main, SideboardingEditorListContext.Sideboard, mainCard, sideIndex);
        controller.MoveCard(SideboardingEditorListContext.Sideboard, SideboardingEditorListContext.Main, sideCard, mainIndex);
      }
    }

    void MoveListElement(SideboardingEditorListContext contextFrom, SideboardingEditorListContext contextTo, int index)
		{
      List<CardItem> cards = new List<CardItem>();

      CardListView listViewFrom = null;
      switch(contextFrom)
      {
        case SideboardingEditorListContext.Main: listViewFrom = listMain; break;
        case SideboardingEditorListContext.Sideboard: listViewFrom = listSideboard; break;
      }

      foreach(ListViewItem item in listViewFrom.SelectedItems)
        cards.Add(((CardListItemData)item.Tag).CardItem);

      foreach(CardItem card in cards)
        controller.MoveCard(contextFrom, contextTo, card, index);
    }
  }
}