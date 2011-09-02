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

using System.Windows.Forms;
using PoL.Common;
using PoL.Services.DataEntities;
using System.Drawing;
using PoL.Services;
using PoL.Logic.Controllers;


namespace PoL.WinFormsView.Game
{
  public class GameViewHelper
  {
    static public ISectorView FindParentSectorView(Control control)
    {
      Control parent = control.Parent;
      while(parent != control.FindForm() && !(parent is ISectorView))
        parent = parent.Parent;
      return parent as ISectorView;
    }

    static public PlayerView FindParentPlayerView(Control control)
    {
      Control parent = control.Parent;
      while(parent != control.FindForm() && !(parent is PlayerView))
        parent = parent.Parent;
      return parent as PlayerView;
    }

    static public PlayerStatusView FindParentPlayerStatusView(Control control)
    {
      Control parent = control.Parent;
      while(parent != control.FindForm() && !(parent is PlayerStatusView))
        parent = parent.Parent;
      return parent as PlayerStatusView;
    }

    static public CardView FindParentCardView(Control control)
    {
      Control parent = control.Parent;
      while(parent != control.FindForm() && !(parent is CardView))
        parent = parent.Parent;
      return parent as CardView;
    }

    static public string QueryForSector(IWin32Window win, List<SectorStructure> sectors)
    {
      string sectorCode = string.Empty;
      SectorInput editor = new SectorInput(sectors);
      editor.StartPosition = FormStartPosition.CenterScreen;
      if(editor.ShowDialog(win) == DialogResult.OK)
        sectorCode = editor.SelectedSectorCode;
      return sectorCode;
    }

    static public int? QueryForNumber(IWin32Window win)
    {
      return QueryForNumber(win, false);
    }

    static public int? QueryForNumber(IWin32Window win, bool allowNegative)
    {
      int? num = null;
      NumberInput editor = new NumberInput();
      editor.AllowNegative = allowNegative;
      editor.StartPosition = FormStartPosition.CenterScreen;
      if(editor.ShowDialog(win) == DialogResult.OK)
        num = editor.SelectedValue;
      return num;
    }

    static public string QueryForOpponent(IWin32Window win, List<PlayerStructure> opponents)
    {
      string opponentKey = string.Empty;
      if(opponents.Count == 1)
        opponentKey = opponents.First().PlayerKey;
      else if(opponents.Count > 1)
      {
        PlayerInput editor = new PlayerInput(opponents);
        editor.StartPosition = FormStartPosition.CenterScreen;
        if(editor.ShowDialog(win) == DialogResult.OK)
          opponentKey = editor.SelectedPlayerKey;
      }
      return opponentKey;
    }

    static bool TryGetSectorValidCardPositions(ISectorView sectorView, CardPositionOffset offset, int positionAmount, out List<CardPosition> cardPositions)
    {
      cardPositions = new List<CardPosition>();
      bool valid = true;
      if(sectorView is StaticFreeSectorView)
      {
        Rectangle cardRect = CardMetricsService.CardRect(CardStyleBehaviorsService.BEHAVIORS_SMALL);

        StaticFreeSectorView staticFreeSectorView = (StaticFreeSectorView)sectorView;
        Point startPoint = new Point();
        startPoint.X = (staticFreeSectorView.Width / 2) - (cardRect.Width / 2);
        startPoint.Y = (staticFreeSectorView.Height / 3) - (cardRect.Height / 2);
        List<PointF> normalizedPoints;
        valid = staticFreeSectorView.TryGetValidCardPositions(startPoint, positionAmount, new List<CardView>(), out normalizedPoints);
        if(valid)
        {
          for(int i = 0; i < positionAmount; i++)
          {
            int z = offset == CardPositionOffset.Top ? i : sectorView.CardViews.Count + i;
            cardPositions.Add(new CardPosition(normalizedPoints[i].X, normalizedPoints[i].Y, z));
          }
        }
      }
      else
      {
        for(int i = 0; i < positionAmount; i++)
          cardPositions.Add(new CardPosition(0, 0, offset == CardPositionOffset.Top ? i : sectorView.CardViews.Count + i));
      }
      return valid;
    }

