﻿/*
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
using System.Xml;

namespace PoL.Services.DataEntities
{
  [Serializable]
  public class BaseItem
  {
    public string Code { get; set; }
    public string Name { get; set; }

    internal BaseItem()
    { 
    }

    internal BaseItem(XmlNode nodeItem, XmlNode nodeLang)
    {
      this.Code = nodeItem.Attributes["code"].Value;
      this.Name = nodeLang.Attributes["name"].Value;
    }
  }
}
