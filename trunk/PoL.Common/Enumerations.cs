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

namespace PoL.Common
{
  public enum GameType
  {
    Solitaire,
    Host,
    Client,
  }

  public enum CardPictureBehavior
  {
    Crop,
    Full
  }

  public enum SystemSectors
  {
    DECK,
    BATTLEFIELD,
    HAND
  }

  public enum DiceType
  {
    D4 = 4,
    D6 = 6,
    D8 = 8,
    D10 = 10,
    D12 = 12,
    D20 = 20
  }

  public enum DeckEditorListContext
  {
    Main,
    Sideboard,
    Archive
  }

  public enum SideboardingEditorListContext
  {
    Main,
    Sideboard,
  }

  public enum CardVisibility
  {
    Visible,
    Private,
    Hidden
  }

  public enum LookupOpenMode
  {
    All,
    Top,
    KeepVisibleTop,
  }

  public enum LookupStyle
  {
    All,
    Top,
    KeepVisibleTop,
  }

  public enum MoveCardsSourceMode
  {
    Specific,
    Random,
  }

  public enum DisplayCardsMode
  {
    Random,
    ByKeys
  }

  public enum SectorBehavior
  {
    Simple = 1,
    StaticFree = 2,
    CollapsableFlow = 3,
  }


  public enum SectorCardsVisibility
  {
    Hidden = 1,
    Visibile = 2,
    Private = 3,
  }

  public enum SmartNameVerbRule
  {
    None,
    ToBe,
    ToHave
  }

  public enum TokenColor
  {
    Red,
    Blue,
    Green,
    Purple,
    Azure,
    Yellow
  }

  public enum ConnectionResult
  {
    Accepted,
    VersionMismatch,
    GameDatabaseMismatch,
    CardDatabaseMismatch,
    PasswordRequired,
    NicknameDuplicated,
    InvalidStartMode,
    GameIsRunning
  }

  public enum ServerStarterState
  {
    Waiting,
    CanStart
  }

  public enum CostCriteria
  {
    None,
    LessThan,
    EqualTo,
    MoreThan
  }

  public enum GameStartMode
  {
    NewGame,
    SavedGame
  }
}
