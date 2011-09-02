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
using PoL.Services.DataEntities;
using System.IO;

namespace PoL.WinFormsView.DeckRoom
{
  public partial class DeckImportStatisticsView : Form, ILocalizable
  {
    public DeckImportStatisticsView()
    {
      InitializeComponent();

      btnOk.Click += new EventHandler(btnOk_Click);

      listResults.SelectedIndexChanged += new EventHandler(listResults_SelectedIndexChanged);

      Localize();
    }

    void listResults_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        listDiscardedLines.Items.Clear();
        if(listResults.SelectedIndices.Count > 0)
        {
          DeckImportResult res = (DeckImportResult)listResults.SelectedItems[0].Tag;
          foreach(var discardedLine in res.DiscardedLines)
          {
            ListViewItem item = new ListViewItem();
            item.Text = discardedLine.Key;
            item.SubItems.Add(discardedLine.Value);
            listDiscardedLines.Items.Add(item);
          }
        }
      }
      catch(Exception ex)
      {
        Program.ExceptionBox(ex);
      }
    }

    void btnOk_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    public DeckImportStatistics ImportStatistics
    {
      set
      {
        try
        {
          listResults.Items.Clear();
          foreach(var result in value.ImportResults)
          {
            ListViewItem item = new ListViewItem(result.Successfull ? "OK" : "KO");
            item.ImageKey = result.Successfull ? "OK" : "KO";
            item.SubItems.Add(Path.GetFileName(result.FileName));
            item.Tag = result;
            listResults.Items.Add(item);
          }
          if(listResults.Items.Count > 0)
            listResults.Items[0].Selected = true;
        }
        catch(Exception ex)
        {
          Program.ExceptionBox(ex);
        }
      }
    }

    public void Localize()
    {
      this.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("IMPORT_RESULTS_DIALOG", "TITLE");
      colStatus.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("IMPORT_RESULTS_DIALOG", "STATUS");
      colFileName.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("IMPORT_RESULTS_DIALOG", "FILENAME");
      colLine.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("IMPORT_RESULTS_DIALOG", "LINE");
      colError.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("IMPORT_RESULTS_DIALOG", "ERROR");
    }
  }
}
