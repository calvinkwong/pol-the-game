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
using System.IO;
using System.Xml;
using System.Collections.Generic;
using Patterns.ComponentModel;
using System.Text;
using Patterns;
using PoL.Configuration;

namespace PoL.Services.DataEntities
{
	public class DecksService
	{
    public const string DECK_FILE_EXTENSION = ".xml";
    ServicesProvider servicesProvider;

    public DecksService(ServicesProvider servicesProvider)
		{
      this.servicesProvider = servicesProvider;
		}

    public List<DeckCategoryItem> SelectAllCategories()
    {
      List<DeckCategoryItem> categories = new List<DeckCategoryItem>();
      IEnumerable<string> deckFiles = GetDeckFiles();
      foreach(string fileName in deckFiles)
      {
        string categoryName = fileName.Split('.').First();
        DeckCategoryItem item = categories.SingleOrDefault(e => string.Compare(e.CategoryName, categoryName, true) == 0);
        if(item == null)
        {
          item = new DeckCategoryItem(categoryName);
          categories.Add(item);
        }
        item.DeckNames.Add(Path.GetFileNameWithoutExtension(fileName).Split('.').Last());
      }
      return categories;
    }

    public DeckItem LoadDeck(string category, string name)
    {
      return LoadDeck(category, name, null);
    }

    public DeckItem LoadDeck(string category, string name, string language)
    {
      DeckItem deck = null;
      string deckPath = Path.Combine(SettingsManager.Settings.DeckPath, category + "." + name + DECK_FILE_EXTENSION);
      if(File.Exists(deckPath))
      {
        XmlDocument xDoc = new XmlDocument();
        try
        {
          xDoc.Load(deckPath);
          deck = new DeckItem(xDoc.DocumentElement.SelectSingleNode("@game").InnerText);
          deck.Category = category;
          deck.Name = name;
          FillDeck(deck.MainCards, xDoc.DocumentElement.SelectSingleNode("main"), language);
          FillDeck(deck.SideboardCards, xDoc.DocumentElement.SelectSingleNode("sideboard"), language);
        }
        catch {  /* invalid deck file, ignored */ }
      }
      return deck;
    }

    public void SaveDeck(DeckItem deck)
    {
      string deckPath = Path.Combine(SettingsManager.Settings.DeckPath, deck.Category + "." + deck.Name + DECK_FILE_EXTENSION);
      SaveDeck(deck, deckPath);
    }

    void SaveDeck(DeckItem deck, string deckPath)
		{
			XmlDocument xDoc = new XmlDocument();
			xDoc.LoadXml(
"<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
"<deck game=''>" +
"	<main />" +
" <sideboard />" +
"</deck>"
			);
      xDoc.DocumentElement.Attributes["game"].Value = deck.GameCode;
      XmlNode cardNode = null;
      XmlAttribute attribute = null;
      foreach(var cardsById in deck.MainCards.GroupBy(e => e.Id))
			{
				cardNode = xDoc.CreateNode(XmlNodeType.Element, "", "card", "");
        attribute = xDoc.CreateAttribute("count");
        attribute.Value = cardsById.Count().ToString();
        cardNode.Attributes.Append(attribute);
        attribute = xDoc.CreateAttribute("id");
        attribute.Value = cardsById.Key;
				cardNode.Attributes.Append(attribute);
				xDoc.DocumentElement.SelectSingleNode("main").AppendChild(cardNode);
			}
			foreach(var cardsById in deck.SideboardCards.GroupBy(e => e.Id))
			{
				cardNode = xDoc.CreateNode(XmlNodeType.Element, "", "card", "");
        attribute = xDoc.CreateAttribute("count");
        attribute.Value = cardsById.Count().ToString();
        cardNode.Attributes.Append(attribute);
        attribute = xDoc.CreateAttribute("id");
        attribute.Value = cardsById.Key;
				cardNode.Attributes.Append(attribute);
				xDoc.DocumentElement.SelectSingleNode("sideboard").AppendChild(cardNode);
			}
      Utils.BackupFile(deckPath, true);
      xDoc.Save(deckPath);
		}

    public void DeleteDeck(string category, string name)
		{
      string deckPath = Path.Combine(SettingsManager.Settings.DeckPath, category + "." + name + DECK_FILE_EXTENSION);
			if(File.Exists(deckPath))
				File.Delete(deckPath);
		}

