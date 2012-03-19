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
using System.Linq;
using System.Text;

using PoL.Services.DataEntities;
using PoL.Models.DeckEditor;
using PoL.Logic.Views;
using PoL.Common;
using PoL.Logic.Commands.DeckEditor;
using Patterns.MVC;
using Patterns;
using Patterns.ComponentModel;
using PoL.Services;

namespace PoL.Logic.Controllers
{
  public class DeckEditorController : BaseController<DeckEditorModel, IDeckEditorView>
  {
    Dictionary<string, CardCounterEntry> mainCardCounter = new Dictionary<string, CardCounterEntry>();
    Dictionary<string, CardCounterEntry> sideCardCounter = new Dictionary<string, CardCounterEntry>();
    ServicesProvider servicesProvider;
    List<CardItem> archiveCards;

    public DeckEditorController(DeckEditorModel model, IDeckEditorView view, ServicesProvider servicesProvider)
      : base(model, view)
    {
      view.RegisterController(this);

      this.servicesProvider = servicesProvider;

      view.BeginLoad();
      try
      {
        foreach(CardItem card in model.Deck.MainCards)
          ManageAddMainCard(card);
        foreach(CardItem card in model.Deck.SideboardCards)
          ManageAddSideboardCard(card);
        view.DeckName = Model.Deck.Name;
        view.DeckCategory = Model.Deck.Category;

        View.SetDecksCategories(Model.ServiceProvider.DecksService.SelectAllCategories().Select(e => e.CategoryName));
        var searchParameters = CreateDefaultSearchParameters();
        archiveCards = servicesProvider.CardsService.SelectCards(searchParameters).ToList();
        View.SetSearchResult(archiveCards);

        View.SetSets(Model.ServiceProvider.GameSetsService.GetAll());
        View.SetColors(servicesProvider.ColorsService.GetAll());
        View.SetTypes(servicesProvider.TypesService.GetAll());
        View.SetRarities(servicesProvider.RaritiesService.GetAll());
      }
      finally
      {
        view.EndLoad();
        view.SetDeckSize(model.Deck.MainCards.Count, model.Deck.SideboardCards.Count);
      }
      model.Deck.MainCards.CollectionChanged += new CollectionChangedEventHandler(MainCards_CollectionChanged);
      model.Deck.SideboardCards.CollectionChanged += new CollectionChangedEventHandler(SideboardCards_CollectionChanged);
    }

    CardSearchParams CreateDefaultSearchParameters()
    {
      CardSearchParams p = new CardSearchParams();
      p.OrderCriteria.Field = OrderField.Name;
      p.OrderCriteria.Ascending = true;
      return p;
    }

    void MainCards_CollectionChanged(object sender, CollectionChangedEventArgs e)
    {
      switch(e.Action)
      {
        case CollectionChangedAction.Add:
          ManageAddMainCard((CardItem)e.NewItems[0]);
          break;
        case CollectionChangedAction.Remove:
          ManageRemoveMainCard((CardItem)e.OldItems[0]);
          break;
        case CollectionChangedAction.Reset:
          ManageClearList(DeckEditorListContext.Main);
          foreach(CardItem card in Model.Deck.MainCards)
            ManageAddMainCard(card);
          break;
      }
      View.SetDeckSize(Model.Deck.MainCards.Count, Model.Deck.SideboardCards.Count);
    }

    void SideboardCards_CollectionChanged(object sender, CollectionChangedEventArgs e)
    {
      switch(e.Action)
      {
        case CollectionChangedAction.Add:
          ManageAddSideboardCard((CardItem)e.NewItems[0]);
          break;
        case CollectionChangedAction.Remove:
          ManageRemoveSideboardCard((CardItem)e.OldItems[0]);
          break;
        case CollectionChangedAction.Reset:
          ManageClearList(DeckEditorListContext.Sideboard);
          foreach(CardItem card in Model.Deck.SideboardCards)
            ManageAddSideboardCard(card);
          break;
      }
      View.SetDeckSize(Model.Deck.MainCards.Count, Model.Deck.SideboardCards.Count);
    }

    public void Search(CardSearchParams searchParams)
    {
      View.BeginLoad();
      try
      {
        archiveCards = servicesProvider.CardsService.SelectCards(searchParams).ToList();

        if(archiveCards.Count == 0)
          View.ShowInfoMessage(Model.ServiceProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "MSG_NO_CARD_FOUND"));
        else
          View.SetSearchResult(archiveCards);
      }
      catch(Exception ex)
      {
        View.ShowExceptionMessage(ex);
      }
      finally
      {
        View.EndLoad();
      }
    }

