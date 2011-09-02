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
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PoL.Services;
using PoL.Services.DataEntities;
using PoL.Common;
using Patterns.MVC;
using PoL.Logic.Controllers;

namespace PoL.Logic.Views
{
  public interface IDeckEditorView : IView<DeckEditorController>
  {
    void BeginLoad();
    void EndLoad();
    void SetDeckSize(int mainSize, int sideboardSize);
    void SetSearchResult(List<CardItem> searchResult);
    void SelectCard(DeckEditorListContext listContext, CardItem card);
    void SetSets(List<GameSetItem> sets);
    void SetColors(List<BaseItem> colors);
    void SetTypes(List<CardTypeItem> types);
    void SetRarities(List<BaseItem> rarities);
    void SetDecksCategories(IEnumerable<string> decksCategories);
    void AddMainCard(CardItem card);
    void SetMainCardCount(CardItem card, int count);
    void RemoveMainCard(CardItem card);
    void AddSideboardCard(CardItem card);
    void SetSideboardCardCount(CardItem card, int count);
    void RemoveSideboardCard(CardItem card);
    void ClearList(DeckEditorListContext listContext);
    string DeckName { get; set; }
    string DeckCategory { get; set; }
    string GetQuickSearchText(DeckEditorListContext listContext);
  }
}
