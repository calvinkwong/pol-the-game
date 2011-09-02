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
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;

namespace Communication
{
  public delegate void ClientConnectedEventHandler(CryptoNetClient client);

  public class NetListener : IDisposable
  {
    private TcpListener listener = null;

    public event ClientConnectedEventHandler ClientConnected;

    public NetListener(int port)
    {
      listener = new TcpListener(IPAddress.Any, port);
    }

    public void Start()
    {
      listener.Start();
      listener.BeginAcceptTcpClient(new AsyncCallback(this.ClientAcceptedCallBack), null);
    }

    public void Stop()
    {
      listener.Stop();
    }

    private void ClientAcceptedCallBack(IAsyncResult Res)
    {
      try
      {
        TcpClient client = listener.EndAcceptTcpClient(Res);
        listener.BeginAcceptTcpClient(new AsyncCallback(this.ClientAcceptedCallBack), null);
        CryptoNetClient netClient = new CryptoNetClient(client);
        OnClientConnected(netClient);
      }
      catch(ObjectDisposedException) { }
    }

    protected void OnClientConnected(CryptoNetClient client)
    {
      if(this.ClientConnected != null)
        this.ClientConnected(client);
    }

    public void Dispose()
    {
      Stop();
    }
  }
}
