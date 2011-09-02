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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PoL.Services
{
	public partial class FullCardLayoutPawn : UserControl
	{
    public FullCardLayoutPawn()
		{
			InitializeComponent();
		}

    //public Rectangle CardRect
    //{
    //  get { return this.Bounds; }
    //}

		public Rectangle NameRect
		{
			get { return mName.Bounds; }
		}

		public Rectangle ImageRect
		{
			get { return mImage.Bounds; }
		}

		public Rectangle TypeRect
		{
			get { return mType.Bounds; }
		}

		public Rectangle SymbolRect
		{
			get { return mSymbol.Bounds; }
		}

		public Rectangle TextRect
		{
			get { return mText.Bounds; }
		}

		public Rectangle ArtistRect
		{
			get { return mArtist.Bounds; }
		}

		public Rectangle CharacteristicsRect
		{
			get { return mCharacteristics.Bounds; }
		}
	}
}
