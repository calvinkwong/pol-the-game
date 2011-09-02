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
using System.Linq;
using System.Data.OleDb;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Security.Cryptography;

using PoL.Services.DataEntities;
using PoL.Services.DataExceptions;
using PoL.Configuration;
using System.Xml;
using System.Reflection;
using System.Threading;
using System.Globalization;

namespace PoL.Services
{
  public class ServicesProvider
  {
    string gameDatabaseCrc = string.Empty;
    string cardDatabaseCrc = string.Empty;

    GameSetsService gameSetsService;
    CardTypesService typesService;
    BaseItemService colorsService;
    BaseItemService raritiesService;
    BaseItemService stylesService;
    BaseItemService commandsService;
    ImagesService imagesService;
    CodesMapService setCodesMapService;

    CardStyleBehaviorsService stylesBehaviorsService;
    DecksService deckService;
    CardsService cardService;
    SectorsService sectorsService;
    NumCountersService numCountersService;

    StringService systemStringsService;
    StringService gameStringsService;

    public string ClientLanguageCode { get; set; }
    public string GameLanguageCode { get; set; }

    public ServicesProvider(string clientLanguageCode, string gameLanguageCode)
    {
      this.ClientLanguageCode = clientLanguageCode;
      this.GameLanguageCode = gameLanguageCode;

      LoadStrings();
    }

    public void LoadStrings()
    {
      string sysStringsPath = Path.Combine(SettingsManager.Settings.DataPath, "system-strings." + ClientLanguageCode + ".xml");
      if(!File.Exists(sysStringsPath))
        throw new InvalidSourceException("File " + sysStringsPath + " not found.");
      XmlDocument systemStringsDatabase = new XmlDocument();
      systemStringsDatabase.Load(sysStringsPath);
      systemStringsService = new StringService(systemStringsDatabase);
    }

    public void LoadGame(GameInfoItem gameInfoItem)
    {
      string gameCode = gameInfoItem.Code;

      string gameDataBasePath = Path.Combine(gameInfoItem.GamePath, "game.xml");
      if(!File.Exists(gameDataBasePath))
        throw new InvalidSourceException("File " + gameDataBasePath + " not found.");
      string gameLangDataBasePath = Path.Combine(gameInfoItem.GamePath, "game." + GameLanguageCode + ".xml");
      if(!File.Exists(gameLangDataBasePath))
        throw new InvalidSourceException("File " + gameLangDataBasePath + " not found.");
      string gameStringsDatabasePath = Path.Combine(gameInfoItem.GamePath, "strings." + GameLanguageCode + ".xml");
      if(!File.Exists(gameStringsDatabasePath))
        throw new InvalidSourceException("File " + gameStringsDatabasePath + " not found.");
      
      string setCodesFilePath = Path.Combine(Path.Combine(SettingsManager.Settings.DataPath, gameCode), "set-codes.xml");

      #region crc
      //SHA256 sha256Encoder = SHA256Managed.Create();
      //try
      //{
      //  using(FileStream fs = File.Open(gameDataBasePath, FileMode.Open, FileAccess.Read, FileShare.Read))
      //    gameDatabaseCrc = Convert.ToBase64String(sha256Encoder.ComputeHash(fs));
      //  using(FileStream fs = File.Open(cardDataBasePath, FileMode.Open, FileAccess.Read, FileShare.Read))
      //    cardDatabaseCrc = Convert.ToBase64String(sha256Encoder.ComputeHash(fs));
      //}
      //finally
      //{
      //  sha256Encoder.Clear();
      //}
      #endregion

      try
      {
        XmlDocument gameDatabase = new XmlDocument();
        gameDatabase.Load(gameDataBasePath);
        XmlDocument gameLangDatabase = new XmlDocument();
        gameLangDatabase.Load(gameLangDataBasePath);
        XmlDocument gameStringsDatabase = new XmlDocument();
        gameStringsDatabase.Load(gameStringsDatabasePath);

        if(File.Exists(setCodesFilePath))
          setCodesMapService = new CodesMapService(setCodesFilePath);
        imagesService = new Services.ImagesService(setCodesMapService);

        typesService = new CardTypesService(gameDatabase.DocumentElement["card_types"], gameLangDatabase.DocumentElement["card_types_lang"]);
        colorsService = new BaseItemService(gameDatabase.DocumentElement["card_colors"], gameLangDatabase.DocumentElement["card_colors_lang"]);
        raritiesService = new BaseItemService(gameDatabase.DocumentElement["card_rarities"], gameLangDatabase.DocumentElement["card_rarities_lang"]);
        stylesService = new BaseItemService(gameDatabase.DocumentElement["card_styles"], gameLangDatabase.DocumentElement["card_styles_lang"]);
        commandsService = new BaseItemService(gameDatabase.DocumentElement["commands"], gameLangDatabase.DocumentElement["commands_lang"]);
        stylesBehaviorsService = new CardStyleBehaviorsService(gameDatabase.DocumentElement["card_style_behaviors"], gameDatabase.DocumentElement["card_styles"]);
        sectorsService = new SectorsService(gameDatabase.DocumentElement["sectors"], gameLangDatabase.DocumentElement["sectors_lang"]);
        numCountersService = new NumCountersService(gameDatabase.DocumentElement["numCounters"], gameLangDatabase.DocumentElement["numCounters_lang"]);

        XmlDocument cardsDatabase;
        XmlDocument cardsLangDatabase;
        List<GameSetItem> gameSets;
        LoadCards(gameInfoItem, out cardsDatabase, out cardsLangDatabase, out gameSets);
        cardService = new CardsService(cardsDatabase, cardsLangDatabase, typesService);

        gameSetsService = new GameSetsService(gameSets);

        deckService = new DecksService(this);
        gameStringsService = new StringService(gameStringsDatabase);
      }
      catch(Exception ex)
      {
        throw new InvalidSourceException("Invalid data source." + Environment.NewLine + ex.Message, ex);
      }
    }

