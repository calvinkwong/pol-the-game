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
using PoL.Models;
using PoL.Common;
using PoL.Models.Game;
using Patterns;

namespace PoL.Logic.Commands.Game
{
  [Serializable]
  public class ThrowDiceCommand : GameCommand, ICommand
  {
    public const string COMMAND_CODE = "THROW_DICE";

    int seed;

    public ThrowDiceArguments Arguments { get; set; }

    public ThrowDiceCommand(GameModel game)
      : base(game)
    {
      seed = DateTime.Now.Millisecond;
    }

    public ThrowDiceCommand()
      : this(null)
    {
    }

    public override void Execute()
    {
      Random rnd = new Random(seed);
      int throwResult = rnd.Next(1, (int)Arguments.DiceType);

      string playerName = Receiver.GetPlayerByKey(Invoker).Info.NickName;
      string commandName = Receiver.GetCommandByKey(COMMAND_CODE).Data.Name;
      Receiver.Console.WriteLog(string.Concat(
        "[", playerName, "] ", 
        commandName, "<", ((int)Arguments.DiceType), ">: ",
        throwResult
        ));
    }
  }

  [Serializable]
  public struct ThrowDiceArguments
  {
    public DiceType DiceType { get; set; }
  }
}
