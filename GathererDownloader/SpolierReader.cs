using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ScaricaSpoilers
{
  public class SpoilerReader
  {
    string cardName;
    string cardColor;
    public SpoilerReader(string cardName, string cardColor)
    {
      this.cardName = cardName;
      this.cardColor = cardColor;
    }

    string GetManaSymbol(string img)
    {
      return "{" +  img.Split(new string[] {";name="}, StringSplitOptions.None).Last().Split('&').First() + "}";
    }

    public void CreateCardNode(XmlNode nodeContent, XmlDocument xCards, XmlDocument xCardsLang, string setCode, DateTime setDate, int ordinal)
    {
      XmlNode cardNode = xCards.CreateNode(XmlNodeType.Element, "item", string.Empty);
      XmlNode cardLangNode = xCardsLang.CreateNode(XmlNodeType.Element, "item", string.Empty);

      // id
      string id = setCode.PadLeft(3, '_').Substring(0, 3) + ordinal.ToString().PadLeft(4, '0').Substring(0, 4);
      cardNode.AppendChild(xCards.CreateNode(XmlNodeType.Element, "id", string.Empty)).InnerText = id;
      cardLangNode.AppendChild(xCardsLang.CreateNode(XmlNodeType.Element, "id", string.Empty)).InnerText = id;
      // language
      //cardLangNode.AppendChild(xCardsLang.CreateNode(XmlNodeType.Element, "language", string.Empty)).InnerText = "ENG";
      // name
      cardLangNode.AppendChild(xCardsLang.CreateNode(XmlNodeType.Element, "name", string.Empty)).InnerText = this.cardName;
      // text
      string text = string.Empty;
      foreach(XmlNode textNode in nodeContent.SelectNodes("div/div[@id='ctl00_ctl00_ctl00_MainContent_SubContent_SubContent_textRow']/div[@class='value']/div[@class='cardtextbox']"))
        text += ReplaceSymbols(textNode.InnerXml.Trim()) + Environment.NewLine;
      cardLangNode.AppendChild(xCardsLang.CreateNode(XmlNodeType.Element, "text", string.Empty)).InnerText = text.Trim().Replace("{tap}", "{T}");
      // flavorText
      string flavorText = string.Empty;
      foreach(XmlNode flavorTextNode in nodeContent.SelectNodes("div/div/div[@id='ctl00_ctl00_ctl00_MainContent_SubContent_SubContent_FlavorText']/div[@class='cardtextbox']"))
        flavorText += flavorTextNode.InnerText.Trim() + Environment.NewLine;
      cardLangNode.AppendChild(xCardsLang.CreateNode(XmlNodeType.Element, "flavorText", string.Empty)).InnerText = flavorText.Trim();

      // set
      //cardNode.AppendChild(xCards.CreateNode(XmlNodeType.Element, "set", string.Empty)).InnerText = setCode;
      // color
      List<string> colors = new List<string>();
      string colorCode = string.Empty;
      foreach(string colorPart in this.cardColor.Split('/'))
      {
        switch(colorPart.ToLower())
        {
          case "black": colors.Add("B"); colorCode += "B"; break;
          case "white": colors.Add("W"); colorCode += "W"; break;
          case "red": colors.Add("R"); colorCode += "R"; break;
          case "blue": colors.Add("U"); colorCode += "U"; break;
          case "green": colors.Add("G"); colorCode += "G"; break;
          case "": colors.Add("A"); colorCode = "A"; break;
          case "colorless": colors.Add("L"); colorCode = "L"; break;
          case "colorless (land)": break;
          default: throw new Exception("Unkonwn color: " + colorPart);
        }
      }
      XmlNode nodeColors = xCards.CreateNode(XmlNodeType.Element, "colors", string.Empty);
      foreach(string color in colors)
        nodeColors.AppendChild(xCards.CreateNode(XmlNodeType.Element, "color", string.Empty)).InnerText = color;
      cardNode.AppendChild(nodeColors);
      // rarity
      string rarity = nodeContent.SelectSingleNode("div/div[@id='ctl00_ctl00_ctl00_MainContent_SubContent_SubContent_rarityRow']/div[@class='value']/span").InnerText.Trim();
      switch(rarity.ToLower())
      {
        case "common": rarity = "C"; break;
        case "uncommon": rarity = "U"; break;
        case "rare": rarity = "R"; break;
        case "basic land": rarity = "C"; break;
        case "mythic rare": rarity = "M"; break;
        case "special": rarity = "S"; break;
        default: throw new Exception("Unkonwn rarity: " + rarity);
      }
      cardNode.AppendChild(xCards.CreateNode(XmlNodeType.Element, "rarity", string.Empty)).InnerText = rarity;
      // cost
      string cost = string.Empty;
      foreach(XmlNode imgNode in nodeContent.SelectNodes("div/div[@id='ctl00_ctl00_ctl00_MainContent_SubContent_SubContent_manaRow']/div[@class='value']/img"))
        cost += GetManaSymbol(imgNode.OuterXml);
      cardNode.AppendChild(xCards.CreateNode(XmlNodeType.Element, "cost", string.Empty)).InnerText = cost;
      // type
      string type = nodeContent.SelectSingleNode("div/div[@id='ctl00_ctl00_ctl00_MainContent_SubContent_SubContent_typeRow']/div[@class='value']").InnerText.Trim();
      if(type.ToLower().StartsWith("creature") ||
        type.ToLower().StartsWith("summon ") || 
        type.ToLower().StartsWith("scariest ") || 
        type.ToLower().StartsWith("(none)") ||
        type.ToLower().StartsWith("eaturecray"))
        type = "CRE";
      else if(type.ToLower().StartsWith("instant") || type.ToLower().StartsWith("interrupt"))
        type = "INS";
      else if(type.ToLower().StartsWith("enchantment") || type.ToLower().StartsWith("enchant "))
        type = "ENC";
      else if(type.ToLower().StartsWith("sorcery"))
        type = "SOR";
      else if(type.ToLower().StartsWith("artifact creature"))
        type = "ARC";
      else if(type.ToLower().StartsWith("artifact"))
        type = "ART";

      else if(type.ToLower().StartsWith("land"))
        type = "LND";
      else if(type.ToLower().StartsWith("basic land"))
        type = "BLA";

      else if(type.ToLower().StartsWith("legendary creature"))
        type = "LCR";
      else if(type.ToLower().StartsWith("legendary enchantment"))
        type = "LEN";
      else if(type.ToLower().StartsWith("legendary land"))
        type = "LLA";
      else if(type.ToLower().StartsWith("legendary artifact"))
        type = "LAR";

      else if(type.ToLower().StartsWith("world enchantment"))
        type = "WEN";

      else if(type.ToLower().StartsWith("basic snow land"))
        type = "BSL";
      else if(type.ToLower().StartsWith("snow creature"))
        type = "SCR";
      else if(type.ToLower().StartsWith("snow land"))
        type = "SLA";
      else if(type.ToLower().StartsWith("snow enchantment"))
        type = "SEN";
      else if(type.ToLower().StartsWith("snow artifact creature"))
        type = "SAC";
      else if(type.ToLower().StartsWith("snow artifact"))
        type = "SAR";
      else if(type.ToLower().StartsWith("legendary snow land"))
        type = "LSL";

      else if(type.ToLower().StartsWith("tribal enchantment"))
        type = "TEN";
      else if(type.ToLower().StartsWith("tribal sorcery"))
        type = "TSO";
      else if(type.ToLower().StartsWith("tribal instant"))
        type = "TIN";
      else if(type.ToLower().StartsWith("tribal artifact"))
        type = "TAR";

      else if(type.ToLower().StartsWith("planeswalker"))
        type = "PLA";
        
      else
        throw new Exception("Unkonwn type: " + type);
      cardNode.AppendChild(xCards.CreateNode(XmlNodeType.Element, "type", string.Empty)).InnerText = type;
      // characteristics
      string characteristics = string.Empty;
      foreach(XmlNode charNode in nodeContent.SelectNodes("div/div[@id='ctl00_ctl00_ctl00_MainContent_SubContent_SubContent_ptRow']/div[@class='value']"))
        characteristics += charNode.InnerText.Trim().Replace(" ", string.Empty);
      cardNode.AppendChild(xCards.CreateNode(XmlNodeType.Element, "characteristics", string.Empty)).InnerText = characteristics;
      // artist
      XmlNode nodeArtist = nodeContent.SelectSingleNode("div/div[@id='ctl00_ctl00_ctl00_MainContent_SubContent_SubContent_artistRow']/div[@class='value']");
      cardNode.AppendChild(xCards.CreateNode(XmlNodeType.Element, "artist", string.Empty)).InnerText = nodeArtist.SelectSingleNode("a") != null ? 
        nodeArtist.SelectSingleNode("a").InnerText.Trim() : nodeArtist.InnerText.Trim();

      // style
      string style = "";
      if(
#region
        //setCode == "NMS" ||
        //setCode == "TMP" ||
        //setCode == "STH" ||
        //setCode == "EXO" ||
        //setCode == "USG" ||
        //setCode == "ULG" ||
        //setCode == "MED" ||
        //setCode == "MMQ" ||
        //setCode == "MIR" ||
        //setCode == "PCY" ||
        //setCode == "INV" ||
        //setCode == "PLS" ||
        //setCode == "APC" ||
        //setCode == "ODY" ||
        //setCode == "LEA" ||
        //setCode == "JUD" ||
        //setCode == "UDS" ||
        //setCode == "ATQ" ||
        //setCode == "LEB" ||
        //setCode == "2ED" ||
        //setCode == "3ED" ||
        //setCode == "4ED" ||
        //setCode == "5ED" ||
        //setCode == "6ED" ||
        //setCode == "WTH" ||
        //setCode == "ARN" ||
        //setCode == "VIS" ||
        //setCode == "LEG" ||
        //setCode == "DRK" ||
        //setCode == "FEM" ||
        //setCode == "HML" ||
        //setCode == "ICE" ||
        //setCode == "ALL" ||
        //setCode == "ONS" ||
        //setCode == "7ED" ||
        //setCode == "PTK" ||
        //setCode == "LGN" ||
        //setCode == "BRB" ||
        //setCode == "TOR" ||
        //setCode == "CHR" ||
        //setCode == "P02" ||
        //setCode == "ATH" ||
        //setCode == "S99" ||
        //setCode == "S00" ||
        //setCode == "UNH" ||
        //setCode == "UGL" ||
        //setCode == "POR" ||
        //setCode == "SCG"
#endregion
        setDate < new DateTime(2003, 7, 28) // 8 ed
        )
        style = "PRE_8";
      else
        style = "POST_8";
      cardNode.AppendChild(xCards.CreateNode(XmlNodeType.Element, "style", string.Empty)).InnerText = style;
      // image path
      string imagepath = Path.ChangeExtension(this.cardName.Replace(" // ", "").Replace("\"", ""), ".jpg");
      //imagepath = Path.Combine(setCode, imagepath);
      cardNode.AppendChild(xCards.CreateNode(XmlNodeType.Element, "imagePath", string.Empty)).InnerText = imagepath;
      // bgimage path large/small
      string bgimagepath = "bg_" + style + "_";
      if(type == "BLA") // basic land
      {
        switch(this.cardName.ToLower())
        {
          case "forest": bgimagepath += "FO"; break;
          case "swamp": bgimagepath += "SW"; break;
          case "plains": bgimagepath += "PL"; break;
          case "mountain": bgimagepath += "MO"; break;
          case "island": bgimagepath += "IS"; break;
        }
      }
      else
      {
        if(colorCode.Length > 1)
          bgimagepath += "M";
        else
          bgimagepath += colorCode;
      }
      cardNode.AppendChild(xCards.CreateNode(XmlNodeType.Element, "bgimagepathLarge", string.Empty)).InnerText = bgimagepath + "_Large.png";
      cardNode.AppendChild(xCards.CreateNode(XmlNodeType.Element, "bgimagepathSmall", string.Empty)).InnerText = bgimagepath + "_Small.png";

      xCardsLang.DocumentElement.AppendChild(cardLangNode);
      xCards.DocumentElement.AppendChild(cardNode);
    }

    private string GetSymbol(string val)
    {
      string symbol = null;
      val = val.ToLower();
      if(val.IndexOf("untap.gif") != -1)
        symbol = "{UNTAP}";
      else if(val.IndexOf("tap.gif") != -1)
        symbol = "{T}";
      else if(val.IndexOf("white_mana.gif") != -1)
        symbol = "{W}";
      else if(val.IndexOf("black_mana.gif") != -1)
        symbol = "{B}";
      else if(val.IndexOf("blue_mana.gif") != -1)
        symbol = "{U}";
      else if(val.IndexOf("green_mana.gif") != -1)
        symbol = "{G}";
      else if(val.IndexOf("red_mana.gif") != -1)
        symbol = "{R}";

      else if(val.IndexOf("symbol_snow_mana.gif") != -1)
        symbol = "{S}";
      else if(val.IndexOf("symbol_x_mana.gif") != -1)
        symbol = "{X}";
      else if(val.IndexOf("symbol_y_mana.gif") != -1)
        symbol = "{Y}";
      else if(val.IndexOf("symbol_z_mana.gif") != -1)
        symbol = "{Z}";
      else if(val.IndexOf("symbol_half_mana.gif") != -1)
        symbol = "{H}";
      else if(val.IndexOf("symbol_0_mana.gif") != -1)
        symbol = "{0}";
      else if(val.IndexOf("symbol_1_mana.gif") != -1)
        symbol = "{1}";
      else if(val.IndexOf("symbol_2_mana.gif") != -1)
        symbol = "{2}";
      else if(val.IndexOf("symbol_3_mana.gif") != -1)
        symbol = "{3}";
      else if(val.IndexOf("symbol_4_mana.gif") != -1)
        symbol = "{4}";
      else if(val.IndexOf("symbol_5_mana.gif") != -1)
        symbol = "{5}";
      else if(val.IndexOf("symbol_6_mana.gif") != -1)
        symbol = "{6}";
      else if(val.IndexOf("symbol_7_mana.gif") != -1)
        symbol = "{7}";
      else if(val.IndexOf("symbol_8_mana.gif") != -1)
        symbol = "{8}";
      else if(val.IndexOf("symbol_9_mana.gif") != -1)
        symbol = "{9}";
      else if(val.IndexOf("symbol_10_mana.gif") != -1)
        symbol = "{10}";
      else if(val.IndexOf("symbol_11_mana.gif") != -1)
        symbol = "{11}";
      else if(val.IndexOf("symbol_12_mana.gif") != -1)
        symbol = "{12}";
      else if(val.IndexOf("symbol_15_mana.gif") != -1)
        symbol = "{15}";
      else if(val.IndexOf("symbol_16_mana.gif") != -1)
        symbol = "{16}";
      else if(val.IndexOf("symbol_100_mana.gif") != -1)
        symbol = "{100}";


      else if(val.IndexOf("symbol_br_mana.gif") != -1)
        symbol = "{BR}";
      else if(val.IndexOf("symbol_wu_mana.gif") != -1)
        symbol = "{WU}";
      else if(val.IndexOf("symbol_gw_mana.gif") != -1)
        symbol = "{GW}";
      else if(val.IndexOf("symbol_rg_mana.gif") != -1)
        symbol = "{RG}";
      else if(val.IndexOf("symbol_ub_mana.gif") != -1)
        symbol = "{UB}";
      else if(val.IndexOf("symbol_rw_mana.gif") != -1)
        symbol = "{RW}";
      else if(val.IndexOf("symbol_wb_mana.gif") != -1)
        symbol = "{WB}";
      else if(val.IndexOf("symbol_ur_mana.gif") != -1)
        symbol = "{UR}";
      else if(val.IndexOf("symbol_bg_mana.gif") != -1)
        symbol = "{BG}";
      else if(val.IndexOf("symbol_gu_mana.gif") != -1)
        symbol = "{GU}";

      else if(val.IndexOf("symbol_2u_mana.gif") != -1)
        symbol = "{2U}";
      else if(val.IndexOf("symbol_2r_mana.gif") != -1)
        symbol = "{2R}";
      else if(val.IndexOf("symbol_2w_mana.gif") != -1)
        symbol = "{2W}";
      else if(val.IndexOf("symbol_2g_mana.gif") != -1)
        symbol = "{2G}";
      else if(val.IndexOf("symbol_2b_mana.gif") != -1)
        symbol = "{2B}";

      return symbol;
    }

    private string ReplaceSymbols(string val)
    {
      string symbol = null;
      int startIndex = 0;
      int endIndex = 0;
      while(startIndex != -1)
      {
        startIndex = val.IndexOf("<img", startIndex);
        if(startIndex != -1)
        {
          endIndex = val.IndexOf("/>", startIndex) + 2;
          //symbol = GetSymbol(val.Substring(startIndex, endIndex - startIndex));
          symbol = GetManaSymbol(val.Substring(startIndex, endIndex - startIndex));
          if(symbol == null)
            throw new Exception("Unknown symbol: " + val.Substring(startIndex, endIndex - startIndex));
          val = val.Remove(startIndex, endIndex - startIndex);
          val = val.Insert(startIndex, symbol);
        }
      }
      return val;
    }
  }
}
