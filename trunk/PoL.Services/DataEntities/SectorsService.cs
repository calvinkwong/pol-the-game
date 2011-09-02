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
using System.Data.OleDb;
using System.IO;
using System.Xml;
using PoL.Configuration;

namespace PoL.Services.DataEntities
{
  public class SectorsService
  {
    XmlNode nodeSectors;
    XmlNode nodeSectorsLang;

    public SectorsService(XmlNode nodeSectors, XmlNode nodeSectorsLang)
    {
      this.nodeSectors = nodeSectors;
      this.nodeSectorsLang = nodeSectorsLang;
    }

    public List<SectorItem> GetAll()
    {
      List<SectorItem> sectors = new List<SectorItem>();
      foreach(XmlNode nodeSector in nodeSectors.ChildNodes)
      {
        XmlNode nodeLang = nodeSectorsLang.SelectSingleNode(string.Concat("item[@code='", nodeSector.Attributes["code"].Value, "']"));
        sectors.Add(new SectorItem(nodeSector, nodeLang));
      }
      return sectors;
    }

    public SectorItem GetByCode(string code)
    {
      SectorItem item = null;
      XmlNode nodeItem = nodeSectors.SelectSingleNode(string.Concat("item[@code='", code, "']"));
      if(nodeItem != null)
      {
        XmlNode nodeLang = nodeSectorsLang.SelectSingleNode(string.Concat("item[@code='", nodeItem.Attributes["code"].Value, "']"));
        item = new SectorItem(nodeItem, nodeLang);
      }
      return item;
    }
  }
}
