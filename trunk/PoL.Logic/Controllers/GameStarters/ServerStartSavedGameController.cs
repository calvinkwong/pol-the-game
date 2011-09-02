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
using Patterns.MVC;
using PoL.Logic.Views;
using PoL.Services;
using PoL.Configuration;
using System.IO;
using PoL.Common;
using PoL.Models.GameStarters;

namespace PoL.Logic.Controllers.GameStarters
{
  public class ServerStartSavedGameController : BaseController<ServerStartSavedGameModel, IServerStartSavedGameView>
  {
    ServicesProvider servicesProvider;
    ServerListener listener;

    public ServerStartSavedGameController(
      ServerStartSavedGameModel serverStartSavedGameModel, IServerStartSavedGameView serverStartSavedGameView,
      ServerListener listener, ServicesProvider servicesProvider)
      : base(serverStartSavedGameModel, serverStartSavedGameView)
    {
      serverStartSavedGameView.RegisterController(this);
      this.servicesProvider = servicesProvider;
      this.listener = listener;

      View.SetSavedGameList(CryptoDataSaver.LoadMetadatas().OrderByDescending(
        e => e.Date).ToList());
    }

    public void Finish()
    {
      if(string.IsNullOrEmpty(View.Password))
        View.ShowInfoMessage(servicesProvider.SystemStringsService.GetString("SERVER_SAVEDGAME_DIALOG", "MSG_PASSWORDREQUIRED"));
      else if(string.IsNullOrEmpty(View.SavedId) || !CryptoDataSaver.Exists(View.SavedId))
        View.ShowInfoMessage(servicesProvider.SystemStringsService.GetString("SERVER_SAVEDGAME_DIALOG", "MSG_INVALIDSAVEDGAME"));
      else
      {
        try
        {
          listener.Start(View.Password.Trim().Length > 0, null, GameStartMode.SavedGame);
          Model.Password = View.Password;
          Model.SaveId = View.SavedId;

          View.ViewResult = ViewResult.Ok;
          View.Close();
        }
        catch(Exception ex)
        {
          View.ShowInfoMessage(ex.Message);
        }
      }
    }

    public bool DeleteSave(SaveMetaData saveMetaData)
    {
      bool deleted = false;
      if(View.ShowQuestionMessage(servicesProvider.SystemStringsService.GetString("SERVER_SAVEDGAME_DIALOG", "MSG_DELETE_CONFIRM")) == ViewResult.Yes)
      {
        CryptoDataSaver.Delete(saveMetaData);
        deleted = true;
      }
      return deleted;
    }
  }
}
