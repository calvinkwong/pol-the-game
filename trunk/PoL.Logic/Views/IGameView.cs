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
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Patterns.MVC;
using PoL.Common;
using PoL.Logic.Controllers;
using PoL.Services.DataEntities;
using System.Windows;

namespace PoL.Logic.Views
{
  public interface IGameView : IView<IGameController>
  {
    void ShowProgress(bool show);
    string ProgressMessage { get; set; }
    int ProgressMin { get; set; }
    int ProgressMax { get; set; }
    int ProgressStep { get; set; }
    int ProgressValue { get; set; }
    void ProgressPerformStep();
    void ProgressRefresh();

    // game
    void EnableRestartGame(bool enable);
    void EnableUndo(bool enable);
    void EnableRedo(bool enable);
    void SetPlayerPoints(string playerKey, int value);
    void BeginLoadGame(bool isSolitaire);
    void EndLoadGame();
    void Clear();
    void EnableSave(bool enabled);
    void AddNumCounter(string playerKey, string numCounterKey, NumCounterItem numCounterItem);
    void SetNumCounterValue(string numCounterKey, int value);
    void UpdateNumCounter(string key, NumCounterItem numCounterItem);
    void DisplayCards(List<CardItem> cards);
    void CloseDisplay();
    void ShowNewGameParameters();

    // player
    void AddPlayer(string key, PlayerInfo info, bool isActive, bool handVisible);
    void EnablePlayerChangePoints(string key, bool enable);

    // sectors 
    void AddSector(string playerKey, string sectorKey, SectorItem sectorItem, SectorActionsSupporting supporting);
    void UpdateSector(string key, SectorItem sectorItem);
    void ClearCards(string sectorKey);
    void EnableSectorAction(string sectorKey, SectorActions action, bool enable);

    // card
    void AddCards(string sectorKey, Dictionary<string, CardViewItem> cardViewItems);
    void LockCard(string key, bool lockState);
    void SetCardRotation(string key, bool rotated);
    void SetCardPosition(string key, CardPosition position);
    void SetCardVisibility(string key, CardVisibility visibility, int hiddenCode);
    void SetCardReversed(string key, bool reversed);
    void SetCardCustomCharacteristics(string key, string characteristics);
    void RemoveCard(string key);
    void UpdateCard(string key, CardItem cardItem);
    void MoveCard(string key, int newIndex);
    void EnableCardRotation(string key, bool enable);

    // lookup
    void OpenSectorLookup(string key, LookupRules rules, string playerKey, bool readOnly, string sectorKey);
    void CloseSectorLookup(string key);
    void AddLookupCard(string lookupKey, string cardKey, bool hidden, CardItem cardItem, int index);
    void RemoveLookupCard(string lookupKey, string cardKey);
    void UpdateLookupCard(string lookupKey, string cardKey, CardItem cardItem);
    void ClearLookupCards(string lookupKey);
    void MoveLookupCard(string lookupKey, string cardKey, int newIndex);

    // token
    void AddToken(string cardKey, string tokenKey, string text, int amount, TokenColor color);
    void RemoveToken(string key);
    void SetTokenText(string key, string text);
    void SetTokenAmount(string key, int amount);
    void SetTokenColor(string key, TokenColor color);

    // console
    void AddConsoleMessage(TextMessage message);
    string ConsoleText { get; set; }

  }
}
