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
using PoL.Common;
using System.IO;
using System.Reflection;
using System.Globalization;
using System.Diagnostics;

namespace PoL.Configuration
{
  [Serializable]
  public class Settings
  {
    string playerName;
    string cardPicturesPath;
    string imagesPath;
    string dataPath;
    string savePath;
    string deckPath;
    string logsPath;
    string gameLanguage;
    string clientLanguage;
    string updateUri;
    string chatUri;
    bool animateHand;
    bool mapEnabled;
    bool keepGameLog;
    CardPictureBehavior cardPictureBehavior;
    List<RecentDeck> recentPlayedDecks;
    RecentDeck lastEditedDeck;
    string currentGameCode;
    DeckEditorOrientation deckEditorOrientation;

    [NonSerialized]
    Action keepGameLogChanged;
    [NonSerialized]
    Action clientLanguageChanged;
    [NonSerialized]
    Action gameLanguageChanged;
    [NonSerialized]
    Action animateHandChanged;
    [NonSerialized]
    Action mapEnabledChanged;
    [NonSerialized]
    Action cardPicturesPathChanged;
    [NonSerialized]
    Action cardPictureBehaviorChanged;
    [NonSerialized]
    Action recentPlayedDecksChanged;
    [NonSerialized]
    Action lastEditedDeckChanged;
    [NonSerialized]
    Action currentGameCodeChanged;
    [NonSerialized]
    Action deckEditorOrientationChanged;

    public event Action KeepGameLogChanged
    {
      add { keepGameLogChanged = (Action)Delegate.Combine(keepGameLogChanged, value); }
      remove { keepGameLogChanged = (Action)Delegate.Remove(keepGameLogChanged, value); }
    }

    public event Action DeckEditorOrientationChanged
    {
      add { deckEditorOrientationChanged = (Action)Delegate.Combine(deckEditorOrientationChanged, value); }
      remove { deckEditorOrientationChanged = (Action)Delegate.Remove(deckEditorOrientationChanged, value); }
    }

    public event Action ClientLanguageChanged
    {
      add { clientLanguageChanged = (Action)Delegate.Combine(clientLanguageChanged, value); }
      remove { clientLanguageChanged = (Action)Delegate.Remove(clientLanguageChanged, value); }
    }

    public event Action GameLanguageChanged
    {
      add { gameLanguageChanged = (Action)Delegate.Combine(gameLanguageChanged, value); }
      remove { gameLanguageChanged = (Action)Delegate.Remove(gameLanguageChanged, value); }
    }

    public event Action AnimateHandChanged
    {
      add { animateHandChanged = (Action)Delegate.Combine(animateHandChanged, value); }
      remove { animateHandChanged = (Action)Delegate.Remove(animateHandChanged, value); }
    }

    public event Action MapEnabledChanged
    {
      add { mapEnabledChanged = (Action)Delegate.Combine(mapEnabledChanged, value); }
      remove { mapEnabledChanged = (Action)Delegate.Remove(mapEnabledChanged, value); }
    }

    public event Action CardPicturesPathChanged
    {
      add { cardPicturesPathChanged = (Action)Delegate.Combine(cardPicturesPathChanged, value); }
      remove { cardPicturesPathChanged = (Action)Delegate.Remove(cardPicturesPathChanged, value); }
    }

    public event Action CardPictureBehaviorChanged
    {
      add { cardPictureBehaviorChanged = (Action)Delegate.Combine(cardPictureBehaviorChanged, value); }
      remove { cardPictureBehaviorChanged = (Action)Delegate.Remove(cardPictureBehaviorChanged, value); }
    }

    public event Action RecentPlayedDecksChanged
    {
      add { recentPlayedDecksChanged = (Action)Delegate.Combine(recentPlayedDecksChanged, value); }
      remove { recentPlayedDecksChanged = (Action)Delegate.Remove(recentPlayedDecksChanged, value); }
    }

    public event Action LastEditedDeckChanged
    {
      add { lastEditedDeckChanged = (Action)Delegate.Combine(lastEditedDeckChanged, value); }
      remove { lastEditedDeckChanged = (Action)Delegate.Remove(lastEditedDeckChanged, value); }
    }

    public event Action CurrentGameCodeChanged
    {
      add { currentGameCodeChanged = (Action)Delegate.Combine(currentGameCodeChanged, value); }
      remove { currentGameCodeChanged = (Action)Delegate.Remove(currentGameCodeChanged, value); }
    }

