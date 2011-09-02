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
using System.IO;
using System.Xml;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Patterns
{
  public class Serializer
  {
    public static T DeserializeXmlType<T>(string xml, Type[] includeTypes)
    {
      if(xml == string.Empty) return default(T);

      MemoryStream memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(xml));
      using(XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(memoryStream, Encoding.Unicode,
                 new XmlDictionaryReaderQuotas(), null))
      {
        XmlSerializer ser = new XmlSerializer(typeof(T), includeTypes);
        return (T)ser.Deserialize(reader);
      }
    }

    public static string SerializeXmlType<T>(T parameters)
    {
      return SerializeXmlType(parameters, new Type[] { });
    }

    public static string SerializeXmlType<T>(T parameters, Type[] includeTypes)
    {
      XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
      xmlWriterSettings.Encoding = Encoding.UTF8;
      xmlWriterSettings.Indent = true;
      xmlWriterSettings.OmitXmlDeclaration = true;
      StringBuilder sb = new StringBuilder();
      XmlSerializer ser = new XmlSerializer(typeof(T), includeTypes);
      using(XmlWriter xmlWriter = XmlWriter.Create(sb, xmlWriterSettings))
        ser.Serialize(xmlWriter, parameters);
      return sb.ToString();
    }
  }
}