		public bool DeckExists(string category, string name)
		{
      string deckPath = Path.Combine(SettingsManager.Settings.DeckPath, category + "." + name + DECK_FILE_EXTENSION);
			return File.Exists(deckPath);
		}

    public string ExportDeck(string category, string name, DeckExportParameters parameters)
    {
      string raw = string.Empty;
      if(DeckExists(category, name))
      {
        DeckItem deck = LoadDeck(category, name, parameters.Language);
        switch(parameters.Format)
        {
          case DeckExportFormat.Text:
            raw = ExportDeckToText(deck, parameters.IncludeTags);
            break;
        }
      }
      return raw;
    }

    string ExportDeckToText(DeckItem deck, bool includeTags)
    {
      StringBuilder str = new StringBuilder();
      str.Append("[");
      str.Append(deck.GameCode);
      str.Append("]");
      str.Append(Environment.NewLine);
      str.Append("[");
      str.Append(deck.Category);
      str.Append("]");
      str.Append(Environment.NewLine);
      str.Append("[");
      str.Append(deck.Name);
      str.Append("]");
      str.Append(Environment.NewLine);
      str.Append(Environment.NewLine);
      str.Append("##MAIN## (");
      str.Append(deck.MainCards.Count);
      str.Append(")");
      str.Append(Environment.NewLine);
      ExportDeckSegmentToText(str, deck.MainCards, includeTags);
      str.Append(Environment.NewLine);
      str.Append("##SIDEBOARD## (");
      str.Append(deck.SideboardCards.Count);
      str.Append(")");
      str.Append(Environment.NewLine);
      ExportDeckSegmentToText(str, deck.SideboardCards, includeTags);
      return str.ToString();
    }

    void ExportDeckSegmentToText(StringBuilder str, IEnumerable<CardItem> deckSegment, bool includeTags)
    {
      var cardTypes = servicesProvider.TypesService.GetAll();
      var orderedCards = deckSegment.OrderBy(e => e.Type).ToList();
      var groupedCards = orderedCards.GroupBy(e => cardTypes.Single(t => t.Code == e.TypeCode).Group);
      foreach(var cardByGroupType in groupedCards)
      {
        str.Append(Environment.NewLine);
        str.Append(cardTypes.Single(t => t.Code == cardByGroupType.Key).Name);
        str.Append(" (").Append(cardByGroupType.Count()).Append(")");
        str.Append(Environment.NewLine);
        foreach(var cardById in cardByGroupType.OrderBy(e => e.Name).GroupBy(e => e.Id))
        {
          if(includeTags)
            str.Append("[").Append(cardById.First().Id).Append("] ");
          str.Append(cardById.Count()).Append("x ");
          if(!includeTags)
            str.Append("[").Append(cardById.First().SetCode).Append("] ");
          str.Append(cardById.First().Name);
          str.Append(Environment.NewLine);
        }
      }
    }

    //public void ImportDeckFromText(GameItem gameItem, string text, MappingManager mappingManager)
    //{
    //  DeckItem deck = new DeckItem(gameItem.Code);
    //  deck.Category = "Imported";
    //  deck.Name = "???";

    //  ImportMwsDeck(deck, text, mappingManager);

    //  SaveDeck(deck);
    //}

    public DeckImportStatistics ImportDecksFromFiles(GameInfoItem gameItem, string[] fileNames, CodesMapService mappingManager)
    {
      DeckImportStatistics statistics = new DeckImportStatistics();

      foreach(string fileName in fileNames)
      {
        Dictionary<string, string> discardedLines = new Dictionary<string, string>();
        if(string.Compare(Path.GetExtension(fileName), DECK_FILE_EXTENSION) != 0)
        {
          DeckItem deck = new DeckItem(gameItem.Code);
          deck.Category = "Imported";
          deck.Name = Path.GetFileNameWithoutExtension(fileName);

          ImportMwsDeck(gameItem, deck, File.ReadAllText(fileName), mappingManager, discardedLines);

          SaveDeck(deck);
        }
        else
        {
          File.Copy(fileName, Path.Combine(SettingsManager.Settings.DeckPath, Path.GetFileName(fileName)), true);
        }
        statistics.ImportResults.Add(new DeckImportResult() 
        { 
          FileName = fileName, 
          Successfull = discardedLines.Count == 0, 
          DiscardedLines = discardedLines 
        });
      }
      return statistics;
    }

