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
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Patterns.Command
{
  public class CommandHandler
  {
    Stack<IUndoableCommand> commandHistory;
    Stack<IUndoableCommand> undoneCommands;

    public event EventHandler CommandHistoryChanged;
    public event BeforeExecuteEventHandler BeforeExecute;
    public event BeforeUndoEventHandler BeforeUndo;
    public event BeforeUndoEventHandler BeforeRedo;

    public CommandHandler()
    {
      commandHistory = new Stack<IUndoableCommand>();
      undoneCommands = new Stack<IUndoableCommand>();
    }

    public void Execute(ICommand command)
    {
      BeforeExecuteEventArgs args = new BeforeExecuteEventArgs() { Cancel = false, Command = command };
      OnBeforeExecute(args);
      if(!args.Cancel)
      {
        command.Execute();
        if(command is IUndoableCommand)
        {
          commandHistory.Push((IUndoableCommand)command);
          undoneCommands.Clear();
          OnCommandHistoryChanged();
        }
      }
    }

    public void Undo()
    {
      if(!CanUndo)
        throw new CommandHistoryEmptyException("Nothing to undo.");
      IUndoableCommand command = commandHistory.Peek();
      BeforeUndoEventArgs args = new BeforeUndoEventArgs() { Cancel = false, Command = command };
      OnBeforeUndo(args);
      if(!args.Cancel)
      {
        command.Undo();
        undoneCommands.Push(commandHistory.Pop());
        OnCommandHistoryChanged();
      }
    }

    public void Redo()
    {
      if(!CanRedo)
        throw new CommandHistoryEmptyException("Nothing to redo.");
      IUndoableCommand command = undoneCommands.Peek();
      BeforeUndoEventArgs args = new BeforeUndoEventArgs() { Cancel = false, Command = command };
      OnBeforeRedo(args);
      if(!args.Cancel)
      {
        command.Execute();
        commandHistory.Push(undoneCommands.Pop());
        OnCommandHistoryChanged();
      }
    }

    public bool CanUndo
    {
      get { return commandHistory.Count > 0; }
    }

    public bool CanRedo
    {
      get { return undoneCommands.Count > 0; }
    }

    public IUndoableCommand LastDoneCommand
    {
      get { return commandHistory.Peek(); }
    }

    public List<IUndoableCommand> GetDoneCommands()
    {
      return GetCommands(commandHistory, -1);
    }

    public List<IUndoableCommand> GetDoneCommands(int count)
    {
      return GetCommands(commandHistory, count);
    }

    public IUndoableCommand LastUndoneCommand
    {
      get { return undoneCommands.Peek(); }
    }

    public List<IUndoableCommand> GetUndoneCommands()
    {
      return GetCommands(undoneCommands, -1);
    }

    public List<IUndoableCommand> GetUndoneCommands(int count)
    {
      return GetCommands(undoneCommands, count);
    }

    List<IUndoableCommand> GetCommands(Stack<IUndoableCommand> commands, int count)
    {
      List<IUndoableCommand> items = new List<IUndoableCommand>();
      if(count < 0)
        count = items.Count;
      IEnumerator<IUndoableCommand> enumerator = commands.GetEnumerator();
      for(int i = 0; i < count && enumerator.MoveNext(); i++)
        items.Add(enumerator.Current);
      return items;
    }

    protected virtual void OnCommandHistoryChanged()
    {
      if(CommandHistoryChanged != null)
        CommandHistoryChanged(this, EventArgs.Empty);
    }

    protected virtual void OnBeforeExecute(BeforeExecuteEventArgs e)
    {
      if(BeforeExecute != null)
        BeforeExecute(this, e);
    }

    protected virtual void OnBeforeUndo(BeforeUndoEventArgs e)
    {
      if(BeforeUndo != null)
        BeforeUndo(this, e);
    }

    protected virtual void OnBeforeRedo(BeforeUndoEventArgs e)
    {
      if(BeforeRedo != null)
        BeforeRedo(this, e);
    }
  }

  public class CommandException : ApplicationException
  {
    public CommandException(string message)
      : base(message) { }
  }

  public class CommandHistoryEmptyException : CommandException
  {
    public CommandHistoryEmptyException(string message)
      : base(message) { }
  }
}
