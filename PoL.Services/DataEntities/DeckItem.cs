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
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using Patterns.ComponentModel;
using System.Text;

using PoL.Services.DataEntities;

namespace PoL.Services
{
	[Serializable]
	public class DeckItem : ICloneable
	{
		[XmlAttribute]
		public string GameCode { get; set; }
		[XmlAttribute]
		public string Category = string.Empty;
		[XmlAttribute]
		public string Name = string.Empty;
		public ObservableCollection<CardItem> MainCards = new ObservableCollection<CardItem> ();
		public ObservableCollection<CardItem> SideboardCards = new ObservableCollection<CardItem> ();

		public DeckItem (string gameCode)
		{
			this.GameCode = gameCode;
		}

		public DeckItem (DeckDataContract deck)
		{
			this.GameCode = deck.GameCode;
			this.Category = deck.Category;
			this.Name = deck.Name;
			foreach (var card in deck.MainCards)
				this.MainCards.Add (card);
			foreach (var card in deck.SideboardCards)
				this.SideboardCards.Add (card);
		}

		public DeckItem () : this(string.Empty)
		{
		}

		public object Clone ()
		{
			DeckItem deck = new DeckItem (this.GameCode);
			deck.Category = this.Category;
			deck.Name = this.Name;
			foreach (var card in this.MainCards)
				deck.MainCards.Add (card);
			foreach (var card in this.SideboardCards)
				deck.SideboardCards.Add (card);
			return deck;
		}

		public DeckStatistics GenerateStatistics ()
		{
			DeckStatistics statistics = new DeckStatistics ();
			statistics.TotalMainCardsPerType = MainCards.GroupBy (e => e.Type).ToDictionary (e => e.Key, e => e.Count ());
			statistics.TotalMainCardsPerColor = MainCards.GroupBy (e => e.ColorCode).ToDictionary (e => e.Key, e => e.Count ());
			statistics.TotalMainCardsPerRarity = MainCards.GroupBy (e => e.RarityCode).ToDictionary (e => e.Key, e => e.Count ());
			return statistics;
		}
	}

	public class DeckStatistics
	{
		public Dictionary<string, int> TotalMainCardsPerType { get; set; }
		public Dictionary<string, int> TotalMainCardsPerColor { get; set; }
		public Dictionary<string, int> TotalMainCardsPerRarity { get; set; }
	}
}
