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
using PoL.Common;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

namespace PoL.Services.DataEntities
{
  [Serializable]
  public class CardItem
  {
    [XmlAttribute]
    public string UniqueID { get; set; }
    [XmlAttribute]
    public string Id { get; set; }
    [XmlAttribute]
    public string SetCode { get; set; }
    [XmlAttribute]
    public string TypeCode { get; set; }
    [XmlAttribute]
    public string RarityCode { get; set; }
    [XmlAttribute]
    public string ColorCode { get; set; }
    [XmlAttribute]
    public string StyleCode { get; set; }

    [XmlAttribute]
    public string Name { get; set; }
    [XmlAttribute]
    public string Text { get; set; }
    [XmlAttribute]
    public string FlavorText { get; set; }
    [XmlAttribute]
    public string Type { get; set; }

    [XmlAttribute]
    public string Artist { get; set; }
    [XmlAttribute]
    public string ImagePath { get; set; }
    [XmlAttribute]
    public string BgImagePathLarge { get; set; }
    [XmlAttribute]
    public string BgImagePathSmall { get; set; }
    [XmlAttribute]
    public string Cost { get; set; }
    [XmlAttribute]
    public string Characteristics { get; set; }
    
    public List<string> Colors { get; set; }

    public CardItem()
    {
      this.Colors = new List<string>();
    }

    internal CardItem(XmlNode cardNode, XmlNode langNode, CardTypeItem typeItem)
      : this()
    {
      this.UniqueID = Guid.NewGuid().ToString();

      this.Id = cardNode["id"].InnerText;
      this.SetCode = cardNode["set"].InnerText;
      this.TypeCode = cardNode["type"].InnerText;
      this.RarityCode = cardNode["rarity"].InnerText;
      this.StyleCode = cardNode["style"].InnerText;

      this.Name = langNode["name"].InnerText;
      this.Text = langNode["text"].InnerText;
      this.FlavorText = langNode["flavorText"] != null ? langNode["flavorText"].InnerText : string.Empty;
      this.Type = typeItem.Name;

      this.Artist = cardNode["artist"].InnerText;
      this.ImagePath = cardNode["imagePath"].InnerText;
      this.BgImagePathLarge = cardNode["bgimagepathLarge"].InnerText;
      this.BgImagePathSmall = cardNode["bgimagepathSmall"].InnerText;
      this.Cost = cardNode["cost"].InnerText;
      this.Characteristics = cardNode["characteristics"].InnerText;

      foreach(XmlNode colorNode in cardNode.SelectNodes("colors/color"))
        this.Colors.Add(colorNode.InnerText);

      this.ColorCode = string.Concat(this.Colors.ToArray());
    }

    public CardItem Clone()
    {
      CardItem item = new CardItem();
      item.UniqueID = Guid.NewGuid().ToString();
      item.Id = this.Id;
      item.SetCode = this.SetCode;
      item.TypeCode = this.TypeCode;
      item.RarityCode = this.RarityCode;
      item.ColorCode = this.ColorCode;
      item.StyleCode = this.StyleCode;

      item.Name = this.Name;
      item.Text = this.Text;
      item.FlavorText = this.FlavorText;
      item.Type = this.Type;

      item.Artist = this.Artist;
      item.ImagePath = this.ImagePath;
      item.BgImagePathLarge = this.BgImagePathLarge;
      item.BgImagePathSmall = this.BgImagePathSmall;
      item.Cost = this.Cost;
      item.Characteristics = this.Characteristics;

      item.Colors = this.Colors.ToList();

      return item;
    }

    public override string ToString()
    {
      return this.Name;
    }
  }

  public class CardItemComparer : IComparer
  {
    OrderCriteria criteria;
    CaseInsensitiveComparer caseInsensitiveComparer = new CaseInsensitiveComparer();

    public CardItemComparer(OrderCriteria criteria)
    {
      this.criteria = criteria;
    }

    public int Compare(object objX, object objY)
    {
      CardItem x = (CardItem)objX, y = (CardItem)objY;

      int compareResult = 0;
      if(criteria.Field != OrderField.None)
      {
        switch(criteria.Field)
        {
          case OrderField.Name: compareResult = caseInsensitiveComparer.Compare(x.Name, y.Name); break;
          case OrderField.Rarity: compareResult = caseInsensitiveComparer.Compare(x.RarityCode, y.RarityCode); break;
          case OrderField.Set: compareResult = caseInsensitiveComparer.Compare(x.SetCode, y.SetCode); break;
          case OrderField.Color: compareResult = caseInsensitiveComparer.Compare(x.ColorCode, y.ColorCode); break;
          case OrderField.Characteristics: compareResult = caseInsensitiveComparer.Compare(x.Characteristics, y.Characteristics); break;
          case OrderField.FlavorText: compareResult = caseInsensitiveComparer.Compare(x.FlavorText, y.FlavorText); break;
          case OrderField.Text: compareResult = caseInsensitiveComparer.Compare(x.Text, y.Text); break;
          case OrderField.Type: compareResult = caseInsensitiveComparer.Compare(x.Type, y.Type); break;
          case OrderField.Artist: compareResult = caseInsensitiveComparer.Compare(x.Artist, y.Artist); break;
          case OrderField.Cost: compareResult = Helper.CompareCost(x.Cost, y.Cost); break;
        }
      }
      if(criteria.Ascending)
        return (int)compareResult;
      else
        return (int)-compareResult;
    }
  }
}
