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

using System.Linq;
using System.Collections.ObjectModel;

using Patterns.Command;
using PoL.Logic.Commands.DeckRoom;
using PoL.Common;
using PoL.Logic.Views;
using PoL.Services;
using PoL.Services.DataEntities;
using Patterns.MVC;
using PoL.Models.DeckRoom;
using System;
using Patterns;
using System.Collections.Generic;
using System.IO;
using PoL.Configuration;

namespace PoL.Logic.Controllers
{
  public class DeckRoomController : BaseController<DeckRoomModel, IDeckRoomView>
  {
    Dictionary<string, CardCounterEntry> mainCardCounter = new Dictionary<string, CardCounterEntry>();
    Dictionary<string, CardCounterEntry> sideCardCounter = new Dictionary<string, CardCounterEntry>();

    public event Action<DeckEditorRequestType> DeckEditorRequest;

    public DeckRoomController(DeckRoomModel deckRoomModel, IDeckRoomView deckRoomView)
      : base(deckRoomModel, deckRoomView)
    {
      deckRoomView.RegisterController(this);
      Model.SelectedDeck.Changed += new EventHandler<ChangedEventArgs<DeckItem>>(SelectedDeck_Changed);

      InitView();
    }

    void InitView()
    {
      List<DeckCategoryItem> categories = Model.ServicesProvider.DecksService.SelectAllCategories();
      View.Initialize(categories);
      View.EnableDelete(false);
      View.EnableEdit(false);

      if(categories.Count > 0 && categories.First().DeckNames.Count > 0)
      {
        if(Model.ServicesProvider.DecksService.DeckExists(SettingsManager.Settings.LastEditedDeck.Category, SettingsManager.Settings.LastEditedDeck.Name))
          this.SelectDeck(SettingsManager.Settings.LastEditedDeck.Category, SettingsManager.Settings.LastEditedDeck.Name);
        else
          this.SelectDeck(categories.First().CategoryName, categories.First().DeckNames.First());
      }
    }

    void SelectedDeck_Changed(object sender, ChangedEventArgs<DeckItem> e)
    {
      View.BeginLoad();
      try
      {
        ManageClearList(DeckEditorListContext.Main);
        ManageClearList(DeckEditorListContext.Sideboard);
        if(Model.SelectedDeck.Value != null)
        {
          foreach(CardItem card in Model.SelectedDeck.Value.MainCards)
            ManageAddMainCard(card);
          foreach(CardItem card in Model.SelectedDeck.Value.SideboardCards)
            ManageAddSideboardCard(card);

          View.EnableDelete(true);
          View.EnableEdit(true);
        }
        else
        {
          View.EnableDelete(false);
          View.EnableEdit(false);
        }
      }
      finally
      {
        View.EndLoad();
        if(Model.SelectedDeck.Value != null)
          View.SetDeckSize(Model.SelectedDeck.Value.MainCards.Count, Model.SelectedDeck.Value.SideboardCards.Count);
        else
          View.SetDeckSize(0, 0);
        View.SelectDeck(Model.SelectedDeck.Value);
      }
    }

    void ManageClearList(DeckEditorListContext listContext)
    {
      switch(listContext)
      {
        case DeckEditorListContext.Main:
          mainCardCounter.Clear();
          break;
        case DeckEditorListContext.Sideboard:
          sideCardCounter.Clear();
          break;
      }
      View.ClearList(listContext);
    }

    void ManageAddMainCard(CardItem card)
    {
      CardCounterEntry entry;
      if(!mainCardCounter.TryGetValue(card.Id, out entry))
      {
        entry = new CardCounterEntry(card, 1);
        mainCardCounter.Add(card.Id, entry);
        View.AddMainCard(card);
      }
      else
      {
        entry.Count++;
        View.SetMainCardCount(entry.Card, entry.Count);
      }
    }

    void ManageAddSideboardCard(CardItem card)
    {
      CardCounterEntry entry;
      if(!sideCardCounter.TryGetValue(card.Id, out entry))
      {
        entry = new CardCounterEntry(card, 1);
        sideCardCounter.Add(card.Id, entry);
        View.AddSideboardCard(card);
      }
      else
      {
        entry.Count++;
        View.SetSideboardCardCount(entry.Card, entry.Count);
      }
    }

    void SaveLastEditedDeck()
    {
      SettingsManager.Settings.LastEditedDeck.Category = Model.SelectedDeck.Value.Category;
      SettingsManager.Settings.LastEditedDeck.Name = Model.SelectedDeck.Value.Name;
      SettingsManager.Save();
    }

    public void SelectDeck(string category, string name)
    {
      SelectDeckCommand cmd = new SelectDeckCommand(Model);
      cmd.Arguments = new SelectDeckCommandArguments() { Category = category, Name = name };
      CommandHandler.Execute(cmd);
    }

    public void NewDeck()
    {
      OnDeckEditorRequest(DeckEditorRequestType.New);
      InitView();
    }

    public void EditDeck()
    {
      SaveLastEditedDeck();
      OnDeckEditorRequest(DeckEditorRequestType.Edit);
      InitView();
    }

    public void DeleteDeck()
    {
      string message = Model.ServicesProvider.SystemStringsService.GetString("DECK_ROOM_DIALOG", "MSG_DELETE_CONFIRMATION");
      if(View.ShowQuestionMessage(message.Replace("#deckname#", Model.SelectedDeck.Value.Name)) == ViewResult.Yes)
      {
        DeleteDeckCommand cmd = new DeleteDeckCommand(Model);
        cmd.Arguments = new DeleteDeckCommandArguments() 
        { 
          Category = Model.SelectedDeck.Value.Category, 
          Name = Model.SelectedDeck.Value.Name
        };
        CommandHandler.Execute(cmd);
        InitView();
        Model.SelectedDeck.Value = null;
      }
    }

    public void ImportDecks(string[] fileNames)
    {
      if(Model.ServicesProvider.SetCodesMapService != null)
      {
        ImportDecksCommand cmd = new ImportDecksCommand(Model);
        cmd.Arguments = new ImportDecksArguments() { FileNames = fileNames, MappingManager = Model.ServicesProvider.SetCodesMapService };
        CommandHandler.Execute(cmd);
        View.SetImportStatistics(cmd.Result);
        InitView();
        Model.SelectedDeck.Value = null;
      }
      else
        View.ShowInfoMessage(Model.ServicesProvider.SystemStringsService.GetString("DECK_ROOM_DIALOG", "MSG_MAPPINGFILENOTFOUND"));
    }

    public string ExportDeck(DeckExportParameters parameters)
    {
      return Model.ServicesProvider.DecksService.ExportDeck(
        Model.SelectedDeck.Value.Category, Model.SelectedDeck.Value.Name, parameters);
    }

    protected virtual void OnDeckEditorRequest(DeckEditorRequestType requestType)
    {
      if(DeckEditorRequest != null)
        DeckEditorRequest(requestType);
    }
  }

  public enum DeckEditorRequestType
  {
    New,
    Edit
  }
}
