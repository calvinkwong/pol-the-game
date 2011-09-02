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
  public class AddTokenCommand : GameCommand, IUndoableCommand
  {
    public const string COMMANDCODE = "ADD_TOKEN";

    List<string> keysArchive;

    [NonSerialized]
    List<CardModel> cards;
    [NonSerialized]
    List<string> tokenKeys;

    public AddTokenArguments Arguments { get; set; }

    public AddTokenCommand(GameModel game)
      : base(game)
    {
      keysArchive = Enumerable.Range(0, 100).Select(e => Guid.NewGuid().ToString()).ToList();
    }

    public AddTokenCommand()
      : this(null)
    {
    }

    public override void Execute()
    {
      cards = Arguments.CardKeys.Select(e => Receiver.GetCardByKey(e)).Where(e => e != null).ToList();
      tokenKeys = keysArchive.Take(cards.Count).ToList();
      for(int i = 0; i < cards.Count; i++)
      {
        string tokenKey = keysArchive[i];
        tokenKeys.Add(tokenKey);
        TokenModel token = new TokenModel(tokenKey);
        token.Text.Value = Arguments.Text;
        token.Amount.Value = Arguments.Amount;
        token.Color.Value = Arguments.Color;
        cards[i].Tokens.Add(token);
        Log(cards[i]);
      }
    }

    public void Undo()
    {
      for(int i = 0; i < cards.Count; i++)
        cards[i].Tokens.Remove(cards[i].Tokens.Single(e => e.Key == tokenKeys[i]));
    }

    void Log(CardModel card)
    {
      string playerName = Receiver.GetPlayerByKey(Invoker).Info.NickName;
      string commandName = Receiver.GetCommandByKey(COMMANDCODE).Data.Name;
      MessageContent logContent = new MessageContent(string.Concat("[", playerName, "] ", commandName, " ("));
      logContent.Add(CardLogger.EncodeCardSmartName(card));
      logContent.Add(")");
      Receiver.Console.WriteLog(logContent);
    }
  }

  [Serializable]
  public struct AddTokenArguments
  {
    public List<string> CardKeys { get; set; }
    public int Amount { get; set; }
    public string Text { get; set; }
    public TokenColor Color { get; set; }
  }
}
