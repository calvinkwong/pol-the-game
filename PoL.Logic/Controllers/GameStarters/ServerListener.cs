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
using System.Threading;
using PoL.Common;
using PoL.Services;
using PoL.Models.Game;
using PoL.Models;
using System.Security;
using System.ServiceModel;

namespace PoL.Logic.Controllers.GameStarters
{
  public class ServerListener: IDisposable
  {
    NetMessageService netMessageService;
    Dictionary<ServiceNetClient, ServerConnectionMessagesHandler> connections = new Dictionary<ServiceNetClient, ServerConnectionMessagesHandler>();
    object syncObject = new object();
    bool passwordRequired;
    DeckItem deck;
    GameStartMode startMode;
    ServicesProvider servicesProvider;
    bool gameIsRunning = false;

    public event Action<object, ServiceNetClient, PlayerAccountData> PlayerConnected;
    public event Action<object, ServiceNetClient, PlayerInfo> PlayerDisconnected;
    public readonly PlayerInfo Player;

    public ServerListener(PlayerInfo player, ServicesProvider servicesProvider, int port)
    {
      this.Player = player;
      this.servicesProvider = servicesProvider;
      this.netMessageService = new NetMessageService(port);
    }

    public ConsoleModel Console { get; set; }

    public void Start(bool passwordRequired, DeckItem deck, GameStartMode startMode)
    {
      this.startMode = startMode;
      this.passwordRequired = passwordRequired;
      this.deck = deck;
      netMessageService.ClientConnected += new Action<object, ServiceNetClient>(netMessageService_ClientConnected);
      netMessageService.Start();
    }

    public void Stop()
    {
      netMessageService.ClientConnected -= new Action<object, ServiceNetClient>(netMessageService_ClientConnected);
      lock(syncObject)
      {
        foreach(var conn in connections)
        {
          conn.Key.Disconnected -= new EventHandler(client_Disconnected);
          conn.Key.Disconnect();
          conn.Value.Dispose();
        }
        connections.Clear();
      }
      netMessageService.Stop();
    }

    public bool IsStarted
    {
      get { return netMessageService.Started; }
    }

    public bool GameIsRunning
    {
      get { return gameIsRunning; }
      set { gameIsRunning = value; }
    }

    public List<PlayerConnection> PlayerConnections
    {
      get 
      {
        List<PlayerConnection> list = null;
        lock(syncObject)
        {
          list = connections.Select(e => new PlayerConnection() { NetClient = e.Key }).ToList();
        }
        return list;
      }
    }

    public void Dispose()
    {
      netMessageService.Stop();
    }

    void netMessageService_ClientConnected(object sender, ServiceNetClient client)
    {
      using(var connectionMessagesHandler = new ServerConnectionMessagesHandler(client))
      {
        if(!WaitHandshake(connectionMessagesHandler))
        {
          if(Console != null)
            Console.WriteLine(MessageCategory.Warning, "Opponent handshake not received");
        }
        else
        {
          ConnectionResult result;
          string refuseReason;
          ValidatePlayer(connectionMessagesHandler, out result, out refuseReason);
          HandshakeResponse handshakeResponse = new HandshakeResponse()
          {
            Deck = new DeckDataContract(deck),
            PlayerInfo = Player,
            ConnectionResult = result,
          };
          Thread.Sleep(100);
          client.SendMessage(handshakeResponse);
          if(result != ConnectionResult.Accepted)
          {
            if(Console != null)
              Console.WriteLine(MessageCategory.Warning, string.Concat("Player ", connectionMessagesHandler.Handshake.PlayerInfo.NickName, " refused: ", refuseReason));
          }
          else
          {
            if(!WaitPlayerConfirm(connectionMessagesHandler))
            {
              if(Console != null)
                Console.WriteLine(MessageCategory.Warning, string.Concat("Player ", connectionMessagesHandler.Handshake.PlayerInfo.NickName, " hasn't confirmed the connection."));
            }
            else
            {
              client.Disconnected += new EventHandler(client_Disconnected);
              lock(syncObject)
                connections.Add(client, connectionMessagesHandler);
              PlayerAccountData connectedPlayer = new PlayerAccountData()
              {
                Info = connectionMessagesHandler.Handshake.PlayerInfo,
                Deck = new DeckItem(connectionMessagesHandler.Handshake.Deck),
                Password = connectionMessagesHandler.Handshake.Password
              };
              OnPlayerConnected(client, connectedPlayer);
            }
          }
        }
      }
    }

