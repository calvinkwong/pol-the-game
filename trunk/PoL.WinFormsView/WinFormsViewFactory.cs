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

using PoL.Logic.Views;
using PoL.Logic;
using PoL.WinFormsView.Game;
using PoL.WinFormsView.DeckEditor;
using PoL.WinFormsView.DeckRoom;
using PoL.WinFormsView.Options;
using PoL.WinFormsView.GameStarters;
using PoL.Common;
using Patterns.MVC;
using System.Threading;
using PoL.WinFormsView.SideboardingEditor;
using PoL.WinFormsView.GameRestarters;

namespace PoL.WinFormsView
{
  public class WinFormsViewFactory : IViewFactory
  {
    #region IViewFactory Members

    public IGameView CreateGameView()
    {
      return new GameView();
    }

    public IDeckRoomView CreateDeckRoomView()
    {
      return new DeckRoomView();
    }

    public IOptionsView CreateOptionsView()
    {
      return new OptionsView();
    }

    public IDeckEditorView CreateDeckEditorView()
    {
      //return new DeckEditorViewCreator().Create();
      return new DeckEditorView();
    }

    public ISideboardingEditorView CreateSideboardingEditorView()
    {
      return new SideboardingEditorViewCreator().Create();
    }

    public IServerStarterView CreateServerStarterView()
    {
      return new ServerStarterView();
    }

    public IClientStarterView CreateClientStarterView()
    {
      return new ClientStarterView();
    }

    public IServerStartNewGameView CreateServerStartNewGameView()
    {
      return new ServerStartNewGameView();
    }

    public IServerStartSavedGameView CreateServerStartSavedGameView()
    {
      return new ServerStartSavedGameView();
    }

    public IClientInitializationView CreateClientInitializationView(GameStartMode startMode)
    {
      return new ClientInitializationView(startMode);
    }

    public IServerConnectionView CreateServerConnectionView()
    {
      return new ServerConnectionView();
    }

    public IServerRestarterView CreateServerRestartGameView()
    {
      return new ServerRestarterView();
    }

    public IClientRestarterView CreateClientRestartGameView()
    {
      return new ClientRestarterView();
    }

    #endregion
  }

  class DeckEditorViewCreator
  {
    object syncObject = new object();
    IDeckEditorView view;

    public IDeckEditorView Create()
    {
      Thread t = new Thread(new ThreadStart(InternalCreate));
      t.SetApartmentState(ApartmentState.STA);
      t.Start();
      t.Join();
      return view;
    }

    void InternalCreate()
    {
      lock(syncObject)
        view = new DeckEditorView();
    }
  }


  class SideboardingEditorViewCreator
  {
    object syncObject = new object();
    ISideboardingEditorView view;

    public ISideboardingEditorView Create()
    {
      Thread t = new Thread(new ThreadStart(InternalCreate));
      t.SetApartmentState(ApartmentState.STA);
      t.Start();
      t.Join();
      return view;
    }

    void InternalCreate()
    {
      lock(syncObject)
        view = new SideboardingEditorView();
    }
  }
}
