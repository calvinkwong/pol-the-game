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

using PoL.Common;
using PoL.Models.Game;
using PoL.Services.DataEntities;
using Patterns.ComponentModel;
using Patterns.Command;
using Patterns;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml;

namespace PoL.Logic.Commands.Game
{
  [Serializable]
  public class MoveCardsCommand : GameCommand, IUndoableCommand
  {
    public const string COMMANDCODE_RANDOM = "MOVE_RANDOM_CARDS";
    public const string COMMANDCODE_MULTIPLE = "MOVE_CARDS";
    public const string COMMANDCODE_SINGLE = "MOVE_SINGLE_CARD";

    [NonSerialized]
    SectorModel sourceSector;
    [NonSerialized]
    List<SectorModel> destinationSectors;
    [NonSerialized]
    List<CardModel> movedCards;
    [NonSerialized]
    List<CardPosition> oldPositions;
    [NonSerialized]
    List<int> oldIndicies;
    [NonSerialized]
    List<CardVisibility> oldVisibilityStates;

    int randomSeed = DateTime.Now.Millisecond;

    public MoveCardsArguments Arguments { get; set; }

    public MoveCardsCommand(GameModel game)
      : base(game)
    {
    }

    public MoveCardsCommand()
      : this(null)
    {
    }

    public override void Execute()
    {
      switch(Arguments.SourceMode)
      {
        case MoveCardsSourceMode.Random:
          sourceSector = Receiver.GetPlayerByKey(Invoker).Sectors.Cast<SectorModel>().Single(e => e.Data.Code == Arguments.SourceSectorCode);
          oldIndicies = Utils.GetUniqueRandomIndices(sourceSector.Cards.Count - 1, Arguments.Amount, randomSeed).OrderBy(e => e).ToList();
          movedCards = oldIndicies.Select(i => sourceSector.Cards[i]).Cast<CardModel>().ToList();
          break;
        case MoveCardsSourceMode.Specific:
          sourceSector = (SectorModel)Receiver.GetCardByKey(Arguments.CardKeys.First()).Parent;
          movedCards = Arguments.CardKeys.Select(k => sourceSector.Cards.Single(c => c.Key == k)).Cast<CardModel>().ToList();
          oldIndicies = movedCards.Select(c => sourceSector.Cards.IndexOf(c)).ToList();
          break;
      }

      var pawnIndicies = movedCards.Where(c => c.IsPawn).Select(c => sourceSector.Cards.IndexOf(c)).ToList();
      oldPositions = movedCards.Select(c => c.Position.Value).ToList();
      oldVisibilityStates = movedCards.Select(c => c.Visibility.Value).ToList();
      if(string.IsNullOrEmpty(Arguments.DestinationPlayerKey))
        destinationSectors = movedCards.Select(c => Receiver.GetPlayerByKey(c.Owner.Key).Sectors.Cast<SectorModel>().Single(e => e.Data.Code == Arguments.DestinationSectorCode)).ToList();
      else
        destinationSectors = Enumerable.Repeat(Receiver.GetPlayerByKey(Arguments.DestinationPlayerKey).Sectors.Cast<SectorModel>().Single(e => e.Data.Code == Arguments.DestinationSectorCode), movedCards.Count).ToList();

      if(
        (Arguments.SourceMode == MoveCardsSourceMode.Random) ||
        (Arguments.SourceMode == MoveCardsSourceMode.Specific && (Arguments.CardKeys.Count > 1))
        )
        Log(sourceSector, Arguments.SourceMode, destinationSectors.First(), movedCards.Count);

      for(int i = 0; i < movedCards.Count; i++)
      {
        int fromIndex = oldIndicies[i];
        int toIndex = (int)Arguments.Positions[i].Z;

        // log before move, movement can reset card state
        // log only if movement is across sectors or if sector is hidden (tipically in a hidden sector lookup)
        if(sourceSector != destinationSectors[i] || sourceSector.Data.CardsVisibility == SectorCardsVisibility.Hidden)
        {
          bool verbose = (Arguments.SourceMode == MoveCardsSourceMode.Specific && Arguments.CardKeys.Count == 1);
          CardLogger.LogMovement(Receiver, Invoker, movedCards[i], sourceSector, destinationSectors[i], fromIndex, toIndex, Arguments.Visibility, verbose);
        }

        if(sourceSector != destinationSectors[i])
        {
          sourceSector.Cards.Remove(movedCards[i]);

          bool acrossBattlefields = sourceSector.Data.Code == SystemSectors.BATTLEFIELD.ToString() && destinationSectors[i].Data.Code == SystemSectors.BATTLEFIELD.ToString();
          if(!acrossBattlefields)
            movedCards[i].Reset();

          if(acrossBattlefields || !movedCards[i].IsPawn)
          {
            movedCards[i].Position.Value = new CardPosition(Arguments.Positions[i].X, Arguments.Positions[i].Y, 0);
            if(Arguments.Visibility.HasValue)
              movedCards[i].Visibility.Value = Arguments.Visibility.Value;
            toIndex -= pawnIndicies.Count(pi => pi < toIndex); // pawn cannot move throught sectors, adjust subsequent card indexes to fill the gap
            destinationSectors[i].Cards.Insert(toIndex, movedCards[i]);
          }
        }
        else
        {
          sourceSector.Cards.Move(fromIndex, Math.Min(toIndex, sourceSector.Cards.Count - 1));
          movedCards[i].Position.Value = new CardPosition(Arguments.Positions[i].X, Arguments.Positions[i].Y, 0);
          if(Arguments.Visibility.HasValue)
            movedCards[i].Visibility.Value = Arguments.Visibility.Value;
        }
      }
    }

