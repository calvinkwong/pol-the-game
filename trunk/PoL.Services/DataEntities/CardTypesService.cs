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
using System.Data.OleDb;
using System.IO;
using PoL.Configuration;
using System.Xml;

namespace PoL.Services.DataEntities
{
  public class CardTypesService
  {
    XmlNode typesNode;
    XmlNode typesLangNode;

    public CardTypesService(XmlNode setsNode, XmlNode setsLangNode)
    {
      this.typesNode = setsNode;
      this.typesLangNode = setsLangNode;
    }

    public List<CardTypeItem> GetAll()
    {
      List<CardTypeItem> types = new List<CardTypeItem>();
      foreach(XmlNode nodeSet in typesNode.ChildNodes)
      {
        XmlNode nodeLang = typesLangNode.SelectSingleNode(string.Concat("item[@code='", nodeSet.Attributes["code"].Value, "']"));
        types.Add(new CardTypeItem(nodeSet, nodeLang));
      }
      return types.ToList();
    }

    public CardTypeItem GetByCode(string code)
    {
      CardTypeItem item = null;
      XmlNode nodeItem = typesNode.SelectSingleNode(string.Concat("item[@code='", code, "']"));
      if(nodeItem != null)
      {
        XmlNode nodeLang = typesLangNode.SelectSingleNode(string.Concat("item[@code='", nodeItem.Attributes["code"].Value, "']"));
        item = new CardTypeItem(nodeItem, nodeLang);
      }
      return item;
    }
  }
}
