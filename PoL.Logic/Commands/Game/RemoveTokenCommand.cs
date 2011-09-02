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
  public class RemoveTokenCommand : GameCommand, IUndoableCommand
  {
    public const string COMMANDCODE = "REMOVE_TOKEN";

    [NonSerialized]
    TokenModel removedToken;
    [NonSerialized]
    CardModel containerCard; 

    public SingleKeyArguments Arguments { get; set; }

    public RemoveTokenCommand(GameModel game)
      : base(game)
    {
    }

    public RemoveTokenCommand()
      : this(null)
    {
    }

    public override void Execute()
    {
      removedToken = Receiver.GetTokenByKey(Arguments.Key);
      if(removedToken != null)
      {
        containerCard = (CardModel)removedToken.Parent;
        containerCard.Tokens.Remove(removedToken);

        Log(containerCard);

      }
    }

    public void Undo()
    {
      if(containerCard != null && removedToken != null)
        containerCard.Tokens.Add(removedToken);
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
}
