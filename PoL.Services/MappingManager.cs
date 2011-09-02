using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Eyn.PoL.Services
{
  public class MappingManager
  {
    XmlDocument xMap = new XmlDocument();
    public MappingManager(string mappingFile)
    {
      xMap.Load(mappingFile);      
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
