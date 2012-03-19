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
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Security.Cryptography;
using System.Security;
using System.Runtime.InteropServices;
using System.Drawing;

using Patterns.Command;
using PoL.Common;
using PoL.Models;
using PoL.Logic.Views;
using PoL.Logic.Commands.Game;
using Patterns.MVC;
using PoL.Models.Game;
using PoL.Services.DataEntities;
using Patterns;
using Patterns.ComponentModel;
using PoL.Configuration;
using PoL.Services;
using System.Diagnostics;

namespace PoL.Logic.Controllers
{
  public class GameController : BaseController<GameModel, IGameView>, IGameController, IDisposable
  {
    GameCommandHandler gameCommandHandler;
    CryptoDataSaver gameSaver;
    ServicesProvider servicesProvider;
    GameType gameType;
    string currentMatchId = string.Empty;
    Dictionary<string, SectorActionsSupporting> sectorActionSupporting = new Dictionary<string, SectorActionsSupporting>();
    TextWriterTraceListener logTracer;

    public event EventHandler ShowOptionsRequested;

    public GameController(GameCommandHandler gameCommandHandler, GameModel gameModel, IGameView gameView,
      List<PlayerAccountData> players, GameType gameType, ServicesProvider servicesProvider, bool initModel)
      : base(gameCommandHandler.BaseCommandHandler, gameModel, gameView)
    {
      this.gameCommandHandler = gameCommandHandler;
      this.servicesProvider = servicesProvider;
      this.gameType = gameType;

      gameCommandHandler.CommandError += new Action<Exception>(gameCommandHandler_CommandError);

      if(initModel)
        InitModel(players);

      Init(players.Select(e => e.Password).ToList());
    }

    public GameModel GameModel
    {
      get { return Model; }
    }

    void gameCommandHandler_CommandError(Exception ex)
    {
      HandleException(ex);
    }

    void InitModel(List<PlayerAccountData> players)
    {
      Model.Players.Clear();
      Model.Lookups.Clear();
      Model.Commands.Clear();
      Model.Console.Messages.Clear();
      
      // commands
      foreach(BaseItem commandItem in servicesProvider.CommandsService.GetAll())
      {
        CommandModel commandModel = new CommandModel(commandItem.Code, commandItem);
        Model.Commands.Add(commandModel);
      }

      for(int i = 0; i < players.Count; i++)
      {
        // players
        PlayerModel player = new PlayerModel(Model, players[i].Info.NickName, players[i].Info, players[i].Deck, players[i].Password);
        player.Points.Value = Model.GameItem.StartPoints;
        Model.Players.Add(player);

        // sectors
        foreach(SectorItem sectorItem in servicesProvider.SectorsService.GetAll())
        {
          SectorModel sector = new SectorModel(string.Concat(player.Key, sectorItem.Code), sectorItem);
          player.Sectors.Add(sector);

          // deck?
          if(sectorItem.Code == SystemSectors.DECK.ToString())
          {
            List<Model> cards = new List<Model>();
            for(int cardIndex = 0; cardIndex < players[i].Deck.MainCards.Count; cardIndex++)
            {
              CardModel card = new CardModel(players[i].Deck.MainCards[cardIndex].UniqueID, player, players[i].Deck.MainCards[cardIndex], false);
              cards.Add(card);
            }
            sector.Cards.AddRange(cards);
          }
        }

        // num counters
        foreach(var numCounterItem in servicesProvider.NumCountersService.GetAll())
        {
          NumCounterModel numCounter = new NumCounterModel(string.Concat(player.Key, numCounterItem.Code), numCounterItem);
          player.NumCounters.Add(numCounter);
        }

        // initial filling?
        foreach(StartSectorFillingRule rule in Model.GameItem.StartSectorFillingRules)
        {
          SectorModel sourceSector = player.Sectors.Cast<SectorModel>().Single(e => e.Data.Code == rule.SourceSector);
          SectorModel destinationSector = player.Sectors.Cast<SectorModel>().Single(e => e.Data.Code == rule.DestinationSector);
          foreach(CardModel card in sourceSector.Cards.Take(rule.CardAmount).ToArray())
          {
            sourceSector.Cards.Remove(card);
            destinationSector.Cards.Add(card);
          }
        }
      }
    }

    void Init(List<string> passwords)
    {
      DateTime now = DateTime.Now;
      currentMatchId = string.Concat(now.Year.ToString().PadLeft(4, '0'), now.Month.ToString().PadLeft(2, '0'), now.Day.ToString().PadLeft(2, '0'), "_",
        now.Hour.ToString().PadLeft(2, '0'), now.Minute.ToString().PadLeft(2, '0'), now.Second.ToString().PadLeft(2, '0'));

      logTracer = new TextWriterTraceListener(Path.Combine(SettingsManager.Settings.LogsPath, currentMatchId + ".txt"));

      SettingsManager.Settings.GameLanguageChanged += new Action(Settings_GameLanguageChanged);
      SettingsManager.Settings.CardPictureBehaviorChanged += new Action(Settings_CardPictureBehaviorChanged);

      this.gameSaver = new CryptoDataSaver(passwords);
      this.View.RegisterController(this);

      View.EnableRestartGame(gameType == GameType.Host);

      bool saveEnabled = passwords.All(e => e.Length > 0);
      View.EnableSave(saveEnabled && gameType == GameType.Host);
      if(gameType != GameType.Solitaire)
        Model.Console.WriteLine(MessageCategory.Warning, servicesProvider.SystemStringsService.GetString("GAME", saveEnabled ? 
          "MSG_SAVE_ENABLED" : "MSG_SAVE_DISABLED"));

      // commandHandler
      gameCommandHandler.BaseCommandHandler.CommandHistoryChanged += new EventHandler(CommandHandler_CommandHistoryChanged);
      gameCommandHandler.ClientDisconnected += new Action<string>(CommandHandler_ClientDisconnected);
      View.EnableUndo(gameCommandHandler.BaseCommandHandler.CanUndo);
      View.EnableRedo(gameCommandHandler.BaseCommandHandler.CanRedo);

      View.BeginLoadGame(gameType == GameType.Solitaire);
      try
      {
        Attach_Game();
      }
      finally
      {
        View.EndLoadGame();
      }
    }

