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
using PoL.Common;

namespace PoL.Services.DataEntities
{
  public class CardSearchParams
  {
    public List<string> Ids { get; set; }
    public List<string> Types { get; set; }
    public List<string> Colors { get; set; }
    public List<string> Sets { get; set; }
    public List<string> Rarities { get; set; }
    public CostFilter Cost { get; set; }
    public string Name { get; set; }
    public string Characteristics { get; set; }
    public bool NameExact { get; set; }
    public string Text { get; set; }
    public string Language { get; set; }
    public OrderCriteria OrderCriteria { get; set; }

    public CardSearchParams()
    {
      Ids = new List<string>();
      Types = new List<string>();
      Colors = new List<string>();
      Sets = new List<string>();
      Rarities = new List<string>();
      Cost = new CostFilter() { Criteria = CostCriteria.None }; 
      NameExact = false;
      this.OrderCriteria = new OrderCriteria() { Field = OrderField.None, Ascending = true };
    }
  }

  public class CostFilter
  {
    public CostCriteria Criteria { get; set; }
    public int Value { get; set; }
  }

  public class OrderCriteria
  {
    public OrderField Field { get; set; }
    public bool Ascending { get; set; }
  }

  public enum OrderField
  {
    None,
    Type,
    Color,
    Set,
    Rarity,
    Cost,
    Name,
    Characteristics,
    Text,
    FlavorText,
    Artist,
  }
}