    void LoadCards(GameInfoItem gameInfoItem, out XmlDocument cardsDatabase, out XmlDocument cardsLangDatabase, out List<GameSetItem> gameSets)
    {
      gameSets = new List<GameSetItem>();
      cardsDatabase = new XmlDocument();
      cardsDatabase.LoadXml("<cards />");
      cardsLangDatabase = new XmlDocument();
      cardsLangDatabase.LoadXml("<cards_lang />");
      var filePaths = Directory.GetFiles(Path.Combine(gameInfoItem.GamePath, "cards"), "*.xml").Where(f => Path.GetFileNameWithoutExtension(f).IndexOf(".") == -1);
      XmlDocument currentSetDoc = new XmlDocument();
      XmlDocument currentSetLangDoc = new XmlDocument();
      foreach(string filePath in filePaths)
      {
        string fileLangPath = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + "." + GameLanguageCode + ".xml");
        if(!File.Exists(fileLangPath))
          throw new InvalidSourceException("File " + fileLangPath + " not found.");

        currentSetDoc.Load(filePath);
        currentSetLangDoc.Load(fileLangPath);
        GameSetItem gameSetItem = new GameSetItem()
        {
          Code = currentSetDoc.DocumentElement.Attributes["code"].Value,
          ReleaseDate = XmlConvert.ToDateTime(currentSetDoc.DocumentElement.Attributes["releaseDate"].Value, "yyyy-MM-ddTHH:mm:ss"),
          Name = currentSetLangDoc.DocumentElement.Attributes["name"].Value,
        };
        gameSets.Add(gameSetItem);
        foreach(XmlNode node in currentSetDoc.DocumentElement.SelectNodes("item"))
        {
          XmlNode importedNode = cardsDatabase.ImportNode(node, true);
          var setElement = cardsDatabase.CreateElement("set");
          setElement.InnerText = gameSetItem.Code;
          importedNode.AppendChild(setElement);
          cardsDatabase.DocumentElement.AppendChild(importedNode);
        }
        foreach(XmlNode node in currentSetLangDoc.DocumentElement.SelectNodes("item"))
          cardsLangDatabase.DocumentElement.AppendChild(cardsLangDatabase.ImportNode(node, true));
      }
    }

    public List<KeyValuePair<string, string>> GetAvaiableClientLanguages()
    {
      List<KeyValuePair<string, string>> languages = new List<KeyValuePair<string, string>>();

      var cultures = CultureInfo.GetCultures(CultureTypes.NeutralCultures);
      foreach(string path in Directory.GetFiles(SettingsManager.Settings.DataPath, "system-strings.*.xml"))
      {
        string isoCode = Path.GetExtension(Path.GetFileNameWithoutExtension(path)).Substring(1);
        var culture = cultures.FirstOrDefault(cult => cult.ThreeLetterISOLanguageName == isoCode);
        if(culture != null)
          languages.Add(new KeyValuePair<string, string>(isoCode, culture.DisplayName));
        else
          languages.Add(new KeyValuePair<string, string>(isoCode, isoCode));
      }
      return languages;
    }

    public List<GameInfoItem> GetAllGames()
    {
      List<GameInfoItem> games = new List<GameInfoItem>();
      foreach(string dir in Directory.GetDirectories(SettingsManager.Settings.DataPath))
      {
        string gameDataBasePath = Path.Combine(dir, "game.xml");
        if(File.Exists(gameDataBasePath))
        {
          string gameLangDataBasePath = Path.Combine(dir, "game." + GameLanguageCode + ".xml");
          if(!File.Exists(gameLangDataBasePath))
            throw new InvalidSourceException("File " + gameLangDataBasePath + " not found.");

          XmlDocument gameDatabase = new XmlDocument();
          gameDatabase.Load(gameDataBasePath);

          XmlDocument gameLangDatabase = new XmlDocument();
          gameLangDatabase.Load(gameLangDataBasePath);

          var gameInfoItem = new GameInfoItem(dir, gameDatabase, gameLangDatabase);
          games.Add(gameInfoItem);
        }
      }
      return games;
    }

    public ImagesService ImagesService
    {
      get { return imagesService; }
    }

    public CodesMapService SetCodesMapService
    {
      get { return setCodesMapService; }
    }

    public GameSetsService GameSetsService
    {
      get { return gameSetsService; }
    }

    public CardTypesService TypesService
    {
      get { return typesService; }
    }

    public BaseItemService ColorsService
    {
      get { return colorsService; }
    }

    public BaseItemService RaritiesService
    {
      get { return raritiesService; }
    }

    public BaseItemService StylesService
    {
      get { return stylesService; }
    }

    public BaseItemService CommandsService
    {
      get { return commandsService; }
    }

    public CardStyleBehaviorsService StylesBehaviorsService
    {
      get { return stylesBehaviorsService; }
    }

    public DecksService DecksService
    {
      get { return deckService; }
    }

    public CardsService CardsService
    {
      get { return cardService; }
    }

    public StringService SystemStringsService
    {
      get { return systemStringsService; }
    }

    public StringService GameStringsService
    {
      get { return gameStringsService; }
    }

    public SectorsService SectorsService
    {
      get { return sectorsService; }
    }

    public NumCountersService NumCountersService
    {
      get { return numCountersService; }
    }

    public string GameDatabaseCrc
    {
      get { return gameDatabaseCrc; }
    }

    public string CardDatabaseCrc
    {
      get { return cardDatabaseCrc; }
    }
  }
}
