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

using PoL.Services.DataEntities;

namespace PoL.Services
{
  public static class CardMetricsService
	{
		static private FullCardLayoutPRE_8 fullCardLayoutFirst = new FullCardLayoutPRE_8();
		static private FullCardLayoutPOST_8 fullCardLayoutSecond = new FullCardLayoutPOST_8();
		static private PartialCardLayoutPRE_8 partialCardLayoutFirst = new PartialCardLayoutPRE_8();
    static private PartialCardLayoutPOST_8 partialCardLayoutSecond = new PartialCardLayoutPOST_8();
    static private FullCardLayoutPawn fullCardLayoutPawn = new FullCardLayoutPawn();
    static private PartialCardLayoutPawn partialCardLayoutPawn = new PartialCardLayoutPawn();
    static private FullCardLayout1ST fullCardLayout1ST = new FullCardLayout1ST();
    static private PartialCardLayout1ST partialCardLayout1ST = new PartialCardLayout1ST();
    static private FullCardLayout2ST fullCardLayout2ST = new FullCardLayout2ST();
    static private PartialCardLayout2ST partialCardLayout2ST = new PartialCardLayout2ST();

    public const string STYLECODE_PRE_8 = "PRE_8";
    public const string STYLECODE_POST_8 = "POST_8";
    public const string STYLECODE_1ST = "1ST";
    public const string STYLECODE_2ST = "2ST";
    public const string STYLECODE_PAWN = "PAWN";

    public static Rectangle CardRect(string styleBehaviorCode)
    {
      Rectangle rect = new Rectangle();
      if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
        rect = new Rectangle(0, 0, 250, 334);
      else
        rect = new Rectangle(0, 0, 84, 120);
      return rect;
    }

    public static Rectangle NameRect(string styleCode, string styleBehaviorCode)
		{
      Rectangle rect = new Rectangle();
      switch(styleCode)
			{
				case STYLECODE_PRE_8:
          if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayoutFirst.NameRect;
					else
            rect = partialCardLayoutFirst.NameRect;
          break;
        case STYLECODE_POST_8:
					if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayoutSecond.NameRect;
					else
            rect = partialCardLayoutSecond.NameRect;
          break;
        case STYLECODE_1ST:
          if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayout1ST.NameRect;
          else
            rect = partialCardLayout1ST.NameRect;
          break;
        case STYLECODE_2ST:
          if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayout2ST.NameRect;
          else
            rect = partialCardLayout2ST.NameRect;
          break;
        case STYLECODE_PAWN:
          if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayoutPawn.NameRect;
          else
            rect = partialCardLayoutPawn.NameRect;
          break;
      }
      return rect;
    }

    public static Rectangle ImageRect(string styleCode, string styleBehaviorCode)
		{
      Rectangle rect = new Rectangle();
      switch(styleCode)
			{
				case STYLECODE_PRE_8:
					if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayoutFirst.ImageRect; 
					else
            rect = partialCardLayoutFirst.ImageRect;
          break;
        case STYLECODE_POST_8:
					if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayoutSecond.ImageRect;
					else
            rect = partialCardLayoutSecond.ImageRect;
          break;
        case STYLECODE_1ST:
          if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayout1ST.ImageRect;
          else
            rect = partialCardLayout1ST.ImageRect;
          break;
        case STYLECODE_2ST:
          if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayout2ST.ImageRect;
          else
            rect = partialCardLayout2ST.ImageRect;
          break;
        case STYLECODE_PAWN:
          if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayoutPawn.ImageRect;
          else
            rect = partialCardLayoutPawn.ImageRect;
          break;
      }
      return rect;
    }

