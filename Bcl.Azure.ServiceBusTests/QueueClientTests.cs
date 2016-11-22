using System;
using Bcl.Azure.ServiceBus;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;

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
        public async Task QueueClient_EnqueueAsync()
        {
            var client = new CCHQueueClient(QUEUE_NAME);
            var msg = new MockMessage();
            await client.EnqueueAsync(msg);
        }

        [Fact]
        public void QueueClient_DequeueAysncEmptyQueue()
        {
            var client = new CCHQueueClient(QUEUE_NAME);
            var msg = client.DequeueAsync().Result;
            Assert.Null(msg);
        }

        [Fact]
        public async Task QueueClient_EnqueueAndDequeue()
        {
            var client = new CCHQueueClient("emailmessagequeue1");
            client.ClearQueue();

            var msg = new MockMessage();
            await client.EnqueueAsync(msg);

            var msgOut = client.DequeueAsync().Result;

            Assert.Equal(msgOut.MessageID, msg.MessageID);

        }

        [Fact]
        public async Task QueueClient_EnqueueMultiAndDequeueFirst()
        {
            var client = new CCHQueueClient("emailmessagequeue2");
            client.ClearQueue();

            var msg1 = new MockMessage();
            var msg2 = new MockMessage();
            var msg3 = new MockMessage();

            await client.EnqueueAsync(msg1);
            await client.EnqueueAsync(msg2);
            await client.EnqueueAsync(msg3);

            var msg = client.DequeueAsync().Result;

            Assert.Equal(msg1.MessageID, msg.MessageID);
        }

        [Fact]
        public async Task QueueClient_EnqueueObjectAndDequeue()
        {

            var msg = new MockMessage()
            {
                Description = "test"
            };

            var client = new CCHQueueClient("emailmessagequeue3");
            client.ClearQueue();

            await client.EnqueueAsync(msg);

            var msgOut = (MockMessage)client.DequeueAsync().Result;

            Assert.Equal(msg.MessageID, msgOut.MessageID);
            Assert.Equal(msg.Description, msgOut.Description);

        }

        [Fact]
        public void QueueClient_ClearAll() {
            var client = new CCHQueueClient("activityfeed");
            client.ClearQueue();

            client = new CCHQueueClient("emailmessagequeue");
            client.ClearQueue();

            client = new CCHQueueClient("emailmessagequeue2");
            client.ClearQueue();

            client = new CCHQueueClient("emailmessagequeue3");
            client.ClearQueue();
        }
        [Fact]
        public async Task QueueClient_DequeueAllMessages() {
            var client = new CCHQueueClient("activityfeed");
            await client.EnqueueAsync(new MockMessage { Description = "cool1" });
            await client.EnqueueAsync(new MockMessage { Description = "cool2" });
            await client.EnqueueAsync(new MockMessage { Description = "cool3" });

            var messageList = await client.DequeueAll();
            var message0 = messageList[0] as MockMessage;
            var message1 = messageList[1] as MockMessage;
            var message2 = messageList[2] as MockMessage;

            Assert.NotNull(messageList);
            Assert.Equal(3, messageList.Count);
            Assert.Equal("cool1", message0.Description);
            Assert.Equal("cool2", message1.Description);
            Assert.Equal("cool3", message2.Description);
        }

    }

}
