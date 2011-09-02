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
using System.Drawing;
using System.Collections.Generic;
using System.Text;

using PoL.Common;
using System.Linq;

namespace PoL.WinFormsView.Game
{
  class DragDropData
  {
    public List<CardView> CardViews;
    public Point CursorOffset;
    public CardView DraggedCardView;

    public DragDropData(List<CardView> cardViews, Point cursorOffset, CardView draggedCardView)
    {
      this.CardViews = cardViews;
      this.CursorOffset = cursorOffset;
      this.DraggedCardView = draggedCardView;
    }

    public DragDropData(List<CardView> cardViews)
      : this(cardViews, Point.Empty, null)
    {
    }

    public DragDropData(CardView cardView)
      : this(Enumerable.Repeat(cardView, 1).ToList())
    {
    }
  }
}