    void Settings_CardPictureBehaviorChanged()
    {
      int cardCount = Model.Players.Cast<PlayerModel>().Sum(ply => ply.Sectors.Cast<SectorModel>().Sum(sec => sec.Cards.Count));
      View.ProgressValue = 0;
      View.ProgressStep = 1;
      View.ProgressMax = cardCount;
      View.ProgressMessage = string.Empty;
      View.ShowProgress(true);
      try
      {
        foreach(PlayerModel player in Model.Players)
          foreach(SectorModel sector in player.Sectors)
            foreach(CardModel card in sector.Cards)
            {
              card.UpdateData(card.Data);
              View.ProgressPerformStep();
              View.ProgressRefresh();
            }
      }
      finally
      {
        View.ShowProgress(false);
      }
    }

    void Settings_GameLanguageChanged()
    {
      int cardCount = Model.Players.Cast<PlayerModel>().Sum(ply => ply.Sectors.Cast<SectorModel>().Sum(sec => sec.Cards.Count));
      View.ProgressValue = 0;
      View.ProgressStep = 1;
      View.ProgressMax = cardCount;
      View.ProgressMessage = string.Empty;
      View.ShowProgress(true);
      string progressMessage = servicesProvider.SystemStringsService.GetString("GAME", "MSG_UPDATING");
      try
      {
        foreach(CommandModel command in Model.Commands)
        {
          BaseItem commandItem = servicesProvider.CommandsService.GetByCode(command.Data.Code);
          command.UpdateData(commandItem);
        }

        foreach(PlayerModel player in Model.Players)
          foreach(SectorModel sector in player.Sectors)
          {
            SectorItem localizedSectorItem = servicesProvider.SectorsService.GetByCode(sector.Data.Code);
            sector.UpdateData(localizedSectorItem);
            if(sector.Cards.Count > 0)
            {
              View.ProgressMessage = progressMessage.Replace(
                "#player#", player.Info.NickName).Replace("#sector#", sector.Data.Name);
              LocalizeCards(sector.Cards.Cast<CardModel>(), true);
            }
          }
      }
      finally
      {
        View.ShowProgress(false);
      }
    }

    void LocalizeCards(IEnumerable<CardModel> cards, bool updateViewProgress)
    {
      CardSearchParams searchParams = new CardSearchParams();
      searchParams.Ids.AddRange(cards.Select(card => card.Data.Id).Distinct());
      foreach(CardItem localizedCardData in servicesProvider.CardsService.SelectCards(searchParams))
        foreach(CardModel card in cards.Where(card => card.Data.Id == localizedCardData.Id))
        {
          card.UpdateData(localizedCardData);
          if(updateViewProgress)
          {
            View.ProgressPerformStep();
            View.ProgressRefresh();
          }
        }
    }

    void Sectors_CollectionChanged(object sender, CollectionChangedEventArgs e)
    {
      SectorModel sector = null;
      switch(e.Action)
      {
        case CollectionChangedAction.Add:
          sector = (SectorModel)e.NewItems[0];
          Attach_Sector(sector);          
          break;
      }
    }

    void Points_Changed(object sender, ChangedEventArgs<int> e)
    {
      ObservableProperty<int, PlayerModel> points = (ObservableProperty<int, PlayerModel>)sender;
      View.SetPlayerPoints(points.Owner.Key, e.NewValue);
    }

    void NumCounterValue_Changed(object sender, ChangedEventArgs<int> e)
    {
      ObservableProperty<int, NumCounterModel> val = (ObservableProperty<int, NumCounterModel>)sender;
      View.SetNumCounterValue(val.Owner.Key, e.NewValue);
    }

    void Sector_DataChanged(object sender, EventArgs e)
    {
      SectorModel sector = (SectorModel)sender;
      View.UpdateSector(sector.Key, sector.Data);
    }

    void NumCounter_DataChanged(object sender, EventArgs e)
    {
      NumCounterModel numCounter = (NumCounterModel)sender;
      View.UpdateNumCounter(numCounter.Key, numCounter.Data);
    }

    void Card_DataChanged(object sender, EventArgs args)
    {
      CardModel card = (CardModel)sender;
      View.UpdateCard(card.Key, card.Data);
    }

    void CommandHandler_ClientDisconnected(string name)
    {
      RemovePlayerCommand cmd = new RemovePlayerCommand(Model);
      cmd.Arguments = new MultipleKeysArguments() { Keys = Enumerable.Repeat(name, 1).ToList() };
      gameCommandHandler.Execute(cmd);
    }

    void CommandHandler_CommandHistoryChanged(object sender, EventArgs e)
    {
      View.EnableUndo(((CommandHandler)sender).CanUndo);
      View.EnableRedo(((CommandHandler)sender).CanRedo);
    }

