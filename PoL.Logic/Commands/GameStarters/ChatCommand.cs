﻿/*
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
using PoL.Models.GameStarters;

namespace PoL.Logic.Commands.GameStarters
{
  [Serializable]
  public class ChatCommand : NetCommand<IGameStarterModel>, ICommand
  {
    public ChatArguments Arguments { get; set; }

    public ChatCommand(IGameStarterModel consoleContainer)
      : base(consoleContainer)
    {
    }

    public override void Execute()
    {
      Receiver.Console.WriteChat(string.Concat("[", Receiver.GetPlayerNickName(Invoker), "] ", Arguments.Text));
    }
  }

  [Serializable]
  public struct ChatArguments
  {
    public string Text { get; set; }
  }
}