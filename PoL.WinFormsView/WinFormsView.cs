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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Patterns.MVC;
using RibbonStyle;

namespace PoL.WinFormsView
{
  public partial class WinFormsView : Form, IView
  {
    public WinFormsView()
    {
      InitializeComponent();
    }

    #region IView Members

    public bool ClosureForced { get; set; }

    public void ShowInfoMessage(string message)
    {
      if(InvokeRequired)
        Invoke(new Action<string>(ShowInfoMessage), message);
      else
        Program.InfoBox(this, message);
    }

    public ViewResult ShowQuestionMessage(string message)
    {
      ViewResult res = ViewResult.Ok;
      if(InvokeRequired)
        res = (ViewResult)Invoke(new Action<string>(ShowInfoMessage), message);
      else
        res = MapResult(Program.QuestionBox(this, message));
      return res;
    }

    public void ShowExceptionMessage(Exception ex)
    {
      if(InvokeRequired)
        Invoke(new Action<Exception>(ShowExceptionMessage), ex);
      else
        Program.ExceptionBox(this, ex);
    }

    public ViewResult ShowModal()
    {
      return MapResult(ShowDialog());
    }

    public ViewResult ShowModal(IView ownerView)
    {
      if(InvokeRequired)
        return (ViewResult)Invoke(new Func<IView, ViewResult>(ShowModal), ownerView);
      else
      {
        var form = (Form)ownerView;
        if(form.InvokeRequired)
          return (ViewResult)form.Invoke(new Func<IView, ViewResult>(ShowModal), ownerView);
        else
          return MapResult(ShowDialog((Form)ownerView));
      }
    }

    public ViewResult ViewResult
    {
      get { return MapResult(DialogResult); }
      set { DialogResult = MapResult(value); }
    }

    ViewResult MapResult(DialogResult dialogResult)
    {
      switch(dialogResult)
      {
        case DialogResult.OK:
          return ViewResult.Ok;
        case DialogResult.Cancel:
          return ViewResult.Cancel;
        case DialogResult.No:
          return ViewResult.No;
        case DialogResult.Yes:
          return ViewResult.Yes;
        default:
          return ViewResult.Ok;
      }
    }

    DialogResult MapResult(ViewResult viewResult)
    {
      switch(viewResult)
      {
        case ViewResult.Ok:
          return DialogResult.OK;
        case ViewResult.Cancel:
          return DialogResult.Cancel;
        case ViewResult.No:
          return DialogResult.No;
        case ViewResult.Yes:
          return DialogResult.Yes;
        default:
          return DialogResult.OK;
      }
    }

    public new void Close()
    {
      try
      {
        if(this.InvokeRequired)
          this.Invoke(new Action(this.Close));
        else
          base.Close();
      }
      catch(ObjectDisposedException)
      { }
    }

    #endregion 
  }
}