    public static void RaiseMoveCards(GameView gameView, List<CardView> cardViews, string targetSectorCode)
    {
      RaiseMoveCards(gameView, cardViews, targetSectorCode, CardPositionOffset.Top, null);
    }

    public static void RaiseMoveCards(GameView gameView, List<CardView> cardViews, string targetSectorCode, CardPositionOffset offset)
    {
      RaiseMoveCards(gameView, cardViews, targetSectorCode, offset, null);
    }

    public static void RaiseMoveCards(GameView gameView, List<CardView> cardViews, string targetSectorCode, CardVisibility? visibility)
    {
      RaiseMoveCards(gameView, cardViews, targetSectorCode, CardPositionOffset.Top, visibility);
    }

    public static void RaiseMoveCards(GameView gameView, List<CardView> cardViews, string targetSectorCode, CardPositionOffset offset, CardVisibility? visibility)
    {
      foreach(var cardsByOwner in cardViews.GroupBy(c => c.CardViewItem.OwnerPlayerKey))
      {
        List<CardPosition> positions;
        PlayerStructure ownerPlayer = gameView.GameStructure.GetPlayer(cardsByOwner.Key);
        ISectorView targetSectorView = (ISectorView)gameView.Controls.Find(ownerPlayer.Sectors.Single(e => e.Item.Code == targetSectorCode).SectorKey, true).First();
        if(GameViewHelper.TryGetSectorValidCardPositions(targetSectorView, offset, cardsByOwner.Count(), out positions))
          gameView.Controller.MoveCards(cardsByOwner.Select(e => e.Name).ToList(), targetSectorCode, positions, visibility);
      }
    }

    public static void RaiseMoveRandomCards(GameView gameView, int amount, string sourceSectorCode, string targetSectorCode)
    {
      List<CardPosition> positions;
      PlayerStructure activePlayer = gameView.GameStructure.GetActivePlayer();
      ISectorView targetSectorView = (ISectorView)gameView.Controls.Find(activePlayer.Sectors.Single(e => e.Item.Code == targetSectorCode).SectorKey, true).First();
      if(GameViewHelper.TryGetSectorValidCardPositions(targetSectorView, CardPositionOffset.Top, amount, out positions))
        gameView.Controller.MoveRandomCards(amount, sourceSectorCode, targetSectorCode, positions, null);
    }

    public static void RaiseCreatePawn(GameView gameView)
    {
      PawnEditor dlg = new PawnEditor(string.Empty, string.Empty, string.Empty, string.Empty);
      dlg.StartPosition = FormStartPosition.CenterScreen;
      if(dlg.ShowDialog(gameView) == DialogResult.OK)
      {
        var sectorKey = gameView.GameStructure.GetActivePlayer().Sectors.Single(e => e.Item.Code == SystemSectors.BATTLEFIELD.ToString()).SectorKey;
        ISectorView sectorView = (ISectorView)gameView.Controls.Find(sectorKey, true).First();
        List<CardPosition> cardPositions;
        if(GameViewHelper.TryGetSectorValidCardPositions(sectorView, CardPositionOffset.Top, 1, out cardPositions))
          gameView.Controller.CreatePawn(sectorView.SectorKey, dlg.NewName, dlg.NewType, dlg.NewText, dlg.NewCharacteristics, cardPositions.First());
      }
    }

    public static void RaiseDuplicateCard(GameView gameView)
    {
      List<CardPosition> cardPositions;
      var sectorKey = gameView.GameStructure.GetActivePlayer().Sectors.Single(e => e.Item.Code == SystemSectors.BATTLEFIELD.ToString()).SectorKey;
      ISectorView sectorView = (ISectorView)gameView.Controls.Find(sectorKey, true).First();
      var cardView = sectorView.CardViews.FirstOrDefault(c => c.Selected);
      if(cardView != null)
        if(GameViewHelper.TryGetSectorValidCardPositions(sectorView, CardPositionOffset.Top, 1, out cardPositions))
          gameView.Controller.DuplicateCard(cardView.Name, cardPositions.First());
    }

