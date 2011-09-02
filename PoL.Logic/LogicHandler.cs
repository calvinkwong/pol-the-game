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

using PoL.Services;
using PoL.Models;
using PoL.Models.GameStarters;
using PoL.Common;
using PoL.Services.DataEntities;
using PoL.Models.Game;
using PoL.Configuration;
using Patterns;
using Patterns.MVC;
using PoL.Logic.Controllers.GameStarters;
using Patterns.Command;
using PoL.Logic.Controllers;
using PoL.Logic.Commands.Game;
using Communication;
using System.Diagnostics;
using PoL.Models.DeckEditor;
using System.Threading;
using PoL.Models.SideboardingEditor;
using PoL.Models.GameRestarters;

namespace PoL.Logic
{
  public class LogicHandler
  {
    ServicesProvider servicesProvider;
    IViewFactory viewFactory;
    GameInfoItem gameItem;

    public GameInfoItem GameItem
    {
      get { return gameItem; }
    }

#if TRACE_COMMANDS
    static TextWriterTraceListener CommandsTracer = new TextWriterTraceListener("commands.xml");
#endif

    static TextWriterTraceListener ErrorsTracer = new TextWriterTraceListener("errors.xml");

    public LogicHandler(IViewFactory viewFactory)
    {
      this.viewFactory = viewFactory;

      servicesProvider = new ServicesProvider(SettingsManager.Settings.ClientLanguage, SettingsManager.Settings.GameLanguage);
      gameItem = servicesProvider.GetAllGames().Single(g => g.Code == SettingsManager.Settings.CurrentGameCode);
      servicesProvider.LoadGame(gameItem);
    }  

    static public void TraceCommand(GameCommand command)
    {
#if TRACE_COMMANDS
      var val = Patterns.Serializer.SerializeXmlType(command, new Type[] { command.GetType() });
      CommandsTracer.WriteLine(val);
      CommandsTracer.Flush();
#endif
    }

    static public void TraceCommand(string xmlCommand)
    {
#if TRACE_COMMANDS
      CommandsTracer.WriteLine(xmlCommand);
      CommandsTracer.Flush();
#endif
    }

    static public void TraceError(Exception ex)
    {
      var val = Patterns.Serializer.SerializeXmlType(new SerializableException(ex));
      ErrorsTracer.WriteLine(val);
      ErrorsTracer.Flush();
    }

    public void ConnectToServer()
    {
      PlayerInfo thisPlayer = CreateLocalPlayerInfo();
      // ----------------------------------------------------------
      // choose game parameters and connect (obtain server channel)
      // ----------------------------------------------------------
      var serverConnectionView = viewFactory.CreateServerConnectionView();
      var serverConnectionModel = new ServerConnectionModel();
      var serverConnectionController = new ServerConnectionController(serverConnectionModel, serverConnectionView, thisPlayer, servicesProvider);
      if(serverConnectionView.ShowModal() == ViewResult.Ok)
      {
        // ------------------------------------------------------------
        // enter lobby chat and and create/join game (obtain players list)
        // ------------------------------------------------------------
      }
    }

    public void StartSolitaire()
    {
      PlayerAccountData thisPlayer = new PlayerAccountData();
      DeckRoom deckRoomLogic = new DeckRoom(this);
      thisPlayer.Deck = deckRoomLogic.Run();
      if(thisPlayer.Deck != null)
      {
        List<PlayerAccountData> players = new List<PlayerAccountData>();

        thisPlayer.Info = CreateLocalPlayerInfo();
        thisPlayer.Deck.MainCards.Shuffle();
        thisPlayer.Password = thisPlayer.Info.NickName;
        players.Add(thisPlayer);

        PlayerAccountData opponentPlayer = new PlayerAccountData();
        opponentPlayer.Info = (PlayerInfo)thisPlayer.Info.Clone();
        opponentPlayer.Info.NickName = "Opponent";
        opponentPlayer.Deck = ServicesProvider.DecksService.LoadDeck(thisPlayer.Deck.Category, thisPlayer.Deck.Name);
        opponentPlayer.Deck.MainCards.Shuffle();
        opponentPlayer.Password = opponentPlayer.Info.NickName;
        players.Add(opponentPlayer);

#if DEBUG
        PlayerAccountData debugPlayer = new PlayerAccountData();
        debugPlayer.Info = (PlayerInfo)thisPlayer.Info.Clone();
        debugPlayer.Info.NickName = "Debug";
        debugPlayer.Deck = ServicesProvider.DecksService.LoadDeck(thisPlayer.Deck.Category, thisPlayer.Deck.Name);
        debugPlayer.Deck.MainCards.Shuffle();
        debugPlayer.Password = debugPlayer.Info.NickName;
        players.Add(debugPlayer);
#endif

        var gameModel = new GameModel(gameItem);
        var gameView = viewFactory.CreateGameView();
        using(GameCommandHandler gameCommandHandler = new GameCommandHandler(gameModel, thisPlayer.Info.NickName, servicesProvider))
        {
          var gameController = new GameController(gameCommandHandler, gameModel, gameView, players, GameType.Solitaire, servicesProvider, true);
          gameController.ShowOptionsRequested += new EventHandler(gameController_ShowOptionsRequested);
          gameView.ShowModal();
        }
      }
    }

