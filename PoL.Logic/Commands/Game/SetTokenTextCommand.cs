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
  public class SetTokenTextCommand : GameCommand, IUndoableCommand
  {
    public const string COMMANDCODE = "SET_TOKEN_TEXT";

    string oldText;

    public SetTokenTextArguments Arguments { get; set; }

    public SetTokenTextCommand(GameModel game)
      : base(game)
    {
    }

    public SetTokenTextCommand()
      : this(null)
    {
    }

    public override void Execute()
    {
      TokenModel token = Receiver.GetTokenByKey(Arguments.Key);
      if(token != null)
      {
        oldText = token.Text.Value;
        token.Text.Value = Arguments.Text;

        Log(Arguments.Text);
      }
    }

    public void Undo()
    {
      TokenModel token = Receiver.GetTokenByKey(Arguments.Key);
      if(token != null)
        token.Text.Value = oldText;
    }

    void Log(string text)
    {
      string playerName = Receiver.GetPlayerByKey(Invoker).Info.NickName;
      string commandName = Receiver.GetCommandByKey(COMMANDCODE).Data.Name;
      Receiver.Console.WriteLog(string.Concat(
        "[", playerName, "] ",
        commandName, " (", text, ")"
        ));
    }
  }

  [Serializable]
  public struct SetTokenTextArguments
  {
    public string Key;
    public string Text;
  }
}
