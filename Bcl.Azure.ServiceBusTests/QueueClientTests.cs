using System;
using Bcl.Azure.ServiceBus;
using Xunit;

namespace Bcl.Azure.ServiceBusTests
{
    public class QueueClientTests
    {

        private const string QUEUE_NAME = "emailmessagequeue";

        [Fact]
        public void QueueClient_Create()
        {
            var client = new CCHQueueClient(QUEUE_NAME);
        }

        [Fact]
        public void QueueClient_Enqueue()
        {
            var client = new CCHQueueClient(QUEUE_NAME);
            var msg = new MockMessage();
            client.Enqueue(msg);
        }

        [Fact]
        public void QueueClient_Dequeue()
        {
            var client = new CCHQueueClient(QUEUE_NAME);
            var msg = client.Dequeue();
        }

        [Fact]
        public void QueueClient_EnqueueAndDequeue()
        {
            var client = new CCHQueueClient("emailmessagequeue1");
            client.ClearQueue();

            var msg = new MockMessage();
            client.Enqueue(msg);

            var msgOut = client.Dequeue();

            Assert.Equal(msgOut.MessageID, msg.MessageID);

        }

        [Fact]
        public void QueueClient_EnqueueMultiAndDequeueFirst()
        {
            var client = new CCHQueueClient("emailmessagequeue2");
            client.ClearQueue();

            var msg1 = new MockMessage();
            var msg2 = new MockMessage();
            var msg3 = new MockMessage();

            client.Enqueue(msg1);
            client.Enqueue(msg2);
            client.Enqueue(msg3);

            var msg = client.Dequeue();

            Assert.Equal(msg1.MessageID, msg.MessageID);
        }

        [Fact]
        public void QueueClient_EnqueueObjectAndDequeue()
        {

            var msg = new MockMessage()
            {
                Description = "test"
            };

            var client = new CCHQueueClient("emailmessagequeue3");
            client.ClearQueue();

            client.Enqueue(msg);

            var msgOut = (MockMessage)client.Dequeue();

            Assert.Equal(msg.MessageID, msgOut.MessageID);
            Assert.Equal(msg.Description, msgOut.Description);

        }

    }

}
