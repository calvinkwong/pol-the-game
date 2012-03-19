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
using Patterns.ComponentModel;

namespace Patterns
{
  public static class Extensions
  {
    public static void Shuffle<T>(this ObservableCollection<T> collection)
    {
      Shuffle<T>(collection, null);
    }

    public static void Shuffle<T>(this ObservableCollection<T> collection, MoaRNGSeed seed)
    {
      //Random stdRnd = new Random((seed != null ? (int)seed.First : DateTime.Now.Millisecond));
      //for(int k = 0; k <= Math.Min(60, collection.Count); k++)
      //  for(int i = 0; i < collection.Count; i++)
      //    collection.Move(i, stdRnd.Next(collection.Count));

      MoaRNG moaRnd = new MoaRNG(seed);
      for(int k = 0; k <= Math.Min(60, collection.Count()); k++)
        for(int i = 0; i < collection.Count(); i++)
          collection.Move(i, i + moaRnd.RandomInt((uint)(collection.Count() - i)));
    }
  }
}
