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

using Patterns;
using Patterns.MVC;
using PoL.Logic.Views;
using Patterns.Command;
using PoL.Services;
using PoL.Common;
using System.IO;
using PoL.Models.GameStarters;
using System.Net;
using PoL.Configuration;

namespace PoL.Logic.Controllers.GameStarters
{
  public class ServerConnectionController : BaseController<ServerConnectionModel, IServerConnectionView>
  {
    ServicesProvider servicesProvider;

    public ServerConnectionController(
      ServerConnectionModel serverConnectionModel, IServerConnectionView serverConnectionView,
      PlayerInfo player, ServicesProvider servicesProvider)
      : base(serverConnectionModel, serverConnectionView)
    {
      serverConnectionView.RegisterController(this);

      View.Port = SettingsManager.Settings.ConnectPort;

      this.servicesProvider = servicesProvider;
    }

    public void Connect()
    {
      bool valid = false;
      IPAddress serverAddress = IPAddress.Loopback;
      if(valid)
      {
        if(!IPAddress.TryParse(View.Address, out serverAddress))
          View.ShowInfoMessage(servicesProvider.SystemStringsService.GetString("CLIENT_INITIALIZATION_DIALOG", "MSG_INVALID_IP"));
        else
          valid = true;
      }

      if(valid)
      {        
      }
    }
  }
}
