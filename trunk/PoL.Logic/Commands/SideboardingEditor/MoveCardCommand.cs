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
using PoL.Services.DataEntities;
using PoL.Common;
using System.Collections.ObjectModel;
using PoL.Models.SideboardingEditor;

namespace PoL.Logic.Commands.SideboardingEditor
{
  public class MoveCardCommand : ICommand
  {
    SideboardingEditorModel sideboardingEditor;

    public MoveCardCommandArgs Arguments;

    public MoveCardCommand(SideboardingEditorModel sideboardingEditor)
    {
      this.sideboardingEditor = sideboardingEditor;
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
        var card = Arguments.Card;
        var list = GetList(Arguments.From);
        if(list != null)
        {
          card = list.First(e => e.Id == card.Id);
          list.Remove(card);
        }
        list = GetList(Arguments.To);
        if(list != null)
        {
          if(Arguments.Index > -1)
            list.Insert(Arguments.Index, card);
          else
            list.Add(card);
        }
      }
    }

    ObservableCollection<CardItem> GetList(SideboardingEditorListContext listContext)
    {
      ObservableCollection<CardItem> list = null;
      switch(listContext)
      {
        case SideboardingEditorListContext.Sideboard:
          list = sideboardingEditor.Deck.SideboardCards;
          break;
        case SideboardingEditorListContext.Main:
          list = sideboardingEditor.Deck.MainCards;
          break;
      }
      return list;
    }
  }

  public struct MoveCardCommandArgs
  {
    public SideboardingEditorListContext From { get; set; }
    public SideboardingEditorListContext To { get; set; }
    public CardItem Card { get; set; }
    public int Index { get; set; }
  }
}
