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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Security.Cryptography;
using PoL.Configuration;
using System.Drawing;
using Patterns;

namespace PoL.Services
{
  public class CryptoDataSaver
  {
    public const string SAVE_FILE_EXTENSION = ".polSave";
    static byte[] CRYPTO_IV = new byte[] { 0x53, 0x20, 0x91, 0x39, 0x88, 0x91, 0x15, 0x64 };
    static byte[] SALT = new byte[] { 0x15, 0x22, 0x53, 0x44, 0x75, 0x18, 0x61, 0x48 };
    const int KEY_SIZE = 128;

    RC2CryptoServiceProvider dataCryptoService = new RC2CryptoServiceProvider();

    public CryptoDataSaver(List<string> passwords)
    {
      string password = string.Concat(passwords.OrderBy(e => e).ToArray());
      
      dataCryptoService.KeySize = KEY_SIZE;
      dataCryptoService.IV = CRYPTO_IV;
      dataCryptoService.Key = KeyGen.DeriveKey(password, KEY_SIZE / 8, SALT);
    }

    public void Save<T>(T data, string id, SaveMetaData metaData)
    {
      using(FileStream file = File.Create(Path.Combine(SettingsManager.Settings.SavePath, id) + SAVE_FILE_EXTENSION))
      {
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(file, metaData);
        using(CryptoStream cryptoStream = new CryptoStream(file, dataCryptoService.CreateEncryptor(), CryptoStreamMode.Write))
          formatter.Serialize(cryptoStream, data);
      }
    }
    
    public void Load<T>(string id, out T data)
    {
      data = default(T);
      string path = Path.Combine(SettingsManager.Settings.SavePath, id) + SAVE_FILE_EXTENSION;
      if(File.Exists(path))
      {
        using(FileStream file = File.Open(path, FileMode.Open))
        {
          BinaryFormatter formatter = new BinaryFormatter();
          SaveMetaData metaData = (SaveMetaData)formatter.Deserialize(file);
          using(CryptoStream cryptoStream = new CryptoStream(file, dataCryptoService.CreateDecryptor(), CryptoStreamMode.Read))
            data = (T)formatter.Deserialize(cryptoStream);
        }
      }
    }

    public static List<SaveMetaData> LoadMetadatas()
    {
      List<SaveMetaData> datas = new List<SaveMetaData>();
      BinaryFormatter formatter = new BinaryFormatter();
      foreach(string fileName in Directory.GetFiles(SettingsManager.Settings.SavePath, "*" + SAVE_FILE_EXTENSION))
      {
        using(FileStream file = File.Open(fileName, FileMode.Open))
        {
          try
          {
            SaveMetaData metaData = (SaveMetaData)formatter.Deserialize(file);
            metaData.Id = Path.GetFileNameWithoutExtension(fileName);
            datas.Add(metaData);
          }
          catch { }
        }
      }
      return datas;
    }

    public static bool Exists(string id)
    {
      return File.Exists(Path.Combine(SettingsManager.Settings.SavePath, id) + SAVE_FILE_EXTENSION);
    }

    public static void Delete(SaveMetaData metaData)
    {
      File.Delete(Path.Combine(SettingsManager.Settings.SavePath, metaData.Id) + SAVE_FILE_EXTENSION);
    }
  }

  [Serializable]
  public class SaveMetaData
  {
    public DateTime Date { get; set; }
    public Bitmap Picture { get; set; }
    public string[] Players { get; set; }
    [NonSerialized]
    string id;

    public string Id
    {
      get { return id; }
      set { id = value; }
    } 
  }
}
