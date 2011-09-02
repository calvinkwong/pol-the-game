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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using PoL.Services.DataEntities;
using Patterns.ComponentModel;

namespace PoL.Models.Game
{
  [Serializable]
  public class CommandModel : Model
  {
    public readonly BaseItem Data;

    [NonSerialized]
    EventHandler dataChanged;

    public event EventHandler DataChanged
    {
      add { dataChanged = (EventHandler)Delegate.Combine(dataChanged, value); }
      remove { dataChanged = (EventHandler)Delegate.Remove(dataChanged, value); }
    }

    public CommandModel(string key, BaseItem commandItem)
      : base(key)
    {
      this.Data = commandItem;
    }

    public void UpdateData(BaseItem newData)
    {
      this.Data.Name = newData.Name;

      OnDataChanged();
    }

    protected virtual void OnDataChanged()
    {
      if(dataChanged != null)
        dataChanged(this, EventArgs.Empty);
    }
  }
}