    public void Undo()
    {
      for(int i = 0; i < movedCards.Count; i++)
      {
        int fromIndex = (int)Arguments.Positions[i].Z;
        int toIndex = oldIndicies[i];
        if(destinationSectors[i] != sourceSector)
        {
          destinationSectors[i].Cards.Remove(movedCards[i]);

          bool acrossBattlefields = sourceSector.Data.Code == SystemSectors.BATTLEFIELD.ToString() && destinationSectors[i].Data.Code == SystemSectors.BATTLEFIELD.ToString();
          if(!acrossBattlefields)
            movedCards[i].Resume();

          movedCards[i].Position.Value = new CardPosition(oldPositions[i].X, oldPositions[i].Y, 0);
          if(Arguments.Visibility.HasValue)
            movedCards[i].Visibility.Value = oldVisibilityStates[i];
          sourceSector.Cards.Insert(toIndex, movedCards[i]);
        }
        else
        {
          sourceSector.Cards.Move(fromIndex, toIndex);
          movedCards[i].Position.Value = new CardPosition(oldPositions[i].X, oldPositions[i].Y, 0);
          if(Arguments.Visibility.HasValue)
            movedCards[i].Visibility.Value = oldVisibilityStates[i];
        }
      }
    }

    void Log(SectorModel sourceSector, MoveCardsSourceMode sourceMode, SectorModel destinationSector, int amount)
    {
      string playerName = Receiver.GetPlayerByKey(Invoker).Info.NickName;
      string commandName = string.Empty;
      switch(sourceMode)
      {
        case MoveCardsSourceMode.Specific:
          commandName = Receiver.GetCommandByKey(COMMANDCODE_MULTIPLE).Data.Name;
          commandName = commandName.Replace("#amount#", Arguments.CardKeys.Count.ToString());
          break;
        case MoveCardsSourceMode.Random:
          commandName = Receiver.GetCommandByKey(COMMANDCODE_RANDOM).Data.Name;
          commandName = commandName.Replace("#amount#", Arguments.Amount.ToString());
          break;
      }
      Receiver.Console.WriteLog(string.Concat(
        "[", playerName, "] ",
        commandName, " (", sourceSector.Data.Name, ">", destinationSector.Data.Name, ")"
        ));
    }
  }

  [Serializable]
  public struct MoveCardsArguments
  {
    [XmlAttribute]
    public MoveCardsSourceMode SourceMode { get; set; }
    [XmlAttribute]
    public string SourceSectorCode { get; set; }
    [XmlAttribute]
    public int Amount { get; set; }
    public List<string> CardKeys { get; set; }
    [XmlAttribute]
    public string DestinationSectorCode { get; set; }
    [XmlAttribute]
    public string DestinationPlayerKey { get; set; }
    public List<CardPosition> Positions { get; set; }
    public CardVisibility? Visibility { get; set; }
  }
}
