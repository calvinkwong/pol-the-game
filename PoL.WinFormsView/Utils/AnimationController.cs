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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoL.WinFormsView.Utils
{
  /// <summary>
  /// This class is used to animate the resizing of a CollapsablePanel
  /// </summary>
  internal class AnimationController : IDisposable
  {
    private static int mNumAnimationFrames = 23;
    private static int mAnimationFrameInterval = 10;
    private CollapsablePanel pnl;
    private int mAnimationStepNum;
    private int mSlideStartSize;
    private int mSlideEndSize;
    private CollapsedState mDestinationState;
    private Timer mAnimationTimer;
    public event EventHandler CollapsedChanged;

    public AnimationController(CollapsablePanel Ctrl)
    {
      pnl = Ctrl;

      mAnimationTimer = new System.Windows.Forms.Timer();
      mAnimationTimer.Tick += new EventHandler(AnimationTimer_Tick);
      mAnimationTimer.Interval = mAnimationFrameInterval;
    }

    public void Dispose()
    {
      if(mAnimationTimer != null)
      {
        mAnimationTimer.Stop();
        mAnimationTimer.Dispose();
        mAnimationTimer = null;
      }

      pnl = null;
    }

    internal void StartAnimation(CollapsedState DestinationState)
    {
      if(pnl.Animating)
        return;

      mAnimationStepNum = 0;

      InitAnimationParameteres(DestinationState);

      mAnimationTimer.Start();
    }

    protected void OnCollapsedChanged()
    {
      if(this.CollapsedChanged != null)
        this.CollapsedChanged(this, new EventArgs());
    }

    private void PerformAnimation()
    {
      if(mAnimationStepNum < mNumAnimationFrames)
      {
        mAnimationStepNum++;

        UpdateAnimation();
      }
      else
      {
        mAnimationTimer.Stop();
        mAnimationTimer.Dispose();

        StopAnimation();
      }
    }

    private void InitAnimationParameteres(CollapsedState destinationState)
    {
      pnl.mAnimating = true;
      pnl.FullExpandedSizeChanged += new EventHandler(pnl_FullExpandedSizeChanged);
      pnl.PartialExpandedSizeChanged += new EventHandler(pnl_PartialExpandedSizeChanged);
      pnl.CollapsedSizeChanged += new EventHandler(pnl_CollapsedSizeChanged);

      pnl.SuspendLayout();

      mDestinationState = destinationState;

      // Set the image that the controll will paint as its background during animation
      // and set initial and final sizes of the animation
      switch(pnl.CollapsedState)
      {
        case CollapsedState.Collapsed:
          if(destinationState == CollapsedState.PartialExpanded)
          {
            // From collapsed to partial
            pnl.AnimationImage = pnl.GetCollapsedImage(ImageSize.Partial);
            mSlideStartSize = pnl.CollapsedSize;
            mSlideEndSize = pnl.PartialExpandedSize;
          }
          else
          {
            // From collapsed to full
            pnl.AnimationImage = pnl.GetCollapsedImage(ImageSize.Full);
            mSlideStartSize = pnl.CollapsedSize;
            mSlideEndSize = pnl.FullExpandedSize;
          }
          break;
        case CollapsedState.PartialExpanded:
          if(destinationState == CollapsedState.FullExpanded)
          {
            // From partial to full
            pnl.AnimationImage = pnl.GetCollapsedImage(ImageSize.Full);
            mSlideStartSize = pnl.PartialExpandedSize;
            mSlideEndSize = pnl.FullExpandedSize;
          }
          else
          {
            // From partial to collapsed
            pnl.AnimationImage = pnl.GetExpandedImage();
            mSlideStartSize = pnl.PartialExpandedSize;
            mSlideEndSize = pnl.CollapsedSize;
          }
          break;
        case CollapsedState.FullExpanded:
          pnl.AnimationImage = pnl.GetExpandedImage();
          if(destinationState == CollapsedState.PartialExpanded)
          {
            // From full to partial
            mSlideStartSize = pnl.FullExpandedSize;
            mSlideEndSize = pnl.PartialExpandedSize;
          }
          else
          {
            // From full to collapsed
            mSlideStartSize = pnl.FullExpandedSize;
            mSlideEndSize = pnl.CollapsedSize;
          }
          break;
      }

    }

    void pnl_CollapsedSizeChanged(object sender, EventArgs e)
    {
      if(pnl.Animating && mDestinationState == CollapsedState.Collapsed)
        mSlideEndSize = pnl.CollapsedSize;
    }

    void pnl_PartialExpandedSizeChanged(object sender, EventArgs e)
    {
      if(pnl.Animating && mDestinationState == CollapsedState.PartialExpanded)
        mSlideEndSize = pnl.PartialExpandedSize;
    }

    void pnl_FullExpandedSizeChanged(object sender, EventArgs e)
    {
      if(pnl.Animating && mDestinationState == CollapsedState.FullExpanded)
        mSlideEndSize = pnl.FullExpandedSize;
    }

    private void UpdateAnimation()
    {
      double step = (1.0 - Math.Cos(Math.PI * (double)mAnimationStepNum / (double)mNumAnimationFrames)) / 2.0;

      // set the size of the group
      int val = mSlideStartSize + (int)((mSlideEndSize - mSlideStartSize) * step);
      switch(pnl.AnimationDirection)
      {
        case AnimationDirection.Vertical:
          pnl.Height = val;
          break;
        case AnimationDirection.Horizontal:
          pnl.Width = val;
          break;
      }
    }

    private void StopAnimation()
    {
      pnl.mCollapsedState = mDestinationState;

      // make sure we're the right size
      switch(pnl.AnimationDirection)
      {
        case AnimationDirection.Vertical:
          pnl.Height = mSlideEndSize;
          break;
        case AnimationDirection.Horizontal:
          pnl.Width = mSlideEndSize;
          break;
      }

      if(pnl.AnimationImage != null)
      {
        pnl.AnimationImage.Dispose();
        pnl.AnimationImage = null;
      }

      pnl.ResumeLayout();

      pnl.mAnimating = false;

      pnl.FullExpandedSizeChanged -= new EventHandler(pnl_FullExpandedSizeChanged);
      pnl.PartialExpandedSizeChanged -= new EventHandler(pnl_PartialExpandedSizeChanged);
      pnl.CollapsedSizeChanged -= new EventHandler(pnl_CollapsedSizeChanged);

      OnCollapsedChanged();
    }

    /// <param name="e">An EventArgs that contains the event data</param>
    private void AnimationTimer_Tick(object sender, EventArgs e)
    {
      PerformAnimation();
    }
  }
}
