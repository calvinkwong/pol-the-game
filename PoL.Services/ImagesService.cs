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
using System.Resources;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Globalization;

using PoL.Services.DataEntities;
using System.Diagnostics;
using PoL.Services;
using PoL.Configuration;

namespace PoL.Services
{
	public class ImagesService
	{
    Dictionary<string, Image> imageCache = new Dictionary<string, Image>();
    CodesMapService codesMapService;

    public ImagesService(CodesMapService codesMapService) 
    {
      this.codesMapService = codesMapService;
    }

		public Image GetCardBack(string styleBehaviorCode)
		{
      try
      {
        string path = Path.Combine(SettingsManager.Settings.ImagesPath, "backgrounds");
        path = Path.Combine(path, "bg_" + styleBehaviorCode);
        path = Path.ChangeExtension(path, ".JPG");
        return Image.FromFile(path);
      }
      catch
      {
        return new Bitmap(1, 1);
      }
		}

    public Image GetCardBackground(string bgPath)
		{
      try
      {
        string path = Path.Combine(SettingsManager.Settings.ImagesPath, "backgrounds");
        path = Path.Combine(path, bgPath);
        return Image.FromFile(path);
      }
      catch
      {
        return new Bitmap(1, 1);
      }
    }

		public Image GetCardSymbol(string code)
		{
      try
      {
        string path = Path.Combine(SettingsManager.Settings.ImagesPath, "symbols");
        path = Path.Combine(path, code);
        path = Path.ChangeExtension(path, ".gif");
        Image img;
        if(!imageCache.TryGetValue(path, out img))
        {
          img = Image.FromFile(path);
          imageCache.Add(path, img);
        }
        return (Image)img.Clone();
      }
      catch
      {
        return new Bitmap(1, 1);
      }
    }

    public Image GetSectorBackground(string code)
    {
      try
      {
        string path = Path.Combine(SettingsManager.Settings.ImagesPath, "symbols");
        path = Path.Combine(path, "sect_" + code);
        path = Path.ChangeExtension(path, ".png");
        return Image.FromFile(path);
      }
      catch
      {
        return new Bitmap(1, 1);
      }
    }

    public Image GetNumCounterBackground(string code)
    {
      try
      {
        string path = Path.Combine(SettingsManager.Settings.ImagesPath, "symbols");
        path = Path.Combine(path, "numcounter_" + code);
        path = Path.ChangeExtension(path, ".gif");
        return Image.FromFile(path);
      }
      catch
      {
        return new Bitmap(1, 1);
      }
    }

    public Image GetCardCharacteristics(string styleCode, string code)
		{
      try
      {
        string path = Path.Combine(SettingsManager.Settings.ImagesPath, "symbols");
        path = Path.Combine(path, "char_" + styleCode + "_" + code);
        path = Path.ChangeExtension(path, ".gif");
        return Image.FromFile(path);
      }
      catch
      {
        return new Bitmap(1, 1);
      }
		}

		public Image GetCardSet(string set, string rarity)
		{
      try
      {
        string path = Path.Combine(SettingsManager.Settings.ImagesPath, "sets");
        path = Path.Combine(path, set);
        if(File.Exists(path + "_" + rarity + ".gif"))
          path += "_" + rarity.ToString();
        path = Path.ChangeExtension(path, ".gif");
        Image img;
        if(!imageCache.TryGetValue(path, out img))
        {
          img = Image.FromFile(path);
          imageCache.Add(path, img);
        }
        return (Image)img.Clone();
      }
      catch
      {
        return new Bitmap(1, 1);
      }
		}

    public Image GetCardPicture(CardItem cardItem)
    {
      try
      {
        Image cardPicture = null;
        string picName = Path.GetFileName(cardItem.ImagePath);

        string code = cardItem.SetCode;
        if(codesMapService != null && SettingsManager.Settings.MapEnabled)
          code = codesMapService.GetAlias(code);
        string picPath = Path.Combine(SettingsManager.Settings.CardPicturesPath, code);

        // search name exact
        string picFullPath = Path.Combine(picPath, picName);
        if(File.Exists(picFullPath))
          cardPicture = System.Drawing.Image.FromFile(picFullPath);
        else
        {
          string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(picName);
          string fileExtension = Path.GetExtension(picName);
          // search name"number".ext
          picFullPath = Path.Combine(picPath, fileNameWithoutExtension + "1" + fileExtension);
          if(File.Exists(picFullPath))
            cardPicture = System.Drawing.Image.FromFile(picFullPath);
          else
          {
            switch(SettingsManager.Settings.CardPictureBehavior)
            {
              case Common.CardPictureBehavior.Full:
                // search name".full".ext
                picFullPath = Path.Combine(picPath, fileNameWithoutExtension + ".full" + fileExtension);
                break;
              case Common.CardPictureBehavior.Crop:
                // search name".crop".ext
                picFullPath = Path.Combine(picPath, fileNameWithoutExtension + ".crop" + fileExtension);
                break;
            }
            if(File.Exists(picFullPath))
              cardPicture = System.Drawing.Image.FromFile(picFullPath);
            else
            {
              switch(SettingsManager.Settings.CardPictureBehavior)
              {
                case Common.CardPictureBehavior.Full:
                  // search name"number"".full".ext
                  picFullPath = Path.Combine(picPath, fileNameWithoutExtension + "1.full" + fileExtension);
                  break;
                case Common.CardPictureBehavior.Crop:
                  // search name"number"".crop".ext
                  picFullPath = Path.Combine(picPath, fileNameWithoutExtension + "1.crop" + fileExtension);
                  break;
              }
              if(File.Exists(picFullPath))
                cardPicture = System.Drawing.Image.FromFile(picFullPath);
              else
              {
                // search name*.ext and pick first
                picFullPath = fileNameWithoutExtension + "*" + fileExtension;
                string[] fileNames = Directory.GetFiles(picPath, picFullPath);
                if(fileNames.Length > 0)
                  cardPicture = System.Drawing.Image.FromFile(fileNames[0]);
              }
            }
          }
        }
        return cardPicture;
      }
      catch
      {
        return null;
      }
    }
	}
}
