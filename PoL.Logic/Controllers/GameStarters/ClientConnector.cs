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

using PoL.Services;
using PoL.Common;
using System.Threading;
using Communication;
using System.Net;
using PoL.Models;
using PoL.Models.Game;
using PoL.Models.GameStarters;

namespace PoL.Logic.Controllers.GameStarters
{
  public class ClientConnector
  {
    PlayerInfo playerInfo;
    object syncObject = new object();
    ClientConnectionMessagesHandler connectionMessagesHandler;
    ServicesProvider servicesProvider;

    public event Action<object, ServiceNetClient> Disconnected;

    public ClientConnector(PlayerInfo playerInfo, ServicesProvider servicesProvider)
    {
      this.playerInfo = playerInfo;
      this.servicesProvider = servicesProvider;
    }

    public bool Connect(IPAddress address, int port, string password, GameStartMode startMode, DeckItem deck, 
      out string errorMessage, out ServerData opponentData)
    {
      bool confirmed = false;
      errorMessage = string.Empty;
      opponentData = null;
      ServiceNetClient client = new ServiceNetClient(address, port);
      client.Disconnected += new EventHandler(client_Disconnected);
      connectionMessagesHandler = new ClientConnectionMessagesHandler(client);
      try
      {
        client.Subscribe();
        Version clientVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        HandshakeRequest handshake = new HandshakeRequest()
        {
          PlayerInfo = playerInfo,
          Deck = new DeckDataContract(deck),
          StartMode = startMode,
          GameDatabaseCRC = servicesProvider.GameDatabaseCrc,
          CardDatabaseCRC = servicesProvider.CardDatabaseCrc,
          ClientVersion = clientVersion.ToString(),
          Password = password,
        };
        Thread.Sleep(100);
        client.SendMessage(handshake);
        if(!WaitForHandshakeResponse())
          throw new Exception("Opponent handshake not received!");
        if(connectionMessagesHandler.Handshake.ConnectionResult != ConnectionResult.Accepted)
        {
          switch(connectionMessagesHandler.Handshake.ConnectionResult)
          {
            case ConnectionResult.VersionMismatch:
              errorMessage = servicesProvider.SystemStringsService.GetString("NEW_SERVER_GAME_DIALOG", "MSG_CONNECTIONREFUSED_VERSIONMISMATCH");
              break;
            case ConnectionResult.GameIsRunning:
              errorMessage = servicesProvider.SystemStringsService.GetString("NEW_SERVER_GAME_DIALOG", "MSG_CONNECTIONREFUSED_GAMEISRUNNING");
              break;
            case ConnectionResult.InvalidStartMode:
              errorMessage = servicesProvider.SystemStringsService.GetString("NEW_SERVER_GAME_DIALOG", "MSG_CONNECTIONREFUSED_INVALIDSTARTMODE");
              break;
            case ConnectionResult.NicknameDuplicated:
              errorMessage = servicesProvider.SystemStringsService.GetString("NEW_SERVER_GAME_DIALOG", "MSG_CONNECTIONREFUSED_NICKNAMEDUPLICATED");
              break;
            case ConnectionResult.GameDatabaseMismatch:
              errorMessage = servicesProvider.SystemStringsService.GetString("NEW_SERVER_GAME_DIALOG", "MSG_CONNECTIONREFUSED_GAMEDATAMISMATCH");
              break;
            case ConnectionResult.CardDatabaseMismatch:
              errorMessage = servicesProvider.SystemStringsService.GetString("NEW_SERVER_GAME_DIALOG", "MSG_CONNECTIONREFUSED_CARDDATAMISMATCH");
              break;
            case ConnectionResult.PasswordRequired:
              errorMessage = servicesProvider.SystemStringsService.GetString("NEW_SERVER_GAME_DIALOG", "MSG_CONNECTIONREFUSED_PASSWORDREQUIRED");
              break;
          }
        }
        else
        {
          Thread.Sleep(100);
          client.SendMessage(new ConfirmMessage());
          opponentData = new ServerData() 
          { 
            Channel = client,
            Player = connectionMessagesHandler.Handshake.PlayerInfo,
            Deck = new DeckItem(connectionMessagesHandler.Handshake.Deck)
          };
          confirmed = true;
        }
      }
      catch(Exception ex)
      {
        errorMessage = ex.Message;
      }
      finally
      {
        connectionMessagesHandler.Dispose();
      }
      return confirmed;
    }

    void client_Disconnected(object sender, EventArgs e)
    {
      OnDisconnected((ServiceNetClient)sender);
      connectionMessagesHandler.Dispose();
    }

    public void Disconnect()
    {
      if(connectionMessagesHandler != null)
      {
        connectionMessagesHandler.Client.Disconnected -= new EventHandler(client_Disconnected);
        if(connectionMessagesHandler.Client.Connected)
          connectionMessagesHandler.Client.Disconnect();
        connectionMessagesHandler.Dispose();
      }
    }

    public bool IsConnected
    {
      get { return connectionMessagesHandler != null && connectionMessagesHandler.Client.Connected; }
    }

    bool WaitForHandshakeResponse()
    {
      bool result = false;
      for(int i = 0; i < 20; i++)
      {
        lock(syncObject)
        {
          if(connectionMessagesHandler.Handshake != null)
          {
            result = true;
            break;
          }
        }
        Thread.Sleep(500);
      }
      return result;
    }

    protected virtual void OnDisconnected(ServiceNetClient client)
    {
      if(Disconnected != null)
        Disconnected(this, client);
    }
  }

  class ClientConnectionMessagesHandler : IDisposable
  {
    ServiceNetClient client;
    HandshakeResponse handshake;
    object syncObject = new object();

    public ClientConnectionMessagesHandler(ServiceNetClient client)
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

    public HandshakeResponse Handshake
    {
      get
      {
        lock(syncObject)
          return handshake;
      }
    }

    void client_MessageReceived(object sender, EventArgs e)
    {
      INetMessage msg = client.DequeueMessage();
      if(msg is HandshakeResponse)
      {
        lock(syncObject)
          handshake = (HandshakeResponse)msg;
      }
    }

    public void Dispose()
    {
      client.MessageReceived -= new EventHandler(client_MessageReceived);
    }
  }
}
