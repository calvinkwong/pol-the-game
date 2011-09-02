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
using System.Linq;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

using PoL.Common;
using PoL.Logic.Views;
using PoL.WinFormsView.GameStarters;
using PoL.WinFormsView.Properties;
using PoL.Logic.Commands.Game;
using PoL.WinFormsView.GameRestarters;

namespace PoL.WinFormsView.Game
{
	public partial class ConsoleView : UserControl, ILocalizable
	{
    public event LinkClickedEventHandler LinkClicked;

    public ConsoleView()
		{
			InitializeComponent();

      txtChat.KeyDown += delegate(object sender, KeyEventArgs e)
      {
        switch(e.KeyCode)
        {
          case Keys.Enter:
            if(txtChat.Text.Length > 0)
              Chat();
            break;
        }
      };

      messageList.LinkClicked += new LinkClickedEventHandler(messageList_LinkClicked);

      btnMessage1.Click += new EventHandler(btnMessage_Click);
      btnMessage2.Click += new EventHandler(btnMessage_Click);
		}

    void btnMessage_Click(object sender, EventArgs e)
    {
      try
      {
        txtChat.Text = ((Control)sender).Text;
        Chat();
      }
      catch(Exception ex)
      {
        if(this.FindForm() is GameView)
          ((GameView)this.FindForm()).HandleException(ex);
        else
          throw;
      }
    }

    [Browsable(true)]
    [DefaultValue(true)]
    public bool DefaultMessagesVisible
    {
      get { return !pnlMain.Panel2Collapsed; }
      set { pnlMain.Panel2Collapsed = !value; }
    }

    public void Localize()
    {
      btnMessage1.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CHAT", "CHANGE_TURN");
      btnMessage2.Text = Program.LogicHandler.ServicesProvider.SystemStringsService.GetString("CHAT", "WAIT");
    }

    void messageList_LinkClicked(object sender, LinkClickedEventArgs e)
    {
      OnLinkClicked(e);
    }

    void Chat()
    {
      try
      {
        // TODO da sistemare con la gestione delle interfacce
        if(this.FindForm() is GameView)
          ((GameView)this.FindForm()).Controller.Chat();
        else if(this.FindForm() is ServerStarterView)
          ((ServerStarterView)this.FindForm()).Controller.Chat();
        else if(this.FindForm() is ClientStarterView)
          ((ClientStarterView)this.FindForm()).Controller.Chat();
        else if(this.FindForm() is ServerRestarterView)
          ((ServerRestarterView)this.FindForm()).Controller.Chat();
        else if(this.FindForm() is ClientRestarterView)
          ((ClientRestarterView)this.FindForm()).Controller.Chat();
      }
      catch(Exception ex)
      {
        if(this.FindForm() is GameView)
          ((GameView)this.FindForm()).HandleException(ex);
        else 
          throw;
      }
    }

    protected virtual void OnLinkClicked(LinkClickedEventArgs e)
    {
      try
      {
        if(LinkClicked != null)
          LinkClicked(this, e);
      }
      catch(Exception ex)
      {
        if(this.FindForm() is GameView)
          ((GameView)this.FindForm()).HandleException(ex);
        else
          throw;
      }
    }

    public void ClearMessages()
    {
      messageList.Text = string.Empty;
    }

    public void AddMessage(TextMessage message)
    {
      if(messageList.InvokeRequired) // indagare, non dovrebbe essere necessario
        messageList.Invoke(new Action<TextMessage>(AddMessage), message);
      else
      {
        if(message.Category != MessageCategory.Log)
        {
          messageList.SelectionStart = messageList.Text.Length;

          switch(message.Category)
          {
            case MessageCategory.Chat:
              messageList.SelectionColor = Color.DarkGreen;
              break;
            case MessageCategory.Warning:
            case MessageCategory.Error:
              messageList.SelectionColor = Color.Red;
              break;
          }
        }
        foreach(var element in message.Content)
        {
          if(!string.IsNullOrEmpty(element.Value))
            messageList.InsertLink(element.Text, element.Value);
          else
            messageList.AppendText(element.Text);
        }
        messageList.AppendText(Environment.NewLine);
        messageList.Select(messageList.Text.Length, 0);
        messageList.ScrollToCaret();
      }
    }

    public string CurrentText
    {
      get { return txtChat.Text; }
      set { txtChat.Text = value; }
    }

    public void FocusOnInput()
    {
      txtChat.Focus();
    }
	}
}
