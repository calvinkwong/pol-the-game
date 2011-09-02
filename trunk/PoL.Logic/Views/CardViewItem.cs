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

using PoL.Services.DataEntities;
using PoL.Common;
using PoL.Models.Game;

namespace PoL.Logic.Views
{
  public class CardViewItem
  {
    public CardItem Data { get; set; }
    public string OwnerPlayerKey { get; set; }
    public bool Reversed { get; set; }
    public bool Rotated { get; set; }
    public bool Locked { get; set; }
    public string CustomCharacteristics { get; set; }
    public CardPosition Position { get; set; }
    public CardVisibility Visibility { get; set; }
    public int HiddenCode { get; set; }
    public int Index { get; set; }

    public CardViewItem Clone()
    {
      return (CardViewItem)this.MemberwiseClone();
    }

    static public CardViewItem FromModel(CardModel card, int index)
    {
      return new CardViewItem()
      {
        Data = card.Data,
        OwnerPlayerKey = card.Owner.Key,
        Position = card.Position.Value,
        Reversed = card.Reversed.Value,
        Rotated = card.Rotated.Value,
        Locked = card.Locked.Value,
        CustomCharacteristics = card.CustomCharacteristics.Value,
        Visibility = card.Visibility.Value,
        HiddenCode = card.HiddenCode,
        Index = index,
      };
    }
  }
}
