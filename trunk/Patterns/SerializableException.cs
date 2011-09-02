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
using System.Xml.Serialization;

namespace Patterns
{
  [Serializable]
  public class SerializableException
  {
    public string Message { get; set; }
    public string Source { get; set; }
    public string StackTrace { get; set; }
    public SerializableException InnerException { get; set; }

    public SerializableException(Exception ex)
    {
      this.Message = ex.Message;
      this.Source = ex.Source;
      this.StackTrace = ex.StackTrace;
      if(ex.InnerException != null)
        this.InnerException = new SerializableException(ex.InnerException);
    }

    public SerializableException()
    { 
    }
  }
}