    void CardDisplay_VisibleChanged(object sender, ChangedEventArgs<bool> e)
    {
      ObservableProperty<bool, CardDisplayModel> prop = (ObservableProperty<bool, CardDisplayModel>)sender;
      if(prop.Value)
        View.DisplayCards(Model.CardDisplay.Cards);
      else
        View.CloseDisplay();
    }

    void Lookups_CollectionChanged(object sender, CollectionChangedEventArgs args)
    {
      LookupModel lookup = null;
      switch(args.Action)
      {
        case CollectionChangedAction.Add:
          lookup = (LookupModel)args.NewItems[0];
          Attach_Lookup(lookup);
          break;
        case CollectionChangedAction.Remove:
          lookup = (LookupModel)args.OldItems[0];
          Detach_Lookup(lookup);
          break;
      }
    }

    void ConsoleMessages_CollectionChanged(object sender, CollectionChangedEventArgs e)
    {
      switch(e.Action)
      {
        case CollectionChangedAction.Add:
          {
            TextMessage msg = (TextMessage)e.NewItems[0];
            View.AddConsoleMessage(msg);
            if(SettingsManager.Settings.KeepGameLog)
            {
              logTracer.WriteLine(msg.Content);
              logTracer.Flush();
            }
          }
          break;
      }
    }

    void Cards_CollectionChanged(object sender, CollectionChangedEventArgs args)
    {
      ModelCollection cards = (ModelCollection)sender;

      IEnumerable<CardModel> items = null;
      switch(args.Action)
      {
        case CollectionChangedAction.Add:
          items = args.NewItems.Cast<CardModel>();
          Attach_Cards(items, Enumerable.Range(args.StartIndex, items.Count()));
          break;
        case CollectionChangedAction.Remove:
          items = args.OldItems.Cast<CardModel>();
          Detach_Cards(items, (SectorModel)cards.Container, true);
          break;
        case CollectionChangedAction.Move:
          View.MoveCard(((CardModel)args.OldItems[0]).Key, args.StartIndex);
          break;
        case CollectionChangedAction.Replace:
          throw new NotSupportedException("Replace CollectionChangedAction not supported!");
        case CollectionChangedAction.Reset:
          // cleared or shuffled
          if(args.OldItems != null)
          {
            // cleared
            SectorModel sector = (SectorModel)cards.Container;
            items = args.OldItems.Cast<CardModel>();
            Detach_Cards(items, sector, false);
          }
          View.ClearCards(cards.Container.Key);
          View.AddCards(cards.Container.Key, cards.ToDictionary(c => c.Key, c => CardViewItem.FromModel((CardModel)c, -1)));
          break;
      }
    }

    void LookupCards_CollectionChanged(object sender, CollectionChangedEventArgs e)
    {
      ModelCollection lookupKeys = (ModelCollection)sender;
      LookupModel lookup = (LookupModel)lookupKeys.Container;

      LookupCardModel lookupCard = null;
      switch(e.Action)
      {
        case CollectionChangedAction.Add:
          lookupCard = (LookupCardModel)e.NewItems[0];
          View.AddLookupCard(lookup.Key, lookupCard.Key, lookupCard.Hidden, Model.GetCardByKey(lookupCard.Key).Data, e.StartIndex);
          break;
        case CollectionChangedAction.Remove:
          lookupCard = (LookupCardModel)e.OldItems[0];
          View.RemoveLookupCard(lookup.Key, lookupCard.Key);
          break;
        case CollectionChangedAction.Move:
          lookupCard = (LookupCardModel)e.OldItems[0];
          View.MoveLookupCard(lookup.Key, lookupCard.Key, e.StartIndex);
          break;
        case CollectionChangedAction.Reset:
          View.ClearLookupCards(lookup.Key);
          foreach(LookupCardModel c in lookup.Cards)
            View.AddLookupCard(lookup.Key, c.Key, c.Hidden, Model.GetCardByKey(c.Key).Data, -1);
          break;
      }
    }

    void Tokens_CollectionChanged(object sender, CollectionChangedEventArgs e)
    {
      TokenModel token = null;
      switch(e.Action)
      {
        case CollectionChangedAction.Add:
          token = (TokenModel)e.NewItems[0];
          Attach_Token(token);
          break;
        case CollectionChangedAction.Remove:
          token = (TokenModel)e.OldItems[0];
          Detach_Token(token);
          break;
      }
    }

