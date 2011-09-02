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
  public class SetCardsCustomCharacteristicsCommand : GameCommand, IUndoableCommand
  {
    public const string COMMANDCODE = "SET_CARD_CHARACTERISTICS";

    [NonSerialized]
    List<string> oldCharacteristics;

    public SetCardCharacteristicsArguments Arguments { get; set; }

    public SetCardsCustomCharacteristicsCommand(GameModel game)
      : base(game)
    {
    }

    public SetCardsCustomCharacteristicsCommand()
      : this(null)
    {
    }

    public override void Execute()
    {
      List<CardModel> cards = Arguments.CardKeys.Select(k => Receiver.GetCardByKey(k)).ToList();
      oldCharacteristics = cards.Select(c => c.CustomCharacteristics.Value).ToList();
      foreach(CardModel card in cards)
      {
        if(
          Arguments.IncludeCardsWithEmtpyCharacteristics || 
          (!string.IsNullOrEmpty(card.Data.Characteristics) || !string.IsNullOrEmpty(card.CustomCharacteristics.Value))
          )
        {
          StringBuilder newCharacteristics = new StringBuilder(Arguments.Characteristics);
          if(Arguments.ApplyNumericalIncrement)
          {
            newCharacteristics.Length = 0;
            string[] newValues = Arguments.Characteristics.Split('/');
            string startCharacteristics = string.IsNullOrEmpty(card.CustomCharacteristics.Value) ? card.Data.Characteristics : card.CustomCharacteristics.Value;
            if(string.IsNullOrEmpty(startCharacteristics))
              startCharacteristics = "0/0";
            string[] oldValues = startCharacteristics.Split('/');
            for(int i = 0; i < newValues.Length; i++)
            {
              int finalVal = 0;
              int newVal;
              if(int.TryParse(newValues[i], out newVal))
              {
                int oldVal;
                if(i < oldValues.Length && int.TryParse(oldValues[i], out oldVal))
                {
                  finalVal = oldVal + newVal;
                } 
              }
              if(i > 0)
                newCharacteristics.Append("/");
              newCharacteristics.Append(finalVal);
            }
          }
          card.CustomCharacteristics.Value = newCharacteristics.ToString();
          Log(card);
        }
      }
    }

    public void Undo()
    {
      List<CardModel> cards = Arguments.CardKeys.Select(k => Receiver.GetCardByKey(k)).ToList();
      for(int i = 0; i < cards.Count; i++)
      {
        if(Arguments.IncludeCardsWithEmtpyCharacteristics ||
          (!string.IsNullOrEmpty(cards[i].Data.Characteristics) || !string.IsNullOrEmpty(cards[i].CustomCharacteristics.Value))
          )
        {
          cards[i].CustomCharacteristics.Value = oldCharacteristics[i];
        }
      }
    }

    void Log(CardModel card)
    {
      string playerName = Receiver.GetPlayerByKey(Invoker).Info.NickName;
      string commandName = Receiver.GetCommandByKey(COMMANDCODE).Data.Name;
      MessageContent logContent = new MessageContent(string.Concat("[", playerName, "] ", commandName, " "));
      logContent.Add(CardLogger.EncodeCardSmartName(card));
      logContent.Add(string.Concat(" (", card.CustomCharacteristics.Value, ")"));
      Receiver.Console.WriteLog(logContent);
    }
  }

  [Serializable]
  public struct SetCardCharacteristicsArguments
  {
    public List<string> CardKeys { get; set; }
    public string Characteristics { get; set; }
    public bool IncludeCardsWithEmtpyCharacteristics { get; set; }
    public bool ApplyNumericalIncrement { get; set; }
  }
}
