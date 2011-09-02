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
using PoL.Common;
using System.Drawing;
using System.Collections.Generic;

namespace PoL.Logic.Controllers
{
  public interface IGameController
  {
    void OpenSectorLookup(string sectorKey, string destinationPlayerKey, LookupOpenMode mode, int amount);
    void OpenSectorLookup(string sectorKey, string destinationPlayerKey, LookupOpenMode mode, List<string> keys);
    void DisplayRandomCards(string sectorKey, string playerKey, int amount);
    void DisplayCards(string playerKey, List<string> cardKeys);
    void CloseCardDisplay();
    void CreatePawn(string sectorKey, string name, string type, string text, string characteristics, CardPosition position);
    void DuplicateCard(string cardKey, CardPosition position);
    void AddToken(List<string> cardKeys, int amount, string text, TokenColor color);
    void Chat();
    void MoveCards(List<string> cardKeys, string destinationSectorCode, List<CardPosition> positions, CardVisibility? visibility);
    void MoveCards(List<string> cardKeys, string destinationSectorCode, string destinationPlayerKey, List<CardPosition> positions, CardVisibility? visibility);
    void MoveRandomCards(int amount, string sourceSectorCode, string destinationSectorCode, List<CardPosition> positions, CardVisibility? visibility);
    void DoMulligan();
    void Redo();
    void CloseSectorLookup(string key);
    void RemoveToken(string key);
    void ReverseCards(List<string> keys);
    void RotateCards(List<string> keys);
    void RotateSectorCards(string sectorKey);
    void SaveGame(Bitmap bmp);
    void RestartGame();
    //void LoadGame();
    void LockCards(List<string> keys);
    void SetCardsCustomCharacteristics(List<string> cardKeys, string customCharacteristics, bool includeCardsWithEmptyCharacteristics, bool applyNumericalIncrement);
    void SetCardsVisibility(List<string> keys, CardVisibility visibility);
    void SetPlayerPoints(string playerKey, int value);
    void SetNumCounterValue(string numCounterKey, int value);
    void SetTokenAmount(string key, int amount);
    void SetTokenColor(string key, TokenColor color);
    void SetTokenText(string key, string text);
    void ShuffleSector(string sectorKey);
    void ThrowCoin();
    void ThrowDice(DiceType diceType);
    void Undo();
    void ShowOptions();
  }
}
