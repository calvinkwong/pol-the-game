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

using PoL.Models;
using PoL.Common;
using Patterns.Command;
using PoL.Models.Game;
using Patterns;

namespace PoL.Logic.Commands.Game
{
  [Serializable]
  public class ReverseCardsCommand : GameCommand, IUndoableCommand
  {
    public const string COMMANDCODE_TRUE = "REVERSE_CARDS_TRUE";
    public const string COMMANDCODE_FALSE = "REVERSE_CARDS_FALSE";

    public MultipleKeysArguments Arguments { get; set; }

    [NonSerialized]
    List<CardModel> cards;
    [NonSerialized]
    List<bool> states;

    public ReverseCardsCommand(GameModel game)
      : base(game)
    {
    }

    public ReverseCardsCommand()
      : this(null)
    {
    }

    public override void Execute()
    {
      cards = Arguments.Keys.Select(e => Receiver.GetCardByKey(e)).Where(e => e != null).ToList();
      states = new List<bool>(cards.Count);
      bool reversed = cards.Any(e => !e.Reversed.Value);
      foreach(var card in cards)
      {
        states.Add(card.Reversed.Value);
        if(card.Reversed.Value != reversed)
        {
          card.Reversed.Value = reversed;
          Log(card);
        }
      }
    }

    public void Undo()
    {
      for(int i = 0; i < cards.Count; i++)
      {
        if(cards[i].Reversed.Value != states[i])
          cards[i].Reversed.Value = states[i];       
      }
    }

    void Log(CardModel card)
    {
      string playerName = Receiver.GetPlayerByKey(Invoker).Info.NickName;
      string commandName = Receiver.GetCommandByKey(card.Rotated.Value ? COMMANDCODE_TRUE : COMMANDCODE_FALSE).Data.Name;
      MessageContent logContent = new MessageContent(string.Concat("[", playerName, "] ", commandName, " "));
      logContent.Add(CardLogger.EncodeCardSmartName(card));
      Receiver.Console.WriteLog(logContent);
    }
  }
}
