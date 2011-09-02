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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace PoL.WinFormsView.Utils
{
	public class CursorCreator
	{
		[DllImport("user32.dll")]
		private static extern IntPtr CreateIconIndirect(ref IconInfo icon);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);

    public static Cursor CreateCursor(Bitmap bmp, Point hotSpot)
    {
      return CreateCursor(bmp, hotSpot.X, hotSpot.Y);
    }

		public static Cursor CreateCursor(Bitmap bmp, int xHotSpot, int yHotSpot)
		{
      IconInfo tmp = new IconInfo();
      GetIconInfo(bmp.GetHicon(), ref tmp);
      tmp.xHotspot = xHotSpot;
      tmp.yHotspot = yHotSpot;
      tmp.fIcon = false;
      return new Cursor(CreateIconIndirect(ref tmp));
		}

    public static Bitmap CreateOpaqueBitmap(Image imgPic, float imgOpac)
    {
      Bitmap bmpPic = new Bitmap(imgPic.Width, imgPic.Height);
			using(Graphics gfxPic = Graphics.FromImage(bmpPic))
			{
				ColorMatrix cmxPic = new ColorMatrix();
				cmxPic.Matrix33 = imgOpac;

				ImageAttributes iaPic = new ImageAttributes();
				iaPic.SetColorMatrix(cmxPic, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
				gfxPic.DrawImage(imgPic, new Rectangle(0, 0, bmpPic.Width, bmpPic.Height), 0, 0, imgPic.Width, imgPic.Height, GraphicsUnit.Pixel, iaPic);
			}
 
      return bmpPic;
    }
	}

  public struct IconInfo
  {
    public bool fIcon;
    public int xHotspot;
    public int yHotspot;
    public IntPtr hbmMask;
    public IntPtr hbmColor;
  }
}