    public void StartServerGame(GameStartMode startMode)
    {
      PlayerInfo thisPlayer = CreateLocalPlayerInfo();
      // ---------------------------------------------------------------
      // choose game parameters or pick a saved game and start to listen 
      // ---------------------------------------------------------------
      ServerStartNewGameModel newGameData = null;
      ServerStartSavedGameModel savedGameData = null;
      ServerListener listener = new ServerListener(thisPlayer, servicesProvider, SettingsManager.Settings.ListenPort);
      try
      {
        bool proceed = false;
        switch(startMode)
        {
          case GameStartMode.NewGame:
            {
              var initView = viewFactory.CreateServerStartNewGameView();
              var initModel = new ServerStartNewGameModel();
              var initController = new ServerStartNewGameController(initModel, initView, listener, servicesProvider);
              initController.DeckRoomRequest += new Func<DeckItem>(initController_DeckRoomRequest);
              if(initView.ShowModal() == ViewResult.Ok)
              {
                proceed = true;
                initModel.Deck.MainCards.Shuffle();
                newGameData = initModel;
              }
            }
            break;
          case GameStartMode.SavedGame:
            {
              var initView = viewFactory.CreateServerStartSavedGameView();
              var initModel = new ServerStartSavedGameModel();
              var initController = new ServerStartSavedGameController(initModel, initView, listener, servicesProvider);
              if(initView.ShowModal() == ViewResult.Ok)
              {
                proceed = true;
                savedGameData = initModel;
              }
            }
            break;
        }
        if(proceed)
        {
          // ---------------------------------------------------------------------------------
          // open room, wait other players and chat (obtain clients channels and players list)
          // ---------------------------------------------------------------------------------
          var serverStarterModel = new ServerStarterModel(thisPlayer);
          var serverStarterView = viewFactory.CreateServerStarterView();

          proceed = false;
          using(NetCommandHandler<IGameStarterModel> commandHandler = new NetCommandHandler<IGameStarterModel>(serverStarterModel, thisPlayer.NickName))
          {
            var serverStarterController = new ServerStarterController(commandHandler, serverStarterModel, listener,
              serverStarterView, thisPlayer, servicesProvider, startMode, newGameData, savedGameData);
            listener.Console = serverStarterModel.Console;
            proceed = serverStarterView.ShowModal() == ViewResult.Ok;
          }
          if(proceed)
          {
            // ----------
            // start game
            // ----------
            listener.Console = null;
            listener.GameIsRunning = true;
            switch(startMode)
            {
              case GameStartMode.NewGame:
                {
                  var players = CreatePlayerAccounts(thisPlayer.NickName, serverStarterModel.Players.ToList());
                  for(int i = 0; i < listener.PlayerConnections.Count; i++)
                    players[i+1].Channel = listener.PlayerConnections[i].NetClient;
                  StartGame(players, null, GameType.Host);
                }
                break;
              case GameStartMode.SavedGame:
                {
                  var players = CreatePlayerAccounts(thisPlayer.NickName, serverStarterModel.SavedGame);
                  for(int i = 0; i < listener.PlayerConnections.Count; i++)
                    players[i+1].Channel = listener.PlayerConnections[i].NetClient;
                  StartGame(players, serverStarterModel.SavedGame, GameType.Host);
                }
                break;
            }
          }
        }
      }
      finally
      {
        if(listener.IsStarted)
          listener.Stop();
      }
    }

