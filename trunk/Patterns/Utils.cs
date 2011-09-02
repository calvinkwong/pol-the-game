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
using System.IO;
using System.Xml;
using System.Runtime.Serialization;

namespace Patterns
{
  public class Utils
  {
    static public bool IsMono
    {
      get { return Type.GetType("Mono.Runtime") != null; }
    }

    public static void BackupFile(string path, bool remove)
    {
      string bakPath = string.Concat(path, ".bak");
      if(File.Exists(bakPath))
        File.Delete(bakPath);
      if(File.Exists(path))
      {
        if(remove)
          File.Move(path, bakPath);
        else
          File.Copy(path, bakPath);
      }
    }

    public static List<int> GetUniqueRandomIndices(int max, int amount, int randomSeed)
    {
      amount = Math.Min(max + 1, amount);
      List<int> result = null;
      if(amount == (max + 1))
        result = Enumerable.Range(0, amount).ToList();
      else
      {
        result = new List<int>();
        Random random = new Random(randomSeed);
        while(result.Count < amount)
        {
          int index = random.Next(0, max);
          if(!result.Contains(index))
            result.Add(index);
        }
      }
      return result;
    }
  }
}
