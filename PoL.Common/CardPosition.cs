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
using System.Drawing;
using System.Xml.Serialization;
using System.Globalization;

namespace PoL.Common
{
  [Serializable]
  public struct CardPosition : IXmlSerializable
  {
    public float X;
    public float Y;
    public float Z;

    public CardPosition(float x, float y)
      : this(x, y, 0f)
    {
    }

    public CardPosition(float x, float y, float z)
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
    }

    static public CardPosition FromPoint(Point p)
    {
      return new CardPosition(p.X, p.Y);
    }

    static public CardPosition Zero
    {
      get { return new CardPosition(); }
    }

    #region IXmlSerializable members

    public System.Xml.Schema.XmlSchema GetSchema()
    {
      throw new NotImplementedException();
    }

    public void ReadXml(System.Xml.XmlReader reader)
    {
      this.X = float.Parse(reader.GetAttribute("X"), CultureInfo.InvariantCulture);
      this.Y = float.Parse(reader.GetAttribute("Y"), CultureInfo.InvariantCulture);
      this.Z = float.Parse(reader.GetAttribute("Z"), CultureInfo.InvariantCulture);
    }

    public void WriteXml(System.Xml.XmlWriter writer)
    {
      writer.WriteAttributeString("X", this.X.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("Y", this.Y.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("Z", this.Z.ToString(CultureInfo.InvariantCulture));
    }

    #endregion
  }
}
