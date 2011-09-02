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

using Patterns;
using PoL.Models;
using PoL.Common;
using Patterns.Command;
using PoL.Models.Game;
using Patterns.ComponentModel;

namespace PoL.Logic.Commands.Game
{
  [Serializable]
  public class ShuffleSectorCommand : GameCommand, IUndoableCommand
  {
    public const string COMMANDCODE = "SHUFFLE_SECTOR";

    MoaRNGSeed seed = new MoaRNGSeed();
    
    List<Model> oldList;

    public ShuffleSectorArguments Arguments { get; set; }

    public ShuffleSectorCommand(GameModel game)
      : base(game)
    {
    }

    public ShuffleSectorCommand()
      : this(null)
    {
    }

    public override void Execute()
    {
      SectorModel sector = Receiver.GetSectorByKey(Arguments.SectorKey);
      oldList = sector.Cards.ToList();

      sector.Cards.SuspendChangeNotifications();
      try
      {
        sector.Cards.Shuffle(seed);
      }
      finally
      {
        sector.Cards.ResumeChangeNotifications();
      }

      Log(sector);
    }

    public void Undo()
    {
      SectorModel sector = Receiver.GetSectorByKey(Arguments.SectorKey);
      sector.Cards.SuspendChangeNotifications();
      try
      {
        sector.Cards.Clear();
        sector.Cards.AddRange(oldList);
      }
      finally
      {
        sector.Cards.ResumeChangeNotifications();
      }
    }

    void Log(SectorModel sector)
    {
      string playerName = Receiver.GetPlayerByKey(Invoker).Info.NickName;
      string commandName = Receiver.GetCommandByKey(COMMANDCODE).Data.Name;
      Receiver.Console.WriteLog(string.Concat(
        "[", playerName, "] ", commandName, " ", sector.Data.Name));
    }
  }

  [Serializable]
  public struct ShuffleSectorArguments
  {
    public string SectorKey { get; set; }
  }
}
