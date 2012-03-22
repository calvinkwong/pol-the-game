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
using System.Net;
using System.ServiceModel;
using System.Collections;

namespace Communication
{
  [CallbackBehavior(UseSynchronizationContext = false, ConcurrencyMode = ConcurrencyMode.Multiple)]
  public class ServiceNetClient : INetMessageServiceCallback
  {
    DuplexChannelFactory<INetMessageService>  channelFactory;
    INetMessageService clientChannel;

    NetMessageService messageService;
    INetMessageServiceCallback callbackChannel;

    public event EventHandler Disconnected;
    public event EventHandler MessageReceived;

    Queue<INetMessage> messageQueue = new Queue<INetMessage>();
    object syncObject = new object();

    public ServiceNetClient(IPAddress serverAddress, int port)
    {
      Uri uri = new Uri(string.Format("net.tcp://{0}:{1}/pol/controltower", serverAddress.ToString(), port));
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
      channelFactory = new DuplexChannelFactory<INetMessageService>(new InstanceContext(this), binding, new EndpointAddress(uri));
      clientChannel = channelFactory.CreateChannel();
      ((IContextChannel)clientChannel).Closed += new EventHandler(channel_Closed);
    }

    public ServiceNetClient(NetMessageService messageService, INetMessageServiceCallback callbackChannel)
    {
      this.messageService = messageService;
      this.callbackChannel = callbackChannel;
      ((IContextChannel)callbackChannel).Closed += new EventHandler(channel_Closed);
      this.messageService.MessageReceived += new Action<object, INetMessageServiceCallback, byte[]>(messageService_MessageReceived);
    }

    void messageService_MessageReceived(object sender, INetMessageServiceCallback callbackChannel, byte[] message)
    {
      if(this.callbackChannel == callbackChannel)
      {
        INetMessage msg = (INetMessage)Serializer.DeserializeObject(message);
        lock(syncObject)
          messageQueue.Enqueue(msg);
        OnMessageReceived();
      }
    }

    void channel_Closed(object sender, EventArgs e)
    {
      OnDisconnected();
    }

    public INetMessage DequeueMessage()
    {
      INetMessage msg = null;
      lock(syncObject)
      {
        if(messageQueue.Count > 0)
          msg = messageQueue.Dequeue();
      }
      return msg;
    }

    public void Subscribe()
    {
      clientChannel.Subscribe();
    }

    public void Disconnect()
    {
      if(clientChannel != null)
			{
				if(((IContextChannel)clientChannel).State == CommunicationState.Opened)
        	((IContextChannel)clientChannel).Close();
			}
      else
        callbackChannel.Disconnect();
      lock(syncObject)
        messageQueue.Clear();
    }

    public bool Connected
    {
      get 
      {
        IContextChannel ch = null;
        if(clientChannel != null)
          ch = (IContextChannel)clientChannel; 
        else
          ch = (IContextChannel)callbackChannel;
        return ch.State == CommunicationState.Opened || ch.State == CommunicationState.Opening;
      }
    }

    public void SendMessage(INetMessage message)
    {
      if(this.Connected)
      {
        if(clientChannel != null)
          clientChannel.SendMessage(Serializer.SerializeObject(message));
        else
          callbackChannel.MessageReceived(Serializer.SerializeObject(message));
      }
    }

    #region INetClientCallback Membri di

    void INetMessageServiceCallback.MessageReceived(byte[] message)
    {
      INetMessage msg = (INetMessage)Serializer.DeserializeObject(message);
      lock(syncObject)
        messageQueue.Enqueue(msg);
      OnMessageReceived();
    }

    void INetMessageServiceCallback.Disconnect()
    {
      Disconnect();
    }

    #endregion

    protected void OnDisconnected()
    {
      if(this.Disconnected != null)
        this.Disconnected(this, EventArgs.Empty);
    }

    protected void OnMessageReceived()
    {
      if(this.MessageReceived != null)
        this.MessageReceived(this, EventArgs.Empty);
    }
  }

  public interface INetMessage
  {
  }
}
