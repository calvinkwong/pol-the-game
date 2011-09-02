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
using System.Xml;
using System.Xml.Serialization;
using PoL.Services.DataEntities;

namespace PoL.Services
{
  [Serializable]
  public class DeckDataContract
  {
    [XmlAttribute]
    public string GameCode { get; set; }
    [XmlAttribute]
    public string Category = string.Empty;
    [XmlAttribute]
    public string Name = string.Empty;
    public List<CardItem> MainCards = new List<CardItem>();
    public List<CardItem> SideboardCards = new List<CardItem>();

    public DeckDataContract(DeckItem deck)
    {
      this.GameCode = deck.GameCode;
      this.Category = deck.Category;
      this.Name = deck.Name;
      foreach(var card in deck.MainCards)
        this.MainCards.Add(card);
      foreach(var card in deck.SideboardCards)
        this.SideboardCards.Add(card);
    }

    public DeckDataContract()
    {
    }
  }
}

