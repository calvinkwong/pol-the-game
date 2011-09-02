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
using System.Data.OleDb;
using System.Xml;

namespace PoL.Services.DataEntities
{
  public class CardStyleBehaviorItem : ICloneable
  {
    public string BehaviorCode { get; set; }
    public string StyleCode { get; set; }

    public Font CardName_Font { get; set; }
    public Color CardName_FontColor { get; set; }
    public bool CardName_FontShadowed { get; set; }
    public Color CardName_FontShadowColor { get; set; }

    public Font CardType_Font { get; set; }
    public Color CardType_FontColor { get; set; }
    public bool CardType_FontShadowed { get; set; }
    public Color CardType_FontShadowColor { get; set; }

    public Font CardText_Font { get; set; }
    public Color CardText_FontColor { get; set; }
    public bool CardText_FontShadowed { get; set; }
    public Color CardText_FontShadowColor { get; set; }

    public Font CardFlavorText_Font { get; set; }
    public Color CardFlavorText_FontColor { get; set; }
    public bool CardFlavorText_FontShadowed { get; set; }
    public Color CardFlavorText_FontShadowColor { get; set; }

    public Font CardArtist_Font { get; set; }
    public Color CardArtist_FontColor { get; set; }
    public bool CardArtist_FontShadowed { get; set; }
    public Color CardArtist_FontShadowColor { get; set; }

    public CardStyleBehaviorItem()
    { 
    }

    internal CardStyleBehaviorItem(XmlNode styleBehaviorNode, XmlNode styleNode, string behaviorCode)
    {
      string fontName = string.Empty;
      int fontSize = 0;
      bool fontBold = false;
      bool fontItalic = false;

      this.BehaviorCode = behaviorCode;
      this.StyleCode = styleNode.Attributes["code"].Value;

      fontName = styleBehaviorNode.Attributes["cardName_fontName"].Value;
      fontSize = XmlConvert.ToInt32(styleBehaviorNode.Attributes["cardName_fontSize"].Value);
      fontBold = XmlConvert.ToBoolean(styleBehaviorNode.Attributes["cardName_fontBold"].Value);
      fontItalic = XmlConvert.ToBoolean(styleBehaviorNode.Attributes["cardName_fontItalic"].Value);
      this.CardName_Font = new Font(fontName, fontSize, GetFontStyle(fontBold, fontItalic));
      this.CardName_FontColor = Color.FromName(styleBehaviorNode.Attributes["cardName_fontColor"].Value);
      this.CardName_FontShadowed = XmlConvert.ToBoolean(styleBehaviorNode.Attributes["cardName_fontShadowed"].Value);
      if(styleBehaviorNode.Attributes["cardName_fontShadowColor"] != null)
        this.CardName_FontShadowColor = Color.FromName(styleBehaviorNode.Attributes["cardName_fontShadowColor"].Value);

      fontName = styleBehaviorNode.Attributes["cardType_fontName"].Value;
      fontSize = XmlConvert.ToInt32(styleBehaviorNode.Attributes["cardType_fontSize"].Value);
      fontBold = XmlConvert.ToBoolean(styleBehaviorNode.Attributes["cardType_fontBold"].Value);
      fontItalic = XmlConvert.ToBoolean(styleBehaviorNode.Attributes["cardType_fontItalic"].Value);
      this.CardType_Font = new Font(fontName, fontSize, GetFontStyle(fontBold, fontItalic));
      this.CardType_FontColor = Color.FromName(styleBehaviorNode.Attributes["cardType_fontColor"].Value);
      this.CardType_FontShadowed = XmlConvert.ToBoolean(styleBehaviorNode.Attributes["cardType_fontShadowed"].Value);
      if(styleBehaviorNode.Attributes["cardType_fontShadowColor"] != null)
        this.CardType_FontShadowColor = Color.FromName(styleBehaviorNode.Attributes["cardType_fontShadowColor"].Value);

      fontName = styleBehaviorNode.Attributes["cardText_fontName"].Value;
      fontSize = XmlConvert.ToInt32(styleBehaviorNode.Attributes["cardText_fontSize"].Value);
      fontBold = XmlConvert.ToBoolean(styleBehaviorNode.Attributes["cardText_fontBold"].Value);
      fontItalic = XmlConvert.ToBoolean(styleBehaviorNode.Attributes["cardText_fontItalic"].Value);
      this.CardText_Font = new Font(fontName, fontSize, GetFontStyle(fontBold, fontItalic));
      this.CardText_FontColor = Color.FromName(styleBehaviorNode.Attributes["cardText_fontColor"].Value);
      this.CardText_FontShadowed = XmlConvert.ToBoolean(styleBehaviorNode.Attributes["cardText_fontShadowed"].Value);
      if(styleBehaviorNode.Attributes["cardText_fontShadowColor"] != null)
        this.CardText_FontShadowColor = Color.FromName(styleBehaviorNode.Attributes["cardText_fontShadowColor"].Value);

      fontName = styleBehaviorNode.Attributes["cardFlavorText_fontName"].Value;
      fontSize = XmlConvert.ToInt32(styleBehaviorNode.Attributes["cardFlavorText_fontSize"].Value);
      fontBold = XmlConvert.ToBoolean(styleBehaviorNode.Attributes["cardFlavorText_fontBold"].Value);
      fontItalic = XmlConvert.ToBoolean(styleBehaviorNode.Attributes["cardFlavorText_fontItalic"].Value);
      this.CardFlavorText_Font = new Font(fontName, fontSize, GetFontStyle(fontBold, fontItalic));
      this.CardFlavorText_FontColor = Color.FromName(styleBehaviorNode.Attributes["cardFlavorText_fontColor"].Value);
      this.CardFlavorText_FontShadowed = XmlConvert.ToBoolean(styleBehaviorNode.Attributes["cardFlavorText_fontShadowed"].Value);
      if(styleBehaviorNode.Attributes["cardFlavorText_fontShadowColor"] != null)
        this.CardFlavorText_FontShadowColor = Color.FromName(styleBehaviorNode.Attributes["cardFlavorText_fontShadowColor"].Value);

      fontName = styleBehaviorNode.Attributes["cardArtist_fontName"].Value;
      fontSize = XmlConvert.ToInt32(styleBehaviorNode.Attributes["cardArtist_fontSize"].Value);
      fontBold = XmlConvert.ToBoolean(styleBehaviorNode.Attributes["cardArtist_fontBold"].Value);
      fontItalic = XmlConvert.ToBoolean(styleBehaviorNode.Attributes["cardArtist_fontItalic"].Value);
      this.CardArtist_Font = new Font(fontName, fontSize, GetFontStyle(fontBold, fontItalic));
      this.CardArtist_FontColor = Color.FromName(styleBehaviorNode.Attributes["cardArtist_fontColor"].Value);
      this.CardArtist_FontShadowed = XmlConvert.ToBoolean(styleBehaviorNode.Attributes["cardArtist_fontShadowed"].Value);
      if(styleBehaviorNode.Attributes["cardArtist_fontShadowColor"] != null)
        this.CardArtist_FontShadowColor = Color.FromName(styleBehaviorNode.Attributes["cardArtist_fontShadowColor"].Value);
    }

    static FontStyle GetFontStyle(bool bold, bool italic)
    {
      return (bold ? FontStyle.Bold : 0) | (italic ? FontStyle.Italic : 0);
    }

    #region ICloneable Members

    public object Clone()
    {
      return this.MemberwiseClone();
    }

    #endregion
  }
}
