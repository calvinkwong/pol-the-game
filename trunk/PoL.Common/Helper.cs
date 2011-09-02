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

namespace PoL.Common
{
  public class Helper
  {
    static public int CompareCost(string cost1, string cost2)
    {
      int costAmount1 = 0, costAmount2 = 0;
      foreach(string symbol in GetSymbols(cost1))
        costAmount1 += CostSymbolToInt(symbol);
      foreach(string symbol in GetSymbols(cost2))
        costAmount2 += CostSymbolToInt(symbol);
      return costAmount1 - costAmount2;
    }

    static public int CostSymbolToInt(string costSymbol)
    {
      int costAmount = 0;
      if(!int.TryParse(costSymbol, out costAmount))
        costAmount = 1;
      return costAmount;
    }

    static public List<string> GetSymbols(string cost)
    {
      List<string> symbols = new List<string>();
      if(!string.IsNullOrEmpty(cost))
      {
        string[] tokens = cost.Split('}');
        for(int i = 0; i < (tokens.Length - 1); i++)
          symbols.Add(tokens[i].ToString().Replace("{", ""));
      }
      return symbols;
    }
  }
}
