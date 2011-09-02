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
using System.Collections;
using System.Windows.Forms;
using PoL.Common;

namespace PoL.WinFormsView.Utils
{
  class ListViewColumnSorter : IComparer
  {
    private CaseInsensitiveComparer mCaseInsensitiveComparer;
    private OrderType[] orderTypes;

    public ListViewColumnSorter(OrderType[] orderTypes)
    {
      mCaseInsensitiveComparer = new CaseInsensitiveComparer();
      this.orderTypes = orderTypes;
    }

    public int Compare(object x, object y)
    {
      ListViewItem listviewX = (ListViewItem)x;
      ListViewItem listviewY = (ListViewItem)y;

      double compareResult = 0;

      switch(orderTypes[SortColumn])
      {
        case OrderType.Text:
          compareResult = mCaseInsensitiveComparer.Compare(listviewX.SubItems[SortColumn].Text, listviewY.SubItems[SortColumn].Text);
          break;
        case OrderType.Numeric:
          compareResult = Convert.ToDouble(listviewX.SubItems[SortColumn].Text) - Convert.ToDouble(listviewY.SubItems[SortColumn].Text);
          if(compareResult < 0)
            compareResult = -1;
          else if(compareResult > 0)
            compareResult = 1;
          break;
        case OrderType.Cost:
          compareResult = Helper.CompareCost(listviewX.SubItems[SortColumn].Text, listviewY.SubItems[SortColumn].Text);
          break;
      }

      if(Order == SortOrder.Ascending)
        return (int)compareResult;
      else if(Order == SortOrder.Descending)
        return (int)-compareResult;
      else
        return 0;
    }

    public int SortColumn { get; set; }

    public SortOrder Order { get; set; }
  }

  public enum OrderType
  {
    Text,
    Numeric,
    Cost
  }
}
