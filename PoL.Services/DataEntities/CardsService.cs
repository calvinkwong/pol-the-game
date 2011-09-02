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
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using PoL.Configuration;
using PoL.Common;
using System.Collections;
using Patterns;

namespace PoL.Services.DataEntities
{
	public class CardsService
	{
    Dictionary<string, XmlNode> cardNodesById = new Dictionary<string, XmlNode>();
    Dictionary<string, XmlNode> langNodesById = new Dictionary<string, XmlNode>();
    XmlNamespaceManager cardsNsManager;

    XmlDocument cardDatabase;
    XmlDocument cardLangDatabase;
    CardTypesService typesService;

    public CardsService(XmlDocument cardDatabase, XmlDocument cardLangDatabase, CardTypesService typesService)
    {
      this.cardDatabase = cardDatabase;
      this.cardLangDatabase = cardLangDatabase;
      this.typesService = typesService;

      XmlDocument xColors = new XmlDocument();
      cardsNsManager = new XmlNamespaceManager(cardDatabase.NameTable);
      cardsNsManager.AddNamespace("ns", "http://www.w3.org/2005/xpath-functions");

      foreach(XmlNode nodeCard in cardDatabase.DocumentElement.ChildNodes)
        cardNodesById.Add(nodeCard.SelectSingleNode("id").InnerText, nodeCard);
      foreach(XmlNode nodeLang in cardLangDatabase.DocumentElement.ChildNodes)
        langNodesById.Add(nodeLang.SelectSingleNode("id").InnerText, nodeLang);
		}

    public void LocalizeCards(IEnumerable<CardItem> cards)
    {
      CardSearchParams parameters = new CardSearchParams();
      parameters.Ids = cards.Select(e => e.Id).ToList();
      foreach(CardItem localizedCard in SelectCards(parameters))
      {
        foreach(CardItem c in cards.Where(e => e.Id == localizedCard.Id))
        {
          c.Name = localizedCard.Name;
          c.Text = localizedCard.Text;
          c.FlavorText = localizedCard.FlavorText;
        }
      }
    }

    public IEnumerable<CardItem> SelectCards(CardSearchParams parameters)
    {
      SortableList cards = new SortableList(new CardItemComparer(parameters.OrderCriteria), 100000);
      cards.KeepSorted = true;

      System.Collections.IEnumerable cardNodes = null;
      // id
      if(parameters.Ids.Count > 0)
      {
        cardNodes = parameters.Ids.Distinct().Where(e => cardNodesById.ContainsKey(e)).Select(id => cardNodesById[id]);
      }
      else
      {
        StringBuilder xpath = new StringBuilder();
        if(parameters.Sets.Count > 0)
          AddParameter(xpath, "set", parameters.Sets);
        if(parameters.Types.Count > 0)
          AddParameter(xpath, "type", parameters.Types);
        if(parameters.Rarities.Count > 0)
          AddParameter(xpath, "rarity", parameters.Rarities);
        if(!string.IsNullOrEmpty(parameters.Characteristics))
        {
          if(xpath.Length > 0)
            xpath.Append(" and ");
          xpath.Append("contains(characteristics,'");
          xpath.Append(parameters.Characteristics.Trim());
          xpath.Append("')");
        }
        if(xpath.Length > 0)
        {
          xpath.Insert(0, "[");
          xpath.Append("]");
        }
        xpath.Insert(0, "item");
        cardNodes = cardDatabase.DocumentElement.SelectNodes(xpath.ToString(), cardsNsManager);
      }

      foreach(XmlNode cardNode in cardNodes)
      {
        XmlNode langNode = langNodesById[cardNode.SelectSingleNode("id").InnerText];
        bool valid = true;
        if(!string.IsNullOrEmpty(parameters.Name))
        {
          if(parameters.NameExact)
            valid = string.Compare(langNode.SelectSingleNode("name").InnerText, parameters.Name, true) == 0;
          else
            valid = langNode.SelectSingleNode("name").InnerText.IndexOf(parameters.Name, StringComparison.OrdinalIgnoreCase) != -1;
        }
        if(valid && !string.IsNullOrEmpty(parameters.Text))
        {
          valid = langNode.SelectSingleNode("text").InnerText.IndexOf(parameters.Text, StringComparison.OrdinalIgnoreCase) != -1;
        }
        if(valid)
        {
          if(parameters.Colors.Count > 0)
          {
            List<string> colors = new List<string>();
            foreach(XmlNode colorNode in cardNode.SelectNodes("colors/color"))
              colors.Add(colorNode.InnerText);
            valid = parameters.Colors.Any(e => colors.Contains(e));
          }
        }
        if(valid && parameters.Cost.Criteria != CostCriteria.None)
        {
          int cost = cardNode.SelectSingleNode("cost").InnerText.Replace("{", "").Replace("}", "").ToCharArray().Sum(c => 
            char.IsNumber(c) ? Convert.ToInt32(c.ToString()) : 1);
          switch(parameters.Cost.Criteria)
          {
            case CostCriteria.EqualTo: valid = cost == parameters.Cost.Value; break;
            case CostCriteria.LessThan: valid = cost < parameters.Cost.Value; break;
            case CostCriteria.MoreThan: valid = cost > parameters.Cost.Value; break;
          }
        }
        if(valid)
        {
          cards.Add(new CardItem(cardNode, langNode, typesService.GetByCode(cardNode["type"].InnerText)));
        }
      }
      return cards.Cast<CardItem>();
    }

    void AddParameter(StringBuilder xpath, string parName, List<string> parameters)
    {
      if(xpath.Length > 0)
        xpath.Append(" and ");
      xpath.Append("(");
      for(int i = 0; i < parameters.Count; i++)
      {
        if(i > 0)
          xpath.Append(" or ");
        xpath.Append(parName);
        xpath.Append("='");
        xpath.Append(parameters[i]);
        xpath.Append("'");
      }
      xpath.Append(")");
    }
  }

	public class CostSearchParams
	{
		public CompareRule CompareRule;
		public int Value;
	}

	public enum CompareRule
	{
		LT,
		EQ,
		GT
	}
}
