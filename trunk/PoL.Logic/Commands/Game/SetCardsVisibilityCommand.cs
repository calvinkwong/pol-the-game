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
  public class SetCardsVisibilityCommand : GameCommand, IUndoableCommand
  {
    public const string COMMANDCODE_VISIBLE = "SET_CARD_VISIBILITY_VISIBLE";
    public const string COMMANDCODE_PRIVATE = "SET_CARD_VISIBILITY_PRIVATE";
    public const string COMMANDCODE_HIDDEN = "SET_CARD_VISIBILITY_HIDDEN";

    [NonSerialized]
    Dictionary<CardModel, CardVisibility> oldVisibilities;

    public SetCardVisibilityArguments Arguments { get; set; }

    public SetCardsVisibilityCommand(GameModel game)
      : base(game)
    {
    }

    public SetCardsVisibilityCommand()
      : this(null)
    {
    }

    public override void Execute()
    {
      oldVisibilities = new Dictionary<CardModel, CardVisibility>();
      foreach(var cardKey in Arguments.Keys)
      {
        CardModel card = Receiver.GetCardByKey(cardKey);
        if(card != null)
        {
          oldVisibilities.Add(card, card.Visibility.Value);
          card.Visibility.Value = Arguments.Visibility;
          Log(card);
        }
      }
    }

    public void Undo()
    {
      foreach(var cardKey in Arguments.Keys)
      {
        CardModel card = Receiver.GetCardByKey(cardKey);
        if(card != null)
          card.Visibility.Value = oldVisibilities[card];
      }
    }

    void Log(CardModel card)
    {
      string playerName = Receiver.GetPlayerByKey(Invoker).Info.NickName;
      string commandName = string.Empty;
      switch(card.Visibility.Value)
      {
        case CardVisibility.Visible: commandName = COMMANDCODE_VISIBLE; break;
        case CardVisibility.Private: commandName = COMMANDCODE_PRIVATE; break;
        case CardVisibility.Hidden: commandName = COMMANDCODE_HIDDEN; break;
      }
      commandName = Receiver.GetCommandByKey(commandName).Data.Name;
      MessageContent logContent = new MessageContent(string.Concat("[", playerName, "] ", commandName, " "));
      logContent.Add(CardLogger.EncodeCardSmartName(card));
      Receiver.Console.WriteLog(logContent);
    }
  }

  [Serializable]
  public struct SetCardVisibilityArguments
  {
    public List<string> Keys { get; set; }
    public CardVisibility Visibility { get; set; }
  }
}