    void EnableSectorActions(SectorModel sector)
    {
      View.EnableSectorAction(sector.Key, SectorActions.StraightAllCards, sectorActionSupporting[sector.Key].Supports(SectorActions.StraightAllCards) &&
        sector.Cards.Count > 0);
      View.EnableSectorAction(sector.Key, SectorActions.ChangeAllCardsCharacteristics, sectorActionSupporting[sector.Key].Supports(SectorActions.ChangeAllCardsCharacteristics) &&
       sector.Cards.Count > 0);
      View.EnableSectorAction(sector.Key, SectorActions.Shuffle, sectorActionSupporting[sector.Key].Supports(SectorActions.Shuffle) &&
        sector.Cards.Count > 0);
      View.EnableSectorAction(sector.Key, SectorActions.MoveAllCards, sectorActionSupporting[sector.Key].Supports(SectorActions.MoveAllCards) && 
        sector.Cards.Count > 0);
      View.EnableSectorAction(sector.Key, SectorActions.MoveCardsToDefaultSector, sectorActionSupporting[sector.Key].Supports(SectorActions.MoveCardsToDefaultSector) && 
        sector.Cards.Count > 0);
      View.EnableSectorAction(sector.Key, SectorActions.MoveTopCards, sectorActionSupporting[sector.Key].Supports(SectorActions.MoveTopCards) &&
        sector.Cards.Count > 0);
      View.EnableSectorAction(sector.Key, SectorActions.MoveRandomCards, sectorActionSupporting[sector.Key].Supports(SectorActions.MoveRandomCards) && 
        sector.Cards.Count > 0);
      View.EnableSectorAction(sector.Key, SectorActions.MoveCards, sectorActionSupporting[sector.Key].Supports(SectorActions.MoveCards) && 
        sector.Cards.Count > 0);
      View.EnableSectorAction(sector.Key, SectorActions.Show, sectorActionSupporting[sector.Key].Supports(SectorActions.Show) && 
        sector.Cards.Count > 0);
      View.EnableSectorAction(sector.Key, SectorActions.ShowTop, sectorActionSupporting[sector.Key].Supports(SectorActions.ShowTop) &&
        sector.Cards.Count > 0);
      View.EnableSectorAction(sector.Key, SectorActions.ShowRandomCards, sectorActionSupporting[sector.Key].Supports(SectorActions.ShowRandomCards) && 
        sector.Cards.Count > 0);
      View.EnableSectorAction(sector.Key, SectorActions.Watch, sectorActionSupporting[sector.Key].Supports(SectorActions.Watch) && 
        sector.Cards.Count > 0);
      View.EnableSectorAction(sector.Key, SectorActions.Mulligan, sectorActionSupporting[sector.Key].Supports(SectorActions.Mulligan));
    }

    void Attach_Game()
    {
      sectorActionSupporting.Clear();

      AttachGameEvents(Model, true);

      // pre load players for load game support:
      // all players must be present before card load (card's owner/controller must be present)
      foreach(PlayerModel player in Model.Players)
      {
        bool isActive = player.Key == Model.ActivePlayer.Key;
        View.AddPlayer(player.Key, player.Info, isActive, isActive || gameType == GameType.Solitaire);
      }

      foreach(PlayerModel player in Model.Players)
        Attach_Player(player);
      foreach(LookupModel lookup in Model.Lookups)
        Attach_Lookup(lookup);
      foreach(TextMessage msg in Model.Console.Messages)
        View.AddConsoleMessage(msg);      
    }

    void Attach_Player(PlayerModel player)
    {
      bool isActive = player.Key == Model.ActivePlayer.Key;
      //View.AddPlayer(player.Key, player.Info, isActive, isActive || gameType == GameType.Solitaire);
      View.EnablePlayerChangePoints(player.Key, gameType == GameType.Solitaire || isActive);

      View.SetPlayerPoints(player.Key, player.Points.Value);
      foreach(SectorModel sector in player.Sectors)
        Attach_Sector(sector);
      foreach(NumCounterModel numCounter in player.NumCounters)
        Attach_NumCounter(numCounter);

      AttachPlayerEvents(player, true);
    }

    void Attach_NumCounter(NumCounterModel numCounter)
    {
      PlayerModel player = (PlayerModel)numCounter.Parent;

      View.AddNumCounter(player.Key, numCounter.Key, numCounter.Data);

      AttachNumCounterEvents(numCounter, true);
    }

    void Attach_Sector(SectorModel sector)
    {
      PlayerModel player = (PlayerModel)sector.Parent;

      SectorActionsSupporting supporting = new SectorActionsSupporting(sector.Data, gameType, player.Key == Model.ActivePlayer.Key);
      sectorActionSupporting.Add(sector.Key, supporting);

      View.AddSector(player.Key, sector.Key, sector.Data, supporting);

      View.EnableSectorAction(sector.Key, SectorActions.CreatePawn, supporting.Supports(SectorActions.CreatePawn));

      EnableSectorActions(sector);

      if(sector.Cards.Count > 0)
        Attach_Cards(sector.Cards.Cast<CardModel>(), Enumerable.Repeat(-1, sector.Cards.Count));

      AttachSectorEvents(sector, true);
    }

    void Attach_Lookup(LookupModel lookup)
    {
      View.OpenSectorLookup(lookup.Key, lookup.Rules, lookup.Player.Key, lookup.ReadOnly, lookup.Sector.Key);
      lookup.Cards.CollectionChanged += new CollectionChangedEventHandler(LookupCards_CollectionChanged);
      foreach(LookupCardModel c in lookup.Cards)
        View.AddLookupCard(lookup.Key, c.Key, c.Hidden, Model.GetCardByKey(c.Key).Data, -1);
    }

    void Detach_Lookup(LookupModel lookup)
    {
      View.CloseSectorLookup(lookup.Key);

      lookup.Cards.CollectionChanged -= new CollectionChangedEventHandler(LookupCards_CollectionChanged);
    }

    void Attach_Card(CardModel card, int index)
    {
      Attach_Cards(Enumerable.Repeat(card, 1), Enumerable.Repeat(index, 1));
    }

