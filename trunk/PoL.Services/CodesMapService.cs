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
using System.Xml;

namespace PoL.Services
{
  public class CodesMapService
  {
    XmlDocument xMap = new XmlDocument();
    public CodesMapService(string filePath)
    {
      xMap.Load(filePath);      
    }

    public string GetCode(string alias)
    {
      string code = alias;
      XmlNode node = xMap.DocumentElement.SelectSingleNode(string.Concat("item[@alias='", alias, "']"));
      if(node != null )
        code = node.SelectSingleNode("@code").InnerText;
      return code;
    }

    public string GetAlias(string code)
    {
      string alias = code;
      XmlNode node = xMap.DocumentElement.SelectSingleNode(string.Concat("item[@code='", code, "']"));
      if(node != null)
        alias = node.SelectSingleNode("@alias").InnerText;
      return alias;
    }
  }
}
