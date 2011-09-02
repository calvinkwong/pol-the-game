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
using PoL.Services.DataEntities;
using PoL.Common;

namespace PoL.Logic.Commands.Game
{
  public class CardLogger
  {
    public static void LogMovement(GameModel game, string executorPlayerKey, CardModel card, SectorModel fromSector, 
      SectorModel toSector, int fromIndex, int toIndex, CardVisibility? toCardVisibility, bool verbose)
    {
      if(fromSector.Key == toSector.Key && fromSector.Data.Behavior != SectorBehavior.Simple)
        return;

      IEnumerable<SectorModel> sectors = game.Players.Cast<PlayerModel>().SelectMany(e => e.Sectors).Cast<SectorModel>();
      SectorCardsVisibility fromSectorVisibility = sectors.First(e => e.Data.Code == fromSector.Data.Code).Data.CardsVisibility;
      SectorCardsVisibility toSectorVisibility = sectors.First(e => e.Data.Code == toSector.Data.Code).Data.CardsVisibility;

      PlayerModel fromPlayer = (PlayerModel)fromSector.Parent;
      PlayerModel toPlayer = (PlayerModel)toSector.Parent;
      PlayerModel executorPlayer = game.GetPlayerByKey(executorPlayerKey);

      MessageContent logContent = new MessageContent();
      StringBuilder logText = new StringBuilder(200);

      if(verbose)
      {
        logText.Append("[").Append(executorPlayer.Info.NickName).Append("] ");
        logText.Append(game.GetCommandByKey(MoveCardsCommand.COMMANDCODE_SINGLE).Data.Name).Append(" ");
      }
      
      bool fromVisible = fromSectorVisibility == SectorCardsVisibility.Visibile ||
        (fromSectorVisibility == SectorCardsVisibility.Private && fromPlayer.Key == game.ActivePlayer.Key);
      if(fromVisible)
      {
        fromVisible = (card.Visibility.Value == CardVisibility.Visible ||
          (card.Visibility.Value == CardVisibility.Private && fromPlayer.Key == game.ActivePlayer.Key));
      }
      bool toVisible = toSectorVisibility == SectorCardsVisibility.Visibile || 
        (toSectorVisibility == SectorCardsVisibility.Private && toPlayer.Key == game.ActivePlayer.Key);
      if(toVisible)
      {
        if(toCardVisibility.HasValue)
          toVisible = (toCardVisibility.Value == CardVisibility.Visible ||
            (toCardVisibility.Value == CardVisibility.Private && toPlayer.Key == game.ActivePlayer.Key));
        else
          toVisible = (card.Visibility.Value == CardVisibility.Visible ||
            (card.Visibility.Value == CardVisibility.Private && toPlayer.Key == game.ActivePlayer.Key));
      }
      logContent.Add(logText.ToString());
      logText.Length = 0;
      logContent.Add(EncodeCardSmartName(card, fromVisible || toVisible));
      if(verbose)
      {
        logText.Append(" (");
        if(fromPlayer.Key != executorPlayerKey)
          logText.Append(fromPlayer.Info.NickName).Append("-");
        logText.Append(fromSector.Data.Name);
        if(fromSector.Data.Behavior == SectorBehavior.Simple)
          logText.Append("[").Append(fromIndex + 1).Append("]");
        logText.Append(">");
        if(toPlayer.Key != executorPlayerKey)
          logText.Append(toPlayer.Info.NickName).Append("-");
        logText.Append(toSector.Data.Name);
        if(toSector.Data.Behavior == SectorBehavior.Simple)
          logText.Append("[").Append(toIndex + 1).Append("]");
        logText.Append(")");
      }
      else
      {
        if(fromSector.Data.Behavior == SectorBehavior.Simple)
          logText.Append("[").Append(fromIndex + 1).Append("]");
        if(toSector.Data.Behavior == SectorBehavior.Simple)
          logText.Append("[").Append(toIndex + 1).Append("]");
      }
      logContent.Add(logText.ToString());
      game.Console.WriteLog(logContent);
    }

    public static MessageContentElement EncodeCardSmartName(CardModel card)
    {
      MessageContentElement element = new MessageContentElement();
      SmartName cardSmartName = card.GetSmartName();
      if(cardSmartName.Visible)
      {
        //element.Value = card.Key;
        element.Value = card.Data.Id;
        element.Text = card.Data.Name;
      }
      else
        element.Text = cardSmartName.Name;
      return element;
    }

    static MessageContentElement EncodeCardSmartName(CardModel card, bool visible)
    {
      MessageContentElement element = new MessageContentElement();
      SmartName cardSmartName = visible ? card.GetVisibleName() : card.GetHiddenName();
      if(cardSmartName.Visible)
      {
        //element.Value = card.Key;
        element.Value = card.Data.Id;
        element.Text = card.Data.Name;
      }
      else
        element.Text = cardSmartName.Name;
      return element;
    }
  }
}