    void Attach_Cards(IEnumerable<CardModel> cards, IEnumerable<int> indexes)
    {
      SectorModel sector = (SectorModel)cards.First().Parent;

      var cardDictionary = new Dictionary<string, CardViewItem>();
      for(int i = 0; i < cards.Count(); i++)
        cardDictionary.Add(cards.ElementAt(i).Key, CardViewItem.FromModel(cards.ElementAt(i), indexes.ElementAt(i)));
      View.AddCards(sector.Key, cardDictionary);
      for(int i = 0; i < cards.Count(); i++)
        View.EnableCardRotation(cards.ElementAt(i).Key, sector.Data.Behavior == SectorBehavior.StaticFree &&
          (gameType == GameType.Solitaire || ((PlayerModel)cards.ElementAt(i).Parent.Parent).Key == Model.ActivePlayer.Key));

      EnableSectorActions(sector);

      for(int i = 0; i < cards.Count(); i++)
        AttachCardEvents(cards.ElementAt(i), true);

      for(int i = 0; i < cards.Count(); i++)
        foreach(TokenModel token in cards.ElementAt(i).Tokens)
          Attach_Token(token);
    }

    void Detach_Card(CardModel card, SectorModel oldSector)
    {
      Detach_Cards(Enumerable.Repeat(card, 1), oldSector, true);
    }

    void Detach_Cards(IEnumerable<CardModel> cards, SectorModel oldSector, bool notifyView)
    {
      if(notifyView)
        foreach(var card in cards)
          View.RemoveCard(card.Key);

      EnableSectorActions(oldSector);

      foreach(var card in cards)
        AttachCardEvents(card, false);
    }

    void Attach_Token(TokenModel token)
    {
      CardModel card = (CardModel)token.Parent;
      AttachTokenEvents(token, true);
      View.AddToken(card.Key, token.Key, token.Text.Value, token.Amount.Value, token.Color.Value);
    }

    void Detach_Token(TokenModel token)
    {
      AttachTokenEvents(token, false);
      View.RemoveToken(token.Key);
    }

    void AttachGameEvents(GameModel game, bool attach)
    {
      if(attach)
      {
        Model.RestartNotified += new EventHandler(GameModel_RestartNotified);
        Model.Lookups.CollectionChanged += new CollectionChangedEventHandler(Lookups_CollectionChanged);
        Model.Console.Messages.CollectionChanged += new CollectionChangedEventHandler(ConsoleMessages_CollectionChanged);
        Model.CardDisplay.Visible.Changed += new EventHandler<ChangedEventArgs<bool>>(CardDisplay_VisibleChanged);
      }
      else
      {
        Model.RestartNotified -= new EventHandler(GameModel_RestartNotified);
        Model.Lookups.CollectionChanged -= new CollectionChangedEventHandler(Lookups_CollectionChanged);
        Model.Console.Messages.CollectionChanged -= new CollectionChangedEventHandler(ConsoleMessages_CollectionChanged);
        Model.CardDisplay.Visible.Changed -= new EventHandler<ChangedEventArgs<bool>>(CardDisplay_VisibleChanged);
      }
    }

    void AttachPlayerEvents(PlayerModel player, bool attach)
    {
      if(attach)
      {
        player.Points.Changed += new EventHandler<ChangedEventArgs<int>>(Points_Changed);
        player.Sectors.CollectionChanged += new CollectionChangedEventHandler(Sectors_CollectionChanged);
      }
      else
      {
        player.Points.Changed -= new EventHandler<ChangedEventArgs<int>>(Points_Changed);
        player.Sectors.CollectionChanged -= new CollectionChangedEventHandler(Sectors_CollectionChanged);
      }
    }

    void AttachSectorEvents(SectorModel sector, bool attach)
    {
      if(attach)
      {
        sector.DataChanged += new EventHandler(Sector_DataChanged);
        sector.Cards.CollectionChanged += new CollectionChangedEventHandler(Cards_CollectionChanged);
      }
      else
      {
        sector.DataChanged -= new EventHandler(Sector_DataChanged);
        sector.Cards.CollectionChanged -= new CollectionChangedEventHandler(Cards_CollectionChanged);
      }
    }

    void AttachNumCounterEvents(NumCounterModel numCounter, bool attach)
    {
      if(attach)
      {
        numCounter.DataChanged += new EventHandler(NumCounter_DataChanged);
        numCounter.Value.Changed += new EventHandler<ChangedEventArgs<int>>(NumCounterValue_Changed);
      }
      else
      {
        numCounter.DataChanged -= new EventHandler(NumCounter_DataChanged);
        numCounter.Value.Changed -= new EventHandler<ChangedEventArgs<int>>(NumCounterValue_Changed);
      }
    }

    void AttachCardEvents(CardModel card, bool attach)
    {
      if(attach)
      {
        card.Visibility.Changed += new EventHandler<ChangedEventArgs<CardVisibility>>(CardVisibility_Changed);
        card.Reversed.Changed += new EventHandler<ChangedEventArgs<bool>>(CardReversed_Changed);
        card.Locked.Changed += new EventHandler<ChangedEventArgs<bool>>(CardLockState_Changed);
        card.Rotated.Changed += new EventHandler<ChangedEventArgs<bool>>(CardRotation_Changed);
        card.Position.Changed += new EventHandler<ChangedEventArgs<CardPosition>>(CardPosition_Changed);
        card.DataChanged += new EventHandler(Card_DataChanged);
        card.CustomCharacteristics.Changed += new EventHandler<ChangedEventArgs<string>>(CardCustomCharacteristics_Changed);
        card.Tokens.CollectionChanged += new CollectionChangedEventHandler(Tokens_CollectionChanged);
      }
      else
      {
        card.Visibility.Changed -= new EventHandler<ChangedEventArgs<CardVisibility>>(CardVisibility_Changed);
        card.Reversed.Changed -= new EventHandler<ChangedEventArgs<bool>>(CardReversed_Changed);
        card.Rotated.Changed -= new EventHandler<ChangedEventArgs<bool>>(CardRotation_Changed);
        card.Position.Changed -= new EventHandler<ChangedEventArgs<CardPosition>>(CardPosition_Changed);
        card.DataChanged -= new EventHandler(Card_DataChanged);
        card.CustomCharacteristics.Changed -= new EventHandler<ChangedEventArgs<string>>(CardCustomCharacteristics_Changed);
        card.Tokens.CollectionChanged -= new CollectionChangedEventHandler(Tokens_CollectionChanged);
      }
    }