    public static Rectangle TypeRect(string styleCode, string styleBehaviorCode)
		{
      Rectangle rect = new Rectangle();
      switch(styleCode)
			{
				case STYLECODE_PRE_8:
          if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayoutFirst.TypeRect; 
          else
            rect = partialCardLayoutFirst.TypeRect;
          break;
        case STYLECODE_POST_8:
          if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayoutSecond.TypeRect; 
          else
            rect = partialCardLayoutSecond.TypeRect;
          break;
        case STYLECODE_1ST:
          if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayout1ST.TypeRect;
          else
            rect = partialCardLayout1ST.TypeRect;
          break;
        case STYLECODE_2ST:
          if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayout2ST.TypeRect;
          else
            rect = partialCardLayout2ST.TypeRect;
          break;
        case STYLECODE_PAWN:
          if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayoutPawn.TypeRect;
          else
            rect = partialCardLayoutPawn.TypeRect;
          break;
      }
      return rect;
    }

    public static Rectangle SymbolRect(string styleCode, string styleBehaviorCode)
		{
      Rectangle rect = new Rectangle();
      switch(styleCode)
			{
				case STYLECODE_PRE_8:
          rect = fullCardLayoutFirst.SymbolRect;
          break;
        case STYLECODE_POST_8:
          rect = fullCardLayoutSecond.SymbolRect;
          break;
        case STYLECODE_1ST:
          rect = fullCardLayout1ST.SymbolRect;
          break;
        case STYLECODE_2ST:
          rect = fullCardLayout2ST.SymbolRect;
          break;
        case STYLECODE_PAWN:
          rect = fullCardLayoutPawn.SymbolRect;
          break;
      }
      return rect;
    }

    public static Rectangle TextRect(string styleCode, string styleBehaviorCode)
		{
      Rectangle rect = new Rectangle();
      switch(styleCode)
			{
				case STYLECODE_PRE_8:
          if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayoutFirst.TextRect;
          else
            rect = partialCardLayoutFirst.TextRect;
          break;
        case STYLECODE_POST_8:
          if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayoutSecond.TextRect; 
          else
            rect = partialCardLayoutSecond.TextRect;
          break;
        case STYLECODE_1ST:
          if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayout1ST.TextRect;
          else
            rect = partialCardLayout1ST.TextRect;
          break;
        case STYLECODE_2ST:
          if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayout2ST.TextRect;
          else
            rect = partialCardLayout2ST.TextRect;
          break;
        case STYLECODE_PAWN:
          if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayoutPawn.TextRect;
          else
            rect = partialCardLayoutPawn.TextRect;
          break;
      }
      return rect;
    }

    public static Rectangle ArtistRect(string styleCode, string styleBehaviorCode)
		{
      Rectangle rect = new Rectangle();
      switch(styleCode)
			{
				case STYLECODE_PRE_8:
          rect = fullCardLayoutFirst.ArtistRect;
          break;
        case STYLECODE_POST_8:
          rect = fullCardLayoutSecond.ArtistRect;
          break;
        case STYLECODE_1ST:
          rect = fullCardLayout1ST.ArtistRect;
          break;
        case STYLECODE_2ST:
          rect = fullCardLayout2ST.ArtistRect;
          break;
        case STYLECODE_PAWN:
          rect = fullCardLayoutPawn.ArtistRect;
          break;
      }
      return rect;
    }

    public static Rectangle CharacteristicsRect(string styleCode, string styleBehaviorCode)
		{
      Rectangle rect = new Rectangle();
      switch(styleCode)
			{
				case STYLECODE_PRE_8:
					if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayoutFirst.CharacteristicsRect;
					else
            rect = partialCardLayoutFirst.CharacteristicsRect;
          break;
        case STYLECODE_POST_8:
					if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayoutSecond.CharacteristicsRect;
					else
            rect = partialCardLayoutSecond.CharacteristicsRect;
          break;
        case STYLECODE_1ST:
          if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayout1ST.CharacteristicsRect;
          else
            rect = partialCardLayout1ST.CharacteristicsRect;
          break;
        case STYLECODE_2ST:
          if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayout2ST.CharacteristicsRect;
          else
            rect = partialCardLayout2ST.CharacteristicsRect;
          break;
        case STYLECODE_PAWN:
          if(styleBehaviorCode == CardStyleBehaviorsService.BEHAVIORS_LARGE)
            rect = fullCardLayoutPawn.CharacteristicsRect;
          else
            rect = partialCardLayoutPawn.CharacteristicsRect;
          break;
      }
      return rect;
    }
	}
}
