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
using System.ComponentModel;
using System.Reflection;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ICSharpCode.SharpZipLib.Zip;
using System.Threading;

namespace Patterns.AutoUpdate
{
  public delegate void UpdateDownloadCompletedEventHandler(UpdateDownloadComplededEventArgs args);

  public class AutoUpdater
  {
    public const string UPDATER_KEY = "&**#@!";
    public const string UPDATE_INFO_FILENAME = "update.txt";
    public const string UPDATE_DIRECTORYNAME = "update";

    public static event CancelEventHandler UpdateConfirm;
    public static event UpdateDownloadCompletedEventHandler UpdateDownloadCompleted;
    public static event DownloadProgressChangedEventHandler DownloadProgressChanged;

    static string downloadFolder = string.Empty;
    static string thisFolder = string.Empty;
    static WebClient webClient;

    public static NeedUpdateResult NeedUpdate(string[] commandLineArgs, Uri updateUri, Version actualVersion)
    {
      NeedUpdateResult result = NeedUpdateResult.NotNeeded;

      thisFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      downloadFolder = Path.Combine(thisFolder, UPDATE_DIRECTORYNAME);
      if(commandLineArgs.Contains(UPDATER_KEY))
      {
        // just updated, clean update directory
        try
        {
          Thread.Sleep(3000);
          if(Directory.Exists(downloadFolder))
            Directory.Delete(downloadFolder, true);
          result = NeedUpdateResult.NotNeeded;
        }
        catch
        {
          //result = NeedUpdateResult.IOError;
        }
      }
      else
      {
        result = ContactServer(commandLineArgs, updateUri, actualVersion);
      }
 
      return result;
    }

    public static void CancelUpdate()
    {
      if(webClient != null && webClient.IsBusy)
        webClient.CancelAsync();
    }

    static NeedUpdateResult ContactServer(string[] commandLineArgs, Uri updateUri, Version actualVersion)
    {
      NeedUpdateResult result = NeedUpdateResult.NotNeeded;

      try
      {
        if(Directory.Exists(downloadFolder))
          Directory.Delete(downloadFolder, true);
      }
      catch
      {
        result = NeedUpdateResult.IOError;
      }

      if(result == NeedUpdateResult.NotNeeded)
      {
        string serverVersion = string.Empty;
        string archiveName = string.Empty;
        string updaterExeName = string.Empty;
        try
        {
          webClient = new WebClient();
          string[] data = webClient.DownloadString(new Uri(updateUri, UPDATE_INFO_FILENAME)).Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
          serverVersion = data[0];
          archiveName = data[1];
          updaterExeName = data[2];
        }
        catch(Exception)
        {
          result = NeedUpdateResult.InvalidUpdateSource;
        }

        if(result == NeedUpdateResult.NotNeeded && new Version(serverVersion) > actualVersion)
        {
          bool cancel = false;
          OnUpdateConfirm(out cancel);
          if(cancel)
            result = NeedUpdateResult.UpdateCanceled;
          else
          {
            Directory.CreateDirectory(downloadFolder);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
            webClient.DownloadFileAsync(new Uri(updateUri, archiveName), Path.Combine(downloadFolder, archiveName),
              new AsyncArgs(archiveName, updaterExeName, commandLineArgs));
            result = NeedUpdateResult.UpdateStarted;
          }
        }
      }
      

      return result;
    }

    static void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
      OnDownloadProgressChanged(sender, e);
    }

    static void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {
      UpdateDownloadComplededEventArgs args = new UpdateDownloadComplededEventArgs();
      if(e.Cancelled)
        args.Result = UpdateDownloadComplededResult.Canceled;
      else if(e.Error != null)
      {
        args.Result = UpdateDownloadComplededResult.InternalError;
        args.Error = e.Error;
      }
      else
      {
        AsyncArgs state = (AsyncArgs)e.UserState;
        try
        {
          FastZip zip = new FastZip();
          zip.ExtractZip(
            Path.Combine(downloadFolder, state.ArchiveName),
            downloadFolder,
            FastZip.Overwrite.Always,
            null, 
            string.Empty, 
            string.Empty);
          System.Threading.Thread.Sleep(3000);
          File.Delete(Path.Combine(downloadFolder, state.ArchiveName));
          args.Result = UpdateDownloadComplededResult.Ready;
        }
        catch(Exception ex)
        {
          args.Result = UpdateDownloadComplededResult.IOError;
          args.Error = ex;
        }
        args.UpdateProcessPath = Path.Combine(downloadFolder, state.UpdaterExeName);
        args.UpdateProcessCommandLine = string.Concat(
          "\"", UPDATER_KEY, "\" ",
          "\"", thisFolder, "\" ",
          state.CommandLineArgs.Aggregate(string.Empty, (aggregator, cmd) => string.Concat(aggregator, " \"", cmd, "\"")));
      }

      OnUpdateDownloadCompleted(args);
    }

    static void OnUpdateConfirm(out bool cancel)
    {
      CancelEventArgs e = new CancelEventArgs();
      if(UpdateConfirm != null)
        UpdateConfirm(null, e);
      cancel = e.Cancel;
    }

    static void OnUpdateDownloadCompleted(UpdateDownloadComplededEventArgs e)
    {
      if(UpdateDownloadCompleted != null)
        UpdateDownloadCompleted(e);
    }

    static void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
      if(DownloadProgressChanged != null)
        DownloadProgressChanged(sender, e);
    }
  }

  class AsyncArgs
  {
    public string ArchiveName { get; set; }
    public string UpdaterExeName { get; set; }
    public string[] CommandLineArgs { get; set; }

    public AsyncArgs(string archiveName, string updaterExeName, string[] commandLineArgs)
    {
      ArchiveName = archiveName;
      UpdaterExeName = updaterExeName;
      CommandLineArgs = commandLineArgs;
    }
  }

  public enum NeedUpdateResult
  {
    NotNeeded,
    InvalidUpdateSource,
    IOError,
    UpdateCanceled,
    UpdateStarted
  }

  public enum UpdateDownloadComplededResult
  {
    IOError,
    InternalError,
    Canceled,
    Ready
  }

  public class UpdateDownloadComplededEventArgs
  {
    public UpdateDownloadComplededResult Result { get; set; }
    public Exception Error { get; set; }
    public string UpdateProcessPath { get; set; }
    public string UpdateProcessCommandLine { get; set; }
  }
}
