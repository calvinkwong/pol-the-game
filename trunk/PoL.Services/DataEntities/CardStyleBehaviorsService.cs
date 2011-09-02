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
using System.Drawing;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Text;

using PoL.Services;
using System.IO;
using System.Xml;
using PoL.Configuration;

namespace PoL.Services.DataEntities
{
  public class CardStyleBehaviorsService
	{
    public const string BEHAVIORS_SMALL = "SMALL";
    public const string BEHAVIORS_LARGE = "LARGE";

    XmlNode styleBehaviorsNode;
    XmlNode stylesNode;

    public CardStyleBehaviorsService(XmlNode styleBehaviorsNode, XmlNode stylesNode)
    {
      this.styleBehaviorsNode = styleBehaviorsNode;
      this.stylesNode = stylesNode;
    }

    public List<CardStyleBehaviorItem> GetAll()
    {
      List<CardStyleBehaviorItem> values = new List<CardStyleBehaviorItem>();
      foreach(XmlNode nodeStyleBehavior in styleBehaviorsNode.ChildNodes)
      {
        XmlNode nodeStyle = stylesNode.SelectSingleNode(string.Concat("item[@code='", nodeStyleBehavior.Attributes["style"].Value, "']"));
        values.Add(new CardStyleBehaviorItem(nodeStyleBehavior, nodeStyle, nodeStyleBehavior.Attributes["behavior"].Value));
      }
      return values;
    }
	}
}
