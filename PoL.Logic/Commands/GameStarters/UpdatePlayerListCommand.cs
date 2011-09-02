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

using PoL.Models.GameStarters;
using Patterns.Command;
using PoL.Common;
using PoL.Services;
using PoL.Models;

namespace PoL.Logic.Commands.GameStarters
{
  [Serializable]
  public class UpdatePlayerListCommand : NetCommand<IGameStarterModel>, ICommand
  {
    public UpdatePlayerListArguments Arguments { get; set; }

    public UpdatePlayerListCommand(IGameStarterModel consoleContainer)
      : base(consoleContainer)
    {
    }

    public override void Execute()
    {
      Receiver.Players.Clear();
      foreach(var connectedPlayer in Arguments.AllPlayers)
        Receiver.Players.Add(connectedPlayer);
      Receiver.Console.WriteLine(Arguments.Connected ? MessageCategory.Log : MessageCategory.Warning,
        string.Concat("Player ", Arguments.ConnectedPlayer.NickName, " has ", 
        Arguments.Connected ? "connected" : "disconnected"));
    }
  }

  [Serializable]
  public struct UpdatePlayerListArguments
  {
    public List<PlayerAccountData> AllPlayers { get; set; }
    public PlayerInfo ConnectedPlayer { get; set; }
    public bool Connected { get; set; }
  }
}
