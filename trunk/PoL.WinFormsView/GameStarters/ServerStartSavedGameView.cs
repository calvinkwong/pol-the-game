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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PoL.Services;
using PoL.WinFormsView.Utils;
using PoL.Logic.Views;
using PoL.Logic.Controllers.GameStarters;
using System.IO;

namespace PoL.WinFormsView.GameStarters
{
  public partial class ServerStartSavedGameView : WinFormsView, IServerStartSavedGameView, ILocalizable
  {
    ServerStartSavedGameController controller;
    List<SaveMetaData> dataSource;

    public ServerStartSavedGameView()
    {
      InitializeComponent();

      btnCancel.Click += new EventHandler(btnCancel_Click);
      btnOk.Click += new EventHandler(btnOk_Click);

      Localize();
    }

    public void Localize()
    {
      this.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("SERVER_SAVEDGAME_DIALOG", "TITLE");
      btnOk.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("SERVER_SAVEDGAME_DIALOG", "OK");
      btnCancel.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("SERVER_SAVEDGAME_DIALOG", "CANCEL");
      lblSaveList.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("SERVER_SAVEDGAME_DIALOG", "SAVE_LIST");
      lblSaveList.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("SERVER_SAVEDGAME_DIALOG", "SAVE_LIST_DESC");
      lblSummary.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("SERVER_SAVEDGAME_DIALOG", "SUMMARY");
      lblSummary.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("SERVER_SAVEDGAME_DIALOG", "SUMMARY_DESC");

      foreach(SavedGameItem item in saveList.Controls)
        item.Localize();
    }

    void btnOk_Click(object sender, EventArgs e)
    {
      try
      {
        controller.Finish();
      }
      catch(Exception ex)
      {
        Program.ExceptionBox(this, ex);
      }
    }

    void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    public List<SaveMetaData> DataSource
    {
      get { return dataSource; }
    }

    void item_QuerySelection(object sender, EventArgs e)
    {
      try
      {
        saveList.SuspendLayout();
        try
        {
          foreach(SavedGameItem item in saveList.Controls)
          {
            item.Selected = item.Equals(sender);
            if(item.Selected)
              picSavedGame.BackgroundImage = item.Save.Picture;
          }
        }
        finally
        {
          saveList.ResumeLayout();
        }
      }
      catch(Exception ex)
      {
        Program.ExceptionBox(this, ex);
      }
    }

    void item_QueryDeletion(object sender, EventArgs e)
    {
      try
      {
        SavedGameItem item = (SavedGameItem)sender;
        if(controller.DeleteSave(item.Save))
          saveList.Controls.Remove(item);
      }
      catch(Exception ex)
      {
        Program.ExceptionBox(this, ex);
      }
    }

    #region IView<ServerStartSavedGameController> Membri di

    public void RegisterController(ServerStartSavedGameController controller)
    {
      this.controller = controller;
    }

    #endregion

    #region IServerStartSavedGameView Membri di

    public void SetSavedGameList(List<SaveMetaData> saveMetaDatas)
    {
      dataSource = saveMetaDatas;
      saveList.Controls.Clear();
      if(dataSource != null)
      {
        foreach(var save in dataSource)
        {
          SavedGameItem item = new SavedGameItem();
          item.Localize();
          item.Width = (int)(saveList.Size.Width * 0.9f);
          item.Save = save;
          item.Margin = Padding.Empty;
          item.QuerySelection += new EventHandler(item_QuerySelection);
          item.QueryDeletion += new EventHandler(item_QueryDeletion);
          saveList.Controls.Add(item);
          if(saveList.Controls.Count == 1)
          {
            item.Selected = true;
            picSavedGame.BackgroundImage = item.Save.Picture;
          }
        }
      }
    }

    public string SavedId
    {
      get 
      {
        SavedGameItem item = saveList.Controls.Cast<SavedGameItem>().FirstOrDefault(i => i.Selected);
        if(item != null)
          return item.Save.Id;
        else 
          return null;
      }
    }

    public string Password
    {
      get
      {
        SavedGameItem item = saveList.Controls.Cast<SavedGameItem>().FirstOrDefault(i => i.Selected);
        if(item != null)
          return item.Password;
        else
          return null;
      }
    }

    #endregion
  }
}