    public void StartClientGame(GameStartMode startMode)
    {
      PlayerInfo thisPlayer = CreateLocalPlayerInfo();

      // ----------------------------------------------------------
      // choose game parameters and connect (obtain server channel)
      // ----------------------------------------------------------
      ClientConnector connector = new ClientConnector(thisPlayer, servicesProvider);
      try
      {
        var initView = viewFactory.CreateClientInitializationView(startMode);
        var initModel = new ClientInitializationModel();
        var initController = new ClientInitializationController(initModel, initView, thisPlayer, connector, servicesProvider);
        initController.DeckRoomRequest += new Func<DeckItem>(initController_DeckRoomRequest);
        if(initView.ShowModal() == ViewResult.Ok)
        {
          // ------------------------------------------------------------
          // open room, wait other players and chat (obtain players list)
          // ------------------------------------------------------------
          var clientStarterModel = new ClientStarterModel(thisPlayer, initModel.Deck, servicesProvider);
          var clientStarterView = viewFactory.CreateClientStarterView();
          bool proceed = false;
          using(var commandHandler = new NetCommandHandler<IGameStarterModel>(clientStarterModel, thisPlayer.NickName))
          {
            commandHandler.AddChannel(initModel.ServerData.Channel, initModel.ServerData.Player.NickName);
            var clientStarterController = new ClientStarterController(commandHandler, clientStarterModel, connector, clientStarterView, servicesProvider, initModel);
            proceed = clientStarterView.ShowModal() == ViewResult.Ok;
          }
          if(proceed)
          {
            // ----------
            // start game
            // ----------
            switch(startMode)
            {
              case GameStartMode.NewGame:
                {
                  var players = CreatePlayerAccounts(thisPlayer.NickName, clientStarterModel.Players.ToList());
                  players.Single(e => e.Info.NickName == initModel.ServerData.Player.NickName).Channel = initModel.ServerData.Channel;
                  StartGame(players, null, GameType.Client);
                }
                break;
              case GameStartMode.SavedGame:
                {
                  var players = CreatePlayerAccounts(thisPlayer.NickName, clientStarterModel.SavedGame);
                  players.Single(e => e.Info.NickName == initModel.ServerData.Player.NickName).Channel = initModel.ServerData.Channel;
                  StartGame(players, clientStarterModel.SavedGame, GameType.Client);
                }
                break;
            }
          }
        }
      }
      finally
      {
        if(connector.IsConnected)
          connector.Disconnect();
      }
    }

    List<PlayerAccountData> CreatePlayerAccounts(string activePlayerKey, GameModel gameModel)
    {
      var players = gameModel.Players.Cast<PoL.Models.Game.PlayerModel>().Select(e => new PlayerAccountData()
      {
        Info = e.Info,
        Deck = e.Deck,
        Password = e.Password,
      }).ToList();
      var tmp = players.Single(e => e.Info.NickName == activePlayerKey);
      players.Remove(tmp);
      players.Insert(0, tmp);
      return players;
    }

    List<PlayerAccountData> CreatePlayerAccounts(string activePlayerKey, List<PlayerAccountData> currentPlayers)
    {
      var players = currentPlayers.ToList();
      var tmp = players.Single(e => e.Info.NickName == activePlayerKey);
      players.Remove(tmp);
      foreach(var ply in players)
      {
        // localize opponent's decks
        servicesProvider.CardsService.LocalizeCards(ply.Deck.MainCards);
        servicesProvider.CardsService.LocalizeCards(ply.Deck.SideboardCards);
      }
      players.Insert(0, tmp);
      return players;
    }

    void StartGame(List<PlayerAccountData> players, GameModel gameModel, GameType gameType)
    {
      bool savedGame = gameModel != null;
      if(savedGame)
        gameModel.Console.Messages.Clear(); // clients must not see saved server's log
      else
        gameModel = new GameModel(gameItem);

      bool exitGame = false;
      while(!exitGame)
      {
        var gameView = viewFactory.CreateGameView();
        using(var commandHandler = new GameCommandHandler(gameModel, players.First().Info.NickName, servicesProvider))
        {
          foreach(var player in players.Where(e => e.Channel != null))
            commandHandler.AddChannel(player.Channel, player.Info.NickName);
          var gameController = new GameController(commandHandler, gameModel, gameView, players, gameType, servicesProvider, !savedGame);
          gameController.ShowOptionsRequested += new EventHandler(gameController_ShowOptionsRequested);
          gameView.ShowModal();
        }
        exitGame = !gameModel.IsRestartNotified;
        if(!exitGame)
        {
          players = players.Where(e => gameModel.Players.Any(p => p.Key == e.Info.NickName)).ToList();
          exitGame = RunRestartGame(players, gameType);
          if(!exitGame)
          {
            gameModel = new GameModel(gameItem);
            savedGame = false;
          }
        }
      }
    }

