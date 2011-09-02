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
using PoL.Services;
using PoL.WinFormsView.Properties;

namespace PoL.WinFormsView.Utils
{
  public partial class SavedGameItem : UserControl
  {
    SaveMetaData save;
    bool selected = false;

    public event EventHandler QuerySelection;
    public event EventHandler QueryDeletion;

    public SavedGameItem()
    {
      InitializeComponent();

      AttachControlsEvents(Controls);

      this.Click += new EventHandler(this_Click);
      picDelete.Click += new EventHandler(picDelete_Click);

      UpdateLayout();
    }

 
    public void Localize()
    {
      lblPassword.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("SERVER_SAVEDGAME_DIALOG", "PASSWORD");
      lblDate.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("SERVER_SAVEDGAME_DIALOG", "DATE");
      lblPlayers.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("SERVER_SAVEDGAME_DIALOG", "PLAYERS");
    }

    void AttachControlsEvents(ControlCollection controls)
    {
      foreach(Control ctrl in controls)
      {
        ctrl.Click += this_Click;
        AttachControlsEvents(ctrl.Controls);
      }
    }

    public SaveMetaData Save
    {
      get { return save; }
      set
      {
        this.save = value;
        if(save != null)
        {
          lblDateValue.Text = save.Date.ToString();
          lblPlayersData.Text = string.Concat(save.Players.Select((e, i) => (i > 0 ? ", " : string.Empty) + e).ToArray());
        }
      }
    }

    public string Password
    {
      get { return txtPassword.Text; }
    }

    [Browsable(true)]
    [DefaultValue(false)]
    public bool Selected
    {
      get { return selected; }
      set 
      {
        selected = value;
        UpdateLayout();
      }
    }

    void UpdateLayout()
    {
      this.SuspendLayout();
      try
      {
        this.BackColor = selected ? Color.CornflowerBlue : Color.White;
        lblDate.ForeColor = selected ? Color.White : Color.DarkBlue;
        lblDateValue.ForeColor = selected ? Color.White : Color.DarkBlue;
        lblPassword.ForeColor = selected ? Color.White : Color.DarkBlue;
        lblPlayers.ForeColor = selected ? Color.White : Color.DarkBlue;
        lblPlayersData.ForeColor = selected ? Color.White : Color.DarkBlue;
        if(selected)
        {
          pnlPassword.Visible = true;
          this.Height = pnlSaveData.Height + pnlPassword.Height;
          txtPassword.Focus();
        }
        else
        {
          pnlPassword.Visible = false;
          this.Height = pnlSaveData.Height;
        }
      }
      finally
      {
        this.ResumeLayout();
      }
    }

    void picDelete_Click(object sender, EventArgs e)
    {
      OnQueryDeletion();
    }

    void this_Click(object sender, EventArgs e)
    {
      OnQuerySelection();
    }

    protected virtual void OnQuerySelection()
    {
      if(QuerySelection != null)
        QuerySelection(this, EventArgs.Empty);
    }

    protected virtual void OnQueryDeletion()
    {
      if(QueryDeletion != null)
        QueryDeletion(this, EventArgs.Empty);
    }
  }
}
