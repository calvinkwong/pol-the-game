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
using System.IO;
using System.Xml;
using PoL.Configuration;

namespace PoL.Services.DataEntities
{
  public class NumCountersService
  {
    XmlNode nodes;
    XmlNode nodesLang;

    public NumCountersService(XmlNode nodeSectors, XmlNode nodeSectorsLang)
    {
      this.nodes = nodeSectors;
      this.nodesLang = nodeSectorsLang;
    }

    public List<NumCounterItem> GetAll()
    {
      List<NumCounterItem> items = new List<NumCounterItem>();
      foreach(XmlNode node in nodes.ChildNodes)
      {
        XmlNode nodeLang = nodesLang.SelectSingleNode(string.Concat("item[@code='", node.Attributes["code"].Value, "']"));
        items.Add(new NumCounterItem(node, nodeLang));
      }
      return items;
    }

    public NumCounterItem GetByCode(string code)
    {
      NumCounterItem item = null;
      XmlNode nodeItem = nodes.SelectSingleNode(string.Concat("item[@code='", code, "']"));
      if(nodeItem != null)
      {
        XmlNode nodeLang = nodesLang.SelectSingleNode(string.Concat("item[@code='", nodeItem.Attributes["code"].Value, "']"));
        item = new NumCounterItem(nodeItem, nodeLang);
      }
      return item;
    }
  }
}
