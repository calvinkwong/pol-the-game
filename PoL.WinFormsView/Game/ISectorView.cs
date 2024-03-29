﻿/*
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

using PoL.Common;
using PoL.WinFormsView.Utils;
using PoL.Services.DataEntities;
using PoL.Logic.Views;

namespace PoL.WinFormsView.Game
{
  public interface ISectorView
  {
    List<CardView> CardViews { get; }
    Control CardContainer { get; }
    void ClearCards();
    void AddCards(Dictionary<string, CardViewItem> cardViewItems);
    void RemoveCard(string key);
    void MoveCard(string key, int newIndex);
    string SectorKey { get; set; }
    string PlayerKey { get; }
    void SetDescription(string description);

    SectorItem SectorItem { get; set; }
  }
}
