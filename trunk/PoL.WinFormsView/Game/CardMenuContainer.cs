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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PoL.Logic.Controllers;
using PoL.Common;
using PoL.Services.DataEntities;
using PoL.WinFormsView.Utils;
using PoL.Logic.Commands.Game;

namespace PoL.WinFormsView.Game
{
  public partial class CardMenuContainer : UserControl, ILocalizable
  {
    ISectorView sectorView;

    public CardMenuContainer()
    {
      InitializeComponent();

      menuRotate.Click += new EventHandler(menuRotate_Click);
      menuLock.Click += new EventHandler(menuLock_Click);
      menuReverse.Click += new EventHandler(menuReverse_Click);
      menuVisible.Click += new EventHandler(menuVisible_Click);
      menuOwnerOnly.Click += new EventHandler(menuOwnerOnly_Click);
      menuHidden.Click += new EventHandler(menuHidden_Click);
      menuAddToken.Click += new EventHandler(menuAddToken_Click);
      menuChangeCharacteristics.Click += new EventHandler(menuChangeCharacteristics_Click);
      menuDuplicate.Click += new EventHandler(menuDuplicate_Click);
      menuMoveToDefault.Click += new EventHandler(menuMoveToDefault_Click);
      menuMoveToDefault_VisibilityOwnerOnly.Click += new EventHandler(menuMoveToDefault_VisibilityOwnerOnly_Click);
      menuMoveToTopSector.Click += new EventHandler(menuMoveToTopSector_Click);
      menuMoveToBottomSector.Click += new EventHandler(menuMoveToBottomSector_Click);
      menuShowToPlayer.Click += new EventHandler(menuShowToPlayer_Click);

      menu.Opening += new CancelEventHandler(menu_Opening);
      
      menu.Tag = this;
      
      Localize();
    }

    GameView GameView
    {
      get { return (GameView)CardView.FindForm(); }
    }

