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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;

namespace PoL.Server
{
  public partial class MainForm : Form, IPoLServerCallback
  {
    ServiceHost host;
    public MainForm()
    {
      InitializeComponent();
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
      if(host != null)
        host.Close();
      host = new ServiceHost(typeof(PoLServer));
      host.Open();
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
      host.Close();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      var channelFactory = new DuplexChannelFactory<IPoLServer>(new InstanceContext(this), "pol");
      var clientChannel = channelFactory.CreateChannel();

      var enterLobbyReq = new DataContracts.EnterLobbyRequest();
      enterLobbyReq.Player = new DataContracts.Player();
      enterLobbyReq.Player.Name = "Pippo";
      var enterLobbyResp = clientChannel.EnterLobby(enterLobbyReq);

      var createroomReq = new DataContracts.CreateRoomRequest();
      createroomReq.GameRoom = new DataContracts.GameRoom();
      createroomReq.GameRoom.Name = "Room1";
      createroomReq.GameRoom.Description = "desc Room1";
      var createroomResp = clientChannel.CreateRoom(createroomReq);
      createroomReq = new DataContracts.CreateRoomRequest();
      createroomReq.GameRoom = new DataContracts.GameRoom();
      createroomReq.GameRoom.Name = "Room2";
      createroomReq.GameRoom.Description = "desc Room2";
      createroomResp = clientChannel.CreateRoom(createroomReq);
      var getallroomsReq = new DataContracts.GetAllRoomsRequest();
      var getallroomsResp = clientChannel.GetAllRooms(getallroomsReq);
    }

    public void RoomCreated(DataContracts.GameRoom gameRoom)
    {
    }

    public void RoomDeleted(string name)
    {
    }

    public void PlayerConnected(DataContracts.Player player)
    {
    }

    public void PlayerDisconnected(string name)
    {
    }

    public void PlayerJoined(string name)
    {
    }

    public void PlayerLeft(string name)
    {
    }

    public void Chat(string player, string message)
    {
    }

    public void SendMessage(byte[] message)
    {
    }

    public void Disconnect()
    {
    }
  }
}