    public void Order(OrderCriteria orderCriteria)
    {
      View.BeginLoad();
      try
      {
        SortableList list = new SortableList(new CardItemComparer(orderCriteria), archiveCards.Count);
        list.AddRange(archiveCards);
        archiveCards.Clear();
        foreach(var item in list)
          archiveCards.Add((CardItem)item);

        View.SetSearchResult(archiveCards);
      }
      catch(Exception ex)
      {
        View.ShowExceptionMessage(ex);
      }
      finally
      {
        View.EndLoad();
      }
    }

    public void ClearList(DeckEditorListContext listContext)
    {
      try
      {
        if(listContext == DeckEditorListContext.Archive)
        {
          View.SetSearchResult(null);
        }
        else
        {
          ClearListCommand cmd = new ClearListCommand(Model);
          cmd.Arguments = new ClearListArguments() { List = listContext };
          CommandHandler.Execute(cmd);
        }
      }
      catch(Exception ex)
      {
        View.ShowExceptionMessage(ex);
      }
    }

    public void MoveCard(DeckEditorListContext from, DeckEditorListContext to, CardItem card, int destinationIndex)
    {
      try
      {
        MoveCardCommand cmd = new MoveCardCommand(Model);
        cmd.Arguments = new MoveCardCommandArgs() { From = from, To = to, Card = card, Index = destinationIndex };
        CommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        View.ShowExceptionMessage(ex);
      }
    }

    public DeckStatistics GetDeckStatistics()
    {
      return Model.Deck.GenerateStatistics();
    }

    public bool Save()
    {
      bool saved = false;
      try
      {
        Model.Deck.Name = View.DeckName;
        Model.Deck.Category = View.DeckCategory;
        SaveCommand cmd = new SaveCommand(Model);
        CommandHandler.Execute(cmd);
        View.ShowInfoMessage(Model.ServiceProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "MSG_SAVE_COMPLETED"));
        saved = true;
      }
      catch(InvalidDeckCategoryNameException)
      {
        View.ShowInfoMessage(Model.ServiceProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "MSG_INVALID_CATEGORY"));
      }
      catch(InvalidDeckNameException)
      {
        View.ShowInfoMessage(Model.ServiceProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "MSG_INVALID_NAME"));
      }
      catch(DeckAlreadyExistsException)
      {
        View.ShowInfoMessage(Model.ServiceProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "MSG_DECK_ALREADY_EXISTS"));
      }
      catch(Exception ex)
      {
        View.ShowExceptionMessage(ex);
      }
      return saved;
    }

    public void QuickSearch(DeckEditorListContext listContext)
    {
      CardItem card = null;
      string text = View.GetQuickSearchText(listContext).Trim();
      if(text.Length > 0)
      {
        IEnumerable<CardItem> list = archiveCards;
        switch(listContext)
        {
          case DeckEditorListContext.Main:
            list = Model.Deck.MainCards;
            break;
          case DeckEditorListContext.Sideboard:
            list = Model.Deck.SideboardCards;
            break;
        }
        if(list != null)
          card = list.FirstOrDefault(e => e.Name.StartsWith(text, StringComparison.OrdinalIgnoreCase));
      }
      View.SelectCard(listContext, card);
    }

    void ManageClearList(DeckEditorListContext listContext)
    {
      if(View.ShowQuestionMessage(servicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "MSG_CONFIRM_CLEAR_LIST")) == ViewResult.Yes)
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

    void ManageRemoveMainCard(CardItem card)
    {
      CardCounterEntry entry;
      if(mainCardCounter.TryGetValue(card.Id, out entry))
      {
        if(entry.Count == 1)
        {
          mainCardCounter.Remove(entry.Card.Id);
          View.RemoveMainCard(entry.Card);
        }
        else
        {
          entry.Count--;
          View.SetMainCardCount(entry.Card, entry.Count);
        }
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

    void ManageRemoveSideboardCard(CardItem card)
    {
      CardCounterEntry entry;
      if(sideCardCounter.TryGetValue(card.Id, out entry))
      {
        if(entry.Count == 1)
        {
          sideCardCounter.Remove(entry.Card.Id);
          View.RemoveSideboardCard(entry.Card);
        }
        else
        {
          entry.Count--;
          View.SetSideboardCardCount(entry.Card, entry.Count);
        }
      }
    }
  }

  public enum DeckEditorMode
  { 
    DeckEditor,
    Sideboarding,
  }

  class CardCounterEntry
  {
    public CardItem Card { get; set; }
    public int Count { get; set; }

    public CardCounterEntry(CardItem card, int count)
    {
      this.Card = card;
      this.Count = count;
    }
  }
}
