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

using Communication;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;

namespace Patterns.Command
{
  public class NetCommandHandler<TReceiver> : IDisposable
  {
    public event Action<NetCommand<TReceiver>> BeforeReceivedCommandHandling;
    public event BeforeExecuteEventHandler BeforeExecute;
    public event BeforeUndoEventHandler BeforeUndo;
    public event BeforeUndoEventHandler BeforeRedo;
    public event Action<Exception> CommandError;

    readonly TReceiver receiver;
    readonly string invoker;
    readonly CommandHandler commandHandler;
    Dictionary<ServiceNetClient, string> channels = new Dictionary<ServiceNetClient, string>();
    object syncObject = new object();
    Queue<NetCommandQueueItem<TReceiver>> commandQueue = new Queue<NetCommandQueueItem<TReceiver>>();

    bool isDisposed = false;

    public event Action<string> ClientDisconnected;

    public NetCommandHandler(TReceiver receiver, string invoker, CommandHandler commandHandler)
    {
      this.receiver = receiver;
      this.invoker = invoker;
      this.commandHandler = commandHandler;

      BackgroundWorker worker = new BackgroundWorker();
      worker.DoWork += new DoWorkEventHandler(worker_DoWork);
      worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
      worker.RunWorkerAsync();
    }

    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
      CommandExecutorThread();
    }

