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
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

using PoL.Logic.Controllers;
using PoL.Logic.Views;
using PoL.Services;
using PoL.Services.DataEntities;
using PoL.WinFormsView.Utils;
using Patterns.MVC;
using PoL.Common;

namespace PoL.WinFormsView.DeckRoom
{
	public partial class DeckRoomView : WinFormsView, IDeckRoomView, ILocalizable
	{
    DeckRoomController controller;
    bool ignoreSelectionChanging;

    string deckTitle = string.Empty;
    string sideboardTitle = string.Empty;

    public DeckRoomView()
		{
			InitializeComponent();

			this.DialogResult = DialogResult.Cancel;
			this.StartPosition = FormStartPosition.CenterParent;

      cardPreview.BackgroundImage = Program.LogicHandler.ServicesProvider.ImagesService.GetCardBack(CardStyleBehaviorsService.BEHAVIORS_LARGE);

      listCard.SelectedIndexChanged += new EventHandler(list_SelectedIndexChanged);
      listCard.OrderList(0);
      listSideboard.SelectedIndexChanged += new System.EventHandler(list_SelectedIndexChanged);
      listSideboard.OrderList(0);

      btnOK.Click += delegate(object sender, EventArgs e)
      {
        this.DialogResult = DialogResult.OK;
        this.Close();
      };
      btnQuit.Click += delegate(object sender, EventArgs e)
      {
        this.Close();
      };
      btnEdit.Click += delegate(object sender, EventArgs e)
      {
        controller.EditDeck();
      };
      btnDelete.Click += delegate(object sender, EventArgs e)
      {
        controller.DeleteDeck();
      };
      btnNew.Click += delegate(object sender, EventArgs e)
      {
        controller.NewDeck();
      };
      btnImport.Click += new EventHandler(btnImport_Click);
      btnExport.Click += new EventHandler(btnExport_Click);

      Localize();
    }

    void btnExport_Click(object sender, EventArgs e)
    {
      ExportParametersView view = new ExportParametersView();
      if(view.ShowDialog() == DialogResult.OK)
      {
        bool export = true;

        if(view.SelectedDestination == DeckExportDestination.File)
        {
          switch(view.SelectedFormat)
          {
            case DeckExportFormat.Text:
              saveFileDialog.Filter = "Text format|*.txt";
              break;
          }
          export = saveFileDialog.ShowDialog() == DialogResult.OK;
        }

        if(export)
        {
          string raw = string.Empty;
          Cursor currentCursor = Cursor.Current;
          Cursor.Current = Cursors.WaitCursor;
          try
          {
            DeckExportParameters parameters = new DeckExportParameters()
            {
              Language = view.SelectedLanguage,
              Format = view.SelectedFormat,
              IncludeTags = view.SelectedIncludeTag
            };
            raw = controller.ExportDeck(parameters);
          }
          finally
          {
            Cursor.Current = currentCursor;
          }

          if(view.SelectedDestination == DeckExportDestination.File)
            File.WriteAllText(saveFileDialog.FileName, raw);
          else
            Clipboard.SetText(raw);

          Program.InfoBox(this, Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_ROOM_DIALOG", "MSG_EXPORTCOMPLETED"));
        }
      }
    }

    void btnImport_Click(object sender, EventArgs e)
    {
      if(openFileDialog.ShowDialog() == DialogResult.OK)
      {
        Cursor currentCursor = Cursor.Current;
        Cursor.Current = Cursors.WaitCursor;
        try
        {
          controller.ImportDecks(openFileDialog.FileNames);
        }
        finally
        {
          Cursor.Current = currentCursor;
        }
      }
    }

    public void Localize()
    {
      this.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_ROOM_DIALOG", "TITLE");
      lblDeckList.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_ROOM_DIALOG", "DECK_LIST");
      lblDeckList.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_ROOM_DIALOG", "DECK_LIST_DESC");
      lblYourDeck.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_ROOM_DIALOG", "CARDS");
      deckTitle = lblYourDeck.Title;
      lblYourDeck.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_ROOM_DIALOG", "CARDS_DESC");
      lblYourSideboard.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_ROOM_DIALOG", "SIDEBOARD");
      sideboardTitle = lblYourSideboard.Title;
      lblYourSideboard.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_ROOM_DIALOG", "SIDEBOARD_DESC");

      btnImport.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_ROOM_DIALOG", "IMPORT");
      btnExport.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_ROOM_DIALOG", "EXPORT");
      btnEdit.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_ROOM_DIALOG", "EDIT");
      btnDelete.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_ROOM_DIALOG", "DELETE");
      btnNew.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_ROOM_DIALOG", "NEW");
      
      colDeckListName.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_ROOM_DIALOG", "NAME");

      btnQuit.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_ROOM_DIALOG", "QUIT");
      btnOK.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_ROOM_DIALOG", "OK");

      openFileDialog.Filter = string.Concat(
        Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_ROOM_DIALOG", "ALL_FORMATS"),
        "|*.mwDeck;*.xml",
        "|PoL deck file|*.xml",
        "|Magic Workstation deck file|*.mwDeck"
        );

      listCard.Localize();
      listSideboard.Localize();
    }

		void list_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListView list = (ListView)sender;
      if(list.SelectedItems.Count > 0)
      {
        CardListItemData data = (CardListItemData)list.SelectedItems[list.SelectedItems.Count-1].Tag;
        cardPreview.Image = CardDrawer.Draw(data.CardItem, CardStyleBehaviorsService.BEHAVIORS_LARGE);
      }
		}

