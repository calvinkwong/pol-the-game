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
using System.Collections.Specialized;
using System.Linq;
using System.Text;

using PoL.Common;
using PoL.Services.DataEntities;
using Patterns.ComponentModel;

namespace PoL.Models.Game
{
  [Serializable]
  public class LookupModel : Model
  {
    public readonly LookupRules Rules;
    public readonly SectorModel Sector;
    public readonly PlayerModel Player;
    public readonly bool Visible;
    public readonly bool ReadOnly;
    public readonly ModelCollection Cards;

    bool disabled = false;

    bool SHOW_HIDDEN_CARDS = false;

    HashSet<string> visibleCards = new HashSet<string>();

    public LookupModel(string key, SectorModel sector, LookupRules rules, PlayerModel player, bool readOnly)
      : base(key)
    {
      this.Cards = new ModelCollection(this);

      this.Player = player;
      this.ReadOnly = readOnly;
      this.Sector = sector;
      this.Rules = rules;
      if(rules == null)
        this.Rules = new LookupRules(LookupStyle.All, -1, new List<string>());

      int i = 0;
      switch(rules.Style)
      { 
        case LookupStyle.All:
        case LookupStyle.KeepVisibleTop:
        case LookupStyle.Top:
          this.Sector.Cards.CollectionChanged += new NotifyCollectionChangedEventHandler(Cards_CollectionChanged);
          for(i = 0; i < sector.Cards.Count; i++)
          {
            if(this.Rules.Style == LookupStyle.Top && i < Rules.Amount)
              visibleCards.Add(sector.Cards[i].Key);
            InsertCard(sector.Cards[i].Key, i);
          }
          break;
      }
    }

    void Cards_CollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
    {
      if(disabled)
        return;

      IEnumerable<CardModel> items = null;
      switch(args.Action)
      {
        case NotifyCollectionChangedAction.Add:
          items = args.NewItems.Cast<CardModel>();
          foreach(var card in items)
            InsertCard(card.Key, args.NewStartingIndex);
          break;
        case NotifyCollectionChangedAction.Remove:
          items = args.OldItems.Cast<CardModel>();
          foreach(var card in items)
            RemoveCard(card.Key);
          break;
        case NotifyCollectionChangedAction.Move:
          MoveCard(((CardModel)args.OldItems[0]).Key, args.OldStartingIndex, args.NewStartingIndex);
          break;
        case NotifyCollectionChangedAction.Reset:
          ResetCards();
          break;
      }
    }

    void ResetCards()
    {
      Cards.SuspendChangeNotifications();
      try
      {
        Cards.Clear();
        if(Rules.Style == LookupStyle.Top)
          disabled = true;
        else
        {
          for(int i = 0; i < Sector.Cards.Count; i++)
            InsertCard(Sector.Cards[i].Key, i);
        }
      }
      finally
      {
        Cards.ResumeChangeNotifications();
      }
    }

    void MoveCard(string cardKey, int oldStartingIndex, int newStartingIndex)
    {
      switch(Rules.Style)
      {
        case LookupStyle.KeepVisibleTop:
          {
            int upperIndex = Math.Min(Sector.Cards.Count, this.Rules.Amount) - 1;
            if(oldStartingIndex <= upperIndex)
            {
              if(newStartingIndex <= upperIndex)
                Cards.Move(oldStartingIndex, newStartingIndex);
              else
                RemoveCard(cardKey);
            }
            else if(newStartingIndex <= upperIndex)
              InsertCard(cardKey, upperIndex);
          }
          break;
        case LookupStyle.All:
          Cards.Move(oldStartingIndex, newStartingIndex);
          break;
        case LookupStyle.Top:
          if(SHOW_HIDDEN_CARDS)
            Cards.Move(oldStartingIndex, newStartingIndex);
          else
          {
            int upperIndex = this.Cards.Count - 1;
            if(oldStartingIndex <= upperIndex)
            {
              if(newStartingIndex <= upperIndex)
                Cards.Move(oldStartingIndex, newStartingIndex);
              else
                RemoveCard(cardKey);
            }
            else if(newStartingIndex <= upperIndex)
              InsertCard(cardKey, upperIndex);
          }
          break;
      }
    }

    void RemoveCard(string cardKey)
    {
      LookupCardModel lookupCard = (LookupCardModel)Cards.SingleOrDefault(e => e.Key == cardKey);
      if(lookupCard != null)
      {
        Cards.Remove(lookupCard);
        if(Rules.Style == LookupStyle.KeepVisibleTop)
        {
          int upperIndex = Math.Min(Sector.Cards.Count, this.Rules.Amount) - 1;
          if((this.Cards.Count - 1) < upperIndex)
            InsertCard(Sector.Cards[upperIndex].Key, upperIndex);
        }
      }
    }

    void InsertCard(string cardKey, int index)
    {
      int upperIndex = 0;
      LookupCardModel lookupCard = null;
      switch(Rules.Style)
      {
        case LookupStyle.All:
          lookupCard = new LookupCardModel(cardKey);
          Cards.Insert(index, lookupCard);
          break;
        case LookupStyle.KeepVisibleTop:
          upperIndex = Math.Min(Sector.Cards.Count, this.Rules.Amount) - 1;
          if(index <= upperIndex)
          {
            lookupCard = new LookupCardModel(cardKey);
            Cards.Insert(index, lookupCard);
            if((this.Cards.Count-1) > upperIndex)
              Cards.Remove(Cards.Last());
          }
          break;
        case LookupStyle.Top:
          if(SHOW_HIDDEN_CARDS || visibleCards.Contains(cardKey) || index < this.Rules.Amount)
          {
            lookupCard = new LookupCardModel(cardKey, !visibleCards.Contains(cardKey));
            Cards.Insert(index, lookupCard);
          }
          break;
      }
    }
  }
}
