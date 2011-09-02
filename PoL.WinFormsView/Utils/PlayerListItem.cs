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
using PoL.Services;
using PoL.WinFormsView.Properties;

namespace PoL.WinFormsView.Utils
{
  public partial class PlayerListItem : UserControl
  {
    PlayerInfo player;
    PlayerReadyState readyState = PlayerReadyState.None;

    public PlayerListItem()
    {
      InitializeComponent();
    }

    public PlayerInfo Player
    {
      get { return player; }
      set 
      { 
        this.player = value;
        if(player != null)
        {
          if(player.Picture != null)
            picAvatar.BackgroundImage = player.Picture;
          lblNickname.Text = player.NickName;
          lblMessage.Text = player.Message;
        }
      }
    }

    public PlayerReadyState ReadyState
    {
      get { return readyState; }
      set
      {
        picReadyState.Visible = value != PlayerReadyState.None;
        switch(value)
        {
          case PlayerReadyState.Ready: picReadyState.BackgroundImage = Resources.button_green_small; break;
          case PlayerReadyState.NotReady: picReadyState.BackgroundImage = Resources.button_red_small; break;
        }
      }
    }
  }

  public enum PlayerReadyState
  { 
    None,
    Ready,
    NotReady
  }
}