    internal Settings()
    {
      string currentDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
      this.imagesPath = Path.Combine(currentDir, "graphics");
      this.dataPath = Path.Combine(currentDir, "data");
      this.savePath = Path.Combine(currentDir, "save");
      this.deckPath = Path.Combine(currentDir, "decks");
      this.cardPicturesPath = Path.Combine(currentDir, "pics");
      this.logsPath = Path.Combine(currentDir, "logs");
      this.mapEnabled = false;
      this.keepGameLog = false;
      this.playerName = "The mage";
      this.AvatarPath = string.Empty;
      this.PlayerMessage = "Play on Line!";
      this.clientLanguage = CultureInfo.CurrentCulture.ThreeLetterISOLanguageName == "ita" ? "ita" : "eng";
      this.gameLanguage = CultureInfo.CurrentCulture.ThreeLetterISOLanguageName == "ita" ? "ita" : "eng";
      this.animateHand = false;
      this.cardPictureBehavior = CardPictureBehavior.Crop;
      this.recentPlayedDecks = new List<RecentDeck>();
      this.lastEditedDeck = new RecentDeck();
      this.ListenPort = 8668;
      this.ConnectPort = 8668;
      this.updateUri = @"http://polthegame.altervista.org/files/";
      this.chatUri = @"http://polthegame.altervista.org/chat/";
      this.currentGameCode = "mtg";
      this.deckEditorOrientation = DeckEditorOrientation.Vertical;
    }

    public string LogsPath
    {
      get
      {
#if DEBUG
        if(string.Compare(Environment.MachineName, "pew-dev24", true) == 0)
          return @"D:\Source Code\Training\PoL\src\logs";
        else if(string.Compare(Environment.MachineName, "linux", true) == 0 ||
          string.Compare(Environment.MachineName, "dhcppc0", true) == 0)
          return @"/home/rupert/tmp/src/logs";
        else
          return @"D:\Programmazione\PoL\src\logs";
#else
        return logsPath;
#endif
      }
    }

    public string ImagesPath 
    {
      get
      {
#if DEBUG
        if(string.Compare(Environment.MachineName, "pew-dev24", true) == 0)
          return @"D:\Source Code\Training\PoL\src\graphics";
        else if(string.Compare(Environment.MachineName, "linux", true) == 0 ||
          string.Compare(Environment.MachineName, "dhcppc0", true) == 0) 
          return @"/home/rupert/tmp/src/graphics";
        else
          return @"D:\Programmazione\PoL\src\graphics";
#else
        return imagesPath;
#endif
      }
    }

    public string DataPath 
    { 
      get
      {
#if DEBUG
        if(string.Compare(Environment.MachineName, "pew-dev24", true) == 0)
          return @"D:\Source Code\Training\PoL\src\data";
        else if(string.Compare(Environment.MachineName, "linux", true) == 0 ||
          string.Compare(Environment.MachineName, "dhcppc0", true) == 0) 
          return @"/home/rupert/tmp/src/data";
        else
          return @"D:\Programmazione\PoL\src\data";
#else
        return dataPath;
#endif
      }
    }

    public string SavePath
    {
      get
      {
#if DEBUG
        if(string.Compare(Environment.MachineName, "pew-dev24", true) == 0)
          return @"D:\Source Code\Training\PoL\src\save";
        else if(string.Compare(Environment.MachineName, "linux", true) == 0 ||
          string.Compare(Environment.MachineName, "dhcppc0", true) == 0) 
          return @"/home/rupert/tmp/src/save";
        else
          return @"D:\Programmazione\PoL\src\save";
#else
        return savePath;
#endif
      }
    }

    public string DeckPath
    {
      get
      {
#if DEBUG
        if(string.Compare(Environment.MachineName, "pew-dev24", true) == 0)
          return @"D:\Source Code\Training\PoL\src\decks";
        else if(string.Compare(Environment.MachineName, "linux", true) == 0 ||
          string.Compare(Environment.MachineName, "dhcppc0", true) == 0) 
          return @"/home/rupert/tmp/src/decks";
        else
          return @"D:\Programmazione\PoL\src\decks";
#else
        return deckPath;
#endif
      }
    }

    public string CardPicturesPath
    {
      get
      {
#if DEBUG
        if(string.Compare(Environment.MachineName, "pew-dev24", true) == 0)
          return @"D:\Source Code\Training\PoL\src\pics";
        else if(string.Compare(Environment.MachineName, "linux", true) == 0 ||
          string.Compare(Environment.MachineName, "dhcppc0", true) == 0) 
          return @"/home/rupert/tmp/src/pics";
        else
          return @"D:\Programmazione\PoL\src\pics";
#else
        return cardPicturesPath;
#endif
      }
      set
      {
        if(value != cardPicturesPath)
        {
          cardPicturesPath = value;
          OnCardPicturesPathChanged();
        }
      }
    }

