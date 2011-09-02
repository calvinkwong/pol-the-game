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
using Patterns;
using Patterns.Command;
using PoL.Models.Game;
using PoL.Common;
using Patterns.ComponentModel;

namespace PoL.Logic.Commands.Game
{
  [Serializable]
  public class DoMulliganCommand : GameCommand, IUndoableCommand
  {
    public const string COMMANDCODE = "MULLIGAN";

    [NonSerialized]
    List<Model> handCards;
    [NonSerialized]
    List<Model> deckCards;

    public DoMulliganCommand(GameModel game)
      : base(game)
    {
    }

    public DoMulliganCommand()
      : this(null)
    {
    }

    public override void Execute()
    {
      var player = Receiver.GetPlayerByKey(Invoker);
      var hand = player.Sectors.Cast<SectorModel>().Single(s => s.Data.Code == SystemSectors.HAND.ToString());
      var deck = player.Sectors.Cast<SectorModel>().Single(s => s.Data.Code == SystemSectors.DECK.ToString());

      handCards = hand.Cards.ToList();
      deckCards = deck.Cards.ToList();

      int toDraw = Receiver.GameItem.StartCardsAmount;
      if(hand.Cards.Count > 1)
        toDraw = hand.Cards.Count - 1;

      if(hand.Cards.Count > 0)
      {
        var discardedCards = hand.Cards.ToList();
        hand.Cards.Clear();
        deck.Cards.AddRange(discardedCards);
      
        deck.Cards.SuspendChangeNotifications();
        try
        {
          deck.Cards.Shuffle();
        }
        finally
        {
          deck.Cards.ResumeChangeNotifications();
        }
      }

      var drawnCards = deck.Cards.Take(toDraw).ToList();
      if(drawnCards.Count > 0)
      {
        foreach(var card in drawnCards)
          deck.Cards.Remove(card);
        hand.Cards.AddRange(drawnCards);
      }

      Log(hand.Cards.Count);
    }
    
    void Log(int cardDrawnAmount)
    {
      string playerName = Receiver.GetPlayerByKey(Invoker).Info.NickName;
      string commandName = Receiver.GetCommandByKey(COMMANDCODE).Data.Name;
      Receiver.Console.WriteLog(string.Concat(
        "[", playerName, "] ", commandName, " (", cardDrawnAmount, ")"));
    }

    public void Undo()
    {
      var player = Receiver.GetPlayerByKey(Invoker);
      var hand = player.Sectors.Cast<SectorModel>().Single(s => s.Data.Code == SystemSectors.HAND.ToString());
      var deck = player.Sectors.Cast<SectorModel>().Single(s => s.Data.Code == SystemSectors.DECK.ToString());

      deck.Cards.Clear();
      deck.Cards.AddRange(deckCards);

      hand.Cards.Clear();
      hand.Cards.AddRange(handCards);
    }
  }
}
