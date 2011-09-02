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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PoL.Services;

namespace PoL.WinFormsView.DeckEditor
{
  public partial class DeckStatisticsView : Form
  {
    DeckStatistics statistics;

    public DeckStatisticsView()
    {
      InitializeComponent();
    }

    public DeckStatistics Statistics
    {
      get { return statistics; }
      set
      {
        this.statistics = value;
        //BuildChart();
      }
    }

    //private void BuildChart()
    //{
    //  // get a reference to the GraphPane

    //  GraphPane myPane = graph.GraphPane;

    //  // Set the Titles
    //  myPane.Title.Text = "Card Colors";
    //  myPane.XAxis.IsVisible = false;
    //  myPane.YAxis.IsVisible = false;

    //  foreach(var colorEntry in statistics.TotalMainCardsPerColor)
    //  {
    //    Color color1 = Color.Transparent;
    //    Color color2 = Color.Transparent;
    //    switch(colorEntry.Key)
    //    {
    //      case "W": color1 = Color.White; color2 = Color.White; break;
    //      case "R": color1 = Color.Red; color2 = Color.White; break;
    //      case "G": color1 = Color.Green; color2 = Color.White; break;
    //      case "U": color1 = Color.Blue; color2 = Color.White; break;
    //      case "B": color1 = Color.Black; color2 = Color.White; break;
    //    }
    //    PieItem pieItem = myPane.AddPieSlice(colorEntry.Value, color1, color2, 0, 0, colorEntry.Key);
    //  }
    //}
  }
}