    bool RunRestartGame(List<PlayerAccountData> players, GameType gameType)
    {
      bool exitGame = false;
      if(gameType == GameType.Host)
      {
        var serverRestarterModel = new ServerRestarterModel();
        var serverRestartGameView = viewFactory.CreateServerRestartGameView();
        using(var commandHandler = new NetCommandHandler<IGameRestarterModel>(serverRestarterModel, players.First().Info.NickName))
        {
          foreach(var player in players.Where(e => e.Channel != null))
            commandHandler.AddChannel(player.Channel, player.Info.NickName);
          var serverRestartGameController = new ServerRestarterController(commandHandler, serverRestarterModel, players, serverRestartGameView, servicesProvider);
          serverRestartGameController.SideboardingEditorRequest += new SideboardingEditorRequestEventHandler(serverRestartGameController_SideboardingEditorRequest);
          if(serverRestartGameView.ShowModal() == ViewResult.Ok)
            UpdatePlayersForRestart(players, serverRestarterModel.Players.Cast<PoL.Models.GameRestarters.PlayerModel>());
          else
            exitGame = true;
        }
      }
      else
      {
        var clientRestarterModel = new ClientRestarterModel();
        var clientRestartGameView = viewFactory.CreateClientRestartGameView();
        using(var commandHandler = new NetCommandHandler<IGameRestarterModel>(clientRestarterModel, players.First().Info.NickName))
        {
          foreach(var player in players.Where(e => e.Channel != null))
            commandHandler.AddChannel(player.Channel, player.Info.NickName);
          var clientRestartGameController = new ClientRestarterController(commandHandler, clientRestarterModel, players, clientRestartGameView, servicesProvider);
          clientRestartGameController.SideboardingEditorRequest += new SideboardingEditorRequestEventHandler(serverRestartGameController_SideboardingEditorRequest);
          if(clientRestartGameView.ShowModal() == ViewResult.Ok)
            UpdatePlayersForRestart(players, clientRestarterModel.Players.Cast<PoL.Models.GameRestarters.PlayerModel>());
          else
            exitGame = true;
        }
      }
      return exitGame;
    }

    void UpdatePlayersForRestart(List<PlayerAccountData> originalPlayers, IEnumerable<PoL.Models.GameRestarters.PlayerModel> actualPlayers)
    {
      List<PlayerAccountData> excluded = new List<PlayerAccountData>();
      foreach(var player in originalPlayers)
      {
        var actualPlayer = actualPlayers.SingleOrDefault(e => e.Key == player.Info.NickName);
        if(actualPlayer == null)
          excluded.Add(player);
        else
          player.Deck = actualPlayer.Deck.Value;
      }
      foreach(var player in excluded)
        originalPlayers.Remove(player);
    }

    void serverRestartGameController_SideboardingEditorRequest(object sender, SideboardingEditorRequestEventArgs args)
    {
      var sideboardingEditorModel = new SideboardingEditorModel(servicesProvider, GameItem, args.Deck);
      var sideboardingEditorView = viewFactory.CreateSideboardingEditorView();
      var sideboardingEditorController = new SideboardingEditorController(sideboardingEditorModel, sideboardingEditorView, servicesProvider);
      args.Cancel = sideboardingEditorView.ShowModal() != ViewResult.Ok;
      args.Deck = sideboardingEditorModel.Deck;
    }

    DeckItem initController_DeckRoomRequest()
    {
      return new DeckRoom(this).Run();
    }

    void gameController_ShowOptionsRequested(object sender, EventArgs e)
    {
      var optionsView = viewFactory.CreateOptionsView();
      OptionsController optionsController = new OptionsController(optionsView, false, servicesProvider);
      optionsView.ShowModal();
    }

    public void ShowDeckEditor()
    {
      DeckItem deck = null;
      do
      {
        DeckRoom deckRoom = new DeckRoom(this);
        deck = deckRoom.Run();
        if(deck != null)
        {
          var deckEditor = new DeckEditorModel(servicesProvider, gameItem, deck);
          var deckEditorView = viewFactory.CreateDeckEditorView();
          var deckEditorController = new DeckEditorController(deckEditor, deckEditorView, servicesProvider);
          deckEditorView.ShowModal();
        }
      } while(deck != null);
    } 

    public void ShowOptions()
    {
      var optionsView = viewFactory.CreateOptionsView();
      OptionsController optionsController = new OptionsController(optionsView, true, servicesProvider);
      optionsView.ShowModal();
    } 

    public ServicesProvider ServicesProvider
    {
      get { return servicesProvider; }
    }

    public IViewFactory ViewFactory
    {
      get { return viewFactory; }
    }

    PlayerInfo CreateLocalPlayerInfo()
    {
      Image avatar = null;
      try
      {
        avatar = Image.FromFile(SettingsManager.Settings.AvatarPath);
      }
      catch { }
      return new PlayerInfo(SettingsManager.Settings.PlayerName, SettingsManager.Settings.PlayerMessage, avatar);
    }
  }
}
