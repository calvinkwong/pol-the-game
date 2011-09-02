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
using PoL.Server.DataContracts;

namespace PoL.Server
{
  [ServiceContract(CallbackContract = typeof(IPoLServerCallback), SessionMode = SessionMode.Allowed)]
  public interface IPoLServer
  {
    [OperationContract]
    EnterLobbyResponse EnterLobby(EnterLobbyRequest request);

    [OperationContract]
    GetAllRoomsResponse GetAllRooms(GetAllRoomsRequest request);

    [OperationContract]
    CreateRoomResponse CreateRoom(CreateRoomRequest request);

    [OperationContract]
    DeleteRoomResponse DeleteRoom(DeleteRoomRequest request);

    [OperationContract]
    JoinRoomResponse JoinRoom(JoinRoomRequest request);

    [OperationContract]
    LeaveRoomResponse LeaveRoom(LeaveRoomRequest request);

    [OperationContract(IsOneWay = true)]
    void Chat(ChatRequest request);
  }

  [ServiceContract]
  public interface IPoLServerCallback
  {
    [OperationContract(IsOneWay = true)]
    void RoomCreated(GameRoom gameRoom);

    [OperationContract(IsOneWay = true)]
    void RoomDeleted(string name);

    [OperationContract(IsOneWay = true)]
    void PlayerConnected(Player player);

    [OperationContract(IsOneWay = true)]
    void PlayerDisconnected(string name);

    [OperationContract(IsOneWay = true)]
    void PlayerJoined(string name);

    [OperationContract(IsOneWay = true)]
    void PlayerLeft(string name);

    [OperationContract(IsOneWay = true)]
    void Chat(string player, string message);

    [OperationContract(IsOneWay = true)]
    void SendMessage(byte[] message);

    [OperationContract(IsOneWay = true)]
    void Disconnect();
  } 
}