		void listDeck_SelectedIndexChanged(object sender, EventArgs e)
		{
      if(ignoreSelectionChanging)
        return;

      Cursor currentCursor = Cursor.Current;
      Cursor.Current = Cursors.WaitCursor;
      try
      {
        if(listDeck.Items.Count > 0 && listDeck.SelectedItems.Count > 0)
        {
          ListViewItem cardItem = listDeck.SelectedItems[0];
          controller.SelectDeck(cardItem.Group.Name, cardItem.Text);
        }
      }
      finally
      {
        Cursor.Current = currentCursor;
      }
    }

    #region IView Members

    public void RegisterController(DeckRoomController controller)
    {
      this.controller = controller;
    }

    #endregion

    #region IDeckRoomView members

    public void Initialize(List<DeckCategoryItem> decks)
		{
      listDeck.SelectedIndexChanged -= new System.EventHandler(listDeck_SelectedIndexChanged);
      listDeck.Items.Clear();
      listDeck.Groups.Clear();
      listDeck.BeginUpdate();
      try
      {
        ListViewGroup group = null;
        ListViewItem item = null;
        foreach(DeckCategoryItem category in decks)
        {
          group = new ListViewGroup(category.CategoryName, category.CategoryName);
          listDeck.Groups.Add(group);
          foreach(string deckName in category.DeckNames)
          {
            item = new ListViewItem();
            item.Group = group;
            item.Text = deckName;
            item.Name = string.Concat(group, deckName);
            listDeck.Items.Add(item);
          }
        }
      }
      finally
      {
        cardPreview.Image = null;
        listDeck.EndUpdate();
        listDeck.SelectedIndexChanged += new System.EventHandler(listDeck_SelectedIndexChanged);
      }
    }

    public void ClearList(DeckEditorListContext listContext)
    {
      switch(listContext)
      {
        case DeckEditorListContext.Main:
          listCard.Items.Clear();
          break;
        case DeckEditorListContext.Sideboard:
          listSideboard.Items.Clear();
          break;
      }
    }

    public void AddMainCard(CardItem card)
    {
      listCard.AddCardItem(card);
    }

    public void SetMainCardCount(CardItem card, int count)
    {
      listCard.UpdateCardItem(card, count);
    }

    public void AddSideboardCard(CardItem card)
    {
      listSideboard.AddCardItem(card);
    }

    public void SetSideboardCardCount(CardItem card, int count)
    {
      listSideboard.UpdateCardItem(card, count);
    }

    Cursor currentCursor = Cursors.Default;
    public void BeginLoad()
    {
      currentCursor = Cursor.Current;
      Cursor.Current = Cursors.WaitCursor;
      listCard.BeginUpdate();
      listSideboard.BeginUpdate();
    }

    public void EndLoad()
    {
      Cursor.Current = currentCursor;
      listCard.EndUpdate();
      listSideboard.EndUpdate();
    }

    public void SetDeckSize(int mainSize, int sideboardSize)
    {
      lblYourDeck.Title = deckTitle + " (" + mainSize + ") ";
      lblYourSideboard.Title = sideboardTitle + " (" + sideboardSize + ") ";
    }

    public void SelectDeck(DeckItem deck)
    {
      if(deck != null)
      {
        ListViewItem item = listDeck.Items.Find(string.Concat(deck.Category, deck.Name), true).FirstOrDefault();
        if(item != null)
        {
          ignoreSelectionChanging = true;
          try
          {
            item.Selected = true;
          }
          finally
          {
            ignoreSelectionChanging = false;
          }
        }
      }
    }

    public void EnableEdit(bool enable)
    {
      btnEdit.Enabled = enable;
    }

    public void EnableDelete(bool enable)
    {
      btnDelete.Enabled = enable;
    }

    public void SetImportStatistics(DeckImportStatistics statistics)
    {
      DeckImportStatisticsView view = new DeckImportStatisticsView();
      view.ImportStatistics = statistics;
      view.ShowDialog(this);
    }

    #endregion 	
  }
}