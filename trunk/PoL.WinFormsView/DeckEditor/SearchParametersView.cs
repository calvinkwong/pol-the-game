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
using PoL.WinFormsView.Utils;
using PoL.Common;
using PoL.Logic.Controllers;

namespace PoL.WinFormsView.DeckEditor
{
  public partial class SearchParametersView : Form, ILocalizable
  {
    DeckEditorController controller;

    public SearchParametersView()
    {
      InitializeComponent();

      cbCost.Text = string.Empty;
      btnClearFields.Click += new EventHandler(btnClearFields_Click);
      btnSearch.Click += new EventHandler(btnSearch_Click);
      btnClose.Click += new EventHandler(btnClose_Click);
      btnSelectAll.Click += new EventHandler(btnSelectAll_Click);

      btnSelectAllSets.Click += new EventHandler(btnSelectAllSets_Click);
      btnSelectNoneSets.Click += new EventHandler(btnSelectNoneSets_Click);
      btnSelectAllColors.Click += new EventHandler(btnSelectAllColors_Click);
      btnSelectNoneColors.Click += new EventHandler(btnSelectNoneColors_Click);
      btnSelectAllRarities.Click += new EventHandler(btnSelectAllRarities_Click);
      btnSelectNoneRarities.Click += new EventHandler(btnSelectNoneRarities_Click);
      btnSelectAllTypes.Click += new EventHandler(btnSelectAllTypes_Click);
      btnSelectNoneTypes.Click += new EventHandler(btnSelectNoneTypes_Click);
      Localize();
    }

    void btnSelectNoneTypes_Click(object sender, EventArgs e)
    {
      for(int i = 0; i < listType.Items.Count; i++)
        listType.SetItemChecked(i, false);
    }

    void btnSelectAllTypes_Click(object sender, EventArgs e)
    {
      for(int i = 0; i < listType.Items.Count; i++)
        listType.SetItemChecked(i, true);
    }

    void btnSelectNoneRarities_Click(object sender, EventArgs e)
    {
      for(int i = 0; i < listRarity.Items.Count; i++)
        listRarity.SetItemChecked(i, false);
    }

    void btnSelectAllRarities_Click(object sender, EventArgs e)
    {
      for(int i = 0; i < listRarity.Items.Count; i++)
        listRarity.SetItemChecked(i, true);
    }

    void btnSelectNoneColors_Click(object sender, EventArgs e)
    {
      for(int i = 0; i < listColor.Items.Count; i++)
        listColor.SetItemChecked(i, false);
    }

    void btnSelectAllColors_Click(object sender, EventArgs e)
    {
      for(int i = 0; i < listColor.Items.Count; i++)
        listColor.SetItemChecked(i, true);
    }

    void btnSelectNoneSets_Click(object sender, EventArgs e)
    {
      for(int i = 0; i < listSet.Items.Count; i++)
        listSet.SetItemChecked(i, false);
    }

    void btnSelectAllSets_Click(object sender, EventArgs e)
    {
      for(int i = 0; i < listSet.Items.Count; i++)
        listSet.SetItemChecked(i, true);
    }

    void btnSelectAll_Click(object sender, EventArgs e)
    {
      SelectAll();
    }

    void SelectAll()
    {
      for(int i = 0; i < listSet.Items.Count; i++)
        listSet.SetItemChecked(i, true);
      for(int i = 0; i < listColor.Items.Count; i++)
        listColor.SetItemChecked(i, true);
      for(int i = 0; i < listType.Items.Count; i++)
        listType.SetItemChecked(i, true);
      for(int i = 0; i < listRarity.Items.Count; i++)
        listRarity.SetItemChecked(i, true);
    }

    void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    public void SetController(DeckEditorController controller)
    {
      this.controller = controller;
    }

    void btnSearch_Click(object sender, EventArgs e)
    {
      controller.Search(GetCardSearchParams());
    }