    void ImportMwsDeck(GameInfoItem gameItem, DeckItem deck, string text, CodesMapService mappingManager, Dictionary<string, string> discardedLines)
    {
      ServicesProvider engServicesProvider = servicesProvider;
      if(engServicesProvider.GameLanguageCode != "eng")
      {
        engServicesProvider = new ServicesProvider("eng", "eng");
        engServicesProvider.LoadGame(gameItem);
      }
      discardedLines.Clear();
      foreach(string line in text.Split(new string[] {Environment.NewLine}, StringSplitOptions.None).
        Select(e => e.Trim()).Where(e => e.Length > 0 && !e.StartsWith("//")))
      {
        string[] lineParts = line.Split(' ');
        if(lineParts.Length < 3)
          continue;

        try
        {
          var cardList = deck.MainCards;
          int partIndex = 0;
          if(lineParts[0] == "SB:")
          {
            partIndex++;
            cardList = deck.SideboardCards;
          }
          int amount;
          if(int.TryParse(lineParts[partIndex++], out amount))
          {
            string mwsSetCode = string.Empty;
            try
            {
              mwsSetCode = lineParts[partIndex++].Replace("[", string.Empty).Replace("]", string.Empty);
            }
            catch
            {
              throw new Exception("Cannot read set code on this line: " + line);
            }
            string cardName = string.Empty;
            try
            {
              cardName = string.Concat(
                lineParts.Skip(partIndex).Where(e => e != "(1)" && e != "(2)" && e != "(3)" && e != "(4)").Select(
                e => string.Concat(e, " ")).ToArray()).TrimEnd();
              cardName = cardName.Split(new string[] { "--" }, StringSplitOptions.None).First();
            }
            catch
            {
              throw new Exception("Cannot read card name on this line: " + line);
            }
            string internalSetCode = mappingManager.GetCode(mwsSetCode);
            if(string.IsNullOrEmpty(internalSetCode))
              throw new Exception("Set code unknown: " + mwsSetCode);
            CardSearchParams p = new CardSearchParams();
            p.Sets.Add(internalSetCode);
            p.Name = cardName;
            p.Language = "ENG";
            p.NameExact = true;

            CardItem cardItem = engServicesProvider.CardsService.SelectCards(p).FirstOrDefault();
            if(cardItem == null)
              throw new Exception("Card name unknown: " + cardName);
            for(int i = 0; i < amount; i++)
              cardList.Add(cardItem.Clone());
          }
          else
          {
            throw new Exception("Cannot read card amount on this line: " + line);
          }
        }
        catch(Exception ex)
        { 
          discardedLines.Add(line, ex.Message);
        }
      }
    }

    void FillDeck(ObservableCollection<CardItem> list, XmlNode deckNode)
    {
      FillDeck(list, deckNode, null);
    }

    void FillDeck(ObservableCollection<CardItem> list, XmlNode deckNode, string language)
		{
      XmlNodeList cardNodes = deckNode.SelectNodes("card");
      CardSearchParams searchParams = new CardSearchParams();
      foreach(XmlNode cardNode in cardNodes)
        searchParams.Ids.Add(cardNode.Attributes["id"].Value);
      if(searchParams.Ids.Count > 0)
      {
        searchParams.Language = language;
        Dictionary<string, CardItem> cardDataById = servicesProvider.CardsService.SelectCards(searchParams).ToDictionary(e => e.Id);
        foreach(XmlNode cardNode in cardNodes)
          for(int i = 0; i < Convert.ToInt32(cardNode.Attributes["count"].Value); i++)
            list.Add(cardDataById[cardNode.Attributes["id"].Value].Clone());
      }
		}

    IEnumerable<string> GetDeckFiles()
    {
      string[] deckFileNames = Directory.GetFiles(SettingsManager.Settings.DeckPath, string.Concat("*.*", DECK_FILE_EXTENSION));
      return deckFileNames.Select(e => Path.GetFileName(e));
    }
	}
}
