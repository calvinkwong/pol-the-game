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
using System.Linq;
using System.Text;

using Patterns.Command;
using PoL.Models.DeckEditor;
using PoL.Services.DataEntities;
using PoL.Common;
using System.Collections.ObjectModel;

namespace PoL.Logic.Commands.DeckEditor
{
  public class MoveCardCommand : ICommand
  {
    DeckEditorModel deckEditor;

    public MoveCardCommandArgs Arguments;

    public MoveCardCommand(DeckEditorModel deckEditor)
    {
      this.deckEditor = deckEditor;
    }

    public void Execute()
    {
      if(Arguments.From == Arguments.To)
      {
        CardItem duplicate = Arguments.Card.Clone();
        var list = GetList(Arguments.From);
        if(list != null)
          list.Add(duplicate);
      }
      else
      {
        var list = GetList(Arguments.From);
        if(list != null)
          list.Remove(list.First(e => e.Id == Arguments.Card.Id));
        list = GetList(Arguments.To);
        if(list != null)
        {
          if(Arguments.Index > -1)
            list.Insert(Arguments.Index, Arguments.Card);
          else
            list.Add(Arguments.Card);
        }
      }
    }

    ObservableCollection<CardItem> GetList(DeckEditorListContext listContext)
    {
      ObservableCollection<CardItem> list = null;
      switch(listContext)
      {
        case DeckEditorListContext.Sideboard:
          list = deckEditor.Deck.SideboardCards;
          break;
        case DeckEditorListContext.Main:
          list = deckEditor.Deck.MainCards;
          break;
      }
      return list;
    }
  }

  public struct MoveCardCommandArgs
  {
    public DeckEditorListContext From { get; set; }
    public DeckEditorListContext To { get; set; }
    public CardItem Card { get; set; }
    public int Index { get; set; }
  }
}
