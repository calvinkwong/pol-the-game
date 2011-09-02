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
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

using PoL.Services.DataEntities;
using PoL.Models.SideboardingEditor;
using PoL.Logic.Views;
using PoL.Common;
using PoL.Logic.Commands.SideboardingEditor;
using Patterns.MVC;
using Patterns;
using PoL.Services;

namespace PoL.Logic.Controllers
{
  public class SideboardingEditorController : BaseController<SideboardingEditorModel, ISideboardingEditorView>
  {
    Dictionary<string, CardCounterEntry> mainCardCounter = new Dictionary<string, CardCounterEntry>();
    Dictionary<string, CardCounterEntry> sideCardCounter = new Dictionary<string, CardCounterEntry>();
    ServicesProvider servicesProvider;

    public SideboardingEditorController(SideboardingEditorModel model, ISideboardingEditorView view, ServicesProvider servicesProvider)
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
      }
      finally
      {
        view.EndLoad();
        view.SetDeckSize(model.Deck.MainCards.Count, model.Deck.SideboardCards.Count);
      }
      model.Deck.MainCards.CollectionChanged += new NotifyCollectionChangedEventHandler(MainCards_CollectionChanged);
      model.Deck.SideboardCards.CollectionChanged += new NotifyCollectionChangedEventHandler(SideboardCards_CollectionChanged);
    }

    void MainCards_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      switch(e.Action)
      {
        case NotifyCollectionChangedAction.Add:
          ManageAddMainCard((CardItem)e.NewItems[0]);
          break;
        case NotifyCollectionChangedAction.Remove:
          ManageRemoveMainCard((CardItem)e.OldItems[0]);
          break;
      }
      View.SetDeckSize(Model.Deck.MainCards.Count, Model.Deck.SideboardCards.Count);
    }

    void SideboardCards_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      switch(e.Action)
      {
        case NotifyCollectionChangedAction.Add:
          ManageAddSideboardCard((CardItem)e.NewItems[0]);
          break;
        case NotifyCollectionChangedAction.Remove:
          ManageRemoveSideboardCard((CardItem)e.OldItems[0]);
          break;
      }
      View.SetDeckSize(Model.Deck.MainCards.Count, Model.Deck.SideboardCards.Count);
    }

    public void ClearList(SideboardingEditorListContext listContext)
    {
      try
      {
        ClearListCommand cmd = new ClearListCommand(Model);
        cmd.Arguments = new ClearListArguments() { List = listContext };
        CommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        View.ShowExceptionMessage(ex);
      }
    }

    public void MoveCard(SideboardingEditorListContext from, SideboardingEditorListContext to, CardItem card, int destinationIndex)
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

    public bool Save()
    {
      bool saved = false;
      try
      {
        if(Model.OriginalDeck.MainCards.Count != Model.Deck.MainCards.Count || Model.OriginalDeck.SideboardCards.Count != Model.Deck.SideboardCards.Count)
        {
          var message = Model.ServiceProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "MSG_INVALID_DECK_SIZE");
          message = message.Replace("#decksize#", Model.OriginalDeck.MainCards.Count.ToString()).Replace("#sideboardsize#", Model.OriginalDeck.SideboardCards.Count.ToString());
          View.ShowInfoMessage(message);
        }
        else
        {
          SaveCommand cmd = new SaveCommand(Model);
          CommandHandler.Execute(cmd);
          View.ShowInfoMessage(Model.ServiceProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "MSG_SAVE_COMPLETED"));
          saved = true;
        }
      }
      catch(Exception ex)
      {
        View.ShowExceptionMessage(ex);
      }
      return saved;
    }

    public void QuickSearch(SideboardingEditorListContext listContext)
    {
      CardItem card = null;
      string text = View.GetQuickSearchText(listContext).Trim();
      if(text.Length > 0)
      {
        IEnumerable<CardItem> list = null;
        switch(listContext)
        {
          case SideboardingEditorListContext.Main:
            list = Model.Deck.MainCards;
            break;
          case SideboardingEditorListContext.Sideboard:
            list = Model.Deck.SideboardCards;
            break;
        }
        if(list != null)
          card = list.FirstOrDefault(e => e.Name.StartsWith(text, StringComparison.OrdinalIgnoreCase));
      }
      View.SelectCard(listContext, card);
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
}
