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

using Patterns.Command;
using PoL.Models.Game;
using PoL.Models;
using PoL.Common;
using PoL.Services.DataEntities;
using System.Collections;
using Patterns;

namespace PoL.Logic.Commands.Game
{
  [Serializable]
  public class OpenSectorLookupCommand : GameCommand
  {
    public const string COMMANDCODE_WATCH_TOP = "WATCH_TOP_CARDS";
    public const string COMMANDCODE_KEEP_VISIBLE_TOP = "KEEP_VISIBLE_TOP_CARDS";
    public const string COMMANDCODE_WATCH_ALL = "WATCH_ALL_CARDS";
    public const string COMMANDCODE_SHOW_ALL = "SHOW_ALL_CARDS";
    public const string COMMANDCODE_SHOW_TOP = "SHOW_TOP_CARDS";

    string lookupKey;
    int seed;

    public OpenSectorLookupArguments Arguments { get; set; }

    public OpenSectorLookupCommand(GameModel game)
      : base(game)
    {
      lookupKey = Guid.NewGuid().ToString();
      seed = DateTime.Now.Millisecond;
    }

    public OpenSectorLookupCommand()
      : this(null)
    {
    }

    public override void Execute()
    {
      SectorModel sector = Receiver.GetSectorByKey(Arguments.SectorKey);
      PlayerModel player = Receiver.GetPlayerByKey(Arguments.DestinationPlayerKey);
      LookupRules rules = null;
      LookupStyle style = LookupStyle.All;
      switch(Arguments.Mode)
      {
        case LookupOpenMode.All: style = LookupStyle.All; break;
        case LookupOpenMode.KeepVisibleTop: style = LookupStyle.KeepVisibleTop; break;
        case LookupOpenMode.Top: style = LookupStyle.Top; break;
      }
      rules = new LookupRules(style, Arguments.Amount, Arguments.CardKeys);
      bool readOnly = sector.Parent.Key != Receiver.ActivePlayer.Key;
      LookupModel lookup = new LookupModel(lookupKey, sector, rules, player, readOnly);
      Receiver.Lookups.Add(lookup);

      Log(sector, rules);
    }

    void Log(SectorModel sector, LookupRules rules)
    {
      string playerName = Receiver.GetPlayerByKey(Invoker).Info.NickName;
      string destinationPlayerName = Receiver.GetPlayerByKey(Arguments.DestinationPlayerKey).Info.NickName;
      bool show = Invoker != Arguments.DestinationPlayerKey;
      string commandName = string.Empty;
      switch(Arguments.Mode)
      {
        case LookupOpenMode.All:
          commandName = Receiver.GetCommandByKey(show ? COMMANDCODE_SHOW_ALL : COMMANDCODE_WATCH_ALL).Data.Name;
          break;
        case LookupOpenMode.KeepVisibleTop:
          commandName = Receiver.GetCommandByKey(COMMANDCODE_KEEP_VISIBLE_TOP).Data.Name;
          break;
        case LookupOpenMode.Top:
          commandName = Receiver.GetCommandByKey(show ? COMMANDCODE_SHOW_TOP : COMMANDCODE_WATCH_TOP).Data.Name;
          break;
      }
      commandName = commandName.Replace("#amount#", Arguments.Amount.ToString());
      string message = string.Concat("[", playerName, "] ", commandName, " (");
      if(!show && sector.Parent.Key != Invoker)
        message += string.Concat(Receiver.GetPlayerByKey(sector.Parent.Key).Info.NickName, "-");
      message += string.Concat(sector.Data.Name, ")");
      if(show)
        message += string.Concat(">", destinationPlayerName);
      Receiver.Console.WriteLog(message);
    }
  }

  [Serializable]
  public struct OpenSectorLookupArguments
  {
    public string SectorKey { get; set; }
    public string DestinationPlayerKey { get; set; }
    public LookupOpenMode Mode { get; set; }
    public int Amount { get; set; }
    public List<string> CardKeys { get; set; }
  }
}