    void AttachTokenEvents(TokenModel token, bool attach)
    {
      if(attach)
      {
        token.Text.Changed += new EventHandler<ChangedEventArgs<string>>(TokenText_Changed);
        token.Color.Changed += new EventHandler<ChangedEventArgs<TokenColor>>(TokenColor_Changed);
        token.Amount.Changed += new EventHandler<ChangedEventArgs<int>>(TokenAmount_Changed);
      }
      else
      {
        token.Text.Changed -= new EventHandler<ChangedEventArgs<string>>(TokenText_Changed);
        token.Color.Changed -= new EventHandler<ChangedEventArgs<TokenColor>>(TokenColor_Changed);
        token.Amount.Changed -= new EventHandler<ChangedEventArgs<int>>(TokenAmount_Changed);
      }
    }

    void AttachAllEvents(bool attach)
    {
      AttachGameEvents(Model, attach);
      foreach(PlayerModel player in Model.Players)
      {
        AttachPlayerEvents(player, attach);
        foreach(NumCounterModel numCounter in player.NumCounters)
          AttachNumCounterEvents(numCounter, attach);
        foreach(SectorModel sector in player.Sectors)
        {
          AttachSectorEvents(sector, attach);
          foreach(CardModel card in sector.Cards)
          {
            AttachCardEvents(card, attach);
            foreach(TokenModel token in card.Tokens)
              AttachTokenEvents(token, attach);
          }
        }
      }
    }

    void GameModel_RestartNotified(object sender, EventArgs e)
    {
      View.ClosureForced = true;
      View.Close();
    }

    void TokenText_Changed(object sender, ChangedEventArgs<string> e)
    {
      ObservableProperty<string, TokenModel> prop = (ObservableProperty<string, TokenModel>)sender;
      View.SetTokenText(prop.Owner.Key, e.NewValue);
    }

    void TokenAmount_Changed(object sender, ChangedEventArgs<int> e)
    {
      ObservableProperty<int, TokenModel> prop = (ObservableProperty<int, TokenModel>)sender;
      View.SetTokenAmount(prop.Owner.Key, e.NewValue);
    }

    void TokenColor_Changed(object sender, ChangedEventArgs<TokenColor> e)
    {
      ObservableProperty<TokenColor, TokenModel> prop = (ObservableProperty<TokenColor, TokenModel>)sender;
      View.SetTokenColor(prop.Owner.Key, e.NewValue);
    }    

    void CardPosition_Changed(object sender, ChangedEventArgs<CardPosition> e)
    {
      ObservableProperty<CardPosition, CardModel> prop = (ObservableProperty<CardPosition, CardModel>)sender;
      View.SetCardPosition(prop.Owner.Key, e.NewValue);
    }

    void CardLockState_Changed(object sender, ChangedEventArgs<bool> e)
    {
      ObservableProperty<bool, CardModel> prop = (ObservableProperty<bool, CardModel>)sender;
      View.LockCard(prop.Owner.Key, e.NewValue);
    }

    void CardRotation_Changed(object sender, ChangedEventArgs<bool> e)
    {
      ObservableProperty<bool, CardModel> prop = (ObservableProperty<bool, CardModel>)sender;
      View.SetCardRotation(prop.Owner.Key, e.NewValue);
    }

    void CardVisibility_Changed(object sender, ChangedEventArgs<CardVisibility> e)
    {
      ObservableProperty<CardVisibility, CardModel> prop = (ObservableProperty<CardVisibility, CardModel>)sender;
      View.SetCardVisibility(prop.Owner.Key, e.NewValue, prop.Owner.HiddenCode);
    }

    void CardReversed_Changed(object sender, ChangedEventArgs<bool> e)
    {
      ObservableProperty<bool, CardModel> prop = (ObservableProperty<bool, CardModel>)sender;
      View.SetCardReversed(prop.Owner.Key, e.NewValue);
    }

    void CardCustomCharacteristics_Changed(object sender, ChangedEventArgs<string> e)
    {
      ObservableProperty<string, CardModel> prop = (ObservableProperty<string, CardModel>)sender;
      View.SetCardCustomCharacteristics(prop.Owner.Key, e.NewValue);
    }

    void HandleException(Exception ex)
    {
      Model.Console.WriteLine(MessageCategory.Error, "Exception occured!");

      LogicHandler.TraceError(ex);

      View.ShowExceptionMessage(ex);
    }

    #region IGameController members

    public void SaveGame(Bitmap bmp)
    {
      try
      {
        bool saved = false;
        AttachAllEvents(false);
        try
        {
          gameSaver.Save(Model, currentMatchId, new SaveMetaData()
          {
            Date = DateTime.Now,
            Picture = bmp,
            Players = Model.Players.Cast<PlayerModel>().Select(e => e.Info.NickName).ToArray()
          });
          saved = true;
        }
        finally
        {
          AttachAllEvents(true);
        }

        if(saved)
        {
          SaveGameCommand cmd = new SaveGameCommand(Model);
          gameCommandHandler.Execute(cmd);
        }
      }
      catch(Exception ex)
      { 
        HandleException(ex);
      }
    }

