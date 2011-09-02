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
using PoL.Services.DataEntities;
using PoL.Common;

namespace PoL.Logic.Controllers
{
  public class SectorActionsSupporting
  {
    SectorItem sector;
    Dictionary<SectorActions, bool> supportEntries = new Dictionary<SectorActions, bool>();

    public SectorActionsSupporting(SectorItem sector, GameType gameType, bool isActivePlayer)
    {
      this.sector = sector;

      supportEntries.Add(SectorActions.StraightAllCards,
        sector.Behavior == SectorBehavior.StaticFree && (gameType == GameType.Solitaire || isActivePlayer));
      supportEntries.Add(SectorActions.ChangeAllCardsCharacteristics,
        sector.Behavior == SectorBehavior.StaticFree && (gameType == GameType.Solitaire || isActivePlayer));
      supportEntries.Add(SectorActions.CreatePawn,
        sector.Behavior == SectorBehavior.StaticFree && (gameType == GameType.Solitaire || isActivePlayer));
      supportEntries.Add(SectorActions.Shuffle,
        sector.Behavior == SectorBehavior.Simple && sector.CardsVisibility == SectorCardsVisibility.Hidden && (gameType == GameType.Solitaire || isActivePlayer));
      supportEntries.Add(SectorActions.Mulligan,
        sector.Code == SystemSectors.HAND.ToString() && (gameType == GameType.Solitaire || isActivePlayer));
      supportEntries.Add(SectorActions.MoveCards,
        (gameType == GameType.Solitaire || isActivePlayer));
      supportEntries.Add(SectorActions.MoveCardsToDefaultSector,
        (sector.Behavior == SectorBehavior.Simple || sector.Behavior == SectorBehavior.CollapsableFlow) && !string.IsNullOrEmpty(sector.DefaultTarget) && (gameType == GameType.Solitaire || isActivePlayer));
      supportEntries.Add(SectorActions.MoveTopCards,
         sector.Behavior == SectorBehavior.Simple && (gameType == GameType.Solitaire || isActivePlayer));
      supportEntries.Add(SectorActions.MoveRandomCards,
        sector.Behavior == SectorBehavior.CollapsableFlow && sector.CardsVisibility != SectorCardsVisibility.Visibile && (gameType == GameType.Solitaire || isActivePlayer));
      supportEntries.Add(SectorActions.MoveAllCards,
        (gameType == GameType.Solitaire || isActivePlayer));
      supportEntries.Add(SectorActions.ShowTop,
        sector.Behavior == SectorBehavior.Simple && sector.CardsVisibility != SectorCardsVisibility.Visibile && (gameType == GameType.Solitaire || isActivePlayer));
      supportEntries.Add(SectorActions.ShowRandomCards,
        sector.Behavior == SectorBehavior.CollapsableFlow && sector.CardsVisibility != SectorCardsVisibility.Visibile && (gameType == GameType.Solitaire || isActivePlayer));
      supportEntries.Add(SectorActions.Show,
        sector.CardsVisibility != SectorCardsVisibility.Visibile && (gameType == GameType.Solitaire || isActivePlayer));
      supportEntries.Add(SectorActions.Watch,
        sector.Behavior == SectorBehavior.Simple && (gameType == GameType.Solitaire || isActivePlayer || sector.CardsVisibility == SectorCardsVisibility.Visibile));
      supportEntries.Add(SectorActions.KeepUncovered,
        sector.CardsVisibility == SectorCardsVisibility.Hidden && (gameType == GameType.Solitaire || isActivePlayer));
    }

    public SectorItem Sector
    {
      get { return sector; }
    }

    public bool Supports(SectorActions action)
    {
      return supportEntries[action];
    }

    public bool NoneSupported
    {
      get { return supportEntries.Values.All(e => !e); }
    }
  }

  public enum SectorActions
  {
    StraightAllCards,
    ChangeAllCardsCharacteristics,
    CreatePawn,
    Shuffle,
    MoveCards,
    MoveCardsToDefaultSector,
    MoveTopCards,
    MoveRandomCards,
    MoveAllCards,
    ShowTop,
    ShowRandomCards,
    Show,
    Watch,
    KeepUncovered,
    Mulligan,
  }
}
