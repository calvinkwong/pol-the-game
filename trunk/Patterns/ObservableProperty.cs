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
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns
{
  [Serializable]
  public class ObservableProperty<TValue, TOwner>
  {
    TValue val;
    TOwner owner;

    [NonSerialized]
    EventHandler<ChangedEventArgs<TValue>> changed;

    public event EventHandler<ChangedEventArgs<TValue>> Changed
    {
      add { changed = (EventHandler<ChangedEventArgs<TValue>>)Delegate.Combine(changed, value); }
      remove { changed = (EventHandler<ChangedEventArgs<TValue>>)Delegate.Remove(changed, value); }
    }

    public ObservableProperty(TOwner owner, TValue val)
    {
      this.owner = owner;
      this.val = val;
    }

    public TOwner Owner
    {
      get { return owner; }
    }

    public TValue Value
    {
      get { return val; }

      set
      {
        if(
          (value == null && val != null)
          || (value != null && val == null)
          || (value != null && !value.Equals(val))
          )
        {
          TValue oldValue = val;
          val = value;
          OnChanged(new ChangedEventArgs<TValue>
          {
            OldValue = oldValue,
            NewValue = value
          });
        }
      }
    }

    void OnChanged(ChangedEventArgs<TValue> e)
    {
      if(changed != null)
        changed(this, e);
    }
  }

  public class ChangedEventArgs<T> : EventArgs
  {
    public T OldValue { get; set; }
    public T NewValue { get; set; }
  }
}
