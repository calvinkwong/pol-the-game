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

using PoL.Models.Game;
using Patterns.Command;
using PoL.Common;
using Patterns;

namespace PoL.Logic.Commands.Game
{
  [Serializable]
  public class RotateSectorCardsCommand : GameCommand, IUndoableCommand
  {
    public const string COMMANDCODE = "ROTATE_ALL_CARDS";

    Dictionary<string, bool> oldRotationStates = new Dictionary<string, bool>();

    public RotateSectorCardsArguments Arguments { get; set; }

    public RotateSectorCardsCommand(GameModel game)
      : base(game)
    {
    }

    public RotateSectorCardsCommand()
      : this(null)
    {
    }

    public override void Execute()
    {
      oldRotationStates.Clear();
      SectorModel sector = Receiver.GetSectorByKey(Arguments.SectorKey);
      foreach(CardModel card in sector.Cards.Cast<CardModel>())
      {
        oldRotationStates.Add(card.Key, card.Rotated.Value);
        if(!card.Locked.Value)
          card.Rotated.Value = false;
      }

      Log(sector);
    }

    public void Undo()
    {
      SectorModel sector = Receiver.GetSectorByKey(Arguments.SectorKey);
      foreach(CardModel card in sector.Cards.Cast<CardModel>())
        card.Rotated.Value = oldRotationStates[card.Key];
    }

    void Log(SectorModel sector)
    {
      string playerName = Receiver.GetPlayerByKey(Invoker).Info.NickName;
      string commandName = Receiver.GetCommandByKey(COMMANDCODE).Data.Name;
      Receiver.Console.WriteLog(string.Concat(
        "[", playerName, "] ",
        commandName, " (", sector.Data.Name ,")"));
    }
  }

  [Serializable]
  public struct RotateSectorCardsArguments
  {
    public string SectorKey { get; set; }
  }
}
