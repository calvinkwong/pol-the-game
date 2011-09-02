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
using Patterns.ComponentModel;
using PoL.Models.Game;

namespace PoL.Models.GameRestarters
{
  public class ServerRestarterModel : Model, IGameRestarterModel
  {
    ModelCollection players;
    ConsoleModel console;

    public event Action<object> Started;

    public ServerRestarterModel()
      : base(Guid.NewGuid().ToString())
    {
      this.players = new ModelCollection(this);
      this.console = new ConsoleModel(Guid.NewGuid().ToString());
    }

    public ModelCollection Players
    {
      get { return players; }
    }

    public ConsoleModel Console
    {
      get { return console; }
    }

    public void Start()
    {
      OnStarted();
    }

    protected virtual void OnStarted()
    {
      if(Started != null)
        Started(this);
    }
  }
}
