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
using PoL.Common;
using PoL.Models.SideboardingEditor;

namespace PoL.Logic.Commands.SideboardingEditor
{
  public class ClearListCommand : ICommand
  {
    SideboardingEditorModel deckEditor;

    public ClearListArguments Arguments;

    public ClearListCommand(SideboardingEditorModel deckEditor)
    {
      this.deckEditor = deckEditor;
    }

    public void Execute()
    {
      switch(Arguments.List)
      {
        case SideboardingEditorListContext.Sideboard:
          deckEditor.Deck.SideboardCards.Clear();
          break;
        case SideboardingEditorListContext.Main:
          deckEditor.Deck.MainCards.Clear();
          break;
      }
    }
  }

  public struct ClearListArguments
  {
    public SideboardingEditorListContext List { get; set; }
  }
}
