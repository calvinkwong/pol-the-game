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
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PoL.Common;
using PoL.Services;
using Patterns.ComponentModel;

namespace PoL.Models.Game
{
  [Serializable]
  public class ConsoleModel : Model
  {
    public ObservableCollection<TextMessage> Messages { get; set; }

    public ConsoleModel(string key)
      : base(key)
    {
      Messages = new ObservableCollection<TextMessage>();
    }

    public void WriteChat(string message)
    {
      Messages.Add(new TextMessage(MessageCategory.Chat, message));
    }

    public void WriteLog(string message)
    {
      Messages.Add(new TextMessage(MessageCategory.Log, message));
    }

    public void WriteLine(MessageCategory category, string message)
    {
      Messages.Add(new TextMessage(category, message));
    }

    public void WriteLog(MessageContent content)
    {
      Messages.Add(new TextMessage(MessageCategory.Log, content));
    }

    public void WriteLine(MessageCategory category, MessageContent content)
    {
      Messages.Add(new TextMessage(category, content));
    }
  }
}