    void ValidatePlayer(ServerConnectionMessagesHandler receiver, out ConnectionResult result, out string refuseReason)
    {
      refuseReason = string.Empty;
      result = ConnectionResult.Accepted;
      Version clientVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
      if(!new Version(receiver.Handshake.ClientVersion).Equals(clientVersion))
      {
        result = ConnectionResult.VersionMismatch;
        refuseReason = servicesProvider.SystemStringsService.GetString("NEW_SERVER_GAME_DIALOG", "MSG_CONNECTIONREFUSED_VERSIONMISMATCH");
      }
      else if(gameIsRunning)
      {
        result = ConnectionResult.GameIsRunning;
        refuseReason = servicesProvider.SystemStringsService.GetString("NEW_SERVER_GAME_DIALOG", "MSG_CONNECTIONREFUSED_GAMEISRUNNING");
      }
      else if(receiver.Handshake.StartMode != this.startMode)
      {
        result = ConnectionResult.InvalidStartMode;
        refuseReason = servicesProvider.SystemStringsService.GetString("NEW_SERVER_GAME_DIALOG", "MSG_CONNECTIONREFUSED_INVALIDSTARTMODE");
      }
      else if(receiver.Handshake.PlayerInfo.NickName == Player.NickName ||
        connections.Any(e => e.Value.Handshake.PlayerInfo.NickName == receiver.Handshake.PlayerInfo.NickName))
      {
        result = ConnectionResult.NicknameDuplicated;
        refuseReason = servicesProvider.SystemStringsService.GetString("NEW_SERVER_GAME_DIALOG", "MSG_CONNECTIONREFUSED_NICKNAMEDUPLICATED");
      }
      else if(receiver.Handshake.GameDatabaseCRC != servicesProvider.GameDatabaseCrc)
      {
        result = ConnectionResult.GameDatabaseMismatch;
        refuseReason = servicesProvider.SystemStringsService.GetString("NEW_SERVER_GAME_DIALOG", "MSG_CONNECTIONREFUSED_GAMEDATAMISMATCH");
      }
      //else if(receiver.Handshake.CardDatabaseCRC != servicesProvider.CardDatabaseCrc)
      //{
      //  result = ConnectionResult.CardDatabaseMismatch;
      //  refuseReason = servicesProvider.StringService.GetString("NEW_SERVER_GAME_DIALOG", "MSG_CONNECTIONREFUSED_CARDDATAMISMATCH");
      //}
      else if(passwordRequired && string.IsNullOrEmpty(receiver.Handshake.Password))
      {
        result = ConnectionResult.PasswordRequired;
        refuseReason = servicesProvider.SystemStringsService.GetString("NEW_SERVER_GAME_DIALOG", "MSG_CONNECTIONREFUSED_PASSWORDREQUIRED");
      }
    }

    void client_Disconnected(object sender, EventArgs e)
    {
      ServiceNetClient client = (ServiceNetClient)sender;
      client.Disconnected -= new EventHandler(client_Disconnected);

      bool notifyDisconnection = false;
      HandshakeRequest handShake = null;
      lock(syncObject)
      {
        if(connections.ContainsKey(client))
        {
          notifyDisconnection = true;
          handShake = connections[client].Handshake;
          connections.Remove(client);
        }
      }
      if(notifyDisconnection)
        OnPlayerDisconnected(client, handShake.PlayerInfo);
    }

    bool WaitHandshake(ServerConnectionMessagesHandler receiver)
    {
      bool result = false;
      for(int i = 0; i < 20; i++)
      {
        if(receiver.Handshake != null)
        {
          result = true;
          break;
        }
        Thread.Sleep(500);
      }
      return result;
    }

    bool WaitPlayerConfirm(ServerConnectionMessagesHandler receiver)
    {
      bool result = false;
      for(int i = 0; i < 20; i++)
      {
        if(receiver.Confirmed)
        {
          result = true;
          break;
        }
        Thread.Sleep(500);
      }
      return result;
    }

    protected virtual void OnPlayerConnected(ServiceNetClient client, PlayerAccountData connectedPlayer)
    {
      if(PlayerConnected != null)
        PlayerConnected(this, client, connectedPlayer);
    }

    protected virtual void OnPlayerDisconnected(ServiceNetClient client, PlayerInfo player)
    {
      if(PlayerDisconnected != null)
        PlayerDisconnected(this, client, player);
    }   
  }

  class ServerConnectionMessagesHandler : IDisposable
  {
    ServiceNetClient client;
    HandshakeRequest handshake;
    bool confirmed;
    object syncObject = new object();

    public ServerConnectionMessagesHandler(ServiceNetClient client)
    {
      this.client = client;
      client.MessageReceived += new EventHandler(client_MessageReceived);
    }

    public ServiceNetClient Client
    {
      get
      {
        lock(syncObject)
          return client;
      }
    }

    public HandshakeRequest Handshake
    {
      get
      {
        lock(syncObject)
          return handshake;
      }
    }

    public bool Confirmed
    {
      get
      {
        lock(syncObject)
          return confirmed;
      }
    }
		
	
    void client_MessageReceived(object sender, EventArgs e)
    {
      INetMessage msg = client.DequeueMessage();
      if(msg is HandshakeRequest)
      {
        lock(syncObject)
          handshake = (HandshakeRequest)msg;
      }
      else if(msg is ConfirmMessage)
      {
        lock(syncObject)
        {
          confirmed = true;
        }
      }
    }

    public void Dispose()
    {
      client.MessageReceived -= new EventHandler(client_MessageReceived);
    }
  }
}
