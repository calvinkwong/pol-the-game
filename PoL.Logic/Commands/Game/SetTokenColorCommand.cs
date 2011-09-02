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
  public class SetTokenColorCommand : GameCommand, IUndoableCommand
  {
    public const string COMMANDCODE = "SET_TOKEN_COLOR";

    TokenColor oldColor;

    public SetTokenColorArguments Arguments { get; set; }

    public SetTokenColorCommand(GameModel game)
      : base(game)
    {
    }

    public SetTokenColorCommand()
      : this(null)
    {
    }

    public override void Execute()
    {
      TokenModel token = Receiver.GetTokenByKey(Arguments.Key);
      if(token != null)
      {
        oldColor = token.Color.Value;
        token.Color.Value = Arguments.Color;

        Log(Arguments.Color);
      }
    }

    public void Undo()
    {
      TokenModel token = Receiver.GetTokenByKey(Arguments.Key);
      if(token != null)
        token.Color.Value = oldColor;
    }

    void Log(TokenColor color)
    {
      string playerName = Receiver.GetPlayerByKey(Invoker).Info.NickName;
      string commandName = Receiver.GetCommandByKey(COMMANDCODE).Data.Name;
      Receiver.Console.WriteLog(string.Concat(
        "[", playerName, "] ",
        commandName, " (", color, ")"
        ));
    }
  }

  [Serializable]
  public struct SetTokenColorArguments
  {
    public string Key { get; set; }
    public TokenColor Color { get; set; }
  }
}