    public static void RaiseSetLifePoints(GameView gameView, PlayerStatusView playerStatusView, SetLifePointsMode mode)
    {
      if(gameView.ChangePointsAbilitationByPlayer[playerStatusView.Name])
      {
        int? num = null;
        switch(mode)
        {
          case SetLifePointsMode.Add: num = playerStatusView.PlayerPoints + 1; break;
          case SetLifePointsMode.Subtract: num = playerStatusView.PlayerPoints - 1; break;
          case SetLifePointsMode.Query: 
            num = QueryForNumber(gameView, true);
            if(num.HasValue)
              num = playerStatusView.PlayerPoints + num.Value;
              break;
        }
        if(num.HasValue)
          gameView.Controller.SetPlayerPoints(playerStatusView.Name, num.Value);
      }
    }

    public static void RaiseAddCardToken(GameView gameView)
    {
      var sectorKey = gameView.GameStructure.GetActivePlayer().Sectors.Single(e => e.Item.Code == SystemSectors.BATTLEFIELD.ToString()).SectorKey;
      ISectorView sectorView = (ISectorView)gameView.Controls.Find(sectorKey, true).First();
      var cardKeys = sectorView.CardViews.Where(c => c.Selected && c.TokenKeys.Count() < 6).Select(e => e.Name).ToList();
      if(cardKeys.Count > 0)
        gameView.Controller.AddToken(cardKeys, 1, string.Empty, TokenColor.Red);
    }

    public static void RaiseChangeCardCharacteristics(GameView gameView, ChangeCardCharacteristicsMode mode)
    {
      var sectorKey = gameView.GameStructure.GetActivePlayer().Sectors.Single(e => e.Item.Code == SystemSectors.BATTLEFIELD.ToString()).SectorKey;
      ISectorView sectorView = (ISectorView)gameView.Controls.Find(sectorKey, true).First();
      var cards = sectorView.CardViews.Where(c => c.Selected).ToList();
      if(cards.Count > 0)
      {
        string characteristics = null;
        bool applyNumericalIncrement = true;
        switch(mode)
        {
          case ChangeCardCharacteristicsMode.AddPower: characteristics = "1/0"; break;
          case ChangeCardCharacteristicsMode.SubtractPower: characteristics = "-1/0"; break;
          case ChangeCardCharacteristicsMode.AddToughness: characteristics = "0/1"; break;
          case ChangeCardCharacteristicsMode.SubtractToughness: characteristics = "0/-1"; break;
          case ChangeCardCharacteristicsMode.Query:
            {
              CharacteristicsEditor dlg = new CharacteristicsEditor(cards.Count > 1 ?
                string.Empty : cards.First().CardViewItem.CustomCharacteristics);
              dlg.StartPosition = FormStartPosition.CenterScreen;
              if(dlg.ShowDialog(gameView) == DialogResult.OK)
              {
                characteristics = dlg.CardCharacteristics;
                applyNumericalIncrement = dlg.ApplyNumericalIncrement;
              }
            }
            break;
        }
        if(characteristics != null)
          gameView.Controller.SetCardsCustomCharacteristics(cards.Select(c => c.Name).ToList(),
            characteristics, true, applyNumericalIncrement);
      }
    }
  }

  public enum CardPositionOffset
  {
    Top,
    Bottom
  }

  public enum SetLifePointsMode
  {
    Add,
    Subtract,
    Query
  }

  public enum ChangeCardCharacteristicsMode
  {
    AddPower,
    SubtractPower,
    AddToughness,
    SubtractToughness,
    Query
  }
}
