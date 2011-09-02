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
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PoL.Common;
using PoL.Logic;
using PoL.Services;
using PoL.Configuration;
using Patterns.AutoUpdate;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace PoL.WinFormsView
{
  public class Program
  {
    public static LogicHandler LogicHandler;    

    [STAThread]
    static void Main(string[] args)
    {
      try
      {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Initialize();

        bool startProgram = true;

        AutoUpdater.UpdateConfirm += new System.ComponentModel.CancelEventHandler(AutoUpdater_UpdateConfirm);
        switch(AutoUpdater.NeedUpdate(args, new Uri(SettingsManager.Settings.UpdateUri), Assembly.GetExecutingAssembly().GetName().Version))
        {
          case NeedUpdateResult.IOError:
            Program.InfoBox(null, LogicHandler.ServicesProvider.SystemStringsService.GetString("PROGRAM", "MSG_UPDATE_IOERROR"));
            break;
          case NeedUpdateResult.UpdateStarted:
            {
              UpdateDownloadView downloadView = new UpdateDownloadView();
              Application.Run(downloadView);
              if(downloadView.Args.Result == UpdateDownloadComplededResult.Ready)
              {
                Process.Start(downloadView.Args.UpdateProcessPath, downloadView.Args.UpdateProcessCommandLine);
                startProgram = false;
              }
            }
            break;
        }

        if(startProgram)
          Application.Run(new MainMenu());
      }
      catch(Exception ex)
      {
        Program.ExceptionBox(ex);
      }
    }

    static void AutoUpdater_UpdateConfirm(object sender, System.ComponentModel.CancelEventArgs e)
    {
      e.Cancel = QuestionBox(null, LogicHandler.ServicesProvider.SystemStringsService.GetString(
        "PROGRAM", "MSG_CONFIRM_UPDATE")) == DialogResult.No;
    }

    public static void Initialize()
    {
      LogicHandler = new LogicHandler(new WinFormsViewFactory());
      
      SettingsManager.Settings.ClientLanguageChanged += delegate()
      {
        LogicHandler.ServicesProvider.ClientLanguageCode = SettingsManager.Settings.ClientLanguage;
        LogicHandler.ServicesProvider.LoadStrings();

        foreach(Form form in Application.OpenForms)
          if(form is ILocalizable)
            (form as ILocalizable).Localize();
      };
      SettingsManager.Settings.GameLanguageChanged += delegate()
      {
        LogicHandler.ServicesProvider.GameLanguageCode = SettingsManager.Settings.GameLanguage;
        LogicHandler.ServicesProvider.LoadGame(LogicHandler.GameItem);

        foreach(Form form in Application.OpenForms)
          if(form is ILocalizable)
            (form as ILocalizable).Localize();
      };
    }

    public static void InfoBox(IWin32Window owner, string message)
    {
      MessageBox.Show(owner, message, Application.ProductName + " - v." + Application.ProductVersion,
        MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static DialogResult QuestionBox(IWin32Window owner, string message)
    {
      return MessageBox.Show(owner, message, Application.ProductName + " - v." + Application.ProductVersion,
        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }

    public static void ExceptionBox(IWin32Window owner, Exception ex)
    {
      string message = string.Empty;
      try
      {
        message = LogicHandler.ServicesProvider.SystemStringsService.GetString("PROGRAM", "MSG_EXCEPTION");
      }
      catch { }
      new ExceptionView(message, ex).ShowDialog(owner);
    }

    public static void ExceptionBox(Exception ex)
    {
      string message = string.Empty;
      try
      {
        message = LogicHandler.ServicesProvider.SystemStringsService.GetString("PROGRAM", "MSG_EXCEPTION");
      }
      catch { }
      new ExceptionView(message, ex).ShowDialog();
    }
  }
}
