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

namespace PoL.Common
{
  [Serializable]
  public class TextMessage
  {
    public MessageCategory Category;
    public MessageContent Content;

    public TextMessage(MessageCategory category, string text)
    {
      this.Category = category;
      this.Content = new MessageContent(text);
    }

    public TextMessage(string text) :
      this(MessageCategory.Log, text)
    {
    }

    public TextMessage(MessageCategory category, MessageContent content)
    {
      this.Category = category;
      this.Content = content;
    }

    public TextMessage(MessageContent content) :
      this(MessageCategory.Log, content)
    {
    }
  }

  [Serializable]
  public class MessageContent : List<MessageContentElement>
  {
    public MessageContent()
    {
    }

    public MessageContent(MessageContentElement element)
    {
      this.Add(element);
    }

    public MessageContent(string text)
    {
      this.Add(text);
    }

    public void Add(string text)
    {
      this.Add(new MessageContentElement(text));
    }

    public void Add(string value, string text)
    {
      this.Add(new MessageContentElement(value, text));
    }

    public override string ToString()
    {
      StringBuilder str = new StringBuilder();
      this.ForEach(e => str.Append(e.Text));
      return str.ToString();
    }
  }

  [Serializable]
  public class MessageContentElement
  {
    public MessageContentElement() :
      this(string.Empty, string.Empty)
    { }

    public MessageContentElement(string value, string text)
    {
      this.Value = value;
      this.Text = text;
    }

    public MessageContentElement(string text)
      : this(string.Empty, text)
    {
    }

    public string Value { get; set; }
    public string Text { get; set; }

    public override string ToString()
    {
      return this.Text;
    }
  }

  public enum MessageCategory
  {
    Log,
    Warning,
    Error,
    Chat
  }
}
