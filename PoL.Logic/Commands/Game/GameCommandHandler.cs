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
using PoL.Models.Game;
using Communication;
using PoL.Common;
using PoL.Services;
using System.IO;
using PoL.Configuration;
using System.Diagnostics;

namespace PoL.Logic.Commands.Game
{
  public class GameCommandHandler : NetCommandHandler<GameModel>
  {
    ServicesProvider servicesProvider;

    public GameCommandHandler(GameModel gameModel, string invoker, ServicesProvider servicesProvider)
      : base(gameModel, invoker)
    {
      this.servicesProvider = servicesProvider;
    }

    protected override void OnBeforeExecute(BeforeExecuteEventArgs e)
    {
      var command = e.Command as GameCommand;
      if(command != null)
      {
        LogicHandler.TraceCommand(command);
      }
    }

    protected override void OnBeforeUndo(BeforeUndoEventArgs e)
    {
      var command = e.Command as GameCommand;
      if(command != null)
      {
        LogicHandler.TraceCommand("<Undo />");

        e.Cancel = this.Invoker != command.Invoker;
        if(e.Cancel)
          Receiver.Console.WriteLine(MessageCategory.Warning, servicesProvider.SystemStringsService.GetString("GAME", "MSG_CANT_UNDO_OPPONENT_COMMAND"));
        else
          Receiver.Console.WriteLine(MessageCategory.Warning, servicesProvider.SystemStringsService.GetString("GAME", "MSG_UNDO_COMMAND"));
      }
    }

    protected override void OnBeforeRedo(BeforeUndoEventArgs e)
    {
      var command = e.Command as GameCommand;
      if(command != null)
      {
        LogicHandler.TraceCommand("<Redo />");
      
        e.Cancel = this.Invoker != command.Invoker;
        if(e.Cancel)
          Receiver.Console.WriteLine(MessageCategory.Warning, servicesProvider.SystemStringsService.GetString("GAME", "MSG_CANT_REDO_OPPONENT_COMMAND"));
        else
          Receiver.Console.WriteLine(MessageCategory.Warning, servicesProvider.SystemStringsService.GetString("GAME", "MSG_REDO_COMMAND"));
      }
    }

    protected override void OnBeforeReceivedCommandHandling(NetCommand<GameModel> netCommand)
    {
      if(netCommand is NetUndoCommand<GameModel>)
      {
        LogicHandler.TraceCommand("<Undo />");

        Receiver.Console.WriteLine(MessageCategory.Warning,
          servicesProvider.SystemStringsService.GetString("GAME", "MSG_OPPONENT_UNDO_COMMAND").Replace("#player#",
          Receiver.GetPlayerByKey(netCommand.Invoker).Info.NickName));
      }
      else if(netCommand is NetRedoCommand<GameModel>)
      {
        LogicHandler.TraceCommand("<Redo />");
      
        Receiver.Console.WriteLine(MessageCategory.Warning,
          servicesProvider.SystemStringsService.GetString("GAME", "MSG_OPPONENT_REDO_COMMAND").Replace("#player#",
          Receiver.GetPlayerByKey(netCommand.Invoker).Info.NickName));
      }
      else
      {
        var command = netCommand as GameCommand;
        if(command != null)
        {
          LogicHandler.TraceCommand(command);
        }
      }

      base.OnBeforeReceivedCommandHandling(netCommand);
    }
  }
}
