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
using PoL.Services.DataEntities;
using PoL.Common;
using PoL.WinFormsView.Utils;
using PoL.Logic.Views;
using PoL.Logic.Controllers;

namespace PoL.WinFormsView.Game
{
  public partial class PlayerStatusView : UserControl, ILocalizable
  {
    string toTopText = string.Empty;
    string toBottomText = string.Empty;

    public PlayerStatusView()
    {
      InitializeComponent();

      lblPoints.MouseDown += new MouseEventHandler(lblPoints_MouseDown);
      picSetLifePoints.Click += new EventHandler(picSetLifePoints_Click);

      Localize();
    }

    void picSetLifePoints_Click(object sender, EventArgs e)
    {
      try
      {
        GameViewHelper.RaiseSetLifePoints(((GameView)this.FindForm()), this, SetLifePointsMode.Query);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    void lblPoints_MouseDown(object sender, MouseEventArgs e)
    {
      try
      {
        if(e.Button == MouseButtons.Left)
          GameViewHelper.RaiseSetLifePoints(((GameView)this.FindForm()), this, SetLifePointsMode.Add);
        else if(e.Button == MouseButtons.Right)
          GameViewHelper.RaiseSetLifePoints(((GameView)this.FindForm()), this, SetLifePointsMode.Subtract);
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    public void Localize()
    {
      foreach(Control sector in simpleSectorsContainer.Controls)
        if(sector.ContextMenuStrip.Tag != null && sector.ContextMenuStrip.Tag is ILocalizable)
          ((ILocalizable)sector.ContextMenuStrip.Tag).Localize();
    }

    public int PlayerPoints
    {
      get { return int.Parse(lblPoints.Text); }
      set { lblPoints.Text = value.ToString(); }
    }

    public void SetPlayer(string key, PlayerInfo player, bool isActive, bool handVisible)
    {
      this.Name = key;
      if(player.Picture != null)
        picAvatar.BackgroundImage = player.Picture;
      lblPlayerName.Text = player.NickName;
      toolTip.SetToolTip(picAvatar, player.Message);
    }

    public void AddSector(string key, SectorItem sectorItem, SectorActionsSupporting sectorActionsSupporting)
    {
      if(sectorItem.Behavior == SectorBehavior.Simple || sectorItem.HasSimpleDuplicate)
      {
        SimpleSectorView sectorView = new SimpleSectorView();
        sectorView.Name = key;
        sectorView.SectorItem = sectorItem;
        sectorView.SetDescription(sectorItem.Name);
        sectorView.MouseDoubleClick += new MouseEventHandler(sectorView_MouseDoubleClick);
        sectorView.SetImage(Program.LogicHandler.ServicesProvider.ImagesService.GetSectorBackground(sectorItem.Code));
        simpleSectorsContainer.Controls.Add(sectorView);

        SectorMenuContainer menu = new SectorMenuContainer();
        menu.SectorView = sectorView;
        sectorView.ContextMenuStrip = menu.InnerMenu;
      }
    }

    public void AddNumCounter(string numCounterKey, NumCounterItem numCounterItem)
    {
      NumCounterView view = new NumCounterView();
      view.Name = numCounterKey;
      view.CounterName = numCounterItem.Name;
      view.CounterValue = 0;
      view.SetImage(Program.LogicHandler.ServicesProvider.ImagesService.GetNumCounterBackground(numCounterItem.Code));
      numCountersContainer.Controls.Add(view);
    }

    GameView GameView
    {
      get { return (GameView)FindForm(); }
    }

    void sectorView_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      try
      {
        ISectorView sectorView = (ISectorView)sender;
        if(GameView.SectorActionsAbilitations[sectorView.SectorKey][SectorActions.MoveCardsToDefaultSector])
        {
          GameViewHelper.RaiseMoveCards(GameView, sectorView.CardViews.Take(1).ToList(), sectorView.SectorItem.DefaultTarget);
        }
      }
      catch(Exception ex)
      {
        GameView.HandleException(ex);
      }
    }

    public void UpdateSector(string key, SectorItem sectorItem)
    {
    }
  }
}
