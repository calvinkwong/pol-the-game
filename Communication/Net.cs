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
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace Communication
{
	public class Net
	{
    private const string MYIP_URL = "http://www.whatismyip.com/automation/n09230945.asp";
    public const int SEND_MESSAGE_TIMEOUT = 5000;

		public static IPAddress GetPublicIP()
		{
      IPAddress ipAddress = IPAddress.None;
      try
      {
        HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(MYIP_URL);
        using(WebResponse res = myRequest.GetResponse())
        {
          using(Stream stream = res.GetResponseStream())
            using(StreamReader readStream = new StreamReader(stream, Encoding.UTF8))
              ipAddress = IPAddress.Parse(readStream.ReadToEnd());
        }
      }
      catch { }
      return ipAddress;
		}

    static public bool IsMono
    {
      get { return Type.GetType("Mono.Runtime") != null; }
    }
	}
}