    public void RestartGame()
    {
      try
      {
        if(View.ShowQuestionMessage(servicesProvider.SystemStringsService.GetString("GAME", "NEW_GAME_CONFIRM")) == ViewResult.Yes)
        {
          RestartGameCommand cmd = new RestartGameCommand(Model);
          gameCommandHandler.Execute(cmd);
        }
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    //public void LoadGame()
    //{
    //  GameModel m;
    //  gameSaver.Load(saveId, out m);
    //  if(m != null)
    //  {
    //    View.BeginLoadGame(gameType == GameType.Solitaire);
    //    AttachAllEvents(false);
    //    try
    //    {
    //      this.Model = m;
    //      gamegameCommandHandler.Invoker = this.Model.ActivePlayer.Key;
    //      gamegameCommandHandler.Receiver = this.Model;
    //    }
    //    finally
    //    {
    //      View.Clear();
    //      Attach_Game();
    //      View.EndLoadGame();
    //    }
    //  }
    //  else
    //    Model.Console.WriteLine(MessageCategory.Warning, "No saves avaiable for this game");
    //}

    public void ShowOptions()
    {
      if(ShowOptionsRequested != null)
        ShowOptionsRequested(this, EventArgs.Empty);
    }

    public void AddToken(List<string> cardKeys, int amount, string text, TokenColor color)
    {
      try
      {
        AddTokenCommand cmd = new AddTokenCommand(Model);
        cmd.Arguments = new AddTokenArguments() { CardKeys = cardKeys, Amount = amount, Text = text, Color = color };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void RemoveToken(string key)
    {
      try
      {
        RemoveTokenCommand cmd = new RemoveTokenCommand(Model);
        cmd.Arguments = new SingleKeyArguments() { Key = key };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void SetPlayerPoints(string playerKey, int value)
    {
      try
      {
        SetPlayerPointsCommand cmd = new SetPlayerPointsCommand(Model);
        cmd.Arguments = new SetPlayerPointsArguments() { Key = playerKey, Value = value };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void SetNumCounterValue(string numCounterKey, int value)
    {
      try
      {
        SetNumCounterValueCommand cmd = new SetNumCounterValueCommand(Model);
        cmd.Arguments = new SetNumCounterValueArguments() { Key = numCounterKey, Value = value };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void SetTokenText(string key, string text)
    {
      try
      {
        SetTokenTextCommand cmd = new SetTokenTextCommand(Model);
        cmd.Arguments = new SetTokenTextArguments() { Key = key, Text = text };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void SetTokenAmount(string key, int amount)
    {
      try
      {
        SetTokenAmountCommand cmd = new SetTokenAmountCommand(Model);
        cmd.Arguments = new SetTokenAmountArguments() { Key = key, Amount = amount };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void SetTokenColor(string key, TokenColor color)
    {
      try
      {
        SetTokenColorCommand cmd = new SetTokenColorCommand(Model);
        cmd.Arguments = new SetTokenColorArguments() { Key = key, Color = color };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void SetCardsVisibility(List<string> keys, CardVisibility visibility)
    {
      try
      {
        SetCardsVisibilityCommand cmd = new SetCardsVisibilityCommand(Model);
        cmd.Arguments = new SetCardVisibilityArguments() { Keys = keys, Visibility = visibility };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void RotateCards(List<string> keys)
    {
      try
      {
        RotateCardsCommand cmd = new RotateCardsCommand(Model);
        cmd.Arguments = new MultipleKeysArguments() { Keys = keys };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void RotateSectorCards(string sectorKey)
    {
      try
      {
        RotateSectorCardsCommand cmd = new RotateSectorCardsCommand(Model);
        cmd.Arguments = new RotateSectorCardsArguments() { SectorKey = sectorKey };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void ReverseCards(List<string> keys)
    {
      try
      {
        ReverseCardsCommand cmd = new ReverseCardsCommand(Model);
        cmd.Arguments = new MultipleKeysArguments() { Keys = keys };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void LockCards(List<string> keys)
    {
      try
      {
        LockCardsCommand cmd = new LockCardsCommand(Model);
        cmd.Arguments = new MultipleKeysArguments() { Keys = keys };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void SetCardsCustomCharacteristics(List<string> cardKeys, string customCharacteristics, bool includeCardsWithEmptyCharacteristics, bool applyNumericalIncrement)
    {
      try
      {
        SetCardsCustomCharacteristicsCommand cmd = new SetCardsCustomCharacteristicsCommand(Model);
        cmd.Arguments = new SetCardCharacteristicsArguments() 
        { 
          CardKeys = cardKeys, 
          Characteristics = customCharacteristics , 
          IncludeCardsWithEmtpyCharacteristics = includeCardsWithEmptyCharacteristics,
          ApplyNumericalIncrement = applyNumericalIncrement,
        };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void DisplayRandomCards(string sectorKey, string playerKey, int amount)
    {
      try
      {
        DisplayCardsCommand cmd = new DisplayCardsCommand(Model);
        cmd.Arguments = new DisplayCardsArguments { SectorKey = sectorKey, PlayerKey = playerKey, Mode = DisplayCardsMode.Random, Amount = amount };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void CloseCardDisplay()
    {
      try
      {
        CloseCardDisplayCommand cmd = new CloseCardDisplayCommand(Model);
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void DisplayCards(string playerKey, List<string> cardKeys)
    {
      try
      {
        DisplayCardsCommand cmd = new DisplayCardsCommand(Model);
        cmd.Arguments = new DisplayCardsArguments { SectorKey = string.Empty, PlayerKey = playerKey, Mode = DisplayCardsMode.ByKeys, CardKeys = cardKeys };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void ShuffleSector(string sectorKey)
    {
      try
      {
        ShuffleSectorCommand cmd = new ShuffleSectorCommand(Model);
        cmd.Arguments = new ShuffleSectorArguments { SectorKey = sectorKey };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void ThrowCoin()
    {
      try
      {
        ThrowCoinCommand cmd = new ThrowCoinCommand(Model);
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void ThrowDice(DiceType diceType)
    {
      try
      {
        ThrowDiceCommand cmd = new ThrowDiceCommand(Model);
        cmd.Arguments = new ThrowDiceArguments() { DiceType = diceType };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void CreatePawn(string sectorKey, string name, string type, string text, string characteristics, CardPosition cardPosition)
    {
      try
      {
        CreatePawnCommand cmd = new CreatePawnCommand(Model);
        cmd.Arguments = new CreatePawnArguments() 
        { 
          SectorKey = sectorKey, 
          Name = name, 
          Type = type,
          Text = text,
          Characteristics = characteristics,
          CardPosition = cardPosition, 
        };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void DuplicateCard(string cardKey, CardPosition cardPosition)
    {
      try
      {
        DuplicateCardCommand cmd = new DuplicateCardCommand(Model);
        cmd.Arguments = new DuplicateCardArguments()
        {
          CardKey = cardKey,
          CardPosition = cardPosition,
        };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void Chat()
    {
      try
      {
        ChatCommand cmd = new ChatCommand(Model);
        cmd.Arguments = new ChatArguments() { Text = View.ConsoleText };
        gameCommandHandler.Execute(cmd);

        View.ConsoleText = string.Empty;
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void OpenSectorLookup(string sectorKey, string destinationPlayerKey, LookupOpenMode mode, List<string> cardKeys)
    {
      OpenSectorLookup(sectorKey, destinationPlayerKey, mode, -1, cardKeys);
    }

    public void OpenSectorLookup(string sectorKey, string destinationPlayerKey, LookupOpenMode mode, int amount)
    {
      OpenSectorLookup(sectorKey, destinationPlayerKey, mode, amount, new List<string>());
    }

    void OpenSectorLookup(string sectorKey, string destinationPlayerKey, LookupOpenMode mode, int amount, List<string> cardKeys)
    {
      try
      {
        OpenSectorLookupCommand cmd = new OpenSectorLookupCommand(Model);
        cmd.Arguments = new OpenSectorLookupArguments()
        {
          SectorKey = sectorKey,
          DestinationPlayerKey = destinationPlayerKey,
          Mode = mode,
          Amount = amount,
          CardKeys = cardKeys,
        };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void CloseSectorLookup(string key)
    {
      try
      {
        CloseSectorLookupCommand cmd = new CloseSectorLookupCommand(Model);
        cmd.Arguments = new SingleKeyArguments() { Key = key };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void MoveCards(List<string> cardKeys, string destinationSectorCode, List<CardPosition> positions, CardVisibility? visibility)
    {
      MoveCards(cardKeys, destinationSectorCode, string.Empty, positions, visibility);
    }

    public void MoveCards(List<string> cardKeys, string destinationSectorCode, string destinationPlayerKey, List<CardPosition> positions, CardVisibility? visibility)
    {
      try
      {
        MoveCardsCommand cmd = new MoveCardsCommand(Model);
        cmd.Arguments = new MoveCardsArguments()
        {
          SourceMode = MoveCardsSourceMode.Specific,
          CardKeys = cardKeys,
          DestinationSectorCode = destinationSectorCode,
          DestinationPlayerKey = destinationPlayerKey,
          Positions = positions,
          Visibility = visibility,
        };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void MoveRandomCards(int amount, string sourceSectorCode, string destinationSectorCode, List<CardPosition> positions, CardVisibility? visibility)
    {
      try
      {
        MoveCardsCommand cmd = new MoveCardsCommand(Model);
        cmd.Arguments = new MoveCardsArguments()
        {
          SourceMode = MoveCardsSourceMode.Random,
          Amount = amount,
          SourceSectorCode = sourceSectorCode,
          DestinationSectorCode = destinationSectorCode,
          Positions = positions,
          Visibility = visibility,
        };
        gameCommandHandler.Execute(cmd);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void DoMulligan()
    {
      try
      {
        if(View.ShowQuestionMessage(servicesProvider.SystemStringsService.GetString("GAME", "MULLIGAN_CONFIRM")) == ViewResult.Yes)
        {
          DoMulliganCommand cmd = new DoMulliganCommand(Model);
          gameCommandHandler.Execute(cmd);
        }
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void Undo()
    {
      try
      {
        gameCommandHandler.Undo();
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void Redo()
    {
      try
      {
        gameCommandHandler.Redo();
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    #endregion

    #region IDisposable Membri di

    public void Dispose()
    {
      SettingsManager.Settings.GameLanguageChanged -= new Action(Settings_GameLanguageChanged);
      SettingsManager.Settings.CardPictureBehaviorChanged -= new Action(Settings_CardPictureBehaviorChanged);
      logTracer.Dispose();
    }

    #endregion
  }
}