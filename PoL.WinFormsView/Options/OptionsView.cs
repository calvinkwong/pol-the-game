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

using PoL.Logic.Controllers;
using PoL.Logic.Views;
using PoL.Services;
using Patterns.MVC;
using PoL.WinFormsView.Utils;
using RibbonStyle;
using System.IO;
using PoL.Common;

namespace PoL.WinFormsView.Options
{
  public partial class OptionsView : WinFormsView, IOptionsView, ILocalizable
  {
    OptionsController controller;
    KeyValuePair<string, string>[] clientLanguages;
    KeyValuePair<string, string>[] gameLanguages;
    string avatarPath = string.Empty;
    ProgressDialog progressDialog = new ProgressDialog();

    public OptionsView()
    {
      InitializeComponent();

      progressDialog.StartPosition = FormStartPosition.CenterScreen;

      btnOk.Click += delegate(object sender, EventArgs e)
      {
        controller.Save();
        this.DialogResult = DialogResult.OK;
        this.Close();
      };
      btnCancel.Click += delegate(object sender, EventArgs e)
      {
        this.Close();
      };
      btnChangePicture.Click += delegate(object sender, EventArgs e)
      {
        if(openAvatarFileDialog.ShowDialog() == DialogResult.OK)
        {
          avatarPath = openAvatarFileDialog.FileName;
          picAvatar.BackgroundImage = Image.FromFile(avatarPath);
        }
      };
      btnRemovePicture.Click += delegate(object sender, EventArgs e)
      {
        avatarPath = string.Empty;
        picAvatar.BackgroundImage = null;
      };
      btnBrowsePicturesPath.Click += delegate(object sender, EventArgs e)
      {
        if(folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
        {
          txtCardPicturesPath.Text = folderBrowserDialog.SelectedPath;
        }
      };

      this.clientLanguages = Program.LogicHandler.ServicesProvider.GetAvaiableClientLanguages().ToArray();
      this.gameLanguages = Program.LogicHandler.GameItem.Languages.Select(e => new KeyValuePair<string, string>(e.Code, e.Name)).ToArray();

      SetupLanguages(clientLanguages, menuClientLanguage, btnClientLanguage, e => this.ClientLanguage = e.Tag.ToString());
      SetupLanguages(gameLanguages, menuGameLanguage, btnGameLanguage, e => this.GameLanguage = e.Tag.ToString());

      Localize();
    }

    bool TryLoadPicture(string path, out Image image)
    {
      bool result = false;
      image = null;
      try
      {
        image = Image.FromFile(path);
        result = true;
      }
      catch
      {
      }
      return result;
    }

    void SetupLanguages(KeyValuePair<string, string>[] languages, ContextMenuStrip menu, RibbonMenuButton button, Action<ToolStripMenuItem> menuClickFunc)
    {
      foreach(var lang in languages)
      {
        ToolStripMenuItem subMenu = new ToolStripMenuItem(lang.Value);
        subMenu.Tag = lang.Key;
        subMenu.Image = button.Image;
        subMenu.Click += delegate(object sender, EventArgs e)
        {
          menuClickFunc(sender as ToolStripMenuItem);
        };
        menu.Items.Add(subMenu);
      }
    }

    protected override void OnLoad(EventArgs e)
    {
      foreach(IComponent component in this.components.Components)
      {
        if(component.GetType() == typeof(ContextMenuStrip))
        {
          ((ContextMenuStrip)component).Renderer = new RibbonMenuRenderer();
        }
      }
    }

    public void Localize()
    {
      this.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "TITLE");
      pagePlayer.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "PLAYER");
      lblNickName.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "NICKNAME");
      lblPicture.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "PLAYER_PICTURE");
      btnChangePicture.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "CHANGE_PICTURE");
      btnRemovePicture.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "REMOVE_PICTURE");
      pageSystem.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "SYSTEM");
      boxNetwork.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "NET");
      chkAnimateHand.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "ANIMATE_HAND");
      lblListenPort.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "LISTEN_PORT");
      lblClientLanguage.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "CLIENT_LANGUAGE");
      lblGameLanguage.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "GAME_LANGUAGE");
      lblPicturesPath.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "CARD_PICTURES_PATH");
      lblMessage.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "MESSAGE");
      btnCancel.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "CANCEL");
      btnOk.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "OK");
      pagePictures.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "CARD_PICTURES");
      menuImportInternalPictures.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "POL_FORMAT");
      menuImportMwsPictures.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "MWS_FORMAT");
      rbCrop.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "BEHAVIOR_CROP");
      rbFull.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "BEHAVIOR_FULL");
      chkSetMapping.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "ENABLE_SET_MAPPING");
      chkKeepGameLog.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "KEEP_GAME_LOG");
      pageLanguages.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "LANGUAGES");

      openAvatarFileDialog.Filter = string.Concat(
        Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "ALL_IMAGES"),
        "|*.bmp;*.gif;*.jpg;*.png",
        "|Bitmap|*.bmp",
        "|Graphics Interchange Format|*.gif",
        "|JPEG File Interchange Format|*.jpg",
        "|Portable Network Graphic|*.png");
    }

    #region IOptionsView Membri di

    public void ShowProgress(bool show)
    {
      if(show)
        progressDialog.Show(this);
      else
        progressDialog.Hide();
    }

    public string ProgressMessage
    {
      get { return progressDialog.ProgressMessage; }
      set { progressDialog.ProgressMessage = value; }
    }

    public int ProgressMin
    {
      get { return progressDialog.ProgressMin; }
      set { progressDialog.ProgressMin = value; }
    }

    public int ProgressMax
    {
      get { return progressDialog.ProgressMax; }
      set { progressDialog.ProgressMax = value; }
    }

    public int ProgressStep
    {
      get { return progressDialog.ProgressStep; }
      set { progressDialog.ProgressStep = value; }
    }

    public int ProgressValue
    {
      get { return progressDialog.ProgressValue; }
      set { progressDialog.ProgressValue = value; }
    }

    public void ProgressPerformStep()
    {
      progressDialog.ProgressPerformStep();
    }

    public void ProgressRefresh()
    {
      Application.DoEvents();
    }

    public string AvatarPath
    {
      get 
      { 
        return avatarPath;
      }
      set 
      {
        avatarPath = value;
        if(avatarPath.Length > 0)
        {
          Image image;
          if(TryLoadPicture(avatarPath, out image))
            picAvatar.BackgroundImage = image;
          else
          {
            avatarPath = string.Empty;
            Program.InfoBox(this, Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("OPTIONS_DIALOG", "MSG_INVALID_AVATAR"));
          }
        }
      }
    }

    public string PlayerName
    {
      get { return txtNickname.Text; }
      set { txtNickname.Text = value; }
    }

    public string PlayerMessage
    {
      get { return txtMessage.Text; }
      set { txtMessage.Text = value; }
    }

    public string ClientLanguage
    {
      get { return btnClientLanguage.Tag.ToString(); }
      set 
      {
        var lang = clientLanguages.Single(e => e.Key == value);
        btnClientLanguage.Tag = lang.Key;
        btnClientLanguage.Text = lang.Value;
      }
    }

    public string GameLanguage
    {
      get { return btnGameLanguage.Tag.ToString(); }
      set
      {
        var lang = gameLanguages.Single(e => e.Key == value);
        btnGameLanguage.Tag = lang.Key;
        btnGameLanguage.Text = lang.Value;
      }
    }

    public ushort ListenPort
    {
      get { return (ushort)numPort.Value; }
      set { numPort.Value = value; }
    }

    public bool AnimateHand
    {
      get { return chkAnimateHand.Checked; }
      set { chkAnimateHand.Checked = value; }
    }
    
    public bool EnableSetMapping
    {
      get { return chkSetMapping.Checked; }
      set { chkSetMapping.Checked = value; }
    }

    public bool KeepGameLog
    {
      get { return chkKeepGameLog.Checked; }
      set { chkKeepGameLog.Checked = value; }
    }

    public string CardPicturesPath
    {
      get { return txtCardPicturesPath.Text; }
      set { txtCardPicturesPath.Text = value; }
    }

    public CardPictureBehavior CardPictureBehavior
    {
      get { return rbCrop.Checked ? CardPictureBehavior.Crop : CardPictureBehavior.Full; }
      set 
      { 
        rbCrop.Checked = value == CardPictureBehavior.Crop;
        rbFull.Checked = value == CardPictureBehavior.Full;
      }
    }

    public void ShowPlayerData(bool showPlayerData)
    {
      if(!showPlayerData)
        mainTab.TabPages.Remove(pagePlayer);
    }

    #endregion

    #region IView<OptionsController> Membri di

    public void RegisterController(OptionsController controller)
    {
      this.controller = controller;
    }

    #endregion
  }
}
