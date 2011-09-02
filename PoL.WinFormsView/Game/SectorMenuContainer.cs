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
using PoL.Services.DataEntities;
using PoL.Common;
using PoL.WinFormsView.Utils;
using PoL.Logic.Views;

namespace PoL.WinFormsView.Game
{
  public partial class SectorMenuContainer : UserControl, ILocalizable
  {
    ISectorView sectorView;

    public SectorMenuContainer()
    {
      InitializeComponent();

      menu.Opening += new CancelEventHandler(menu_Opening);
      menuStraightAllCards.Click += new EventHandler(menuStraightAllCards_Click);
      menuChangeAllCardsCharacteristics.Click += new EventHandler(menuChangeAllCharacteristics_Click);
      menuCreatePawn.Click += new EventHandler(menuCreatePawn_Click);
      menuShowXRandomToPlayer.Click += new EventHandler(menuShowXRandomToPlayer_Click);
      menuMoveXRandomToSector.Click += new EventHandler(menuMoveXRandomToSector_Click);
      menuMoveAllToTopSector.Click += new EventHandler(menuMoveAllToTopSector_Click);
      menuMoveAllToBottomSector.Click += new EventHandler(menuMoveAllToBottomSector_Click);
      menuShuffle.Click += new EventHandler(menuShuffle_Click);
      menuMoveTopToDefaultSector.Click += new EventHandler(menuMoveTopToDefaultSector_Click);
      menuMoveXTopToDefaultSector.Click += new EventHandler(menuMoveXTopToDefaultSector_Click);
      menuWatchXTop.Click += new EventHandler(menuWatchXTop_Click);
      menuShowXTopToPlayer.Click += new EventHandler(menuShowXTopToPlayer_Click);
      menuWatchAll.Click += new EventHandler(menuWatchAll_Click);
      menuShowAllToPlayer.Click += new EventHandler(menuShowAllToPlayer_Click);
      menuKeepUncoveredXTop.Click += new EventHandler(menuKeepUncoveredXTop_Click);
      menuMoveXTopToSector.Click += new EventHandler(menuMoveXTopToSector_Click);
      menuMulligan.Click += new EventHandler(menuMulligan_Click);

      menu.Tag = this;

      Localize();
    }

