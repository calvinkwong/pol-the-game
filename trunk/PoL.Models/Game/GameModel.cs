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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using PoL.Common;
using PoL.Services.DataEntities;
using PoL.Services;
using Patterns.ComponentModel;
using System.Windows;
using Patterns;

namespace PoL.Models.Game
{
  [Serializable]
  public class GameModel : Model
  {
    public readonly GameInfoItem GameItem;
    public readonly ModelCollection Players;
    public readonly ModelCollection Lookups;
    public readonly ModelCollection Commands;
    public readonly ConsoleModel Console;
    public readonly CardDisplayModel CardDisplay;

    bool isRestartNotified;

    [NonSerialized]
    EventHandler restartNotified;

    public event EventHandler RestartNotified
    {
      add { restartNotified = (EventHandler)Delegate.Combine(restartNotified, value); }
      remove { restartNotified = (EventHandler)Delegate.Remove(restartNotified, value); }
    }

    public GameModel(GameInfoItem gameItem)
      : base(Guid.NewGuid().ToString())
    {
      this.GameItem = gameItem;
      this.Players = new ModelCollection(this);
      this.Lookups = new ModelCollection(this);
      this.Commands = new ModelCollection(this);
      this.CardDisplay = new CardDisplayModel(Guid.NewGuid().ToString());
      this.Console = new ConsoleModel(Guid.NewGuid().ToString());
    }

    public void Restart()
    {
      isRestartNotified = true;
      OnRestartNotified();
    }

    public bool IsRestartNotified
    {
      get { return isRestartNotified; }
    }

    public PlayerModel ActivePlayer
    {
      get { return (PlayerModel)this.Players.FirstOrDefault(); }
    }

    public PlayerModel GetPlayerByKey(string key)
    {
      return (PlayerModel)Players.SingleOrDefault(e => e.Key == key);
    }

    public CommandModel GetCommandByKey(string key)
    {
      return (CommandModel)Commands.SingleOrDefault(e => e.Key == key);
    }

    public SectorModel GetSectorByKey(string key)
    {
      SectorModel result = null;
      foreach(PlayerModel player in Players)
      {
        result = (SectorModel)player.Sectors.SingleOrDefault(e => e.Key == key);
        if(result != null)
          break;
      }
      return result;
    }

    public NumCounterModel GetNumCounterByKey(string key)
    {
      NumCounterModel result = null;
      foreach(PlayerModel player in Players)
      {
        result = (NumCounterModel)player.NumCounters.SingleOrDefault(e => e.Key == key);
        if(result != null)
          break;
      }
      return result;
    }

    public CardModel GetCardByKey(string key)
    {
      CardModel card = null;
      foreach(PlayerModel player in this.Players)
      {
        foreach(SectorModel sector in player.Sectors)
        {
          card = (CardModel)sector.Cards.SingleOrDefault(e => e.Key == key);
          if(card != null)
            break;
        }
        if(card != null)
          break;
      }
      return card;
    }

    public TokenModel GetTokenByKey(string key)
    {
      TokenModel token = null;
      foreach(PlayerModel player in this.Players)
      {
        foreach(SectorModel sector in player.Sectors)
        {
          foreach(CardModel card in sector.Cards)
          {
            token = (TokenModel)card.Tokens.SingleOrDefault(e => e.Key == key);
            if(token != null)
              break;
          }
          if(token != null)
            break;
        }
        if(token != null)
          break;
      }
      return token;
    }

    public LookupModel GetLookupByKey(string key)
    {
      return Lookups.Cast<LookupModel>().SingleOrDefault(e => e.Key == key);
    }


    public PlayerModel GetSectorPlayer(string sectorKey)
    {
      PlayerModel result = null;
      foreach(PlayerModel player in Players)
        if(player.Sectors.Any(e => e.Key == sectorKey))
        {
          result = player;
          break;
        }
      return result;
    }

    public PlayerModel GetCardParentPlayer(string cardKey)
    {
      PlayerModel result = null;
      foreach(PlayerModel player in Players)
        foreach(SectorModel sector in player.Sectors)
          if(sector.Cards.Any(e => e.Key == cardKey))
          {
            result = player;
            break;
          }
      return result;
    }

    public PlayerModel GetCardOwnerPlayer(string cardKey)
    {
      CardModel card = GetCardByKey(cardKey);
      PlayerModel result = null;
      if(card != null)
        result = GetPlayerByKey(card.Owner.Key);
      return result;
    }

    protected virtual void OnRestartNotified()
    {
      if(restartNotified != null)
        restartNotified(this, EventArgs.Empty);
    }
  }
}
