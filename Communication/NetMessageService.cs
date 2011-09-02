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
using System.ServiceModel;

namespace Communication
{
  [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext=false)]
  public class NetMessageService : INetMessageService
  {
    ServiceHost serviceHost;
    Uri uri;

    public event Action<object, ServiceNetClient> ClientConnected;
    public event Action<object, INetMessageServiceCallback, byte[]> MessageReceived;

    public NetMessageService(int port)
    {
      this.uri = new Uri(string.Format("net.tcp://localhost:{0}/pol", port));
      NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
      binding.MaxBufferSize = int.MaxValue;
      binding.MaxReceivedMessageSize = int.MaxValue;
      if(Net.IsMono)
        binding.ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas();
      binding.ReaderQuotas.MaxDepth = 32;
      binding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
      binding.ReaderQuotas.MaxArrayLength = int.MaxValue;
      binding.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
      binding.ReaderQuotas.MaxNameTableCharCount = 16384;
      this.serviceHost = new ServiceHost(this, new Uri[] { uri });
      this.serviceHost.AddServiceEndpoint(typeof(INetMessageService), binding, "controltower");
    }

    public void Start()
    {
      serviceHost.Open();
    }

    public bool Started
    {
      get { return serviceHost.State == CommunicationState.Opened; }
    }

    public void Stop()
    {
      serviceHost.Close();
    }

    protected void OnClientConnected(ServiceNetClient client)
    {
      if(this.ClientConnected != null)
        this.ClientConnected(this, client);
    }

    protected void OnMessageReceived(INetMessageServiceCallback channel, byte[] message)
    {
      if(this.MessageReceived != null)
        this.MessageReceived(this, channel, message);
    }

    #region INetMessageService Membri di

    void INetMessageService.Subscribe()
    {
      INetMessageServiceCallback channel = OperationContext.Current.GetCallbackChannel<INetMessageServiceCallback>();
      ServiceNetClient client = new ServiceNetClient(this, channel);
      OnClientConnected(client);
    }

    void INetMessageService.SendMessage(byte[] message)
    {
      INetMessageServiceCallback channel = OperationContext.Current.GetCallbackChannel<INetMessageServiceCallback>();
      OnMessageReceived(channel, message);
    }

    #endregion
  }
}
