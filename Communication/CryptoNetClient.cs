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
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Diagnostics;

namespace Communication
{
	public class CryptoNetClient : IDisposable
	{
		IPAddress serverAddress;
		int port;
    TcpClient tcpClient;
    Thread readDataThread;
    object syncObject = new object();
    bool connected;
    RSACryptoServiceProvider keyDecriptor = new RSACryptoServiceProvider();
    RSACryptoServiceProvider keyEncryptor = new RSACryptoServiceProvider();
    RijndaelManaged dataCryptoService = new RijndaelManaged();
    static byte[] IV = new byte[] { 0x45, 0x22, 0x03, 0x34, 0x35, 0x98, 0x11, 0x48, 0x39, 0x33, 0x66, 0x22, 0x94, 0x75, 0x93, 0x66 };
    bool encrypt = false;

    public event Action<object, object> MessageReceived;
    public event EventHandler Disconnected;

		public CryptoNetClient(IPAddress serverAddress, int port)
      : this(null, serverAddress, port)
    {
    }

    public CryptoNetClient(TcpClient tcpClient)
      : this(tcpClient, IPAddress.None, 0)
    {
    }

    CryptoNetClient(TcpClient tcpClient, IPAddress serverAddress, int port)
    {
      dataCryptoService.IV = IV;
      this.serverAddress = serverAddress;
      this.port = port;
      readDataThread = new Thread(new ThreadStart(ReadIncomingData));
      readDataThread.IsBackground = true;
      this.tcpClient = tcpClient;
      if(tcpClient == null)
        this.tcpClient = new TcpClient();
      else
      {
        connected = true;
        readDataThread.Start();
      }
    }

    public string PublicKey
    {
      get { return keyDecriptor.ToXmlString(false); }
    }

    public bool Connected
    {
      get { return connected; }
    }

    public void ActivateEncryption(string destinationPublicKey)
    {
      keyEncryptor.FromXmlString(destinationPublicKey);
      encrypt = true;
    }

		public bool Connect()
		{
      if(!connected)
      {
        tcpClient.Connect(serverAddress, port);
        if(tcpClient.Connected)
        {
          connected = true;
          readDataThread.Start();
        }
      }
			return tcpClient.Connected;
		}

		public void Disconnect()
		{
      if(tcpClient.Connected)
      {
        connected = false;
        tcpClient.GetStream().Close();
        tcpClient.Close();
      }
		}

		public bool SendMessage(object message)
		{
      lock(syncObject)
      {
        byte[] cryptedKey = null;
        byte[] data = Serializer.SerializeObject(message);
        if(encrypt)
        {
          dataCryptoService.GenerateKey();
          cryptedKey = keyEncryptor.Encrypt(dataCryptoService.Key, true);
          data = dataCryptoService.CreateEncryptor().TransformFinalBlock(data, 0, data.Length);
        }
        //data = Compressor.Compress(data);
        try
        {
          if(encrypt)
            Write(cryptedKey);
          Write(data);
        }
        catch
        {
          // socket disconnected...?
          connected = false;
        }
      }
      return connected;
		}

    void Write(byte[] buf)
    {
      byte[] contentLenth = BitConverter.GetBytes(buf.Length);
      tcpClient.GetStream().Write(contentLenth, 0, contentLenth.Length);
      tcpClient.GetStream().Write(buf, 0, buf.Length);
    }

    byte[] Read()
    {
      // get length
      byte[] buf = new byte[sizeof(int)];
      tcpClient.GetStream().Read(buf, 0, buf.Length);
      int len = BitConverter.ToInt32(buf, 0);

      // get content
      using(MemoryStream mem = new MemoryStream(len))
      {
        for(int i = 0; i < len; i++)
        {
          while(!tcpClient.GetStream().DataAvailable)
            Thread.Sleep(10);
          mem.WriteByte((byte)tcpClient.GetStream().ReadByte());
        }
        buf = mem.GetBuffer();
      }
      return buf;
    }

		void ReadIncomingData()
		{
      while(connected)
      {
        try
        {
          byte[] data = null;
          lock(syncObject)
          {
            if(tcpClient.GetStream().DataAvailable)
            {
              byte[] key = null;
              if(encrypt)
                key = Read();
              data = Read();
              if(encrypt)
              {
                key = keyDecriptor.Decrypt(key, true);
                dataCryptoService.Key = key;
                data = dataCryptoService.CreateDecryptor().TransformFinalBlock(data, 0, data.Length);
              }
            }
          }
          if(data != null)
          {
            Thread dispatchThread = new Thread(new ParameterizedThreadStart(DispatchMessage));
            dispatchThread.Start(data);
          }
          Thread.Sleep(10);
        }
        catch
        {
          // socket disconnected...?
          connected = false;
        }
      }
      OnDisconnected();
		}

    private void DispatchMessage(object state)
    {
      //byte[] data = Compressor.Decompress(args.Data);
      object message = Serializer.DeserializeObject((byte[])state);
      OnMessageReceived(message);
    }

    protected void OnDisconnected()
    {
      if(this.Disconnected != null)
        this.Disconnected(this, new EventArgs());
    }

		protected void OnMessageReceived(object message)
		{
			if(this.MessageReceived != null)
				this.MessageReceived(this, message);
		}

		public void Dispose()
		{
			Disconnect();
      this.tcpClient = null;
		}
	}
}
