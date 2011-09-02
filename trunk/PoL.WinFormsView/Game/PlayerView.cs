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

using PoL.Common;
using PoL.Logic;
using PoL.WinFormsView.Utils;
using PoL.Services;
using PoL.Services.DataEntities;
using PoL.Logic.Controllers;
using PoL.Configuration;

namespace PoL.WinFormsView.Game
{
  public partial class PlayerView : UserControl, ILocalizable
  {
    bool isActivePlayer;

    public PlayerView()
    {
      InitializeComponent();

      handView.CollapsedSize = CardMetricsService.CardRect(CardStyleBehaviorsService.BEHAVIORS_SMALL).Height / 2;
      handView.FullExpandedSize = CardMetricsService.CardRect(CardStyleBehaviorsService.BEHAVIORS_SMALL).Height + (CardView.BORDER_SIZE * 4);      
      handView.CollapsedState = CollapsedState.Collapsed;

      handView.MouseEnterByHook += delegate(object sender, EventArgs e)
      {
        handView.CollapsedState = CollapsedState.FullExpanded;
      };
      handView.MouseLeaveByHook += delegate(object sender, EventArgs e)
      {
        handView.CollapsedState = CollapsedState.Collapsed;
      };
    }

    public void Localize()
    {
      if(playView.ContextMenuStrip.Tag != null && playView.ContextMenuStrip.Tag is ILocalizable)
        ((ILocalizable)playView.ContextMenuStrip.Tag).Localize();
      if(handView.ContextMenuStrip.Tag != null && handView.ContextMenuStrip.Tag is ILocalizable)
        ((ILocalizable)handView.ContextMenuStrip.Tag).Localize();
    }

    public bool AnimateHand
    {
      get { return handView.Animate; }
      set { handView.Animate = value; }
    }

    public bool IsActivePlayer
    {
      get { return isActivePlayer; }
    }

    GameView GameView
    {
      get { return (GameView)FindForm(); }
    }

    public void SetPlayer(string key, PlayerInfo player, bool isActive, bool handVisible)
    {
      this.Name = key;
      this.isActivePlayer = isActive;
      this.handView.Visible = handVisible;
      if(!isActive)
        playView.BackgroundImage = Properties.Resources.background2;
    }

    public void AddSector(string key, SectorItem sectorItem, SectorActionsSupporting sectorActionsSupporting)
    {
      ISectorView sectorView = null;
      switch(sectorItem.Behavior)
      {
        case SectorBehavior.StaticFree: sectorView = playView; break;
        case SectorBehavior.CollapsableFlow: sectorView = handView; break;
      }
      if(sectorView != null)
      {
        sectorView.SectorKey = key;
        sectorView.SetDescription(sectorItem.Name);
        sectorView.SectorItem = sectorItem;

        SectorMenuContainer menu = new SectorMenuContainer();
        menu.SectorView = sectorView;
        ((Control)sectorView).ContextMenuStrip = menu.InnerMenu;
      }
    }
  }
}
