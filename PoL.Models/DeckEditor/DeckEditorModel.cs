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
using System.Text;
using System.IO;

using PoL.Common;
using PoL.Services;
using PoL.Services.DataEntities;
using PoL.Models.Game;
using Patterns;

namespace PoL.Models.DeckEditor
{
  public class DeckEditorModel
  {
    public readonly ServicesProvider ServiceProvider;
    public readonly DeckItem Deck;
    public readonly GameInfoItem GameItem;

    DeckItem originalDeck;

    public DeckEditorModel(ServicesProvider servicesProvider, GameInfoItem gameItem, DeckItem deck)
    {
      this.ServiceProvider = servicesProvider;
      this.GameItem = gameItem;
      if(deck == null)
        Deck = new DeckItem(gameItem.Code);
      else
      {
        originalDeck = deck;
        Deck = (DeckItem)deck.Clone();
      }
    }

    public void Save()
    {
      if(string.IsNullOrEmpty(Deck.Category))
        throw new InvalidDeckCategoryNameException(string.Concat("Category name is empty!"));
      if(string.IsNullOrEmpty(Deck.Name))
        throw new InvalidDeckNameException(string.Concat("Name is empty!"));

      if(Deck.Category.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
        throw new InvalidDeckCategoryNameException(string.Concat("Category name ", Deck.Category, " contains invalid chars!"));
      if(Deck.Name.IndexOfAny(Path.GetInvalidFileNameChars()) != -1) 
        throw new InvalidDeckNameException(string.Concat("Name ", Deck.Name, " contains invalid chars!"));

      // new deck?
      if(originalDeck == null && ServiceProvider.DecksService.DeckExists(Deck.Category, Deck.Name))
        throw new DeckAlreadyExistsException(string.Concat("Deck ", Deck.Category, " ", Deck.Name, " already exists!"));

      // renamed deck?
      if(originalDeck != null && (originalDeck.Category != Deck.Category || originalDeck.Name != Deck.Name))
        if(ServiceProvider.DecksService.DeckExists(Deck.Category, Deck.Name))
          throw new DeckAlreadyExistsException(string.Concat("Deck ", Deck.Category, " ", Deck.Name, " already exixts!"));

      ServiceProvider.DecksService.SaveDeck(Deck);
      originalDeck = (DeckItem)Deck.Clone();
    }
  }

  public class InvalidDeckCategoryNameException : Exception
  {
    public InvalidDeckCategoryNameException(string message)
      : base(message) { }
  }


  public class InvalidDeckNameException : Exception
  {
    public InvalidDeckNameException(string message)
      : base(message) { }
  }

  public class DeckAlreadyExistsException : Exception
  {
    public DeckAlreadyExistsException(string message)
      : base(message) { }
  }
}
