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

using PoL.Logic;
using PoL.Logic.Views;
using Patterns.MVC;
using PoL.Configuration;
using PoL.Services;
using System.IO;

namespace PoL.Logic.Controllers
{
  public class OptionsController : BaseController<object, IOptionsView>
  {
    ServicesProvider servicesProvider;

    public OptionsController(IOptionsView optionsView, bool showPlayerData, ServicesProvider servicesProvider)
      : base(null, optionsView)
    {
      optionsView.RegisterController(this);
      this.servicesProvider = servicesProvider;

      View.ShowPlayerData(showPlayerData);
      View.PlayerName = SettingsManager.Settings.PlayerName;
      View.AvatarPath = SettingsManager.Settings.AvatarPath;
      View.PlayerMessage = SettingsManager.Settings.PlayerMessage;
      View.ListenPort = SettingsManager.Settings.ListenPort;
      View.ClientLanguage = SettingsManager.Settings.ClientLanguage;
      View.GameLanguage = SettingsManager.Settings.GameLanguage;
      View.AnimateHand = SettingsManager.Settings.AnimateHand;
      View.EnableSetMapping = SettingsManager.Settings.MapEnabled;
      View.CardPictureBehavior = SettingsManager.Settings.CardPictureBehavior;
      View.CardPicturesPath = SettingsManager.Settings.CardPicturesPath;
      View.KeepGameLog = SettingsManager.Settings.KeepGameLog;
    }

    public void Save()
    {
      if(View.PlayerName.Trim().Length == 0)
        View.ShowInfoMessage(servicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "MSG_INVALID_PLAYERNAME"));
      else if(View.ListenPort < 1)
        View.ShowInfoMessage(servicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "MSG_INVALID_PORT"));
      else
      {
        SettingsManager.Settings.AvatarPath = View.AvatarPath;
        SettingsManager.Settings.PlayerName = View.PlayerName;
        SettingsManager.Settings.ListenPort = View.ListenPort;
        SettingsManager.Settings.PlayerMessage = View.PlayerMessage;
        SettingsManager.Settings.ClientLanguage = View.ClientLanguage;
        SettingsManager.Settings.GameLanguage = View.GameLanguage;
        SettingsManager.Settings.AnimateHand = View.AnimateHand;
        SettingsManager.Settings.MapEnabled = View.EnableSetMapping;
        SettingsManager.Settings.CardPictureBehavior = View.CardPictureBehavior;
        SettingsManager.Settings.CardPicturesPath = View.CardPicturesPath;
        SettingsManager.Settings.KeepGameLog = View.KeepGameLog;
        SettingsManager.Save();
      }
    }
  }
}
