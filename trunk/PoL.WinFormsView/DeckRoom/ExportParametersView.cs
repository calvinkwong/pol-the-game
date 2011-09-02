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
using PoL.Services.DataEntities;
using PoL.WinFormsView.Utils;
using PoL.Common;
using PoL.Logic.Controllers;
using RibbonStyle;
using PoL.Configuration;

namespace PoL.WinFormsView.DeckRoom
{
  public partial class ExportParametersView : Form, ILocalizable
  {
    DeckExportFormat selectedFormat;
    DeckExportDestination selectedDestination;
    bool selectedIncludeTag;

    public ExportParametersView()
    {
      InitializeComponent();

      Localize();

      SetupLanguage();
      
      this.SelectedLanguage = SettingsManager.Settings.GameLanguage;

      btnCancel.Click += new EventHandler(btnCancel_Click);
      btnOk.Click += new EventHandler(btnOk_Click);
    }

    public void Localize()
    {
      this.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("EXPORT_DECK_DIALOG", "TITLE");
      lblLanguage.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("EXPORT_DECK_DIALOG", "LANGUAGE");
      boxDestination.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("EXPORT_DECK_DIALOG", "DESTINATION");
      rbFile.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("EXPORT_DECK_DIALOG", "DESTINATION_FILE");
      rbClipboard.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("EXPORT_DECK_DIALOG", "DESTINATION_CLIPBOARD");
      btnOk.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("EXPORT_DECK_DIALOG", "OK");
      chkNoTag.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("EXPORT_DECK_DIALOG", "EXCLUDE_TAGS");
      btnCancel.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("EXPORT_DECK_DIALOG", "CANCEL");
    }

    void SetupLanguage()
    {
      foreach(var lang in Program.LogicHandler.GameItem.Languages)
      {
        ToolStripMenuItem subMenu = new ToolStripMenuItem(lang.Name);
        subMenu.Tag = lang.Code;
        subMenu.Image = btnLanguage.Image;
        subMenu.Click += delegate(object sender, EventArgs e)
        {
          this.SelectedLanguage = (sender as ToolStripMenuItem).Tag.ToString();
        };
        menuCardsLanguage.Items.Add(subMenu);
      }
    }

    public DeckExportFormat SelectedFormat
    {
      get { return selectedFormat; }
    }

    public DeckExportDestination SelectedDestination
    {
      get { return selectedDestination; }
    }

    public bool SelectedIncludeTag
    {
      get { return selectedIncludeTag; }
    }

    public string SelectedLanguage
    {
      get { return btnLanguage.Tag.ToString(); }
      set
      {
        var lang = Program.LogicHandler.GameItem.Languages.Single(e => e.Code == value);
        btnLanguage.Tag = lang.Code;
        btnLanguage.Text = lang.Name;
      }
    }

    void btnOk_Click(object sender, EventArgs e)
    {
      selectedFormat = DeckExportFormat.Text;
      selectedDestination = rbFile.Checked ? DeckExportDestination.File : DeckExportDestination.Clipboard;
      selectedIncludeTag = !chkNoTag.Checked;
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }

  public enum DeckExportDestination
  {
    File,
    Clipboard
  }
}
