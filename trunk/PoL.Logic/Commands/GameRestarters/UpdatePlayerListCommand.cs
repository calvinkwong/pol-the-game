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

using PoL.Models.GameRestarters;
using Patterns.Command;
using PoL.Common;
using PoL.Services;
using PoL.Models;

namespace PoL.Logic.Commands.GameRestarters
{
  [Serializable]
  public class UpdatePlayerListCommand : NetCommand<IGameRestarterModel>, ICommand
  {
    public UpdatePlayerListArguments Arguments { get; set; }

    public UpdatePlayerListCommand(IGameRestarterModel model)
      : base(model)
    {
    }

    public override void Execute()
    {
      foreach(var player in Arguments.Players)
      {
        if(Arguments.Connected)
          Receiver.Players.Add(new PlayerModel(player.Info, player.Deck));
        else
          Receiver.Players.Remove(Receiver.Players.Single(e => e.Key == player.Info.NickName));
        Receiver.Console.WriteLine(Arguments.Connected ? MessageCategory.Log : MessageCategory.Warning,
          string.Concat("Player ", player.Info.NickName, " has ", 
          Arguments.Connected ? "connected" : "disconnected"));
      }
    }
  }

  [Serializable]
  public struct UpdatePlayerListArguments
  {
    public List<PlayerAccountData> Players { get; set; }
    public bool Connected { get; set; }
  }
}
