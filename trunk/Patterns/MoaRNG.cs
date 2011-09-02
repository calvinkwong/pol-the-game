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

namespace Patterns
{
  public class MoaRNG
  {
    MoaRNGSeed seed;

    public MoaRNG()
      : this(null)
    {
    }

    public MoaRNG(MoaRNGSeed seed)
    {
      this.seed = seed ?? new MoaRNGSeed();
    }

    /// <summary>
    /// Return a random value in 0, v-1
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public int RandomInt(uint v)
    {
      int result = 0;
      uint r = RandomUint();
      if(v > 0)
        result = (int)(r % v);
      return result;
    }

    uint RandomUint()
    {
      long s = 2111111111 * (long)seed.First + 1492 * (long)seed.Second +
        1776 * (long)seed.Third + 5115 * (long)seed.Fourth + (long)seed.Fifth;
      uint xs = (uint)(s >> 32);
      uint xn = (uint)s;
      seed.First = seed.Second;
      seed.Second = seed.Third;
      seed.Third = seed.Fourth;
      seed.Fourth = xn;
      seed.Fifth = xs;
      return xn;
    }
  }

  [Serializable]
  public class MoaRNGSeed
  {
    uint[] seed = new uint[5];

    public MoaRNGSeed()
    {
      seed[0] = (uint)DateTime.Now.Ticks;
      byte[] guid = Guid.NewGuid().ToByteArray();
      for(int i = 0; i < 4; i++)
        seed[i + 1] = BitConverter.ToUInt32(guid, i * 4);
    }

    public uint First 
    { 
      get { return seed[0]; } 
      set { seed[0] = value; } 
    }

    public uint Second 
    { 
      get { return seed[1]; }
      set { seed[1] = value; }
    }

    public uint Third 
    { 
      get { return seed[2]; }
      set { seed[2] = value; }
    }
    
    public uint Fourth 
    { 
      get { return seed[3]; }
      set { seed[3] = value; }
    }

    public uint Fifth 
    { 
      get { return seed[4]; }
      set { seed[4] = value; }
    }
  }
}
