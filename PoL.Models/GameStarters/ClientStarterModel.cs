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
using System.Linq;
using System.Configuration;
using System.Threading;
using System.ComponentModel;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Net;

using PoL.Services;
using Communication;
using PoL.Common;
using PoL.Models;
using PoL.Models.Game;
using Patterns.ComponentModel;

namespace PoL.Models.GameStarters
{
  public class ClientStarterModel: Model, IGameStarterModel 
  {
    DeckItem deck;
    PlayerInfo playerInfo;
    ConsoleModel console;
    GameModel savedGame;
    ObservableCollection<PlayerAccountData> players;

    public event Action<object> Started;

    public ClientStarterModel(PlayerInfo playerInfo, DeckItem deck, ServicesProvider servicesProvider)
      : base(Guid.NewGuid().ToString())
    {
      this.console = new ConsoleModel(Guid.NewGuid().ToString());
      this.deck = deck;
      this.playerInfo = playerInfo;
      this.players = new ObservableCollection<PlayerAccountData>();
    }

    public PlayerInfo Player
    {
      get { return playerInfo; }
    }

    public DeckItem Deck
    {
      get { return deck; }
    }

    public GameModel SavedGame
    {
      get { return savedGame; }
    }

    #region IGameStarterModel Members

    public ObservableCollection<PlayerAccountData> Players
    {
      get { return players; }
    }

    public string GetPlayerNickName(string key)
    {
      if(playerInfo.NickName == key)
        return playerInfo.NickName;
      else
        return Players.Single(e => e.Info.NickName == key).Info.NickName;
    }

    public void Start(GameModel savedGame)
    {
      this.savedGame = savedGame;
      OnStarted();
    }

    public ConsoleModel Console
    {
      get { return console; }
    }

    #endregion   

    protected virtual void OnStarted()
    {
      if(Started != null)
        Started(this);
    }
  }
}
