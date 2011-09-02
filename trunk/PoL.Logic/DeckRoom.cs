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
using PoL.Logic.Views;
using PoL.Models;
using PoL.Common;
using PoL.Services;
using PoL.Services.DataEntities;
using PoL.Logic.Controllers;
using PoL.Models.DeckRoom;
using Patterns.MVC;
using PoL.Models.DeckEditor;

namespace PoL.Logic
{
  public class DeckRoom
  {
    LogicHandler logicStarter;
    DeckRoomController deckRoomController;
    IDeckRoomView deckRoomView;
    DeckRoomModel deckRoom;

    internal DeckRoom(LogicHandler logicStarter)
    {
      this.logicStarter = logicStarter;

      deckRoom = new DeckRoomModel(logicStarter.ServicesProvider, logicStarter.GameItem);
      deckRoomView = logicStarter.ViewFactory.CreateDeckRoomView();
      deckRoomController = new DeckRoomController(deckRoom, deckRoomView);
      deckRoomController.DeckEditorRequest += new Action<DeckEditorRequestType>(DeckRoomController_DeckEditorRequest);
    }

    void DeckRoomController_DeckEditorRequest(DeckEditorRequestType requestType)
    {
      var deckEditor = new DeckEditorModel(logicStarter.ServicesProvider, 
        logicStarter.GameItem, requestType == DeckEditorRequestType.New ? null : deckRoom.SelectedDeck.Value);
      var deckEditorView = logicStarter.ViewFactory.CreateDeckEditorView();
      var deckEditorController = new DeckEditorController(deckEditor, deckEditorView, logicStarter.ServicesProvider);
      deckEditorView.ShowModal();
    }

    public DeckItem Run()
    {
      DeckItem deck = null;
      if(deckRoomView.ShowModal() == ViewResult.Ok)
        deck = deckRoom.SelectedDeck.Value;
      return deck;
    }
  }
}
