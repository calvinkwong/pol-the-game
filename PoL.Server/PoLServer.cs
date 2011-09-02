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
using System.ServiceModel;
using System.Threading;
using PoL.Server.DataContracts;
using dm = PoL.Server.DomainEntities;
using Communication;

namespace PoL.Server
{
  [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
  public class PoLServer : IPoLServer, INetMessageService
  {
    ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();

    dm.GameLobby gameLobby = new dm.GameLobby();

    public EnterLobbyResponse EnterLobby(EnterLobbyRequest request)
    {
      EnterLobbyResponse response = new EnterLobbyResponse();

      rwLock.EnterWriteLock();
      try
      {
        response.Success = !gameLobby.Players.ContainsKey(request.Player.Name);
        if(response.Success)
        {
          IPoLServerCallback channel = OperationContext.Current.GetCallbackChannel<IPoLServerCallback>();
          ((IContextChannel)channel).Closed += new EventHandler(channel_Closed);
          gameLobby.Players.Add(request.Player.Name, new dm.Player(request.Player.Name, channel));
        }
      }
      finally
      {
        rwLock.ExitWriteLock();
      }

      return response;
    }

    public GetAllRoomsResponse GetAllRooms(GetAllRoomsRequest request)
    {
      GetAllRoomsResponse response = new GetAllRoomsResponse();

      response.RoomList = new List<GameRoom>();
      rwLock.EnterReadLock();
      try
      {
        foreach(var room in gameLobby.Rooms.Values)
          response.RoomList.Add(new GameRoom() { Name = room.Name, Description = room.Description });
      }
      finally
      {
        rwLock.ExitReadLock();
      }

      return response;
    }

    public CreateRoomResponse CreateRoom(CreateRoomRequest request)
    {
      CreateRoomResponse response = new CreateRoomResponse();

      rwLock.EnterWriteLock();
      try
      {
        response.Success = !gameLobby.Rooms.ContainsKey(request.GameRoom.Name);
        if(response.Success)
        {
          IPoLServerCallback channel = OperationContext.Current.GetCallbackChannel<IPoLServerCallback>();
          var ply = gameLobby.GetPlayerByChannel(channel);
          gameLobby.Rooms.Add(request.GameRoom.Name, new dm.GameRoom(request.GameRoom.Name, request.GameRoom.Description, ply));
        }
      }
      finally
      {
        rwLock.ExitWriteLock();
      }
      
      return response;
    }

    public DeleteRoomResponse DeleteRoom(DeleteRoomRequest request)
    {
      DeleteRoomResponse response = new DeleteRoomResponse();

      rwLock.EnterWriteLock();
      try
      {
        response.Success = gameLobby.Rooms.ContainsKey(request.Name);
        if(response.Success)
        {
          gameLobby.Rooms.Remove(request.Name);
        }
      }
      finally
      {
        rwLock.ExitWriteLock();
      }

      return response;
    }

    public JoinRoomResponse JoinRoom(JoinRoomRequest request)
    {
      JoinRoomResponse response = new JoinRoomResponse();

      rwLock.EnterWriteLock();
      try
      {
        IPoLServerCallback channel = OperationContext.Current.GetCallbackChannel<IPoLServerCallback>();
        var ply = gameLobby.GetPlayerByChannel(channel);
        response.Success = gameLobby.Rooms.ContainsKey(request.Name) &&
          !gameLobby.Rooms.Any(r => r.Value.Owner.Equals(ply) && !gameLobby.Rooms.Any(p => p.Value.Players.Contains(ply)));
        if(response.Success)
        {
          gameLobby.Rooms[request.Name].Players.Add(ply);
        }
      }
      finally
      {
        rwLock.ExitWriteLock();
      }

      return response;
    }

    public LeaveRoomResponse LeaveRoom(LeaveRoomRequest request)
    {
      LeaveRoomResponse response = new LeaveRoomResponse();

      rwLock.EnterWriteLock();
      try
      {
        IPoLServerCallback channel = OperationContext.Current.GetCallbackChannel<IPoLServerCallback>();
        var ply = gameLobby.GetPlayerByChannel(channel);
        var room = gameLobby.Rooms.Values.FirstOrDefault(r => r.Players.Contains(ply));
        response.Success = room != null;
        if(response.Success)
        {
          room.Players.Remove(ply);
        }
      }
      finally
      {
        rwLock.ExitWriteLock();
      }

      return response;
    }

    public void Chat(ChatRequest request)
    {
      rwLock.EnterReadLock();
      try
      {
        IPoLServerCallback channel = OperationContext.Current.GetCallbackChannel<IPoLServerCallback>();
        var ply = gameLobby.GetPlayerByChannel(channel);
        var room = gameLobby.Rooms.Values.FirstOrDefault(r => r.Players.Contains(ply));
        foreach(var roomChannel in room.Players.Select(p => p.Channel))
          roomChannel.Chat(ply.Name, request.Message);
      }
      finally
      {
        rwLock.ExitReadLock();
      }
    }

    public void Subscribe()
    {
    }

    public void SendMessage(byte[] message)
    {
      rwLock.EnterReadLock();
      try
      {
        IPoLServerCallback channel = OperationContext.Current.GetCallbackChannel<IPoLServerCallback>();
        var ply = gameLobby.GetPlayerByChannel(channel);
        var room = gameLobby.Rooms.Values.FirstOrDefault(r => r.Players.Contains(ply));
        foreach(var roomChannel in room.Players.Select(p => p.Channel))
          roomChannel.SendMessage(message);
      }
      finally
      {
        rwLock.ExitReadLock();
      }
    }

    void channel_Closed(object sender, EventArgs e)
    {
      rwLock.EnterWriteLock();
      try
      {
        IPoLServerCallback channel = (IPoLServerCallback)sender;
        var ply = gameLobby.GetPlayerByChannel(channel);
        gameLobby.Players.Remove(ply.Name);
        foreach(var otherChannel in gameLobby.Players.Values.Select(p => p.Channel))
          otherChannel.PlayerDisconnected(ply.Name);
      }
      finally
      {
        rwLock.ExitWriteLock();
      }
    }
  }
}