    void menuLock_Click(object sender, EventArgs e)
    {
      try
      {
        List<string> cardKeys = sectorView.CardViews.Where(c => c.Selected).Select(c => c.Name).ToList();
        if(cardKeys.Count > 0)
          GameView.Controller.LockCards(cardKeys);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menu_Opening(object sender, CancelEventArgs e)
    {
      try
      {
        e.Cancel = !GameView.IsSolitaire && GameView.ActivePlayerKey != GameViewHelper.FindParentPlayerView(CardView).Name;

        if(!e.Cancel)
        {
          menuAddToken.Enabled = CardView.TokenKeys.Count() < 6;
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuShowToPlayer_Click(object sender, EventArgs e)
    {
      try
      {
        List<string> cardKeys = sectorView.CardViews.Where(c => c.Selected).Select(c => c.Name).ToList();
        if(cardKeys.Count > 0)
        {
          string opponentKey = GameViewHelper.QueryForOpponent(this, GameView.GameStructure.GetOpponents());
          if(!string.IsNullOrEmpty(opponentKey))
            GameView.Controller.DisplayCards(opponentKey, cardKeys);
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuMoveToBottomSector_Click(object sender, EventArgs e)
    {
      try
      {
        var cards = sectorView.CardViews.Where(c => c.Selected).ToList();
        if(cards.Count > 0)
        {
          string targetSectorCode = GameViewHelper.QueryForSector(this, GameView.GameStructure.GetActivePlayer().Sectors);
          if(!string.IsNullOrEmpty(targetSectorCode))
            GameViewHelper.RaiseMoveCards(GameView, cards, targetSectorCode, CardPositionOffset.Bottom);
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuMoveToTopSector_Click(object sender, EventArgs e)
    {
      try
      {
        var cards = sectorView.CardViews.Where(c => c.Selected).ToList();
        if(cards.Count > 0)
        {
          string targetSectorCode = GameViewHelper.QueryForSector(this, GameView.GameStructure.GetActivePlayer().Sectors);
          if(!string.IsNullOrEmpty(targetSectorCode))
            GameViewHelper.RaiseMoveCards(GameView, cards, targetSectorCode);
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuMoveToDefault_VisibilityOwnerOnly_Click(object sender, EventArgs e)
    {
      try
      {
        var cards = sectorView.CardViews.Where(c => c.Selected).ToList();
        if(cards.Count > 0)
          GameViewHelper.RaiseMoveCards(GameView, cards, sectorView.SectorItem.DefaultTarget, CardVisibility.Private);        
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuMoveToDefault_Click(object sender, EventArgs e)
    {
      try
      {
        var cards = sectorView.CardViews.Where(c => c.Selected).ToList();
        if(cards.Count > 0)
          GameViewHelper.RaiseMoveCards(GameView, cards, sectorView.SectorItem.DefaultTarget);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuChangeCharacteristics_Click(object sender, EventArgs e)
    {
      try
      {
        //var cards = sectorView.CardViews.Where(c => c.Selected).ToList();
        //if(cards.Count > 0)
        //{
        //  CharacteristicsEditor dlg = new CharacteristicsEditor(cards.Count > 1 ? 
        //    string.Empty : CardView.CardViewItem.CustomCharacteristics);
        //  dlg.StartPosition = FormStartPosition.CenterScreen;
        //  if(dlg.ShowDialog(this) == DialogResult.OK)
        //    GameView.Controller.SetCardsCustomCharacteristics(cards.Select(c => c.Name).ToList(), 
        //      dlg.CardCharacteristics, true, dlg.ApplyNumericalIncrement);
        //}
        GameViewHelper.RaiseChangeCardCharacteristics(GameView, ChangeCardCharacteristicsMode.Query);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuDuplicate_Click(object sender, EventArgs e)
    {
      try
      {
        GameViewHelper.RaiseDuplicateCard(GameView);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuAddToken_Click(object sender, EventArgs e)
    {
      try
      {
        GameViewHelper.RaiseAddCardToken(GameView);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuHidden_Click(object sender, EventArgs e)
    {
      try
      {
        List<string> cardKeys = sectorView.CardViews.Where(c => c.Selected).Select(c => c.Name).ToList();
        if(cardKeys.Count > 0)
          GameView.Controller.SetCardsVisibility(cardKeys, CardVisibility.Hidden);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuOwnerOnly_Click(object sender, EventArgs e)
    {
      try
      {
        List<string> cardKeys = sectorView.CardViews.Where(c => c.Selected).Select(c => c.Name).ToList();
        if(cardKeys.Count > 0)
          GameView.Controller.SetCardsVisibility(cardKeys, CardVisibility.Private);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuVisible_Click(object sender, EventArgs e)
    {
      try
      {
        List<string> cardKeys = sectorView.CardViews.Where(c => c.Selected).Select(c => c.Name).ToList();
        if(cardKeys.Count > 0)
          GameView.Controller.SetCardsVisibility(cardKeys, CardVisibility.Visible);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuReverse_Click(object sender, EventArgs e)
    {
      try
      {
        List<string> cardKeys = sectorView.CardViews.Where(c => c.Selected).Select(c => c.Name).ToList();
        if(cardKeys.Count > 0)
          GameView.Controller.ReverseCards(cardKeys);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuRotate_Click(object sender, EventArgs e)
    {
      try
      {
        List<string> cardKeys = sectorView.CardViews.Where(c => c.Selected).Select(c => c.Name).ToList();
        if(cardKeys.Count > 0)
          GameView.Controller.RotateCards(cardKeys);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    public CardView CardView { get; set; }

    public void Localize()
    {
      menuRotate.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("CARD_MENU", "ROTATE");
      menuReverse.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("CARD_MENU", "REVERSE");
      menuVisible.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("CARD_MENU", "VISIBILITY_VISIBLE");
      menuHidden.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("CARD_MENU", "VISIBILITY_HIDDEN");
      menuOwnerOnly.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("CARD_MENU", "VISIBILITY_PRIVATE");
      menuAddToken.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("CARD_MENU", "ADD_TOKEN");
      menuChangeCharacteristics.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("CARD_MENU", "SET_CHARACTERISTICS");
      menuDuplicate.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("CARD_MENU", "DUPLICATE");
      menuMoveToTopSector.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("CARD_MENU", "MOVE_TO_TOP_SECTOR");
      menuMoveToBottomSector.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("CARD_MENU", "MOVE_TO_BOTTOM_SECTOR");
      menuShowToPlayer.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("CARD_MENU", "SHOW");
      menuMoveToDefault.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("CARD_MENU", "MOVE_TO_DEFAULT");
      menuMoveToDefault_VisibilityOwnerOnly.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("CARD_MENU", "MOVE_TO_DEFAULT_PRIVATE");
      menuLock.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("CARD_MENU", "KEEP_ROTATED");
    }

    public ContextMenuStrip InnerMenu { get { return menu; } }

    public ISectorView SectorView
    {
      get { return sectorView; }
      set
      {
        try
        {
          sectorView = value;

          menuRotate.Visible = sectorView.SectorItem.Behavior == SectorBehavior.StaticFree;
          menuLock.Visible = sectorView.SectorItem.Behavior == SectorBehavior.StaticFree;
          sepRotation.Visible = sectorView.SectorItem.Behavior == SectorBehavior.StaticFree;

          menuReverse.Visible = sectorView.SectorItem.Behavior == SectorBehavior.StaticFree;
          menuVisible.Visible = sectorView.SectorItem.Behavior == SectorBehavior.StaticFree;
          menuOwnerOnly.Visible = sectorView.SectorItem.Behavior == SectorBehavior.StaticFree;
          menuHidden.Visible = sectorView.SectorItem.Behavior == SectorBehavior.StaticFree;
          sepVisibility.Visible = sectorView.SectorItem.Behavior == SectorBehavior.StaticFree;

          menuAddToken.Visible = sectorView.SectorItem.Behavior == SectorBehavior.StaticFree;
          menuChangeCharacteristics.Visible = sectorView.SectorItem.Behavior == SectorBehavior.StaticFree;
          menuDuplicate.Visible = sectorView.SectorItem.Behavior == SectorBehavior.StaticFree;
          sepCard.Visible = sectorView.SectorItem.Behavior == SectorBehavior.StaticFree;

          menuMoveToDefault.Visible = sectorView.SectorItem.Behavior == SectorBehavior.CollapsableFlow;
          menuMoveToDefault_VisibilityOwnerOnly.Visible = sectorView.SectorItem.Behavior == SectorBehavior.CollapsableFlow;
          sepMoveDefault.Visible = sectorView.SectorItem.Behavior == SectorBehavior.CollapsableFlow;

          menuMoveToTopSector.Visible = true;
          menuMoveToBottomSector.Visible = true;
          sepMove.Visible = true;

          menuShowToPlayer.Visible = true;
        }
        catch(Exception ex)
        {
          GameView.HandleException(ex);
        }
      }
    }
  }
}

