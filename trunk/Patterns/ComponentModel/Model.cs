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

namespace Patterns.ComponentModel
{
  [Serializable]
  public class Model
  {
    Model parent;
    Model owner;
    string key;

    public Model(Model parent, Model owner, string key)
    {
      if(string.IsNullOrEmpty(key))
        throw new ArgumentException("Name cannot be null or empty!", "key");
      this.parent = parent;
      this.owner = owner;
      this.key = key;
    }

    public Model(Model owner, string key)
      : this(null, owner, key)
    {
    }

    public Model(string key)
      : this(null, null, key)
    {
    }

    public Model Parent
    {
      get { return parent; }
    }

    public Model Owner
    {
      get { return owner; }
    }

    public string Key
    {
      get { return key; }
    }

    internal void SetParent(Model parent)
    {
      this.parent = parent;

      OnParentChanged();
    }

    protected virtual void OnParentChanged()
    {
    }
  }
}
