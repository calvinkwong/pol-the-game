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
using System.IO;
using PoL.Configuration;
using PoL.Services.DataExceptions;
using System.Globalization;

namespace PoL.Services.DataEntities
{
  [Serializable]
  public class GameInfoItem
  {
    public string GamePath { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public int StartPoints { get; set; }
    public int StartCardsAmount { get; set; }
    public List<BaseItem> Languages { get; set; }
    public List<StartSectorFillingRule> StartSectorFillingRules { get; set; }

    internal GameInfoItem(string gamePath, XmlDocument gameDatabase, XmlDocument gameLangDatabase)
    {
      this.GamePath = gamePath;
      this.Code = gameDatabase.DocumentElement["info"].Attributes["code"].Value;
      this.StartPoints = XmlConvert.ToInt32(gameDatabase.DocumentElement["info"].Attributes["startPoints"].Value);
      this.StartCardsAmount = XmlConvert.ToInt32(gameDatabase.DocumentElement["info"].Attributes["startCardsAmount"].Value);
      this.StartSectorFillingRules = new List<StartSectorFillingRule>();
      this.Name = gameLangDatabase.DocumentElement["info"].Attributes["name"].Value;

      this.Languages = new List<BaseItem>();
      var cultures = CultureInfo.GetCultures(CultureTypes.NeutralCultures);
      foreach(string path in Directory.GetFiles(gamePath, "strings.*.xml"))
      {
        string isoCode = Path.GetExtension(Path.GetFileNameWithoutExtension(path)).Substring(1);
        var culture = cultures.FirstOrDefault(cult => cult.ThreeLetterISOLanguageName == isoCode);
        if(culture != null)
          Languages.Add(new BaseItem() { Code = isoCode, Name = culture.DisplayName });
        else
          Languages.Add(new BaseItem() { Code = isoCode, Name = isoCode });
      }

      //StartSectorFillingRules.Add(new StartSectorFillingRule()
      //{
      //  SourceSector = 1,
      //  DestinationSector = 5,
      //  CardAmount = 7
      //});
    }
  }

  [Serializable]
  public class StartSectorFillingRule
  {
    public string SourceSector { get; set; }
    public string DestinationSector { get; set; }
    public int CardAmount { get; set; }
  }
}
