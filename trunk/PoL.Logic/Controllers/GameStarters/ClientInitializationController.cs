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

using Patterns;
using Patterns.MVC;
using PoL.Logic.Views;
using Patterns.Command;
using PoL.Services;
using PoL.Common;
using System.IO;
using PoL.Models.GameStarters;
using System.Net;
using PoL.Configuration;

namespace PoL.Logic.Controllers.GameStarters
{
  public class ClientInitializationController : BaseController<ClientInitializationModel, IClientInitializationView>
  {
    ServicesProvider servicesProvider;
    public event Func<DeckItem> DeckRoomRequest;
    ClientConnector connector;

    public ClientInitializationController(
      ClientInitializationModel clientInitialization, IClientInitializationView clientInitializationView,
      PlayerInfo clientPlayer, ClientConnector connector, ServicesProvider servicesProvider)
      : base(clientInitialization, clientInitializationView)
    {
      clientInitializationView.RegisterController(this);

      View.Port = SettingsManager.Settings.ListenPort;

      this.servicesProvider = servicesProvider;
      this.connector = connector;

      if(SettingsManager.Settings.RecentPlayedDecks.Count > 0)
      {
        var recentDeck = SettingsManager.Settings.RecentPlayedDecks.First();
        if(servicesProvider.DecksService.DeckExists(recentDeck.Category, recentDeck.Name))
          SetCurrentDeck(servicesProvider.DecksService.LoadDeck(recentDeck.Category, recentDeck.Name));
      }
    }

    public void Finish()
    {
      bool valid = false;
      switch(View.StartMode)
      {
        case GameStartMode.NewGame:
          if(Model.Deck == null)
            View.ShowInfoMessage(servicesProvider.SystemStringsService.GetString("CLIENT_INITIALIZATION_DIALOG", "MSG_INVALIDDECK"));
          else 
            valid = true;
          break;
        case GameStartMode.SavedGame:
          if(string.IsNullOrEmpty(View.Password))
            View.ShowInfoMessage(servicesProvider.SystemStringsService.GetString("CLIENT_INITIALIZATION_DIALOG", "MSG_PASSWORDREQUIRED"));
          else
            valid = true;
          break;
      }
      IPAddress serverAddress = IPAddress.Loopback;
      if(valid)
      {
        if(!IPAddress.TryParse(View.Address, out serverAddress))
          View.ShowInfoMessage(servicesProvider.SystemStringsService.GetString("CLIENT_INITIALIZATION_DIALOG", "MSG_INVALID_IP"));
        else
          valid = true;
      }

      if(valid)
      {
        if(View.StartMode == GameStartMode.NewGame)
        {
          SettingsManager.Settings.RecentPlayedDecks.Clear();
          SettingsManager.Settings.RecentPlayedDecks.Add(new RecentDeck() { Category = Model.Deck.Category, Name = Model.Deck.Name });
          SettingsManager.Save();
        }

        string errorMessage;
        ServerData opponentData;
        valid = connector.Connect(serverAddress, View.Port, View.Password, View.StartMode, Model.Deck, out errorMessage, out opponentData);
        if(!valid)
        {
          View.ShowInfoMessage(errorMessage);
        }
        else
        {
          Model.StartMode = View.StartMode;
          Model.Password = View.Password;
          Model.ServerIP = serverAddress;
          Model.ServerPort = View.Port;
          Model.ServerData = opponentData;

          View.ViewResult = ViewResult.Ok;
          View.Close();
        }
      }
    }

    public void LoadDeck()
    {
      var deck = OnDeckRoomRequest();
      SetCurrentDeck(deck);
    }

    void SetCurrentDeck(DeckItem deckItem)
    {
      Model.Deck = deckItem;
      if(Model.Deck != null)
      {
        Model.Deck.MainCards.Shuffle();
        View.SetDeckName(Model.Deck.Name);
      }
    }

    protected virtual DeckItem OnDeckRoomRequest()
    {
      DeckItem deck = null;
      if(DeckRoomRequest != null)
        deck = DeckRoomRequest();
      return deck;
    }
  }
}
