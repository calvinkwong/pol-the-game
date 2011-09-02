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

namespace PoL.WinFormsView.Utils
{
	[System.ComponentModel.Browsable(false)]
	[System.ComponentModel.DesignTimeVisible(false)]
	public class DragableContainer : System.Windows.Forms.Panel
	{
		// Begin: Singleton Pattern
		private static DragableContainer _instance;
		public static DragableContainer Instance
		{
			get
			{
				if (_instance == null)
					_instance = new DragableContainer();

				return (_instance);
			}
		}

		private DragableContainer()
		{
			Initialize();
		}
		// End: Singleton Pattern

		protected enum DragModes
		{
			None,
			TopLeft,
			TopRight,
			Top,
			BottomLeft,
			BottomRight,
			Bottom,
			Left,
			Right
		}

		private System.Windows.Forms.Control _myControl;
		protected System.Windows.Forms.Control MyControl
		{
			get
			{
				return (_myControl);
			}
			set
			{
				_myControl = value;

				if (value != null)
				{
					_myControl.Resize += new System.EventHandler(MyControl_Resize);
					_myControl.MouseEnter += new System.EventHandler(MyControl_MouseEnter);
				}
			}
		}

		private System.Windows.Forms.AnchorStyles _myControlAnchorStyles;
		protected System.Windows.Forms.AnchorStyles MyControlAnchorStyles
		{
			get
			{
				return (_myControlAnchorStyles);
			}
			set
			{
				_myControlAnchorStyles = value;
			}
		}

		protected virtual int Gap
		{
			get
			{
				return (1);
			}
		}

		private bool _isMouseDown;
		protected bool IsMouseDown
		{
			get
			{
				return (_isMouseDown);
			}
			set
			{
				_isMouseDown = value;
			}
		}

		private int _edgeSize;
		[System.ComponentModel.DefaultValue(4)]
		public virtual int EdgeSize
		{
			get
			{
				return (_edgeSize);
			}
			set
			{
				_edgeSize = value;
			}
		}

		private DragModes _dragMode;
		protected DragModes DragMode
		{
			get
			{
				return (_dragMode);
			}
			set
			{
				_dragMode = value;
			}
		}

		private System.Drawing.Pen _squarePen;
		protected System.Drawing.Pen SquarePen
		{
			get
			{
				if (_squarePen == null)
					_squarePen = new System.Drawing.Pen(System.Drawing.Color.Black, 1);

				return (_squarePen);
			}
		}

		private System.Drawing.Brush _squareFillBrush;
		protected System.Drawing.Brush SquareFillBrush
		{
			get
			{
				if (_squareFillBrush == null)
					_squareFillBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);

				return (_squareFillBrush);
			}
		}

		protected virtual void RefreshControl()
		{
			Refresh();
			Invalidate();
		}

		public virtual void SetControl(System.Windows.Forms.Control control)
		{
			if (MyControl == control)
				return;

			System.Windows.Forms.Control ctlParent = null;

			if (MyControl != null)
			{
				ctlParent = Parent;

				MyControl.Top = Top + EdgeSize + Gap;
				MyControl.Left = Left + EdgeSize + Gap;
				MyControl.Width = Width - EdgeSize * 2 - Gap - 1;
				MyControl.Height = Height  - EdgeSize * 2 - Gap - 1;

				Controls.Remove(MyControl);
				ctlParent.Controls.Add(MyControl);

				// It's too important to write this code here!
				// specially if the control is for [Label].
				MyControl.Anchor = MyControlAnchorStyles;
			}

			if (control == null)
			{
				if (ctlParent != null)
				{
					MyControl = null;
					ctlParent.Controls.Remove(this);
				}
			}
			else
			{
				MyControl = control;
				MyControlAnchorStyles = MyControl.Anchor;
				MyControl.Anchor =
					System.Windows.Forms.AnchorStyles.Top |
					System.Windows.Forms.AnchorStyles.Left |
					System.Windows.Forms.AnchorStyles.Right |
					System.Windows.Forms.AnchorStyles.Bottom;

				Top = control.Top - EdgeSize - Gap;
				Left = control.Left - EdgeSize - Gap;
				Width = MyControl.Width + EdgeSize * 2 + Gap + 1;
				Height = MyControl.Height + EdgeSize * 2 + Gap + 1;

				ctlParent = control.Parent;

				ctlParent.Controls.Remove(MyControl);
				MyControl.Top = EdgeSize + Gap;
				MyControl.Left = EdgeSize + Gap;
				Controls.Add(MyControl);
				ctlParent.Controls.Add(this);
			}

			Initialize();
		}

