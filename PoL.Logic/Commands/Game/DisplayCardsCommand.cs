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

using PoL.Models.Game;
using PoL.Common;
using Patterns;

namespace PoL.Logic.Commands.Game
{
  [Serializable]
  public class DisplayCardsCommand : GameCommand
  {
    public const string COMMANDCODE_RANDOM = "DISPLAY_RANDOM_CARDS";
    public const string COMMANDCODE_MULTIPLE = "DISPLAY_CARDS";

    int randomSeed = DateTime.Now.Millisecond;

    public DisplayCardsArguments Arguments { get; set; }

    public DisplayCardsCommand(GameModel game)
      : base(game)
    {
    }

    public DisplayCardsCommand()
      : this(null)
    {
    }

    public override void Execute()
    {
      if(Receiver.CardDisplay.Visible.Value)
        return;

      string destinationPlayerKey = Arguments.PlayerKey;
      PlayerModel destinationPlayer = Receiver.GetPlayerByKey(destinationPlayerKey);
      SectorModel sector = null;
      switch(Arguments.Mode)
      {
        case DisplayCardsMode.Random: sector = Receiver.GetSectorByKey(Arguments.SectorKey); break;
        case DisplayCardsMode.ByKeys: sector = (SectorModel)((CardModel)Receiver.GetCardByKey(Arguments.CardKeys.First())).Parent; break;
      }

      Log(destinationPlayer, sector);

      IEnumerable<CardModel> cards = null;
      switch(Arguments.Mode)
      {
        case DisplayCardsMode.Random:
          cards = Utils.GetUniqueRandomIndices(sector.Cards.Count - 1, Arguments.Amount, randomSeed).Select(i => (CardModel)sector.Cards[i]);
          break;
        case DisplayCardsMode.ByKeys:
          cards = Arguments.CardKeys.Select(k => (CardModel)sector.Cards.Single(c => c.Key == k));
          break;
      }

      if(destinationPlayerKey == Receiver.ActivePlayer.Key)
      {
        Receiver.CardDisplay.Cards.Clear();
        Receiver.CardDisplay.Cards.AddRange(cards.Select(c => c.Data));
        Receiver.CardDisplay.Visible.Value = true;
      }
      else if(Invoker == Receiver.ActivePlayer.Key && sector.Data.CardsVisibility != SectorCardsVisibility.Hidden)
      {
        // caller can view random cards showed to opponent into log
        foreach(var c in cards)
          Receiver.Console.WriteLog(new MessageContent(CardLogger.EncodeCardSmartName(c)));
      }
    }

    void Log(PlayerModel destinationPlayer, SectorModel sector)
    {
        string playerName = Receiver.GetPlayerByKey(Invoker).Info.NickName;
        string commandName = string.Empty;
        switch(Arguments.Mode)
        {
          case DisplayCardsMode.ByKeys: 
            commandName = Receiver.GetCommandByKey(COMMANDCODE_MULTIPLE).Data.Name;
            commandName = commandName.Replace("#amount#", Arguments.CardKeys.Count.ToString());
            break;
          case DisplayCardsMode.Random: 
            commandName = Receiver.GetCommandByKey(COMMANDCODE_RANDOM).Data.Name;
            commandName = commandName.Replace("#amount#", Arguments.Amount.ToString());
            break;
        }
        Receiver.Console.WriteLog(string.Concat(
          "[", playerName, "] ",
          commandName, " (", sector.Data.Name, ")", ">", destinationPlayer.Info.NickName));
    }
  }

  [Serializable]
  public struct DisplayCardsArguments
  {
    public string SectorKey { get; set; }
    public string PlayerKey { get; set; }
    public DisplayCardsMode Mode { get; set; }
    public int Amount { get; set; }
    public List<string> CardKeys { get; set; }
  }
}
