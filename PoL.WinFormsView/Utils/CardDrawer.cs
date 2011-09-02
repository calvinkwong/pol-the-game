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
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PoL.Services.DataEntities;
using PoL.Services;
using PoL.WinFormsView.Properties;
using PoL.Configuration;
using PoL.Common;

namespace PoL.WinFormsView.Utils
{
  class CardDrawer
  {
    static List<CardStyleBehaviorItem> cardStyleBehaviors = null;    

    static public Bitmap Draw(CardItem cardItem, string styleBehaviorCode)
    {
      return Draw(cardItem, string.Empty, styleBehaviorCode);
    }

    static public Bitmap Draw(CardItem cardItem, string customCharacteristics, string styleBehaviorCode)
    {
      if(cardStyleBehaviors == null)
        cardStyleBehaviors = Program.LogicHandler.ServicesProvider.StylesBehaviorsService.GetAll();
      CardStyleBehaviorItem behavior = cardStyleBehaviors.Where(e =>
        e.StyleCode == cardItem.StyleCode && e.BehaviorCode == styleBehaviorCode).Single();

      Rectangle cardRect = CardMetricsService.CardRect(styleBehaviorCode);
      Bitmap image = new Bitmap(cardRect.Width, cardRect.Height);
      
      bool drawCrop = true;
      if(SettingsManager.Settings.CardPictureBehavior == CardPictureBehavior.Full)
      {
        using(Image pic = Program.LogicHandler.ServicesProvider.ImagesService.GetCardPicture(cardItem))
        {
          if(pic != null)
          {
            drawCrop = false;
            using(Graphics g = Graphics.FromImage(image))
            {
              g.DrawImage(pic, cardRect);
              switch(styleBehaviorCode)
              {
                case CardStyleBehaviorsService.BEHAVIORS_SMALL:
                  CardStyleBehaviorItem forcedShadowedBehavior = new CardStyleBehaviorItem();
                  forcedShadowedBehavior.CardName_FontShadowed = true;
                  forcedShadowedBehavior.CardName_FontColor = Color.White;
                  forcedShadowedBehavior.CardName_FontShadowColor = Color.Black;
                  forcedShadowedBehavior.CardName_Font = new Font("Arial", 8, FontStyle.Bold);
                  forcedShadowedBehavior.CardType_FontShadowed = true;
                  forcedShadowedBehavior.CardType_FontColor = Color.White;
                  forcedShadowedBehavior.CardType_FontShadowColor = Color.Black;
                  forcedShadowedBehavior.CardType_Font = new Font("Arial", 8, FontStyle.Bold);
                  PaintSmallCardElements(g, cardItem, forcedShadowedBehavior, false);
                  PaintCardCharacteristics(g, cardItem, customCharacteristics, behavior);
                  break;
              }
            }
          }
        }
      }
      
      if(drawCrop)
      {
        using(Graphics g = Graphics.FromImage(image))
        {
          g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
          switch(styleBehaviorCode)
          {
            case CardStyleBehaviorsService.BEHAVIORS_LARGE:
              PaintBackGround(g, cardItem, behavior);
              PaintFullCardName(g, cardItem, behavior);
              PaintCardImage(g, cardItem, behavior);
              PaintCardType(g, cardItem, behavior);
              PaintFullCardSymbol(g, cardItem, behavior);
              PaintFullCardText(g, cardItem, behavior);
              PaintCastingCost(g, cardItem, behavior);
              PaintArtist(g, cardItem, behavior);
              PaintCardCharacteristics(g, cardItem, string.Empty, behavior);
              break;
            case CardStyleBehaviorsService.BEHAVIORS_SMALL:
              PaintBackGround(g, cardItem, behavior);
              PaintSmallCardElements(g, cardItem, behavior, true);
              PaintCardCharacteristics(g, cardItem, customCharacteristics, behavior);
              break;
          }
        }
      }
      return image;
    }

    static Rectangle ShadowRect(Rectangle rect)
    {
      Rectangle shadowRect = new Rectangle(rect.Location, rect.Size);
      shadowRect.Offset(1, 1);
      return shadowRect;
    }