    void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if(e.Error != null)
        throw e.Error;
    }
 
    public NetCommandHandler(TReceiver receiver, string invoker)
      : this(receiver, invoker, new CommandHandler())
    {
    }

    public void AddChannel(ServiceNetClient channel, string name)
    {
      lock(syncObject)
        channels.Add(channel, name);
    }

    public void RemoveChannel(ServiceNetClient channel)
    {
      lock(syncObject)
        channels.Remove(channel);
    }

    public bool IsDisposed
    {
      get { return isDisposed; }
    }

    public string Invoker
    {
      get { return invoker; }
    }

    public TReceiver Receiver
    {
      get { return receiver; }
    }

    public CommandHandler BaseCommandHandler
    {
      get { return commandHandler; }
    }

    public void Execute(NetCommand<TReceiver> netCmd)
    {
      //lock(syncObject)
      //  commandQueue.Enqueue(new NetCommandQueueItem<TReceiver>() { Command = netCmd, Source = CommandSource.Local });
      ExecuteQueuedItem(new NetCommandQueueItem<TReceiver>()
      {
        Command = netCmd,
        Source = CommandSource.Local,
      });
    }

    public void Undo()
    {
      NetUndoCommand<TReceiver> undoCommand = new NetUndoCommand<TReceiver>(receiver);
      //lock(syncObject)
      //  commandQueue.Enqueue(new NetCommandQueueItem<TReceiver>() { Command = undoCommand, Source = CommandSource.Local });
      ExecuteQueuedItem(new NetCommandQueueItem<TReceiver>()
      {
        Command = undoCommand,
        Source = CommandSource.Local,
      });
    }

    public void Redo()
    {
      NetRedoCommand<TReceiver> redoCommand = new NetRedoCommand<TReceiver>(receiver);
      //lock(syncObject)
      //  commandQueue.Enqueue(new NetCommandQueueItem<TReceiver>() { Command = redoCommand, Source = CommandSource.Local });
      ExecuteQueuedItem(new NetCommandQueueItem<TReceiver>()
      {
        Command = redoCommand,
        Source = CommandSource.Local,
      });
    }

    public void Dispose()
    {
      lock(syncObject)
        isDisposed = true;
    }    

    void CommandExecutorThread()
    {
      bool end = false;
      while(!end)
      {
        NetCommandQueueItem<TReceiver> queueItem = null;
        Dictionary<ServiceNetClient, string> invalidClients = null;
        lock(syncObject)
        {
          invalidClients = CheckClients();

          if(commandQueue.Count > 0)
            queueItem = commandQueue.Dequeue();
          else if(isDisposed)
            end = true;
        } 

        if(!end)
        {
          foreach(var invalidNetClientEntry in invalidClients)
            OnClientDisconnected(invalidNetClientEntry.Value);
          if(queueItem != null)
          {
            try
            {
              ExecuteQueuedItem(queueItem);
            }
            catch(Exception ex)
            {
              OnCommandError(ex);
            }
          }
        }
        Thread.Sleep(10);
      }
    }

    Dictionary<ServiceNetClient, string> CheckClients()
    {
      // enqueue remote messages looping on clients
      // disconnected clients are removed
      Dictionary<ServiceNetClient, string> invalidClients = new Dictionary<ServiceNetClient, string>();
      foreach(var netClientEntry in channels)
      {
        if(!netClientEntry.Key.Connected)
          invalidClients.Add(netClientEntry.Key, netClientEntry.Value);
        else
        {
          INetMessage receivedMessage = null;
          while((receivedMessage = netClientEntry.Key.DequeueMessage()) != null)
            if(receivedMessage is NetCommand<TReceiver>)
              commandQueue.Enqueue(new NetCommandQueueItem<TReceiver>()
              {
                Command = receivedMessage as NetCommand<TReceiver>,
                Source = CommandSource.Remote,
                SourceClient = netClientEntry.Key
              });
        }
      }
      foreach(var client in invalidClients)
        channels.Remove(client.Key);
      return invalidClients;
    }

    void ExecuteQueuedItem(NetCommandQueueItem<TReceiver> queueItem)
    {
      switch(queueItem.Source)
      {
        case CommandSource.Local:
          {
            queueItem.Command.Invoker = this.invoker;
            if(queueItem.Command is NetUndoCommand<TReceiver>)
            {
              BeforeUndoEventArgs args = new BeforeUndoEventArgs() { Cancel = false, Command = commandHandler.LastDoneCommand };
              OnBeforeUndo(args);
              if(!args.Cancel)
              {
                commandHandler.Undo();
                lock(syncObject)
                {
                  foreach(var client in channels.Keys)
                    client.SendMessage(queueItem.Command);
                }
              }
            }
            else if(queueItem.Command is NetRedoCommand<TReceiver>)
            {
              BeforeUndoEventArgs args = new BeforeUndoEventArgs() { Cancel = false, Command = commandHandler.LastUndoneCommand };
              OnBeforeRedo(args);
              if(!args.Cancel)
              {
                commandHandler.Redo();
                lock(syncObject)
                {
                  foreach(var client in channels.Keys)
                    client.SendMessage(queueItem.Command);
                }
              }
            }
            else
            {
              BeforeExecuteEventArgs args = new BeforeExecuteEventArgs() { Cancel = false, Command = queueItem.Command };
              OnBeforeExecute(args);
              if(!args.Cancel)
              {
                commandHandler.Execute(queueItem.Command);
                lock(syncObject)
                {
                  foreach(var client in channels.Keys)
                    client.SendMessage(queueItem.Command);
                }
              }
            }
          }
          break;
        case CommandSource.Remote:
          {
            OnBeforeReceivedCommandHandling(queueItem.Command);
            if(queueItem.Command is NetUndoCommand<TReceiver>)
              commandHandler.Undo();
            else if(queueItem.Command is NetRedoCommand<TReceiver>)
              commandHandler.Redo();
            else
            {
              queueItem.Command.Bind(receiver);
              commandHandler.Execute(queueItem.Command);
            }

            // send message to other clients
            lock(syncObject)
            {
              foreach(var otherClient in channels.Keys.Where(e => !e.Equals(queueItem.SourceClient)))
                otherClient.SendMessage(queueItem.Command);
            }
          }
          break;
      }
    }

    protected virtual void OnBeforeReceivedCommandHandling(NetCommand<TReceiver> netCommand)
    {
      if(BeforeReceivedCommandHandling != null)
        BeforeReceivedCommandHandling(netCommand);
    }

    protected virtual void OnClientDisconnected(string name)
    {
      if(ClientDisconnected != null)
        ClientDisconnected(name);
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

    protected virtual void OnCommandError(Exception e)
    {
      if(CommandError != null)
        CommandError(e);
    }
 }

  class NetCommandQueueItem<TReceiver>
  {
    public NetCommand<TReceiver> Command { get; set; }
    public CommandSource Source { get; set; }
    public ServiceNetClient SourceClient { get; set; }
  }

  enum CommandSource
  {
    Local,
    Remote,
  }
}