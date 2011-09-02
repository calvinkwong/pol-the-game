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
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace PoL.WinFormsView.Utils
{
  public class CollapsablePanel : UserControl
  {
    private AnimationController mAnimationController = null;
    private Panel AnimationPanel = new Panel();
    private int mCollapsedSize;
    private int mPartialExpandedSize;
    private int mFullExpandedSize;
    internal CollapsedState mCollapsedState = CollapsedState.FullExpanded;
    internal bool mAnimating = false;
    private bool mAnimate = false;
    private AnimationDirection mAnimationDirection = AnimationDirection.Horizontal;
    internal Image AnimationImage = null;

    public event EventHandler FullExpandedSizeChanged;
    public event EventHandler PartialExpandedSizeChanged;
    public event EventHandler CollapsedSizeChanged;

    public event EventHandler CollapsedChanging;
    public event EventHandler CollapsedStartedChanging;
    public event EventHandler CollapsedChanged;

    public event EventHandler MouseEnterByHook;
    public event EventHandler MouseLeaveByHook;

    public CollapsablePanel()
    {
      mAnimationController = new AnimationController(this);
      mAnimationController.CollapsedChanged += new EventHandler(AnimationController_CollapsedChanged);
    }

    [CategoryAttribute("Collapse")]
    [DefaultValue(CollapsedState.FullExpanded)]
    public CollapsedState CollapsedState
    {
      get
      {
        return mCollapsedState;
      }
      set
      {
        // only change this if we are not currently animating
        if(!mAnimating && (value != mCollapsedState))
        {
          if(mAnimate)
          {
            mAnimationController.StartAnimation(value);
          }
          else
          {
            mAnimating = true;
            try
            {
              switch(value)
              {
                case CollapsedState.Collapsed:
                  if(mAnimationDirection == AnimationDirection.Horizontal)
                    this.Width = mCollapsedSize;
                  else
                    this.Height = mCollapsedSize;
                  break;
                case CollapsedState.PartialExpanded:
                  if(mAnimationDirection == AnimationDirection.Horizontal)
                    this.Width = mPartialExpandedSize;
                  else
                    this.Height = mPartialExpandedSize;
                  break;
                case CollapsedState.FullExpanded:
                  if(mAnimationDirection == AnimationDirection.Horizontal)
                    this.Width = FullExpandedSize;
                  else
                    this.Height = FullExpandedSize;
                  break;
              }
              mCollapsedState = value;
              OnCollapsedChanged();
            }
            finally
            {
              mAnimating = false;
            }
          }
        }
      }
    }

    /// <summary>
    /// Specifies which direction will be used for collapse / expand the Panel
    /// </summary>
    [CategoryAttribute("Collapse")]
    [DefaultValue(AnimationDirection.Horizontal)]
    public AnimationDirection AnimationDirection
    {
      get
      {
        return mAnimationDirection;
      }
      set
      {
        if(mAnimating)
          throw new ArgumentException("Can't change direction if Panel is animating!", "AnimationDirection");

        mAnimationDirection = value;
      }
    }

    /// <summary>
    /// Gets or sets the size of the Control when is fully expanded
    /// </summary>
    [CategoryAttribute("Collapse")]
    [DefaultValue(0)]
    public int FullExpandedSize
    {
      get { return mFullExpandedSize; }
      set
      {
        if(value < 0)
          throw new ArgumentOutOfRangeException("value", "FullExpandedSize must be at least 0");

        mFullExpandedSize = value;

        // refresh Control size if fully expanded
        if(mCollapsedState == CollapsedState.FullExpanded)
        {
          switch(mAnimationDirection)
          {
            case AnimationDirection.Vertical:
              this.Height = mFullExpandedSize;
              break;
            case AnimationDirection.Horizontal:
              this.Width = mFullExpandedSize;
              break;
          }
        }

        OnFullExpandedSizeChanged();
      }
    }

    /// <summary>
    /// Gets or sets the size of the Control when is partially expanded
    /// </summary>
    [CategoryAttribute("Collapse")]
    [DefaultValue(0)]
    public int PartialExpandedSize
    {
      get { return mPartialExpandedSize; }
      set
      {
        if(value < 0)
          throw new ArgumentOutOfRangeException("value", "PartialExpandedSize must be at least 0");

        mPartialExpandedSize = value;

        // refresh Control size if partially expanded
        if(mCollapsedState == CollapsedState.PartialExpanded)
        {
          switch(mAnimationDirection)
          {
            case AnimationDirection.Vertical:
              this.Height = mPartialExpandedSize;
              break;
            case AnimationDirection.Horizontal:
              this.Width = mPartialExpandedSize;
              break;
          }
        }

        OnPartialExpandedSizeChanged();
      }
    }

    /// <summary>
    /// Gets or sets the size of the Control when is Collapsed
    /// </summary>
    [CategoryAttribute("Collapse")]
    [DefaultValue(0)]
    public int CollapsedSize
    {
      get
      {
        return mCollapsedSize;
      }
      set
      {
        if(value < 0)
          throw new ArgumentOutOfRangeException("value", "CollapsedSize must be at least 0");

        mCollapsedSize = value;

        // refresh Control size if collapsed
        if(mCollapsedState == CollapsedState.Collapsed)
        {
          switch(mAnimationDirection)
          {
            case AnimationDirection.Vertical:
              this.Height = mCollapsedSize;
              break;
            case AnimationDirection.Horizontal:
              this.Width = mCollapsedSize;
              break;
          }
        }

        OnCollapsedSizeChanged();
      }
    }

    /// <summary>
    /// Gets or sets if use animation.
    /// When you set CollapsedSize / PartialExpandedSize / FullExpandedSize 
    /// properties for the first time, this property must be left to false, so
    /// that animation will not disturb control initialization.
    /// Normally you can activate the animation during Load() form event, when 
    /// you or Windows Forms Designer ( the InitializeComponent method ) have
    /// already set that properties. After that, you can change Animate property
    /// whenever you want.
    /// </summary>
    [Browsable(false)]
    public bool Animate
    {
      get
      {
        return mAnimate;
      }
      set
      {
        if(!mAnimating)
          mAnimate = value;
      }
    }

    [Browsable(false)]
    public bool Animating
    {
      get
      {
        return mAnimating;
      }
    }

    protected void OnCollapsedChanging()
    {
      if(this.CollapsedChanging != null)
        this.CollapsedChanging(this, new EventArgs());
    }

    protected void OnCollapsedStartedChanging()
    {
      if(this.CollapsedStartedChanging != null)
        this.CollapsedStartedChanging(this, new EventArgs());
    }

    protected void OnCollapsedChanged()
    {
      if(this.CollapsedChanged != null)
        this.CollapsedChanged(this, new EventArgs());
    }

    protected void OnFullExpandedSizeChanged()
    {
      if(FullExpandedSizeChanged != null)
        FullExpandedSizeChanged(this, new EventArgs());
    }

    protected void OnPartialExpandedSizeChanged()
    {
      if(PartialExpandedSizeChanged != null)
        PartialExpandedSizeChanged(this, new EventArgs());
    }

    protected void OnCollapsedSizeChanged()
    {
      if(CollapsedSizeChanged != null)
        CollapsedSizeChanged(this, new EventArgs());
    }

    private void AnimationController_CollapsedChanged(object sender, EventArgs e)
    {
      OnCollapsedChanged();
    }

    [DllImport("User32.dll", EntryPoint = "SendMessage")]
    private static extern int InternalSendMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Gets the image to be used in the animation while the 
    /// Expando is in its expanded state
    /// </summary>
    /// <returns>The Image to use during the fade animation</returns>
    internal Image GetExpandedImage()
    {
      return GetImageFromControl(this);
    }

    private Image GetImageFromControl(Control ctrl)
    {
      if(ctrl.Width < 1 || ctrl.Height < 1)
        return null;

      // create a new image to draw into
      Image image = new Bitmap(ctrl.Width, ctrl.Height);

      // get a graphics object we can draw into
      Graphics g = Graphics.FromImage(image);
      IntPtr hDC = g.GetHdc();

      // some flags to tell the control how to draw itself
      IntPtr flags = (IntPtr)(WMPrintFlags.PRF_CLIENT | WMPrintFlags.PRF_CHILDREN);

      // tell the control to draw itself into Image
      InternalSendMessage(this.Handle, (int)WMFlags.WM_PRINT, hDC, flags);

      // clean up resources
      g.ReleaseHdc(hDC);
      g.Dispose();

      // return the completed animation image
      return image;
    }

    /// <summary>
    /// Gets the image to be used in the animation while the 
    /// Panel is in its collapsed state
    /// </summary>
    /// <returns>The Image to use during the animation</returns>
    internal Image GetCollapsedImage(ImageSize Size)
    {
      // make sure the AnimationPanel is the same size as our image
      switch(AnimationDirection)
      {
        case AnimationDirection.Vertical:
          if(Size == ImageSize.Full)
            this.AnimationPanel.Size = new Size(this.Width, mFullExpandedSize);
          else
            this.AnimationPanel.Size = new Size(this.Width, mPartialExpandedSize);
          break;
        case AnimationDirection.Horizontal:
          if(Size == ImageSize.Full)
            this.AnimationPanel.Size = new Size(mFullExpandedSize, this.Height);
          else
            this.AnimationPanel.Size = new Size(mPartialExpandedSize, this.Height);
          break;
      }

      // move all our controls to the AnimationPanel, and then add
      // the AnimationPanel to us
      while(this.Controls.Count > 0)
      {
        Control control = this.Controls[0];

        this.AnimationPanel.Controls.Add(control);
      }
      //this.Controls.Add(this.AnimationPanel);

      Image image = GetImageFromControl(this.AnimationPanel);

      // get our controls back
      //this.Controls.Remove(this.AnimationPanel);

      while(this.AnimationPanel.Controls.Count > 0)
      {
        Control control = this.AnimationPanel.Controls[0];

        this.Controls.Add(control);
      }

      return image;
    }

    private void InitializeComponent()
    {
      // 
      // CollapsablePanel
      // 
      this.Name = "CollapsablePanel";

    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if(this.AnimationImage != null)
      {
        //int y = this.ClientRectangle.Bottom - this.AnimationImage.Height ;

        // draw the image
        e.Graphics.DrawImageUnscaled(this.AnimationImage, 0, 0);
      }
      else
        base.OnPaint(e);
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      if(!Patterns.Utils.IsMono)
      {
        if(!DesignMode)
        {
          hookProc = new HookProc(LowLevelMouseProc);
          hook = SetWindowsHookEx(WH_MOUSE_LL, hookProc, GetModuleHandle(null), 0);
        }
      }
    }

    protected override void OnHandleDestroyed(EventArgs e)
    {
      if(!Patterns.Utils.IsMono)
      {
        UnhookWindowsHookEx(hook);
      }
      base.OnHandleDestroyed(e);
    }

    // create a mouse over eventstatic 
    int WH_MOUSE_LL = 14;
    [System.Runtime.InteropServices.DllImport("kernel32.dll")]
    static extern IntPtr GetModuleHandle(string moduleName);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern int UnhookWindowsHookEx(IntPtr hhook);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, uint wParam, IntPtr lParam);
    delegate IntPtr HookProc(int nCode, uint wParam, IntPtr lParam);

    private HookProc hookProc;
    private IntPtr hook;
    private bool mMouseInside = false;

    IntPtr LowLevelMouseProc(int nCode, uint wParam, IntPtr lParam)
    {
      // get the current mouse position
      Point p = Cursor.Position;

      // convert to client rectangle to screen position
      Rectangle r = RectangleToScreen(ClientRectangle);

      // check to see if mouse is within control bounds
      bool inside = (p.Y > r.Top && p.Y < r.Bottom && p.X > r.Left && p.X < r.Right);
      if(!mMouseInside && inside)
      {
        mMouseInside = true;
        OnMouseEnterByHook();
      }
      if(mMouseInside && !inside)
      {
        mMouseInside = false;
        OnMouseLeaveByHook();
      }

      // Finished with this
      return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
    }

    protected void OnMouseEnterByHook()
    {
      if(MouseEnterByHook != null)
        MouseEnterByHook(this, new EventArgs());
    }

    protected void OnMouseLeaveByHook()
    {
      if(MouseLeaveByHook != null)
        MouseLeaveByHook(this, new EventArgs());
    }
  }

  public enum AnimationDirection
  {
    Vertical,
    Horizontal
  }

  public enum CollapsedState
  {
    Collapsed,
    PartialExpanded,
    FullExpanded
  }

  internal enum ImageSize
  {
    Full,
    Partial
  }

  /// <summary>
  /// The WindowMessageFlags enemeration contains Windows messages that the 
  /// XPExplorerBar may be interested in listening for
  /// </summary>
  internal enum WMFlags
  {
    /// <summary>
    /// The WM_PRINT message is sent to a window to request that it draw 
    /// itself in the specified device context, most commonly in a printer 
    /// device context
    /// </summary>
    WM_PRINT = 791,

    /// <summary>
    /// The WM_PRINTCLIENT message is sent to a window to request that it draw 
    /// its client area in the specified device context, most commonly in a 
    /// printer device context
    /// </summary>
    WM_PRINTCLIENT = 792,
  }

  /// <summary>
  /// The WmPrintFlags enemeration contains flags that may be sent 
  /// when a WM_PRINT or WM_PRINTCLIENT message is recieved
  /// </summary>
  internal enum WMPrintFlags
  {
    /// <summary>
    /// Draws the window only if it is visible
    /// </summary>
    PRF_CHECKVISIBLE = 1,

    /// <summary>
    /// Draws the nonclient area of the window
    /// </summary>
    PRF_NONCLIENT = 2,

    /// <summary>
    /// Draws the client area of the window
    /// </summary>
    PRF_CLIENT = 4,

    /// <summary>
    /// Erases the background before drawing the window
    /// </summary>
    PRF_ERASEBKGND = 8,

    /// <summary>
    /// Draws all visible children windows
    /// </summary>
    PRF_CHILDREN = 16,

    /// <summary>
    /// Draws all owned windows
    /// </summary>
    PRF_OWNED = 32
  }
}