    static void PaintFullCardName(Graphics g, CardItem cardItem, CardStyleBehaviorItem behavior)
    {
      if(behavior.CardName_FontShadowed)
        g.DrawString(
          cardItem.Name
          , behavior.CardName_Font
          , new SolidBrush(behavior.CardName_FontShadowColor)
          , ShadowRect(CardMetricsService.NameRect(cardItem.StyleCode, behavior.BehaviorCode))
          );
      g.DrawString(
        cardItem.Name
        , behavior.CardName_Font
        , new SolidBrush(behavior.CardName_FontColor)
        , CardMetricsService.NameRect(cardItem.StyleCode, behavior.BehaviorCode)
        );
    }

    static void PaintCardImage(Graphics g, CardItem cardItem, CardStyleBehaviorItem behavior)
    {
      if(string.IsNullOrEmpty(cardItem.ImagePath))
        return;

      using(Image pic = Program.LogicHandler.ServicesProvider.ImagesService.GetCardPicture(cardItem))
        if(pic != null)
          g.DrawImage(pic, CardMetricsService.ImageRect(cardItem.StyleCode, behavior.BehaviorCode));
    }

    static void PaintCardType(Graphics g, CardItem cardItem, CardStyleBehaviorItem behavior)
    {
      StringFormat f = new StringFormat();
      f.Trimming = StringTrimming.EllipsisCharacter;
      f.LineAlignment = StringAlignment.Center;
      if(behavior.CardName_FontShadowed)
        g.DrawString(
          cardItem.Type
          , behavior.CardType_Font
          , new SolidBrush(behavior.CardType_FontShadowColor)
          , ShadowRect(CardMetricsService.TypeRect(cardItem.StyleCode, behavior.BehaviorCode))
          , f
          );
      g.DrawString(
        cardItem.Type
        , behavior.CardType_Font
        , new SolidBrush(behavior.CardType_FontColor)
        , CardMetricsService.TypeRect(cardItem.StyleCode, behavior.BehaviorCode)
        , f
        );
    }

    static void PaintFullCardSymbol(Graphics g, CardItem cardItem, CardStyleBehaviorItem behavior)
    {
      if(!string.IsNullOrEmpty(cardItem.SetCode) && !string.IsNullOrEmpty(cardItem.RarityCode))
      {
        using(Image symbol = Program.LogicHandler.ServicesProvider.ImagesService.GetCardSet(cardItem.SetCode, cardItem.RarityCode))
        {
          if(symbol != null)
            g.DrawImage(symbol, CardMetricsService.SymbolRect(cardItem.StyleCode, behavior.BehaviorCode));
        }
      }
    }

