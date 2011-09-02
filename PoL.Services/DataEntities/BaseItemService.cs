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
using System.Xml;
using PoL.Configuration;

namespace PoL.Services.DataEntities
{
  public class BaseItemService
  {
    XmlNode itemsNode;
    XmlNode itemsLangNode;

    public BaseItemService(XmlNode itemsNode, XmlNode itemsLangNode)
    {
      this.itemsNode = itemsNode;
      this.itemsLangNode = itemsLangNode;
    }

    public List<BaseItem> GetAll()
    {
      List<BaseItem> values = new List<BaseItem>();
      foreach(XmlNode nodeItem in itemsNode.ChildNodes)
      {
        XmlNode nodeLang = itemsLangNode.SelectSingleNode(string.Concat("item[@code='", nodeItem.Attributes["code"].Value, "']"));
        values.Add(new BaseItem(nodeItem, nodeLang));
      }
      return values;
    }

    public BaseItem GetByCode(string code)
    {
      BaseItem item = null;
      XmlNode nodeItem = itemsNode.SelectSingleNode(string.Concat("item[@code='", code, "']"));
      if(nodeItem != null)
      {
        XmlNode nodeLang = itemsLangNode.SelectSingleNode(string.Concat("item[@code='", nodeItem.Attributes["code"].Value, "']"));
        item = new BaseItem(nodeItem, nodeLang);
      }
      return item;
    }
  }
}
