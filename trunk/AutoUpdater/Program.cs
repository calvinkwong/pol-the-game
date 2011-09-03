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
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;

namespace AutoUpdater
{
  class Program
  {
    const int ERROR_NONE = 0;
    const int ERROR_INVALID_ARGS = 1;
    const int ERROR_INTERNAL = 999;

    const int MIN_NUM_ARGS = 2;

    static int Main(string[] args)
    {
      int error = ERROR_NONE;

      if(args.Length < MIN_NUM_ARGS)
        error = ERROR_INVALID_ARGS;
      else
      {
        string updaterKey = args[0];
        string installPath = args[1];
        using(StreamWriter logFile = File.CreateText(Path.Combine(installPath, "update.log")))
        {
          try
          {
            Thread.Sleep(3000);

            string thisPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string thisName = Path.GetFileName(Assembly.GetExecutingAssembly().Location);
            //Version instalVersion = AssemblyName.GetAssemblyName(Path.Combine(thisPath, "PoL.WinFormsView.exe")).Version;
            //Version systemVersion = AssemblyName.GetAssemblyName(Path.Combine(installPath, "PoL.WinFormsView.exe")).Version;

            Update(logFile, thisPath, installPath);

            string arguments = string.Concat(updaterKey, " ", args.Skip(MIN_NUM_ARGS).Aggregate(string.Empty, (aggregator, e) => string.Concat(aggregator, " ", e)));
            Process.Start(Path.Combine(installPath, "PoL.exe"), arguments);
          }
          catch(Exception ex)
          {
            error = ERROR_INTERNAL;
            
            logFile.WriteLine(ex.Message);
            logFile.WriteLine(string.Empty);
            logFile.WriteLine(ex.StackTrace);

            Console.WriteLine(ex.Message);
            Console.WriteLine(string.Empty);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            Console.WriteLine("Press <ENTER> to continue.");
            Console.ReadLine();
          }
        }
      }
      return error;
    }


