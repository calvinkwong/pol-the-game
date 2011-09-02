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
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using PoL.Common;
using System.IO;
using Patterns;
using System.Reflection;

namespace PoL.Configuration
{
  public static class SettingsManager 
  {
    static string settingsFilePath;

    static Settings settings;


    public static Settings Settings
    {
      get
      {
        if(settings == null)
        {
          XmlSerializer serializer = new XmlSerializer(typeof(Settings));
          string assembyLocation = Assembly.GetEntryAssembly().Location;
          string currentDir = Path.GetDirectoryName(assembyLocation);
          string exeName = Path.GetFileName(assembyLocation);
          settingsFilePath = Path.Combine(currentDir, Path.ChangeExtension(exeName, ".xml"));
          if(File.Exists(settingsFilePath))
          {
            using(FileStream file = File.OpenRead(settingsFilePath))
              settings = (Settings)serializer.Deserialize(file);
          }
          else
          {
            settings = new Settings();
            using(FileStream file = File.Create(settingsFilePath))
              serializer.Serialize(file, settings);
          }
        }
        return settings;
      }
    }

    static public void Save()
    {
      XmlSerializer serializer = new XmlSerializer(typeof(Settings));
      Utils.BackupFile(settingsFilePath, true);
      using(FileStream file = File.Create(settingsFilePath))
        serializer.Serialize(file, settings);
    }
  }
}
