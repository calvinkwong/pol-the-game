using System;
using NUnit.Framework;
using Communication;
using System.Net;
using System.Threading;

namespace PoL.Tests
{
	[TestFixture]
	public class CommunicationTest
	{		
		INetMessage msg = null;
		NetMessageService service = null;
		
		[SetUp]
		public void Setup()
		{
			msg = null;
			service = new NetMessageService(8668);
			service.Start();
			service.MessageReceived += HandleServiceMessageReceived; 
		}

		[TearDown]
		public void TearDown()
		{
			service.Stop();
		}
		
		[Test]
		public void TestCase()
		{
			var client = new ServiceNetClient(IPAddress.Parse("127.0.0.1"), 8668);
			client.Subscribe();
			client.SendMessage(new Message());
			for(int i = 0; i < 6; i++)
			{
				Thread.Sleep(100);
				if(msg != null)
					break;
			}
			//client.Disconnect();
			Assert.That(msg, Is.Not.Null);
		}

		void HandleServiceMessageReceived(object arg1, INetMessageServiceCallback arg2, Byte[] message)
		{
			msg = (INetMessage)Communication.Serializer.DeserializeObject(message);
		}
	}
	
	[Serializable]
	class Message : INetMessage
	{
	}

}