    static void PaintFullCardText(Graphics g, CardItem cardItem, CardStyleBehaviorItem behavior)
    {
      Font textFont = null;
      Font flavorTextFont = null;
      if(!string.IsNullOrEmpty(cardItem.Text) || !string.IsNullOrEmpty(cardItem.FlavorText))
      {
        if(((string.IsNullOrEmpty(cardItem.Text) ? 0 : cardItem.Text.Length) +
          (string.IsNullOrEmpty(cardItem.FlavorText) ? 0 : cardItem.FlavorText.Length)) < 250)
        {
          textFont = behavior.CardText_Font;
          flavorTextFont = behavior.CardFlavorText_Font;
        }
        else
        {
          textFont = new Font(behavior.CardText_Font.Name, behavior.CardText_Font.Size - 1, behavior.CardText_Font.Style);
          flavorTextFont = new Font(behavior.CardFlavorText_Font.Name, behavior.CardFlavorText_Font.Size - 1, behavior.CardFlavorText_Font.Style);
        }
      }

      float textLineHeight = textFont != null ? MeasureString(g, "A", textFont).Height : 0;
      Rectangle textRect = CardMetricsService.TextRect(cardItem.StyleCode, behavior.BehaviorCode);
      float topBorder = textRect.Top;

      if(!string.IsNullOrEmpty(cardItem.Text))
      {
        float leftBorder = textRect.Left + 2;
        float totalWidth = textRect.Width;
        float lineLeft = leftBorder;

        int startIdx = 0;
        for(int endIdx = 0; endIdx < cardItem.Text.Length; endIdx++)
        {
          if(cardItem.Text[endIdx] == '{')
          {
            // symbol?
            int endSymIdx = cardItem.Text.IndexOf("}", endIdx);
            if(endSymIdx != -1)
            {
              string symbolText = cardItem.Text.Substring(endIdx, (endSymIdx - endIdx) + 1);
              // draw symbol
              float symbolSize = textLineHeight * 0.8f; // forced symbol size
              if(((lineLeft - leftBorder) + symbolSize) >= totalWidth)
              {
                // new line
                topBorder += textLineHeight;
                lineLeft = leftBorder;
              }
              using(Image symbol = Program.LogicHandler.ServicesProvider.ImagesService.GetCardSymbol(symbolText.Substring(1, symbolText.Length - 2)))
              {
                if(symbol != null)
                  g.DrawImage(symbol, lineLeft , topBorder + (textLineHeight - symbolSize), symbolSize, symbolSize);
              }
              lineLeft += symbolSize;

              startIdx = endSymIdx + 1;
              endIdx = endSymIdx;
            }
          }
          else
          {
            // word/text end
            if(endIdx == (cardItem.Text.Length - 1) || cardItem.Text[endIdx] == ' ' || cardItem.Text[endIdx] == '(' || cardItem.Text[endIdx] == '\n')
            {
              string token = cardItem.Text.Substring(startIdx, (endIdx - startIdx) + 1);
              // word						
              float wordWidth = MeasureString(g, token, textFont).Width;
              if(((lineLeft - leftBorder) + wordWidth) >= totalWidth)
              {
                // new line
                topBorder += textLineHeight;
                lineLeft = leftBorder;
                token = token.TrimStart();
              }

              DrawString(g , token, textFont, new SolidBrush(behavior.CardText_FontColor), lineLeft, topBorder);
              lineLeft += wordWidth;

              if(cardItem.Text[endIdx] == '\n')
              {
                // forced new line
                topBorder += textLineHeight;
                lineLeft = leftBorder;
              }
              startIdx = endIdx + 1;
            }
          }       
        }
      }

      if(!string.IsNullOrEmpty(cardItem.FlavorText))
      {
        // card flavor Text
        RectangleF flavorRect = textRect;
        flavorRect.Y = topBorder + textLineHeight;
        g.DrawString(cardItem.FlavorText, flavorTextFont, new SolidBrush(behavior.CardFlavorText_FontColor), flavorRect);
      }
    }

    static SizeF MeasureString(Graphics g, string s, Font f)
    {
      StringFormat sf = StringFormat.GenericTypographic;
      sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
      return g.MeasureString(s, f, 10000, sf);
    }

    static void DrawString(Graphics g, string s, Font f, Brush brush, float x, float y)
    {
      StringFormat sf = StringFormat.GenericTypographic;
      g.DrawString(
        s
        , f
        , brush
        , x
        , y
        , sf
        );
    }

    static void PaintSmallCardElements(Graphics g, CardItem cardItem, CardStyleBehaviorItem behavior, bool paintPicture)
    {
      int costWidth = 0;

      // card cost
      if(!string.IsNullOrEmpty(cardItem.Cost))
        costWidth = PaintCastingCost(g, cardItem, behavior);

      // card name
      Rectangle nameRect = CardMetricsService.NameRect(cardItem.StyleCode, behavior.BehaviorCode);
      nameRect = new Rectangle(nameRect.Location, new Size(nameRect.Width - costWidth, nameRect.Height));

      StringFormat f = new StringFormat();
      f.Trimming = StringTrimming.EllipsisCharacter;
      if(behavior.CardName_FontShadowed)
        g.DrawString(
          cardItem.Name
          , behavior.CardName_Font
          , new SolidBrush(behavior.CardName_FontShadowColor)
          , ShadowRect(nameRect)
          , f
          );
      g.DrawString(
        cardItem.Name
        , behavior.CardName_Font
        , new SolidBrush(behavior.CardName_FontColor)
        , nameRect
        , f
        );

      // card image
      if(paintPicture)
        PaintCardImage(g, cardItem, behavior);

      // card type
      PaintCardType(g, cardItem, behavior);
    }