		protected virtual void Initialize()
		{
			EdgeSize = 4;
			IsMouseDown = false;
			DragMode = DragModes.None;

			RefreshControl();
		}

		protected void MyControl_Resize(object sender, System.EventArgs e)
		{
			if (Width != MyControl.Width + EdgeSize * 2 + Gap + 1)
				Width = MyControl.Width + EdgeSize * 2 + Gap + 1;

			if (Height != MyControl.Height + EdgeSize * 2 + Gap + 1)
				Height = MyControl.Height + EdgeSize * 2 + Gap + 1;
		}

		protected virtual void MyControl_MouseEnter(object sender, System.EventArgs e)
		{
			// Node
			DragMode = DragModes.None;
			Cursor = System.Windows.Forms.Cursors.Default;

			RefreshControl();
		}

		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
		{
			base.OnMouseDown(e);

			// If we are in design mode (not in runtime mode) do nothing.
			if (DesignMode)
				return;

			if (e.Button == System.Windows.Forms.MouseButtons.Left)
				IsMouseDown = true;
		}

		protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
		{
			base.OnMouseMove(e);

			// If we are in design mode (not in runtime mode) do nothing.
			if (DesignMode)
				return;

			if ((IsMouseDown) && (DragMode != DragModes.None))
			{
				SuspendLayout();

				switch (DragMode)
				{
					case DragModes.TopLeft:
					{
						//SetBounds(Left + e.X, Top + e.Y, Width, Height); // Original
						SetBounds(Left + e.X - EdgeSize, Top + e.Y - EdgeSize, Width, Height);
						break;
					}

					case DragModes.TopRight:
					{
						SetBounds(Left, Top + e.Y, e.X + EdgeSize, Height - e.Y);
						break;
					}

					case DragModes.Top:
					{
						SetBounds(Left, Top + e.Y, Width, Height - e.Y);
						break;
					}

					case DragModes.BottomLeft:
					{
						SetBounds(Left + e.X, Top, Width - e.X, e.Y + EdgeSize);
						break;
					}

					case DragModes.BottomRight:
					{
						SetBounds(Left, Top, e.X + EdgeSize, e.Y + EdgeSize);
						break;
					}

					case DragModes.Bottom:
					{
						// SetBounds(Left, Top, Width, e.Y); // Original
						SetBounds(Left, Top, Width, e.Y + EdgeSize);
						break;
					}

					case DragModes.Left:
					{
						SetBounds(Left + e.X, Top, Width - e.X, Height);
						break;
					}

					case DragModes.Right:
					{
						//SetBounds(Left, Top, e.X, Height); // Original
						SetBounds(Left, Top, e.X + EdgeSize, Height);
						break;
					}
				}

				ResumeLayout();
			}
			else
			{
				// Top Left
				if ((e.Y <= EdgeSize * 2) && (e.X <= EdgeSize * 2))
				{
					DragMode = DragModes.TopLeft;
					Cursor = System.Windows.Forms.Cursors.SizeAll;
					RefreshControl();
					return;
				}

				// Top Right
				if ((e.Y <= EdgeSize) && (e.X >= Width - EdgeSize))
				{
					DragMode = DragModes.TopRight;
					Cursor = System.Windows.Forms.Cursors.SizeNESW;
					RefreshControl();
					return;
				}

				// Top
				if (e.Y <= EdgeSize)
				{
					DragMode = DragModes.Top;
					Cursor = System.Windows.Forms.Cursors.SizeNS;
					RefreshControl();
					return;
				}

				// Bottom Left
				if ((e.Y >= Height - EdgeSize) && (e.X <= EdgeSize))
				{
					DragMode = DragModes.BottomLeft;
					Cursor = System.Windows.Forms.Cursors.SizeNESW;
					RefreshControl();
					return;
				}

				// Bottom Right
				if ((e.Y >= Height - EdgeSize) && (e.X >= Width - EdgeSize))
				{
					DragMode = DragModes.BottomRight;
					Cursor = System.Windows.Forms.Cursors.SizeNWSE;
					RefreshControl();
					return;
				}

				// Bottom
				if (e.Y >= Height - EdgeSize)
				{
					DragMode = DragModes.Bottom;
					Cursor = System.Windows.Forms.Cursors.SizeNS;
					RefreshControl();
					return;
				}

				// Left
				if (e.X <= EdgeSize)
				{
					DragMode = DragModes.Left;
					Cursor = System.Windows.Forms.Cursors.SizeWE;
					RefreshControl();
					return;
				}

				// Right
				if (e.X >= Width - EdgeSize)
				{
					DragMode = DragModes.Right;
					Cursor = System.Windows.Forms.Cursors.SizeWE;
					RefreshControl();
					return;
				}

				// Node
				DragMode = DragModes.None;
				Cursor = System.Windows.Forms.Cursors.Default;
			}

			RefreshControl();
		}

		protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
		{
			base.OnMouseUp(e);

			// If we are in design mode (not in runtime mode) do nothing.
			if (DesignMode)
				return;

			IsMouseDown = false;
			DragMode = DragModes.None;

			RefreshControl();
		}

		protected override void OnMouseLeave(System.EventArgs e)
		{
			base.OnMouseLeave(e);

			// If we are in design mode (not in runtime mode) do nothing.
			if (DesignMode)
				return;

			IsMouseDown = false;
			DragMode = DragModes.None;

			RefreshControl();
		}

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			base.OnPaint(e);

			// If we are in design mode (not in runtime mode) do nothing.
			if (DesignMode)
				return;

			int intTop;
			int intLeft;

			int intSquareWidth = EdgeSize;
			int intSquareHeight = EdgeSize;

			int intSquareFillWidth = EdgeSize - 1;
			int intSquareFillHeight = EdgeSize - 1;

			System.Drawing.Graphics oGraphics = e.Graphics;

			// Draw Square in [Top Left]
			intTop = 0;
			intLeft = 0;
			oGraphics.DrawRectangle(SquarePen, intLeft, intTop, intSquareWidth, intSquareHeight);
			oGraphics.FillRectangle(SquareFillBrush, intLeft + 1, intTop + 1, intSquareFillWidth, intSquareFillHeight);

			// Draw Square in [Top Middle]
			intTop = 0;
			intLeft = (Width - EdgeSize) / 2 + (EdgeSize / 2);
			oGraphics.DrawRectangle(SquarePen, intLeft, intTop, intSquareWidth, intSquareHeight);
			oGraphics.FillRectangle(SquareFillBrush, intLeft + 1, intTop + 1, intSquareFillWidth, intSquareFillHeight);

			// Draw Square in [Top Right]
			intTop = 0;
			intLeft = Width - EdgeSize - 1;
			oGraphics.DrawRectangle(SquarePen, intLeft, intTop, intSquareWidth, intSquareHeight);
			oGraphics.FillRectangle(SquareFillBrush, intLeft + 1, intTop + 1, intSquareFillWidth, intSquareFillHeight);

			// Draw Square in [Middle Left]
			intTop = (Height - EdgeSize) / 2;
			intLeft = 0;
			oGraphics.DrawRectangle(SquarePen, intLeft, intTop, intSquareWidth, intSquareHeight);
			oGraphics.FillRectangle(SquareFillBrush, intLeft + 1, intTop + 1, intSquareFillWidth, intSquareFillHeight);

			// Draw Square in [Middle Right]
			intTop = (Height - EdgeSize) / 2;
			intLeft = Width - EdgeSize - 1;
			oGraphics.DrawRectangle(SquarePen, intLeft, intTop, intSquareWidth, intSquareHeight);
			oGraphics.FillRectangle(SquareFillBrush, intLeft + 1, intTop + 1, intSquareFillWidth, intSquareFillHeight);

			// Draw Square in [Bottom Left]
			intTop = Height - EdgeSize - 1;
			intLeft = 0;
			oGraphics.DrawRectangle(SquarePen, intLeft, intTop, intSquareWidth, intSquareHeight);
			oGraphics.FillRectangle(SquareFillBrush, intLeft + 1, intTop + 1, intSquareFillWidth, intSquareFillHeight);

			// Draw Square in [Bottom Middle]
			intTop = Height - EdgeSize - 1;
			intLeft = (Width - EdgeSize) / 2 + (EdgeSize / 2);
			oGraphics.DrawRectangle(SquarePen, intLeft, intTop, intSquareWidth, intSquareHeight);
			oGraphics.FillRectangle(SquareFillBrush, intLeft + 1, intTop + 1, intSquareFillWidth, intSquareFillHeight);

			// Draw Square in [Bottom Right]
			intTop = Height - EdgeSize - 1;
			intLeft = Width - EdgeSize - 1;
			oGraphics.DrawRectangle(SquarePen, intLeft, intTop, intSquareWidth, intSquareHeight);
			oGraphics.FillRectangle(SquareFillBrush, intLeft + 1, intTop + 1, intSquareFillWidth, intSquareFillHeight);

			if (Width != MyControl.Width + EdgeSize * 2 + Gap + 1)
				Width = MyControl.Width + EdgeSize * 2 + Gap + 1;

			if (Height != MyControl.Height + EdgeSize * 2 + Gap + 1)
				Height = MyControl.Height + EdgeSize * 2 + Gap + 1;
		}
	}
}
