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
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Patterns.MVC;
using PoL.Logic.Controllers;
using PoL.Common;

namespace PoL.Logic.Views
{
  public interface IOptionsView : IView<OptionsController>
  {
    void ShowPlayerData(bool showPlayerData);
    string AvatarPath { get; set; }
    string PlayerName { get; set; }
    string PlayerMessage { get; set; }
    string ClientLanguage { get; set; }
    string GameLanguage { get; set; }
    ushort ListenPort { get; set; }
    bool AnimateHand { get; set; }
    bool EnableSetMapping { get; set; }
    bool KeepGameLog { get; set; }
    CardPictureBehavior CardPictureBehavior { get; set; }
    string CardPicturesPath { get; set; }

    // Progress
    void ShowProgress(bool show);
    string ProgressMessage { get; set; }
    int ProgressMin { get; set; }
    int ProgressMax { get; set; }
    int ProgressStep { get; set; }
    int ProgressValue { get; set; }
    void ProgressPerformStep();
    void ProgressRefresh();

  }
}
