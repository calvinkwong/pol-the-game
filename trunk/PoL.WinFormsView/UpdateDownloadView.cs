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

using Patterns.AutoUpdate;
using PoL.Logic;
using System.Net;

namespace PoL.WinFormsView
{
  public partial class UpdateDownloadView : Form, ILocalizable
  {
    public UpdateDownloadComplededEventArgs Args { get; set; }

    public UpdateDownloadView()
    {
      InitializeComponent();

      btnCancelClose.Click += new EventHandler(btnCancelClose_Click);
      this.FormClosing += new FormClosingEventHandler(UpdateDownloadView_FormClosing);

      progressBar.Minimum = 0;
      progressBar.Maximum = 100;

      AutoUpdater.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(AutoUpdater_DownloadProgressChanged);
      AutoUpdater.UpdateDownloadCompleted += new UpdateDownloadCompletedEventHandler(AutoUpdater_UpdateDownloadCompleted);

      Localize();
    }

    void UpdateDownloadView_FormClosing(object sender, FormClosingEventArgs e)
    {
      if(Args == null)
        e.Cancel = true;
    }

    void btnCancelClose_Click(object sender, EventArgs e)
    {
      if(Args == null)
      {
        btnCancelClose.Enabled = false;
        AutoUpdater.CancelUpdate();
      }
      else
        this.Close();
    }

    public void Localize()
    {
      this.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("UPDATE_DIALOG", "TITLE");
      if(Args == null)
      {
        lblStatus.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("UPDATE_DIALOG", "STATUS_DOWNLOADING");
        btnCancelClose.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("UPDATE_DIALOG", "CANCEL");
      }
      else
      {
        switch(Args.Result)
        {
          case UpdateDownloadComplededResult.Canceled:
            lblStatus.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("PROGRAM", "MSG_UPDATE_CANCELED");
            break;
          case UpdateDownloadComplededResult.InternalError:
            lblStatus.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("PROGRAM", "MSG_UPDATE_INTERNALERROR");
            if(Args.Error != null)
              lblStatus.Text += Environment.NewLine + Args.Error.Message;              
            break;
          case UpdateDownloadComplededResult.IOError:
            lblStatus.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("PROGRAM", "MSG_UPDATE_IOERROR");
            if(Args.Error != null)
              lblStatus.Text += Environment.NewLine + Args.Error.Message;
            break;
          case UpdateDownloadComplededResult.Ready:
            lblStatus.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("UPDATE_DIALOG", "STATUS_DONE");
            break;
        }
        btnCancelClose.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("UPDATE_DIALOG", "OK");
      }
      lblProgress.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("UPDATE_DIALOG", "PROGRESS");
    }

    void AutoUpdater_UpdateDownloadCompleted(UpdateDownloadComplededEventArgs args)
    {
      if(this.InvokeRequired)
        this.Invoke(new Action<UpdateDownloadComplededEventArgs>(AutoUpdater_UpdateDownloadCompleted), args);
      else
      {
        btnCancelClose.Enabled = true;
        this.Args = args;
        Localize();
      }
    }

    void AutoUpdater_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
    {
      if(this.InvokeRequired)
        this.Invoke(new Action<object, DownloadProgressChangedEventArgs>(AutoUpdater_DownloadProgressChanged), sender, e);
      else
      {
        progressBar.Value = e.ProgressPercentage;
        lblProgressValue.Text = (e.BytesReceived / 1024) + "KB / " + (e.TotalBytesToReceive / 1024) + "KB (" + e.ProgressPercentage + "%)";
      }
    } 
  }
}
