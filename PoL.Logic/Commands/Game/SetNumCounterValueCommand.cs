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
  public class SetNumCounterValueCommand : GameCommand, IUndoableCommand
  {
    public const string COMMANDCODE = "SET_NUMCOUNTER_VALUE";

    int oldValue;

    public SetNumCounterValueArguments Arguments { get; set; }

    public SetNumCounterValueCommand(GameModel game)
      : base(game)
    {
    }

    public SetNumCounterValueCommand()
      : this(null)
    {
    }

    public override void Execute()
    {
      NumCounterModel numCounter = Receiver.GetNumCounterByKey(Arguments.Key);
      if(numCounter != null)
      {
        oldValue = numCounter.Value.Value;
        numCounter.Value.Value = Arguments.Value;

        Log(oldValue, numCounter.Value.Value);
      }
    }

    public void Undo()
    {
      NumCounterModel numCounter = Receiver.GetNumCounterByKey(Arguments.Key);
      if(numCounter != null)
      {
        int from = numCounter.Value.Value;
        numCounter.Value.Value = oldValue;
      }
    }

    void Log(int from, int to)
    {
      string playerName = Receiver.GetPlayerByKey(Invoker).Info.NickName;
      string commandName = Receiver.GetCommandByKey(COMMANDCODE).Data.Name;
      NumCounterModel numCounter = Receiver.GetNumCounterByKey(Arguments.Key);
      Receiver.Console.WriteLog(string.Concat(
         "[", playerName, "] ",
         commandName, " ", numCounter.Data.Name, " (", to, ")"));
    }
  }

  [Serializable]
  public struct SetNumCounterValueArguments
  {
    public string Key;
    public int Value;
  }
}
