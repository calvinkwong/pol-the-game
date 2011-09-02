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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

using PoL.Services;
using PoL.Services.DataEntities;
using PoL.Common;
using PoL.Logic.Controllers;
using PoL.Logic.Views;
using PoL.Logic;
using PoL.Configuration;
using PoL.WinFormsView.Utils;
using Patterns.MVC;
using System.IO;
using Patterns;
using System.Diagnostics;

namespace PoL.WinFormsView.Game
{
  public partial class GameView : WinFormsView, IGameView, ILocalizable
  {
    IGameController controller;
    List<LookupView> lookupViews = new List<LookupView>();
    List<PlayerView> playerViews = new List<PlayerView>();
    ProgressDialog progressDialog = new ProgressDialog();
    bool saveEnabled;
    bool restartGameEnabled;
    string activePlayerKey;
    bool isSolitaire;
    CardDisplayView cardDisplayView = null;

    GameStructure gameStructure = new GameStructure();

    Dictionary <string, SectorActionsSupporting> sectorActionsSupporting = new Dictionary<string, SectorActionsSupporting>();
    Dictionary<string, Dictionary<SectorActions, bool>> sectorActionsAbilitations = new Dictionary<string, Dictionary<SectorActions, bool>>();

    Dictionary<string, bool> changePointsAbilitationByPlayer = new Dictionary<string, bool>();

    public GameView()
    {
      InitializeComponent();

      this.Text = Application.ProductName + " v." + Application.ProductVersion;

      SettingsManager.Settings.AnimateHandChanged += new Action(Settings_AnimateHandChanged);
      cardPreview.BackgroundImage = Program.LogicHandler.ServicesProvider.ImagesService.GetCardBack(CardStyleBehaviorsService.BEHAVIORS_LARGE);

      pnlGameFields.SplitterDistance = this.ClientRectangle.Height / 2;
      pnlGameFields.Panel1Collapsed = true;

      progressDialog.StartPosition = FormStartPosition.CenterScreen;

      consoleView.LinkClicked += new LinkClickedEventHandler(consoleView_LinkClicked);

      tabControl.SelectedIndexChanged += new EventHandler(tabControl_SelectedIndexChanged);

      this.FormClosing += delegate(object sender, FormClosingEventArgs e)
      {
        if(!ClosureForced)
          e.Cancel = Program.QuestionBox(this, Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("GAME", "QUIT_CONFIRM")) != DialogResult.Yes;
      };

      // menu
      menuDice4.Click += delegate(object sender, EventArgs e)
      {
        controller.ThrowDice(DiceType.D4);
      };
      menuDice6.Click += delegate(object sender, EventArgs e)
      {
        controller.ThrowDice(DiceType.D6);
      };
      menuDice8.Click += delegate(object sender, EventArgs e)
      {
        controller.ThrowDice(DiceType.D8);
      };
      menuDice10.Click += delegate(object sender, EventArgs e)
      {
        controller.ThrowDice(DiceType.D10);
      };
      menuDice12.Click += delegate(object sender, EventArgs e)
      {
        controller.ThrowDice(DiceType.D12);
      };
      menuDice20.Click += delegate(object sender, EventArgs e)
      {
        controller.ThrowDice(DiceType.D20);
      };

      btnOptions.Click += delegate(object sender, EventArgs e)
      {
        controller.ShowOptions();
      };
      btnUndo.Click += delegate(object sender, EventArgs e)
      {
        controller.Undo();
      };
      btnRedo.Click += delegate(object sender, EventArgs e)
      {
        controller.Redo();
      };
      btnCoin.Click += delegate(object sender, EventArgs e)
      {
        controller.ThrowCoin();
      };
      btnSave.Click += delegate(object sender, EventArgs e)
      {
        SaveGame();
      };
      btnRestart.Click += delegate(object sender, EventArgs e)
      {
        RestartGame();
      };
      Localize();
    }