    void menu_Opening(object sender, CancelEventArgs e)
    {
      try
      {
        if(GameView.SectorActionsSupporting[sectorView.SectorKey].NoneSupported)
          e.Cancel = true;
        else
        {
          menuStraightAllCards.Visible = GameView.SectorActionsSupporting[sectorView.SectorKey].Supports(SectorActions.StraightAllCards);
          menuChangeAllCardsCharacteristics.Visible = GameView.SectorActionsSupporting[sectorView.SectorKey].Supports(SectorActions.ChangeAllCardsCharacteristics);
          menuCreatePawn.Visible = GameView.SectorActionsSupporting[sectorView.SectorKey].Supports(SectorActions.CreatePawn);

          menuShuffle.Visible = GameView.SectorActionsSupporting[sectorView.SectorKey].Supports(SectorActions.Shuffle);          
          sepShuffle.Visible = GameView.SectorActionsSupporting[sectorView.SectorKey].Supports(SectorActions.Shuffle);

          menuMoveTopToDefaultSector.Visible = GameView.SectorActionsSupporting[sectorView.SectorKey].Supports(SectorActions.MoveCardsToDefaultSector);
          menuMoveXTopToDefaultSector.Visible = GameView.SectorActionsSupporting[sectorView.SectorKey].Supports(SectorActions.MoveCardsToDefaultSector);
          sepDefault.Visible = GameView.SectorActionsSupporting[sectorView.SectorKey].Supports(SectorActions.MoveCardsToDefaultSector);

          menuMoveXTopToSector.Visible = GameView.SectorActionsSupporting[sectorView.SectorKey].Supports(SectorActions.MoveTopCards);
          menuMoveXRandomToSector.Visible = GameView.SectorActionsSupporting[sectorView.SectorKey].Supports(SectorActions.MoveRandomCards);
          menuMoveAllToTopSector.Visible = GameView.SectorActionsSupporting[sectorView.SectorKey].Supports(SectorActions.MoveAllCards);
          menuMoveAllToBottomSector.Visible = GameView.SectorActionsSupporting[sectorView.SectorKey].Supports(SectorActions.MoveAllCards);

          menuShowXRandomToPlayer.Visible = GameView.SectorActionsSupporting[sectorView.SectorKey].Supports(SectorActions.ShowRandomCards);
          menuShowXTopToPlayer.Visible = GameView.SectorActionsSupporting[sectorView.SectorKey].Supports(SectorActions.ShowTop);
          menuShowAllToPlayer.Visible = GameView.SectorActionsSupporting[sectorView.SectorKey].Supports(SectorActions.Show);

          menuWatchXTop.Visible = GameView.SectorActionsSupporting[sectorView.SectorKey].Supports(SectorActions.Watch);
          menuWatchAll.Visible = GameView.SectorActionsSupporting[sectorView.SectorKey].Supports(SectorActions.Watch);

          menuKeepUncoveredXTop.Visible = GameView.SectorActionsSupporting[sectorView.SectorKey].Supports(SectorActions.KeepUncovered);
          sepShow.Visible = GameView.SectorActionsSupporting[sectorView.SectorKey].Supports(SectorActions.Show);

          menuMulligan.Visible = GameView.SectorActionsSupporting[sectorView.SectorKey].Supports(SectorActions.Mulligan);

          //

          menuStraightAllCards.Enabled = GameView.SectorActionsAbilitations[sectorView.SectorKey][SectorActions.StraightAllCards];
          menuChangeAllCardsCharacteristics.Enabled = GameView.SectorActionsAbilitations[sectorView.SectorKey][SectorActions.ChangeAllCardsCharacteristics];

          menuShuffle.Enabled = GameView.SectorActionsAbilitations[sectorView.SectorKey][SectorActions.Shuffle];

          menuMoveXTopToSector.Enabled = GameView.SectorActionsAbilitations[sectorView.SectorKey][SectorActions.MoveTopCards];
          menuMoveXRandomToSector.Enabled = GameView.SectorActionsAbilitations[sectorView.SectorKey][SectorActions.MoveRandomCards];
          menuMoveAllToTopSector.Enabled = GameView.SectorActionsAbilitations[sectorView.SectorKey][SectorActions.MoveAllCards];
          menuMoveAllToBottomSector.Enabled = GameView.SectorActionsAbilitations[sectorView.SectorKey][SectorActions.MoveAllCards];
          menuMoveTopToDefaultSector.Enabled = GameView.SectorActionsAbilitations[sectorView.SectorKey][SectorActions.MoveCardsToDefaultSector];
          menuMoveXTopToDefaultSector.Enabled = GameView.SectorActionsAbilitations[sectorView.SectorKey][SectorActions.MoveCardsToDefaultSector];

          menuShowXRandomToPlayer.Enabled = GameView.SectorActionsAbilitations[sectorView.SectorKey][SectorActions.ShowRandomCards];
          menuShowXTopToPlayer.Enabled = GameView.SectorActionsAbilitations[sectorView.SectorKey][SectorActions.ShowTop];
          menuShowAllToPlayer.Enabled = GameView.SectorActionsAbilitations[sectorView.SectorKey][SectorActions.Show];

          menuMulligan.Visible = GameView.SectorActionsAbilitations[sectorView.SectorKey][SectorActions.Mulligan];
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    public void Localize()
    {
      menuStraightAllCards.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("SECTOR_MENU", "ROTATE_ALL");
      menuChangeAllCardsCharacteristics.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("SECTOR_MENU", "CHANGE_ALL_CHARACTERISTICS");
      menuCreatePawn.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("SECTOR_MENU", "CREATE_PAWN");
      menuShowXRandomToPlayer.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("SECTOR_MENU", "SHOW_X_RANDOM");
      menuMoveXRandomToSector.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("SECTOR_MENU", "MOVE_X_RANDOM");
      menuMoveAllToTopSector.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("SECTOR_MENU", "MOVE_ALL_TO_TOP");
      menuMoveAllToBottomSector.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("SECTOR_MENU", "MOVE_ALL_TO_BOTTOM");
      menuShuffle.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("SECTOR_MENU", "SHUFFLE");
      menuMoveTopToDefaultSector.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("SECTOR_MENU", "MOVE_TOP_TO_DEFAULT");
      menuMoveXTopToDefaultSector.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("SECTOR_MENU", "MOVE_X_TO_DEFAULT");
      menuWatchXTop.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("SECTOR_MENU", "WATCH_X_TOP");
      menuWatchAll.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("SECTOR_MENU", "WATCH_ALL");
      menuShowXTopToPlayer.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("SECTOR_MENU", "SHOW_X_TOP");
      menuShowAllToPlayer.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("SECTOR_MENU", "SHOW_ALL");
      menuKeepUncoveredXTop.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("SECTOR_MENU", "KEEP_UNCOVERED_X");
      menuMoveXTopToSector.Text = Program.LogicHandler.ServicesProvider.GameStringsService.GetString("SECTOR_MENU", "MOVE_X_TOP");
    }

    public ISectorView SectorView
    {
      get { return sectorView; }
      set { sectorView = value; }
    }

    public ContextMenuStrip InnerMenu { get { return menu; } }

    GameView GameView
    {
      get { return (GameView)((Control)sectorView).FindForm(); }
    }

    void menuMoveXTopToSector_Click(object sender, EventArgs e)
    {
      try
      {
        int? num = GameViewHelper.QueryForNumber(this);
        if(num.HasValue)
        {
          string targetSectorCode = GameViewHelper.QueryForSector(this, GameView.GameStructure.GetActivePlayer().Sectors);
          if(!string.IsNullOrEmpty(targetSectorCode))
          {
            GameViewHelper.RaiseMoveCards(GameView, sectorView.CardViews.Take(num.Value).ToList(), targetSectorCode);
          }
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }


    void menuKeepUncoveredXTop_Click(object sender, EventArgs e)
    {
      try
      {
        int? num = GameViewHelper.QueryForNumber(this);
        if(num.HasValue)
        {
          GameView.Controller.OpenSectorLookup(sectorView.SectorKey, GameView.ActivePlayerKey, LookupOpenMode.KeepVisibleTop, num.Value);
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuShowAllToPlayer_Click(object sender, EventArgs e)
    {
      try
      {
        string opponentKey = GameViewHelper.QueryForOpponent(this, GameView.GameStructure.GetOpponents());
        if(!string.IsNullOrEmpty(opponentKey))
          GameView.Controller.OpenSectorLookup(sectorView.SectorKey, opponentKey, LookupOpenMode.All, -1);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuWatchAll_Click(object sender, EventArgs e)
    {
      try
      {
        GameView.Controller.OpenSectorLookup(sectorView.SectorKey, GameView.ActivePlayerKey, LookupOpenMode.All, -1);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuShowXTopToPlayer_Click(object sender, EventArgs e)
    {
      try
      {
        int? num = GameViewHelper.QueryForNumber(this);
        if(num.HasValue)
        {
          string opponentKey = GameViewHelper.QueryForOpponent(this, GameView.GameStructure.GetOpponents());
          if(!string.IsNullOrEmpty(opponentKey))
            //GameView.Controller.OpenSectorLookup(sectorView.SectorKey, opponentKey, LookupOpenMode.Top, num.Value);
            GameView.Controller.DisplayCards(opponentKey, sectorView.CardViews.Take(num.Value).Select(c => c.Name).ToList());
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuWatchXTop_Click(object sender, EventArgs e)
    {
      try
      {
        int? num = GameViewHelper.QueryForNumber(this);
        if(num.HasValue)
          GameView.Controller.OpenSectorLookup(sectorView.SectorKey, GameView.ActivePlayerKey, LookupOpenMode.Top, num.Value);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuMoveXTopToDefaultSector_Click(object sender, EventArgs e)
    {
      try
      {
        if(!string.IsNullOrEmpty(sectorView.SectorItem.DefaultTarget))
        {
          int? num = GameViewHelper.QueryForNumber(this);
          if(num.HasValue)
          {
            GameViewHelper.RaiseMoveCards(GameView, sectorView.CardViews.Take(num.Value).ToList(), sectorView.SectorItem.DefaultTarget);
          }
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuMoveTopToDefaultSector_Click(object sender, EventArgs e)
    {
      try
      {
        if(!string.IsNullOrEmpty(sectorView.SectorItem.DefaultTarget))
        {
          GameViewHelper.RaiseMoveCards(GameView, sectorView.CardViews.Take(1).ToList(), sectorView.SectorItem.DefaultTarget);
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuShuffle_Click(object sender, EventArgs e)
    {
      try
      {
        GameView.Controller.ShuffleSector(sectorView.SectorKey);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuMulligan_Click(object sender, EventArgs e)
    {
      try
      {
        GameView.Controller.DoMulligan();
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuMoveAllToBottomSector_Click(object sender, EventArgs e)
    {
      try
      {
        string targetSectorCode = GameViewHelper.QueryForSector(this, GameView.GameStructure.GetActivePlayer().Sectors);
        if(!string.IsNullOrEmpty(targetSectorCode))
          GameViewHelper.RaiseMoveCards(GameView, sectorView.CardViews.ToList(), targetSectorCode, CardPositionOffset.Bottom);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuMoveAllToTopSector_Click(object sender, EventArgs e)
    {
      try
      {
        string targetSectorCode = GameViewHelper.QueryForSector(this, GameView.GameStructure.GetActivePlayer().Sectors);
        if(!string.IsNullOrEmpty(targetSectorCode))
          GameViewHelper.RaiseMoveCards(GameView, sectorView.CardViews.ToList(), targetSectorCode);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuMoveXRandomToSector_Click(object sender, EventArgs e)
    {
      try
      {
        int? num = GameViewHelper.QueryForNumber(this);
        if(num.HasValue)
        {
          string targetSectorCode = GameViewHelper.QueryForSector(this, GameView.GameStructure.GetActivePlayer().Sectors);
          if(!string.IsNullOrEmpty(targetSectorCode))
            GameViewHelper.RaiseMoveRandomCards(GameView, num.Value, sectorView.SectorItem.Code, targetSectorCode);
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuShowXRandomToPlayer_Click(object sender, EventArgs e)
    {
      try
      {
        int? num = GameViewHelper.QueryForNumber(this);
        if(num.HasValue)
        {
          string opponentKey = GameViewHelper.QueryForOpponent(this, GameView.GameStructure.GetOpponents());
          if(!string.IsNullOrEmpty(opponentKey))
            GameView.Controller.DisplayRandomCards(sectorView.SectorKey, opponentKey, num.Value);
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }     
    }

    void menuCreatePawn_Click(object sender, EventArgs e)
    {
      try
      {
        GameViewHelper.RaiseCreatePawn(GameView);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuStraightAllCards_Click(object sender, EventArgs e)
    {
      try
      {
        GameView.Controller.RotateSectorCards(sectorView.SectorKey);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void menuChangeAllCharacteristics_Click(object sender, EventArgs e)
    {
      try
      {
        CharacteristicsEditor dlg = new CharacteristicsEditor(string.Empty);
        dlg.StartPosition = FormStartPosition.CenterScreen;
        if(dlg.ShowDialog(this) == DialogResult.OK)
          GameView.Controller.SetCardsCustomCharacteristics(sectorView.CardViews.Select(v => v.Name).ToList(),
            dlg.CardCharacteristics, false, dlg.ApplyNumericalIncrement);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }
  }
}
