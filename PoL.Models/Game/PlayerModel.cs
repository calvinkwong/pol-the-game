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
using Patterns;
using Patterns.ComponentModel;
using PoL.Services.DataEntities;
using PoL.Services;
using Communication;

namespace PoL.Models.Game
{
  [Serializable]
  public class PlayerModel : Model
  {
    public readonly PlayerInfo Info;
    public readonly DeckItem Deck;
    public ObservableProperty<int, PlayerModel> Points { get; set; }
    public readonly ModelCollection Sectors;
    public readonly ModelCollection NumCounters;
    public readonly string Password;

    public PlayerModel(GameModel parent, string key, PlayerInfo info, DeckItem deck, string password)
      : base(parent, null, key)
    {
      this.Info = info;
      this.Deck = deck;
      this.Points = new ObservableProperty<int, PlayerModel>(this, 0);
      this.Sectors = new ModelCollection(this);
      this.NumCounters = new ModelCollection(this);
      this.Password = password;
    }

    public SmartName GetSmartName(SmartNameVerbRule verbRule)
    {
      string name = string.Empty;
      bool visible = false;
      GameModel game = (GameModel)this.Parent;
      if(this.Key == game.ActivePlayer.Key)
      {
        name = "You";
        switch(verbRule)
        {
          case SmartNameVerbRule.ToBe: name += " are"; break;
          case SmartNameVerbRule.ToHave: name += " have"; break;
        }
      }
      else
      {
        visible = true;
        name = this.Info.NickName;
        switch(verbRule)
        {
          case SmartNameVerbRule.ToBe: name += " is"; break;
          case SmartNameVerbRule.ToHave: name += " has"; break;
        }
      }
      return new SmartName(name, visible);
    }
  }
}
