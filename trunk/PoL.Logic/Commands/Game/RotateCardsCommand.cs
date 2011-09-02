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
  public class RotateCardsCommand : GameCommand, IUndoableCommand
  {
    public const string COMMANDCODE_TRUE = "ROTATE_CARDS_TRUE";
    public const string COMMANDCODE_FALSE = "ROTATE_CARDS_FALSE";

    public MultipleKeysArguments Arguments { get; set; }
    
    [NonSerialized]
    List<CardModel> cards;
    [NonSerialized]
    List<bool> states;

    public RotateCardsCommand(GameModel game)
      : base(game)
    {
    }

    public RotateCardsCommand()
      : this(null)
    {
    }

    public override void Execute()
    {
      cards = Arguments.Keys.Select(e => Receiver.GetCardByKey(e)).Where(e => e != null).ToList();
      states = new List<bool>(cards.Count);
      bool rotated = cards.Any(e => !e.Rotated.Value);
      foreach(var card in cards)
      {
        states.Add(card.Rotated.Value);
        if(card.Rotated.Value != rotated)
        {
          card.Rotated.Value = rotated;
          Log(card);
        }
      }
    }

    public void Undo()
    {
      for(int i = 0; i < cards.Count; i++)
      {
        if(cards[i].Rotated.Value != states[i])
          cards[i].Rotated.Value = states[i];
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
