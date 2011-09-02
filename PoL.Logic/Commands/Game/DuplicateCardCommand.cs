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

using PoL.Models;
using PoL.Common;
using Patterns.Command;
using PoL.Models.Game;
using PoL.Services.DataEntities;
using Patterns;

namespace PoL.Logic.Commands.Game
{
  [Serializable]
  public class DuplicateCardCommand : GameCommand, IUndoableCommand
  {
    public const string COMMANDCODE = "DUPLICATE_CARD";

    string pawnKey = Guid.NewGuid().ToString();

    public DuplicateCardArguments Arguments { get; set; }

    public DuplicateCardCommand(GameModel game)
      : base(game)
    {
    }

    public DuplicateCardCommand()
      : this(null)
    {
    }

    public override void Execute()
    {
      CardModel card = Receiver.GetCardByKey(Arguments.CardKey);
      CardItem pawnItem = card.Data.Clone();
      pawnItem.UniqueID = pawnKey;

      SectorModel sector = (SectorModel)card.Parent;
      PlayerModel player = (PlayerModel)Receiver.GetPlayerByKey(Invoker);
      CardModel pawn = new CardModel(pawnKey, player, pawnItem, true);
      pawn.Position.Value = Arguments.CardPosition;
      pawn.Data.StyleCode = "PAWN";
      pawn.Data.BgImagePathLarge = "bg_PAWN_Large.png";
      pawn.Data.BgImagePathSmall = "bg_PAWN_Small.png";
      sector.Cards.Insert(0, pawn);

      Log(pawn);
    }

    public void Undo()
    {
      CardModel pawn = Receiver.GetCardByKey(pawnKey);
      if(pawn != null)
      {
        SectorModel sector = (SectorModel)pawn.Parent;
        sector.Cards.Remove(pawn);
      }
    }

    void Log(CardModel pawn)
    {
      string playerName = Receiver.GetPlayerByKey(Invoker).Info.NickName;
      string commandName = Receiver.GetCommandByKey(COMMANDCODE).Data.Name;
      MessageContent logContent = new MessageContent(string.Concat("[", playerName, "] ", commandName, " "));
      logContent.Add(CardLogger.EncodeCardSmartName(pawn));
      Receiver.Console.WriteLog(logContent);
    }
  }

  [Serializable]
  public struct DuplicateCardArguments
  {
    public string CardKey { get; set; }
    public CardPosition CardPosition { get; set; }
  }
}