    public DeckEditorOrientation DeckEditorOrientation
    {
      get { return deckEditorOrientation; }
      set
      {
        if(value != deckEditorOrientation)
        {
          deckEditorOrientation = value;
          OnDeckEditorOrientationChanged();
        }
      }
    }

    public bool MapEnabled
    {
      get { return mapEnabled; }
      set
      {
        if(value != mapEnabled)
        {
          mapEnabled = value;
          OnMapEnabledChanged();
        }
      }
    }

    public bool KeepGameLog
    {
      get { return keepGameLog; }
      set
      {
        if(value != keepGameLog)
        {
          keepGameLog = value;
          OnKeepGameLogChanged();
        }
      }
    }

    public string AvatarPath { get; set; }

#if DEBUG
    static string debugPlayerName = "Player n." + Process.GetProcessesByName("PoL.WinFormsView").Length.ToString();
#endif
    public string PlayerName
    {
      get
      {
#if DEBUG
        return debugPlayerName;
#else
        return playerName;
#endif
      }
      set
      {
        if(value != playerName)
        {
          playerName = value;
        }
      }
    }

    public string PlayerMessage { get; set; }

    public bool AnimateHand
    {
      get { return animateHand; }
      set
      {
        if(value != animateHand)
        {
          animateHand = value;
          OnAnimateHandChanged();
        }
      }
    }

    public string ClientLanguage
    {
      get { return clientLanguage; }
      set
      {
        if(value != clientLanguage)
        {
          clientLanguage = value;
          OnClientLanguageChanged();
        }
      }
    }

    public string GameLanguage
    {
      get { return gameLanguage; }
      set
      {
        if(value != gameLanguage)
        {
          gameLanguage = value;
          OnGameLanguageChanged();
        }
      }
    }

    public CardPictureBehavior CardPictureBehavior
    {
      get { return cardPictureBehavior; }
      set
      {
        if(value != cardPictureBehavior)
        {
          cardPictureBehavior = value;
          OnCardPictureBehaviorChanged();
        }
      }
    }

    public List<RecentDeck> RecentPlayedDecks
    {
      get { return recentPlayedDecks; }
      set
      {
        recentPlayedDecks = value;
        OnRecentPlayedDecksChanged();
      }
    }

    public RecentDeck LastEditedDeck
    {
      get { return lastEditedDeck; }
      set
      {
        lastEditedDeck = value;
        OnLastEditedDeckChanged();
      }
    }

    public ushort ListenPort { get; set; }

    public ushort ConnectPort { get; set; }

    public string UpdateUri
    {
      get { return updateUri; }
    }

    public string ChatUri
    {
      get { return chatUri; }
    }

    public string CurrentGameCode
    {
      get { return currentGameCode; }
      set
      {
        currentGameCode = value;
        OnCurrentGameCodeChanged();
      }
    }

    void OnDeckEditorOrientationChanged()
    {
      if(deckEditorOrientationChanged != null)
        deckEditorOrientationChanged();
    }

    void OnAnimateHandChanged()
    {
      if(animateHandChanged != null)
        animateHandChanged();
    }

    void OnGameLanguageChanged()
    {
      if(gameLanguageChanged != null)
        gameLanguageChanged();
    }

    void OnClientLanguageChanged()
    {
      if(clientLanguageChanged != null)
        clientLanguageChanged();
    }

    void OnMapEnabledChanged()
    {
      if(mapEnabledChanged != null)
        mapEnabledChanged();
    }

    void OnKeepGameLogChanged()
    {
      if(keepGameLogChanged != null)
        keepGameLogChanged();
    }

    void OnCardPicturesPathChanged()
    {
      if(cardPicturesPathChanged != null)
        cardPicturesPathChanged();
    }

    void OnCardPictureBehaviorChanged()
    {
      if(cardPictureBehaviorChanged != null)
        cardPictureBehaviorChanged();
    }

    void OnRecentPlayedDecksChanged()
    {
      if(recentPlayedDecksChanged != null)
        recentPlayedDecksChanged();
    }

    void OnLastEditedDeckChanged()
    {
      if(lastEditedDeckChanged != null)
        lastEditedDeckChanged();
    }

    void OnCurrentGameCodeChanged()
    {
      if(currentGameCodeChanged != null)
        currentGameCodeChanged();
    }
  }

  [Serializable]
  public class RecentDeck
  {
    public string Name { get; set; }
    public string Category { get; set; }
  }

  public enum DeckEditorOrientation
  {
    Horizontal,
    Vertical
  }
}