    static int PaintCastingCost(Graphics g, CardItem cardItem, CardStyleBehaviorItem behavior)
    {
      int costWidth = 0;
      if(!string.IsNullOrEmpty(cardItem.Cost))
      {
        const int SPACE = 2;
        int symbolWidth = behavior.BehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE ? 12 : 10;

        Rectangle nameRect = CardMetricsService.NameRect(cardItem.StyleCode, behavior.BehaviorCode);

        string[] symbols = cardItem.Cost.Split('}');
        costWidth = symbolWidth * (symbols.Length - 1);

        Rectangle symbolRect = new Rectangle(
          nameRect.Right - costWidth
          , nameRect.Top + SPACE
          , symbolWidth, symbolWidth
          );

        for(int i = 0; i < (symbols.Length - 1); i++)
        {
          using(Image img = Program.LogicHandler.ServicesProvider.ImagesService.GetCardSymbol(symbols[i].ToString().Replace("{", "")))
          {
            if(img != null)
            {
              g.DrawImage(img, symbolRect);
              symbolRect.X += img.Width;
            }
          }
        }
      }
      return costWidth;
    }

    static void PaintArtist(Graphics g, CardItem cardItem, CardStyleBehaviorItem behavior)
    {
      if(behavior.CardArtist_FontShadowed)
        g.DrawString(
          cardItem.Artist
          , behavior.CardArtist_Font
          , new SolidBrush(behavior.CardArtist_FontShadowColor)
          , ShadowRect(CardMetricsService.ArtistRect(cardItem.StyleCode, behavior.BehaviorCode))
          );
      g.DrawString(
        cardItem.Artist
        , behavior.CardArtist_Font
        , new SolidBrush(behavior.CardArtist_FontColor)
        , CardMetricsService.ArtistRect(cardItem.StyleCode, behavior.BehaviorCode)
        );
    }

    static void PaintBackGround(Graphics g, CardItem cardItem, CardStyleBehaviorItem behavior)
    {
      if(string.IsNullOrEmpty(cardItem.BgImagePathLarge))
        return;
      
      Image pic = behavior.BehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE ?
        Program.LogicHandler.ServicesProvider.ImagesService.GetCardBackground(cardItem.BgImagePathLarge) : Program.LogicHandler.ServicesProvider.ImagesService.GetCardBackground(cardItem.BgImagePathSmall);
      if(pic == null)
        pic = Program.LogicHandler.ServicesProvider.ImagesService.GetCardBack(behavior.BehaviorCode);
      if(pic != null)
      {
        g.DrawImage(pic, CardMetricsService.CardRect(behavior.BehaviorCode));
        pic.Dispose();
      }
    }

    static void PaintCardCharacteristics(Graphics g, CardItem cardItem, string customCharacteristics, CardStyleBehaviorItem behavior)
    {
      if(string.IsNullOrEmpty(cardItem.Characteristics) && string.IsNullOrEmpty(customCharacteristics))
        return;

      StringFormat f = new StringFormat();
      f.Alignment = StringAlignment.Center;
      f.LineAlignment = StringAlignment.Center;
      Rectangle rect = CardMetricsService.CharacteristicsRect(cardItem.StyleCode, behavior.BehaviorCode);
      if(!string.IsNullOrEmpty(customCharacteristics))
      {
        // ...rectangle...
        g.DrawImage(Resources.redbanner, CardMetricsService.CharacteristicsRect(cardItem.StyleCode, behavior.BehaviorCode));
        // ...characteristics
        g.DrawString(
          customCharacteristics
          , new Font(behavior.CardName_Font, behavior.CardName_Font.Style | FontStyle.Bold)
          , new SolidBrush(Color.White)
          , rect
          , f
          );
      }
      else
      {
        // ...rectangle...
        using(Image symbol = Program.LogicHandler.ServicesProvider.ImagesService.GetCardCharacteristics(cardItem.StyleCode, cardItem.ColorCode))
          if(symbol != null)
            g.DrawImage(symbol, CardMetricsService.CharacteristicsRect(cardItem.StyleCode, behavior.BehaviorCode));
        // ...characteristics
        if(behavior.CardName_FontShadowed)
          g.DrawString(
            cardItem.Characteristics
            , new Font(behavior.CardName_Font, behavior.CardName_Font.Style | FontStyle.Bold)
            , new SolidBrush(behavior.CardName_FontShadowColor)
            , ShadowRect(rect)
            , f
            );
        g.DrawString(
          cardItem.Characteristics
          , new Font(behavior.CardName_Font, behavior.CardName_Font.Style | FontStyle.Bold)
          , new SolidBrush(behavior.CardName_FontColor)
          , rect
          , f
          );
      }
    }
  }
}