    static void Update(StreamWriter logFile, string thisPath, string installPath)
    {
      string path = string.Empty;
      string fromPath = string.Empty;
      string toPath = string.Empty;

      // ***********
      // DIRECTORIES
      // ***********

      // dat (rimossa in 0.2.4.0)
      path = Path.Combine(installPath, "dat");
      if(Directory.Exists(path))
      {
        logFile.WriteLine("Removing directory \"" + path + "\"");
        Directory.Delete(path, true);
      }
      // lang (rimossa in 0.2.4.0)
      path = Path.Combine(installPath, "lang");
      if(Directory.Exists(path))
      {
        logFile.WriteLine("Removing directory \"" + path + "\"");
        Directory.Delete(path, true);
      }
      // img (rimossa in 0.2.4.0)
      path = Path.Combine(installPath, "img");
      if(Directory.Exists(path))
      {
        logFile.WriteLine("Removing directory \"" + path + "\"");
        Directory.Delete(path, true);
      }

      // *****
      // FILES
      // *****

      // Eyn.PoL.WinFormsView.exe (rimosso in 1.2.5.1)
      path = Path.Combine(installPath, "Eyn.PoL.WinFormsView.exe");
      if(File.Exists(path))
      {
        logFile.WriteLine("Removing file \"" + path + "\"");
        File.Delete(path);
      }
      // Eyn.Communication.dll (rimosso in 1.2.5.1)
      path = Path.Combine(installPath, "Eyn.Communication.dll");
      if(File.Exists(path))
      {
        logFile.WriteLine("Removing file \"" + path + "\"");
        File.Delete(path);
      }
      // Eyn.Patterns.dll (rimosso in 1.2.5.1)
      path = Path.Combine(installPath, "Eyn.Patterns.dll");
      if(File.Exists(path))
      {
        logFile.WriteLine("Removing file \"" + path + "\"");
        File.Delete(path);
      }
      // Eyn.PoL.Common.dll (rimosso in 1.2.5.1)
      path = Path.Combine(installPath, "Eyn.PoL.Common.dll");
      if(File.Exists(path))
      {
        logFile.WriteLine("Removing file \"" + path + "\"");
        File.Delete(path);
      }
      // Eyn.PoL.Configuration.dll (rimosso in 1.2.5.1)
      path = Path.Combine(installPath, "Eyn.PoL.Configuration.dll");
      if(File.Exists(path))
      {
        logFile.WriteLine("Removing file \"" + path + "\"");
        File.Delete(path);
      }
      // Eyn.PoL.Logic.dll (rimosso in 1.2.5.1)
      path = Path.Combine(installPath, "Eyn.PoL.Logic.dll");
      if(File.Exists(path))
      {
        logFile.WriteLine("Removing file \"" + path + "\"");
        File.Delete(path);
      }
      // Eyn.PoL.Models.dll (rimosso in 1.2.5.1)
      path = Path.Combine(installPath, "Eyn.PoL.Models.dll");
      if(File.Exists(path))
      {
        logFile.WriteLine("Removing file \"" + path + "\"");
        File.Delete(path);
      }
      // Eyn.PoL.Services.dll (rimosso in 1.2.5.1)
      path = Path.Combine(installPath, "Eyn.PoL.Services.dll");
      if(File.Exists(path))
      {
        logFile.WriteLine("Removing file \"" + path + "\"");
        File.Delete(path);
      }
      // ICSharpCode.SharpZipLib.dll (rimosso in 1.2.5.1)
      path = Path.Combine(installPath, "ICSharpCode.SharpZipLib.dll");
      if(File.Exists(path))
      {
        logFile.WriteLine("Removing file \"" + path + "\"");
        File.Delete(path);
      }
      // RibbonStyle.dll (rimosso in 1.2.5.1)
      path = Path.Combine(installPath, "RibbonStyle.dll");
      if(File.Exists(path))
      {
        logFile.WriteLine("Removing file \"" + path + "\"");
        File.Delete(path);
      }
      // setCodes.polMapping / setCodes.xml (rimosso in 1.2.5.1)
      path = Path.Combine(installPath, "setCodes.polMapping");
      if(File.Exists(path))
      {
        logFile.WriteLine("Removing file \"" + path + "\"");
        File.Delete(path);
      }
      path = Path.Combine(installPath, "setCodes.xml");
      if(File.Exists(path))
      {
        logFile.WriteLine("Removing file \"" + path + "\"");
        File.Delete(path);
      }


      // **********
      // MIGRATIONS
      // **********

      // modifica enstensione mazzi (migrazione in in 0.2.4.0)
      path = Path.Combine(installPath, "decks");
      if(Directory.Exists(path))
      {
        foreach(string file in Directory.GetFiles(path, "*.polDeck"))
        {
          fromPath = file;
          toPath = Path.ChangeExtension(file, ".xml");
          logFile.WriteLine("Moving file \"" + fromPath + "\" to \"" + toPath + "\"");
          File.Move(fromPath, toPath);
        }
      }

      // modifica enstensione e adeguamento parametri settings (migrazione in in 0.2.4.0)
      foreach(string file in Directory.GetFiles(installPath, "*.polSettings"))
      {
        logFile.WriteLine("Updating settings");
        XmlDocument doc = new XmlDocument();
        doc.Load(file);
        doc.DocumentElement["ClientLanguage"].InnerText = doc.DocumentElement["ClientLanguage"].InnerText.ToLower();
        doc.DocumentElement["GameLanguage"].InnerText = doc.DocumentElement["GameLanguage"].InnerText.ToLower();
        XmlNode node = doc.CreateElement("DeckEditorOrientation");
        node.InnerText = "Vertical";
        doc.DocumentElement.AppendChild(node);
        node = doc.CreateElement("CurrentGameCode");
        node.InnerText = "mtg";
        doc.DocumentElement.AppendChild(node);
        doc.Save(file);
        fromPath = file;
        toPath = Path.ChangeExtension(file, ".xml");
        logFile.WriteLine("Moving file \"" + fromPath + "\" to \"" + toPath + "\"");
        File.Move(fromPath, toPath);
      }

      // rinominazione file settings (migrazione in 1.2.5.1)
      fromPath = Path.Combine(installPath, "Eyn.PoL.Configuration.xml");
      if(File.Exists(fromPath))
      {
        toPath = Path.Combine(installPath, "PoL.xml");
        logFile.WriteLine("Moving file \"" + fromPath + "\" to \"" + toPath + "\"");
        File.Move(fromPath, toPath);
      }

      // ************
      // INSTALLATION
      // ************

      // data
      CopyDirectoryTree(logFile, Path.Combine(thisPath, "data"), Path.Combine(installPath, "data"), new string[] { "*.xml" });

      // decks
      path = Path.Combine(installPath, "decks");
      if(!Directory.Exists(path))
      {
        logFile.WriteLine("Creating directory \"" + path + "\"");
        Directory.CreateDirectory(path);
      }

      // graphics
      CopyDirectoryTree(logFile, Path.Combine(thisPath, "graphics"), Path.Combine(installPath, "graphics"), new string[] { "*.jpg", "*.jpeg", "*.png", "*.gif" });

      // logs
      path = Path.Combine(installPath, "logs");
      if(!Directory.Exists(path))
      {
        logFile.WriteLine("Creating directory \"" + path + "\"");
        Directory.CreateDirectory(path);
      }

      // save
      path = Path.Combine(installPath, "save");
      if(!Directory.Exists(path))
      {
        logFile.WriteLine("Creating directory \"" + path + "\"");
        Directory.CreateDirectory(path);
      }

      // PoL.exe
      fromPath = Path.Combine(thisPath, "PoL.exe");
      toPath = Path.Combine(installPath, "PoL.exe");
      logFile.WriteLine("Copying file \"" + fromPath + "\" to \"" + toPath + "\"");
      File.Copy(fromPath, toPath, true);

      // license.txt
      fromPath = Path.Combine(thisPath, "license.txt");
      toPath = Path.Combine(installPath, "license.txt");
      logFile.WriteLine("Copying file \"" + fromPath + "\" to \"" + toPath + "\"");
      File.Copy(fromPath, toPath, true);
    }

    static void CopyDirectoryTree(StreamWriter logFile, string fromDir, string toDir, string[] searchPatterns)
    {
      if(!Directory.Exists(toDir))
      {
        logFile.WriteLine("Creating directory \"" + toDir + "\"");
        Directory.CreateDirectory(toDir);
      }
      foreach(string searchPattern in searchPatterns)
        foreach(string file in Directory.GetFiles(fromDir, searchPattern))
        {
          string fromPath = file;
          string toPath = Path.Combine(toDir, Path.GetFileName(file));
          logFile.WriteLine("Copying file \"" + fromPath + "\" to \"" + toPath + "\"");
          File.Copy(fromPath, toPath, true);
        }
      foreach(string dir in Directory.GetDirectories(fromDir))
        CopyDirectoryTree(logFile, dir, Path.Combine(toDir, dir.Split(Path.DirectorySeparatorChar).Last()), searchPatterns);
    }
  }
}
