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
using PoL.Models.GameStarters;
using PoL.Logic.Views;
using Patterns.Command;
using PoL.Services;
using PoL.Common;
using System.IO;
using PoL.Configuration;

namespace PoL.Logic.Controllers.GameStarters
{
  public class ServerStartNewGameController : BaseController<ServerStartNewGameModel, IServerStartNewGameView>
  {
    ServicesProvider servicesProvider;
    ServerListener listener;

    public event Func<DeckItem> DeckRoomRequest;

    public ServerStartNewGameController(
      ServerStartNewGameModel serverInitialization, IServerStartNewGameView serverInitializationView,
      ServerListener listener, ServicesProvider servicesProvider)
      : base(serverInitialization, serverInitializationView)
    {
      serverInitializationView.RegisterController(this);
      this.servicesProvider = servicesProvider;
      this.listener = listener;

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
      if(Model.Deck == null)
        View.ShowInfoMessage(servicesProvider.SystemStringsService.GetString("SERVER_NEWGAME_DIALOG", "MSG_INVALIDDECK"));
      else
        valid = true;
      if(valid)
      {
        SettingsManager.Settings.RecentPlayedDecks.Clear();
        SettingsManager.Settings.RecentPlayedDecks.Add(new RecentDeck() { Category = Model.Deck.Category, Name = Model.Deck.Name });
        SettingsManager.Save();

        try
        {
          listener.Start(View.Password.Trim().Length > 0, Model.Deck, GameStartMode.NewGame);
          Model.Password = View.Password;

          View.ViewResult = ViewResult.Ok;
          View.Close();
        }
        catch(Exception ex)
        {
          View.ShowInfoMessage(ex.Message);
          valid = false;
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