    void Settings_AnimateHandChanged()
    {
      try
      {
        foreach(var playerView in playerViews)
          playerView.AnimateHand = SettingsManager.Settings.AnimateHand;
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    void tabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        if(tabControl.SelectedTab != null)
        {
          PlayerStatusView playerStatusView = (PlayerStatusView)playerStatusContainer.Panel1.Controls.Find(tabControl.SelectedTab.Name, true).Single();
          playerStatusContainer.Panel1.Controls.SetChildIndex(playerStatusView, 0);
        }
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    void consoleView_LinkClicked(object sender, LinkClickedEventArgs e)
    {
      try
      {
        CardSearchParams searchParams = new CardSearchParams();
        searchParams.Ids = Enumerable.Repeat(e.LinkText.Split('#').Last(), 1).ToList();
        var card = Program.LogicHandler.ServicesProvider.CardsService.SelectCards(searchParams).FirstOrDefault();
        if(card != null)
          ShowCardMagnification(card);
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void Localize()
    {
      toolTip.SetToolTip(btnOptions, Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("GAME", "OPTIONS"));
      toolTip.SetToolTip(btnCoin, Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("GAME", "ACTIONS_THROW_COIN"));
      toolTip.SetToolTip(btnDice, Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("GAME", "ACTIONS_THROW_DICE"));
      menuDice4.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("GAME", "ACTIONS_DICE4");
      menuDice6.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("GAME", "ACTIONS_DICE6");
      menuDice8.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("GAME", "ACTIONS_DICE8");
      menuDice10.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("GAME", "ACTIONS_DICE10");
      menuDice12.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("GAME", "ACTIONS_DICE12");
      menuDice20.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("GAME", "ACTIONS_DICE20");
      toolTip.SetToolTip(btnUndo, Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("GAME", "ACTIONS_UNDO"));
      toolTip.SetToolTip(btnRedo, Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("GAME", "ACTIONS_REDO"));
      toolTip.SetToolTip(btnSave, Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("GAME", "SAVE_GAME"));
      toolTip.SetToolTip(btnRestart, Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("GAME", "RESTART"));

      PropagateLocalization(this.Controls);
    }

    public Dictionary<string, SectorActionsSupporting> SectorActionsSupporting 
    {
      get { return sectorActionsSupporting; }
    }

    public GameStructure GameStructure
    {
      get { return gameStructure; }
    }

    public Dictionary<string, Dictionary<SectorActions, bool>> SectorActionsAbilitations
    {
      get { return sectorActionsAbilitations; }
    }

    public Dictionary<string, bool> ChangePointsAbilitationByPlayer
    {
      get { return changePointsAbilitationByPlayer; }
    }

    void PropagateLocalization(Control.ControlCollection controls)
    {
      foreach(Control control in controls)
      {
        if(control is ILocalizable)
          (control as ILocalizable).Localize();
        PropagateLocalization(control.Controls);
      }
    }

    void SaveGame()
    {
      if(saveEnabled)
      {
        Bitmap bmp = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
        this.DrawToBitmap(bmp, this.ClientRectangle);
        controller.SaveGame(bmp);
      }
    }

    void RestartGame()
    {
      if(restartGameEnabled)
      {
        controller.RestartGame();
      }
    }

    void SwitchPlayer(bool forward)
    {
      int nextPageIndex = tabControl.SelectedIndex + (forward ? 1 : -1);
      if(nextPageIndex == tabControl.TabPages.Count)
        nextPageIndex = 0;
      else if(nextPageIndex == -1)
        nextPageIndex = tabControl.TabPages.Count - 1;
      tabControl.SelectedIndex = nextPageIndex;
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      try
      {
        switch(e.KeyCode)
        {
          case Keys.Enter: // chat
            consoleView.FocusOnInput();
            break;
          case Keys.F5: // save
            SaveGame();
            break;
          case Keys.Tab: // switch player
            if(e.Control)
              SwitchPlayer(!e.Shift);
            break;
          case Keys.Z:
            if(e.Control)
            {
              if(e.Shift)
              {
                if(btnRedo.Enabled) // undo
                  controller.Redo();
              }
              else
              {
                if(btnUndo.Enabled) // redo
                  controller.Undo();
              }
            }
            break;
          case Keys.D: // draw 
            if(e.Control)
            {
              string sectorKey = string.Concat(activePlayerKey, SystemSectors.DECK);
              ISectorView sectorView = (ISectorView)Controls.Find(sectorKey, true).First();
              if(SectorActionsAbilitations[sectorKey][SectorActions.MoveCardsToDefaultSector])
                GameViewHelper.RaiseMoveCards(this, sectorView.CardViews.Take(1).ToList(), sectorView.SectorItem.DefaultTarget);
            }
            else if(e.Alt) // duplicate
            {
              GameViewHelper.RaiseDuplicateCard(this);
            }
            break;
          case Keys.S: // shuffle
            if(e.Control)
            {
              string sectorKey = string.Concat(activePlayerKey, SystemSectors.DECK);
              if(SectorActionsAbilitations[sectorKey][SectorActions.Shuffle])
                Controller.ShuffleSector(sectorKey);
            }
            break;
          case Keys.P: // pawn
            if(e.Control)
            {
              GameViewHelper.RaiseCreatePawn(this);
            }
            break;
          case Keys.T: // add token
            if(e.Control)
            {
              GameViewHelper.RaiseAddCardToken(this);
            }
            break;
          case Keys.Add:
            if(e.Control) // add power
            {
              GameViewHelper.RaiseChangeCardCharacteristics(this, ChangeCardCharacteristicsMode.AddPower);
            }
            if(e.Alt) // add toughness 
            {
              GameViewHelper.RaiseChangeCardCharacteristics(this, ChangeCardCharacteristicsMode.AddToughness);
            }
            break;
          case Keys.Subtract:
            if(e.Control) // subtract power
            {
              GameViewHelper.RaiseChangeCardCharacteristics(this, ChangeCardCharacteristicsMode.SubtractPower);
            }
            if(e.Alt) // subtract toughness 
            {
              GameViewHelper.RaiseChangeCardCharacteristics(this, ChangeCardCharacteristicsMode.SubtractToughness);
            }
            break;
          case Keys.F: // coin
            if(e.Control)
              controller.ThrowCoin();
            break;
          case Keys.I: // dice
            if(e.Control)
              controller.ThrowDice(DiceType.D20);
            break;
          case Keys.U: // rotate all
            if(e.Control)
            {
              string sectorKey = string.Concat(activePlayerKey, SystemSectors.BATTLEFIELD);
              if(sectorActionsAbilitations[sectorKey][SectorActions.StraightAllCards])
                controller.RotateSectorCards(sectorKey);
            }
            break;
          case Keys.M: // mulligan
            if(e.Control)
              controller.DoMulligan();
            break;
          case Keys.L: // query life points
            if(e.Control)
            {
              foreach(var ctrl in this.Controls.Find(activePlayerKey,  true))
                if(ctrl is PlayerStatusView)
                  GameViewHelper.RaiseSetLifePoints(this, (PlayerStatusView)ctrl, SetLifePointsMode.Query);
            }
            break;
          case Keys.F11: // subtract life points
            foreach(var ctrl in this.Controls.Find(activePlayerKey, true))
              if(ctrl is PlayerStatusView)
                GameViewHelper.RaiseSetLifePoints(this, (PlayerStatusView)ctrl, SetLifePointsMode.Subtract);
            break;
          case Keys.F12: // add life points
            foreach(var ctrl in this.Controls.Find(activePlayerKey, true))
              if(ctrl is PlayerStatusView)
                GameViewHelper.RaiseSetLifePoints(this, (PlayerStatusView)ctrl, SetLifePointsMode.Add);
            break;
          case Keys.F2: // new game
            RestartGame();
            break;
        }
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public IGameController Controller
    {
      get { return controller; }
    }

    public void ShowCardMagnification(CardItem cardItem)
    {
      cardPreview.Image = CardDrawer.Draw(cardItem, CardStyleBehaviorsService.BEHAVIORS_LARGE);
    }

    public void HandleException(Exception ex)
    {
      LogicHandler.TraceError(ex);

      this.ShowExceptionMessage(ex);
    }

    #region IView Members

    public void RegisterController(IGameController controller)
    {
      this.controller = controller; 
    }

    #endregion 

    #region IGameView Members

    public void Clear()
    {
      if(InvokeRequired)
        Invoke(new Action(Clear));
      else
      {
        try
        {
          foreach(PlayerView playerView in playerViews)
          {
            playerView.Parent.Controls.Remove(playerView);
            playerView.Dispose();
          }
          playerViews.Clear();

          playerStatusContainer.Panel1.Controls.Clear();
          playerStatusContainer.Panel2.Controls.Clear();

          tabControl.TabPages.Clear();
          pnlGameFields.Panel1Collapsed = true;

          foreach(LookupView lookupView in lookupViews)
            lookupView.Close();
          lookupViews.Clear();

          consoleView.ClearMessages();

          sectorActionsSupporting.Clear();
          gameStructure = new GameStructure();
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void ShowNewGameParameters()
    {
      if(InvokeRequired)
        Invoke(new Action(ShowNewGameParameters));
      else
      {
        try
        {
          Program.InfoBox(this, "debug... query new game parameters...");
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void BeginLoadGame(bool isSolitaire)
    {
      try
      {
        this.isSolitaire = isSolitaire;
        this.SuspendLayout();
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void EndLoadGame()
    {
      try
      {
        this.ResumeLayout();
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public string ActivePlayerKey
    {
      get { return activePlayerKey; }
    }

    public bool IsSolitaire 
    {
      get { return isSolitaire; }
    }

    public void AddPlayer(string key, PlayerInfo info, bool isActive, bool handVisible)
    {
      if(InvokeRequired)
        Invoke(new Action<string, PlayerInfo, bool, bool>(AddPlayer), key, info, isActive, handVisible);
      else
      {
        try
        {
          gameStructure.Players.Add(new PlayerStructure() { PlayerKey = key, Item = info, IsActive = isActive });

          PlayerView playerView = new PlayerView();
          playerView.SetPlayer(key, info, isActive, handVisible);
          playerView.AnimateHand = SettingsManager.Settings.AnimateHand;
          playerView.Dock = DockStyle.Fill;
          if(isActive)
          {
            activePlayerKey = key;
            pnlGameFields.Panel2.Controls.Add(playerView);
          }
          else
          {
            pnlGameFields.Panel1Collapsed = false;
            TabPage page = new TabPage();
            page.Name = key;
            page.Text = info.NickName;
            page.Controls.Add(playerView);
            page.BorderStyle = BorderStyle.None;
            tabControl.TabPages.Add(page);
          }
          playerViews.Add(playerView);

          PlayerStatusView statusView = new PlayerStatusView();
          statusView.SetPlayer(key, info, isActive, handVisible);
          statusView.Dock = DockStyle.Fill;
          if(isActive)
            playerStatusContainer.Panel2.Controls.Add(statusView);
          else
            playerStatusContainer.Panel1.Controls.Add(statusView);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void AddNumCounter(string playerKey, string numCounterKey, NumCounterItem numCounterItem)
    {
      if(InvokeRequired)
        Invoke(new Action<string, string, NumCounterItem>(AddNumCounter), playerKey, numCounterKey, numCounterItem);
      {
        try
        {
          foreach(PlayerStatusView playerStatusView in Controls.Find(playerKey, true).OfType<PlayerStatusView>())
            playerStatusView.AddNumCounter(numCounterKey, numCounterItem);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void AddSector(string playerKey, string sectorKey, SectorItem sectorItem, SectorActionsSupporting sectorActionsSupporting)
    {
      if(InvokeRequired)
        Invoke(new Action<string, string, SectorItem, SectorActionsSupporting>(AddSector), playerKey, sectorKey, sectorItem, sectorActionsSupporting);
      else
      {
        try
        {
          this.sectorActionsSupporting.Add(sectorKey, sectorActionsSupporting);

          gameStructure.GetPlayer(playerKey).Sectors.Add(new SectorStructure() { SectorKey = sectorKey, Item = sectorItem });

          foreach(PlayerView playerView in Controls.Find(playerKey, true).OfType<PlayerView>())
            playerView.AddSector(sectorKey, sectorItem, sectorActionsSupporting);
          foreach(PlayerStatusView playerStatusView in Controls.Find(playerKey, true).OfType<PlayerStatusView>())
            playerStatusView.AddSector(sectorKey, sectorItem, sectorActionsSupporting);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void UpdateSector(string key, SectorItem sectorItem)
    {
      if(InvokeRequired)
        Invoke(new Action<string, SectorItem>(UpdateSector), key, sectorItem);
      else      
      {
        try
        {
          foreach(ISectorView sectorView in Controls.Find(key, true))
          {
            sectorView.SetDescription(sectorItem.Name);

            PlayerStatusView fieldView = GameViewHelper.FindParentPlayerStatusView((Control)sectorView);
            if(fieldView != null)
              fieldView.UpdateSector(key, sectorItem);
          }
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void ShowProgress(bool show)
    {
      try
      {
        if(show)
          progressDialog.Show(this);
        else
          progressDialog.Hide();
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public string ProgressMessage
    {
      get { return progressDialog.ProgressMessage; }
      set 
      {
        try
        {
          progressDialog.ProgressMessage = value;
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public int ProgressMin
    {
      get { return progressDialog.ProgressMin; }
      set 
      {
        try
        {
          progressDialog.ProgressMin = value;
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public int ProgressMax
    {
      get { return progressDialog.ProgressMax; }
      set 
      {
        try
        {
          progressDialog.ProgressMax = value;
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public int ProgressStep
    {
      get { return progressDialog.ProgressStep; }
      set 
      {
        try
        {
          progressDialog.ProgressStep = value;
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public int ProgressValue
    {
      get { return progressDialog.ProgressValue; }
      set 
      {
        try
        {
          progressDialog.ProgressValue = value;
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void ProgressPerformStep()
    {
      try
      {
        progressDialog.ProgressPerformStep();
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void ProgressRefresh()
    {
      try
      {
        Application.DoEvents();
      }
      catch(Exception ex)
      {
        HandleException(ex);
      }
    }

    public void AddConsoleMessage(TextMessage message) 
    {
      if(InvokeRequired)
        Invoke(new Action<TextMessage>(AddConsoleMessage), message);
      else
      {
        try
        {
          consoleView.AddMessage(message);
          FlashWindow.Flash(this);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public string ConsoleText
    {
      get { return consoleView.CurrentText; }
      set 
      {
        try
        {
          consoleView.CurrentText = value;
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public class AddTokenArgs
    {
      public string CardKey;
      public string TokenKey;
      public string Text;
      public int Amount;
      public TokenColor Color;
    }

    public void AddToken(string cardKey, string tokenKey, string text, int amount, TokenColor color)
    {
      AddTokenArgs args = new AddTokenArgs() { CardKey = cardKey, TokenKey = tokenKey, Amount = amount, Text = text, Color = color };
      if(InvokeRequired)
        Invoke(new Action<AddTokenArgs>(AddToken), args);
      else
      {
        try
        {
          AddToken(args);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    void AddToken(AddTokenArgs args)
    {
      foreach(CardView card in Controls.Find(args.CardKey, true))
        card.AddToken(args.TokenKey, args.Text, args.Amount, args.Color);
    }

    public void RemoveToken(string key)
    {
      if(InvokeRequired)
        Invoke(new Action<string>(RemoveToken), key);
      else
      {
        try
        {
          foreach(TokenView token in Controls.Find(key, true))
            GameViewHelper.FindParentCardView(token).RemoveToken(key);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void SetTokenText(string key, string text)
    {
      if(InvokeRequired)
        Invoke(new Action<string, string>(SetTokenText), key, text);
      else
      {
        try
        {
          foreach(TokenView token in Controls.Find(key, true))
            GameViewHelper.FindParentCardView(token).SetTokenText(key, text);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void SetTokenAmount(string key, int amount)
    {
      if(InvokeRequired)
        Invoke(new Action<string, int>(SetTokenAmount), key, amount);
      else
      {
        try
        {
          foreach(TokenView token in Controls.Find(key, true))
            GameViewHelper.FindParentCardView(token).SetTokenAmount(key, amount);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void SetTokenColor(string key, TokenColor color)
    {
      if(InvokeRequired)
        Invoke(new Action<string, TokenColor>(SetTokenColor), key, color);
      else
      {
        try
        {
          foreach(TokenView token in Controls.Find(key, true))
            GameViewHelper.FindParentCardView(token).SetTokenColor(key, color);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void AddCards(string sectorKey, Dictionary<string, CardViewItem> cardViewItems)
    {
      if(InvokeRequired)
        Invoke(new Action<string, Dictionary<string, CardViewItem>>(AddCards), sectorKey, cardViewItems);
      else
      {
        try
        {
          foreach(ISectorView sectorView in Controls.Find(sectorKey, true))
            sectorView.AddCards(cardViewItems);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void UpdateCard(string key, CardItem cardItem)
    {
      if(InvokeRequired)
        Invoke(new Action<string, CardItem>(UpdateCard), key, cardItem);
      else
      {
        try
        {
          foreach(CardView card in Controls.Find(key, true))
            card.UpdateCard(cardItem);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void RemoveCard(string key)
    {
      if(InvokeRequired)
        Invoke(new Action<string>(RemoveCard), key);
      else      
      {
        try
        {
          foreach(Control card in Controls.Find(key, true))
            GameViewHelper.FindParentSectorView(card).RemoveCard(key);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void MoveCard(string key, int newIndex)
    {
      if(InvokeRequired)
        Invoke(new Action<string, int>(MoveCard), key, newIndex);
      else
      {
        try
        {
          foreach(Control card in Controls.Find(key, true))
            GameViewHelper.FindParentSectorView(card).MoveCard(key, newIndex);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void ClearCards(string sectorKey)
    {
      if(InvokeRequired)
        Invoke(new Action<string>(ClearCards), sectorKey);
      else
      {
        try
        {
          foreach(ISectorView sectorView in Controls.Find(sectorKey, true))
            sectorView.ClearCards();
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void SetCardRotation(string key, bool rotated)
    {
      if(InvokeRequired)
        Invoke(new Action<string, bool>(SetCardRotation), key, rotated);
      else
      {
        try
        {
          foreach(CardView card in Controls.Find(key, true))
            card.SetRotation(rotated);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void LockCard(string key, bool lockState)
    {
      if(InvokeRequired)
        Invoke(new Action<string, bool>(LockCard), key, lockState);
      else
      {
        try
        {
          foreach(CardView card in Controls.Find(key, true))
            card.SetLockState(lockState);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void SetCardPosition(string key, CardPosition position)
    {
      if(InvokeRequired)
        Invoke(new Action<string, CardPosition>(SetCardPosition), key, position);
      else
      {
        try
        {
          foreach(CardView card in Controls.Find(key, true))
            card.SetPosition(position);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void SetCardVisibility(string key, CardVisibility visibility, int hiddenCode)
    {
      if(InvokeRequired)
        Invoke(new Action<string, CardVisibility, int>(SetCardVisibility), key, visibility, hiddenCode);
      else
      {
        try
        {
          foreach(CardView card in Controls.Find(key, true))
            card.SetVisibility(visibility, hiddenCode);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void SetCardReversed(string key, bool reversed)
    {
      if(InvokeRequired)
        Invoke(new Action<string, bool>(SetCardReversed), key, reversed);
      else
      {
        try
        {
          foreach(CardView card in Controls.Find(key, true))
            card.SetReversed(reversed);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void SetCardCustomCharacteristics(string key, string characteristics)
    {
      if(InvokeRequired)
        Invoke(new Action<string, string>(SetCardCustomCharacteristics), key, characteristics);
      else
      {
        try
        {
          foreach(CardView card in Controls.Find(key, true))
            card.SetCustomCharacteristics(characteristics);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void EnableSectorAction(string sectorKey, SectorActions action, bool enable)
    {
      if(InvokeRequired)
        Invoke(new Action<string, SectorActions, bool>(EnableSectorAction), sectorKey, action, enable);
      else
      {
        try
        {
          if(!sectorActionsAbilitations.ContainsKey(sectorKey))
            sectorActionsAbilitations.Add(sectorKey, new Dictionary<SectorActions, bool>());
          if(!sectorActionsAbilitations[sectorKey].ContainsKey(action))
            sectorActionsAbilitations[sectorKey].Add(action, false);
          sectorActionsAbilitations[sectorKey][action] = enable;
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void EnablePlayerChangePoints(string key, bool enable)
    {
      if(InvokeRequired)
        Invoke(new Action<string, bool>(EnablePlayerChangePoints), key, enable);
      else
      {
        try
        {
          changePointsAbilitationByPlayer[key] = enable;
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void EnableUndo(bool enable)
    {
      if(InvokeRequired)
        Invoke(new Action<bool>(EnableUndo), enable);
      else
      {
        try
        {
          btnUndo.Enabled = enable;
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void EnableRestartGame(bool enable)
    {
      if(InvokeRequired)
        Invoke(new Action<bool>(EnableRestartGame), enable);
      else
      {
        try
        {
          btnRestart.Enabled = enable;
          restartGameEnabled = enable;
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void EnableSave(bool enable)
    {
      if(InvokeRequired)
        Invoke(new Action<bool>(EnableSave), enable);
      else
      {
        try
        {
          btnSave.Enabled = enable;
          saveEnabled = enable;
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void EnableRedo(bool enable)
    {
      if(InvokeRequired)
        Invoke(new Action<bool>(EnableRedo), enable);
      else
      {
        try
        {
          btnRedo.Enabled = enable;
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void EnableCardRotation(string key, bool enable)
    {
      if(InvokeRequired)
        Invoke(new Action<string, bool>(EnableCardRotation), key, enable);
      else
      {
        try
        {
          foreach(CardView card in Controls.Find(key, true))
            card.EnableRotation = enable;
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void DisplayCards(List<CardItem> cards)
    {
      if(InvokeRequired)
        Invoke(new Action<List<CardItem>>(DisplayCards), cards);
      else
      {
        try
        {
          cardDisplayView = new CardDisplayView();
          cardDisplayView.StartPosition = FormStartPosition.CenterParent;
          cardDisplayView.AddCards(cards);
          cardDisplayView.ShowDialog(this);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void CloseDisplay()
    {
      if(InvokeRequired)
        Invoke(new Action(CloseDisplay));
      else
      {
        try
        {
          if(!cardDisplayView.IsClosing)
            cardDisplayView.Close();
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public class AddLookupArgs
    {
      public string LookupKey;
      public LookupRules Rules;
      public string PlayerKey;
      public bool ReadOnly;
      public string SectorKey;
    }

    public void OpenSectorLookup(string key, LookupRules rules, string playerKey, bool readOnly, string sectorKey)
    {
      AddLookupArgs args = new AddLookupArgs() { LookupKey = key, Rules = rules, PlayerKey = playerKey, ReadOnly = readOnly, SectorKey = sectorKey };
      if(InvokeRequired)
        Invoke(new Action<AddLookupArgs>(OpenSectorLookup), args);
      else
      {
        try
        {
          OpenSectorLookup(args);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    void OpenSectorLookup(AddLookupArgs args)
    {
      ISectorView sector = (ISectorView)Controls.Find(args.SectorKey, true).First();      
      LookupView lookupView = new LookupView(args.Rules, args.ReadOnly, sector.SectorItem, args.SectorKey, args.PlayerKey);
      lookupView.Name = args.LookupKey;
      lookupViews.Add(lookupView);
      if(gameStructure.GetActivePlayer().PlayerKey == args.PlayerKey)
        lookupView.Show(this);
      UpdateLookupPlayers();
    }

    void UpdateLookupPlayers()
    {
      foreach(var player in gameStructure.Players)
        foreach(var sectorStruct in player.Sectors)
          foreach(var sectorView in this.Controls.Find(sectorStruct.SectorKey, true))
        {
          SimpleSectorView simpleSector = sectorView as SimpleSectorView;
          if(simpleSector != null)
          {
            var playerNames = lookupViews.Where(e => e.SectorKey == simpleSector.SectorKey)
              .Select(e => gameStructure.GetPlayer(e.PlayerKey).Item.NickName).Distinct().ToList();
            simpleSector.SetLookupPlayers(playerNames);
          }
        }
    }

    public void CloseSectorLookup(string key)
    {
      if(InvokeRequired)
        Invoke(new Action<string>(CloseSectorLookup), key);
      else
      {
        try
        {
          LookupView lookupView = lookupViews.Single(e => e.Name == key);
          lookupViews.Remove(lookupView);
          if(!lookupView.IsClosing)
            lookupView.Close();
          UpdateLookupPlayers();
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public class AddLookupCardArgs
    {
      public string LookupKey;
      public string CardKey;
      public bool Hidden;
      public CardItem CardItem;
      public int Index;
    }

    public void AddLookupCard(string lookupKey, string cardKey, bool hidden, CardItem cardItem, int index)
    {
      AddLookupCardArgs args = new AddLookupCardArgs() { LookupKey = lookupKey, CardKey = cardKey, Hidden = hidden, CardItem = cardItem, Index = index };
      if(InvokeRequired)
        Invoke(new Action<AddLookupCardArgs>(AddLookupCard), args);
      else
      {
        try
        {
          AddLookupCard(args);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    void AddLookupCard(AddLookupCardArgs args)
    {
      LookupView lookupView = lookupViews.Single(e => e.Name == args.LookupKey);
      lookupView.AddCard(args.CardKey, args.Hidden, args.CardItem, args.Index);
    }

    public void RemoveLookupCard(string lookupKey, string cardKey)
    {
      if(InvokeRequired)
        Invoke(new Action<string, string>(RemoveLookupCard), lookupKey, cardKey);
      else
      {
        try
        {
          LookupView lookupView = lookupViews.Single(e => e.Name == lookupKey);
          lookupView.RemoveCard(cardKey);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void MoveLookupCard(string lookupKey, string cardKey, int newIndex)
    {
      if(InvokeRequired)
        Invoke(new Action<string, string, int>(MoveLookupCard), lookupKey, cardKey, newIndex);
      else
      {
        try
        {
          LookupView lookupView = lookupViews.Single(e => e.Name == lookupKey);
          lookupView.MoveCard(cardKey, newIndex);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void UpdateLookupCard(string lookupKey, string cardKey, CardItem cardItem)
    {
      if(InvokeRequired)
        Invoke(new Action<string, string, CardItem>(UpdateLookupCard), lookupKey, cardKey, cardItem);
      else
      {
        try
        {
          LookupView lookupView = lookupViews.Single(e => e.Name == lookupKey);
          lookupView.UpdateCard(cardKey, cardItem);
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void ClearLookupCards(string lookupKey)
    {
      if(InvokeRequired)
        Invoke(new Action<string>(ClearLookupCards), lookupKey);
      else
      {
        try
        {
          LookupView lookupView = lookupViews.Single(e => e.Name == lookupKey);
          lookupView.ClearCards();
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void SetPlayerPoints(string playerKey, int value)
    {
      if(InvokeRequired)
        Invoke(new Action<string, int>(SetPlayerPoints), playerKey, value);
      else
      {
        try
        {
          PlayerStatusView playerStatusView = (PlayerStatusView)Controls.Find(playerKey, true).OfType<PlayerStatusView>().First();
          playerStatusView.PlayerPoints = value;
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void SetNumCounterValue(string numCounterKey, int value)
    {
      if(InvokeRequired)
        Invoke(new Action<string, int>(SetNumCounterValue), numCounterKey, value);
      else
      {
        try
        {
          foreach(NumCounterView view in Controls.Find(numCounterKey, true))
            view.CounterValue = value;
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    public void UpdateNumCounter(string key, NumCounterItem numCounterItem)
    {
      if(InvokeRequired)
        Invoke(new Action<string, NumCounterItem>(UpdateNumCounter), key, numCounterItem);
      else
      {
        try
        {
          foreach(NumCounterView view in Controls.Find(key, true))
            view.Name = numCounterItem.Name;
        }
        catch(Exception ex)
        {
          HandleException(ex);
        }
      }
    }

    #endregion
  }

  public class GameStructure
  {
    public List<PlayerStructure> Players = new List<PlayerStructure>();

    public PlayerStructure GetPlayer(string key)
    {
      return Players.Single(e => e.PlayerKey == key);
    }

    public PlayerStructure GetActivePlayer()
    {
      return Players.Single(e => e.IsActive);
    }

    public List<PlayerStructure> GetOpponents()
    {
      return Players.Where(e => !e.IsActive).ToList();
    }
  }

  public class PlayerStructure
  {
    public string PlayerKey;
    public PlayerInfo Item;
    public bool IsActive;
    public List<SectorStructure> Sectors = new List<SectorStructure>();

    public SectorStructure GetSector(string key)
    {
      return Sectors.Single(e => e.SectorKey == key);
    }
  }

  public class SectorStructure
  {
    public string SectorKey { get; set; }
    public SectorItem Item { get; set; }
  }
}