    private void btnClearFields_Click(object sender, EventArgs e)
    {
      for(int i = 0; i < listSet.Items.Count; i++)
        listSet.SetItemChecked(i, false);
      for(int i = 0; i < listColor.Items.Count; i++)
        listColor.SetItemChecked(i, false);
      for(int i = 0; i < listType.Items.Count; i++)
        listType.SetItemChecked(i, false);
      for(int i = 0; i < listRarity.Items.Count; i++)
        listRarity.SetItemChecked(i, false);
      txtText.Text = string.Empty;
      txtName.Text = string.Empty;
      txtCharacteristics.Text = string.Empty;
      numCost.Value = 0;
      cbCost.SelectedValue = string.Empty;
    }

    public void Localize()
    {
      lblSet.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "SET");
      lblColor.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "COLOR");
      lblType.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "TYPE");
      lblRarity.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "RARITY");
      lblCharacteristics.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "CHARACTERISTICS");
      lblSearchName.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "NAME");
      lblSearchText.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "TEXT");
      lblSearchCost.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "COST");
      lblSearchParameters.Title = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "SEARCH_ARCHIVE");
      lblSearchParameters.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "SEARCH_ARCHIVE_DESC");
      btnSearch.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "SEARCH");
      btnClearFields.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "CLEAR_FIELDS");
      btnClose.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "CLOSE");
      btnSelectAll.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("DECK_EDITOR_DIALOG", "SELECT_ALL");
    }

    public void BeginLoad()
    {
      listSet.BeginUpdate();
      listType.BeginUpdate();
      listColor.BeginUpdate();
      listRarity.BeginUpdate();
    }

    public void EndLoad()
    {
      listSet.EndUpdate();
      listType.EndUpdate();
      listColor.EndUpdate();
      listRarity.EndUpdate();
    }

    public void SetRarities(List<BaseItem> rarities)
    {
      foreach(BaseItem rarity in rarities)
        listRarity.Items.Add(new ListItem(rarity.Code, rarity.Name), true);
    }

    public void SetSets(List<GameSetItem> sets)
    {
      foreach(GameSetItem set in sets)
        listSet.Items.Add(new ListItem(set.Code, set.Name), true);
    }

    public void SetColors(List<BaseItem> colors)
    {
      foreach(BaseItem color in colors)
        listColor.Items.Add(new ListItem(color.Code, color.Name), true);
    }

    public void SetTypes(List<CardTypeItem> types)
    {
      foreach(CardTypeItem t in types)
        listType.Items.Add(new ListItem(t.Code, t.Name), true);
    }

    public CardSearchParams GetCardSearchParams()
    {
      CardSearchParams parameters = new CardSearchParams();
      for(int i = 0; i < listSet.Items.Count; i++)
      {
        if(listSet.GetItemChecked(i))
          parameters.Sets.Add((listSet.Items[i] as ListItem).Value.ToString());
      }
      for(int i = 0; i < listColor.Items.Count; i++)
      {
        if(listColor.GetItemChecked(i))
          parameters.Colors.Add((listColor.Items[i] as ListItem).Value.ToString());
      }
      for(int i = 0; i < listType.Items.Count; i++)
      {
        if(listType.GetItemChecked(i))
          parameters.Types.Add((listType.Items[i] as ListItem).Value.ToString());
      }
      for(int i = 0; i < listRarity.Items.Count; i++)
      {
        if(listRarity.GetItemChecked(i))
          parameters.Rarities.Add((listRarity.Items[i] as ListItem).Value.ToString());
      }
      parameters.Cost.Criteria = CostCriteria.None;
      switch(cbCost.Text.ToString())
      {
        case "<": parameters.Cost.Criteria = CostCriteria.LessThan; break;
        case "=": parameters.Cost.Criteria = CostCriteria.EqualTo; break;
        case ">": parameters.Cost.Criteria = CostCriteria.MoreThan; break;
      }
      parameters.Cost.Value = (int)numCost.Value;
      if(txtName.Text.Trim().Length > 0)
        parameters.Name = txtName.Text;
      if(txtText.Text.Trim().Length > 0)
        parameters.Text = txtText.Text;
      if(txtCharacteristics.Text.Trim().Length > 0)
        parameters.Characteristics = txtCharacteristics.Text;
      parameters.OrderCriteria = new OrderCriteria() { Field = OrderField.Name, Ascending = true };
      return parameters;
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      e.Cancel = true;
      this.Visible = false;
    }
  }
}
