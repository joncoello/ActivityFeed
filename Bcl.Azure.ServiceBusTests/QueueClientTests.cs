using System;
using Bcl.Azure.ServiceBus;
using Xunit;
using System.Threading.Tasks;

namespace Bcl.Azure.ServiceBusTests {
    public class QueueClientTests : IDisposable
    {
        private const string QUEUE_NAME_ACTIVITYFEED = "activityfeed";
        private CCHQueueClient _client;

        public QueueClientTests() {
            _client = new CCHQueueClient(QUEUE_NAME_ACTIVITYFEED);
        }
        
        [Fact]
        public async Task QueueClient_EnqueueAsync()
        {
            var msg = new MockMessage();
            await _client.EnqueueAsync(msg);
        }

        [Fact]
        public void QueueClient_DequeueAysncEmptyQueue()
        {
            var msg = _client.DequeueAsync().Result;
            Assert.Null(msg);
        }

        [Fact]
        public async Task QueueClient_EnqueueAndDequeue()
        {
            var msg = new MockMessage();
            await _client.EnqueueAsync(msg);

            var msgOut = _client.DequeueAsync().Result;

            Assert.Equal(msgOut.MessageID, msg.MessageID);

        }

        [Fact]
        public async Task QueueClient_EnqueueMultiAndDequeueFirst()
        {
            var message1 = new MockMessage();
            var message2 = new MockMessage();
            var message3 = new MockMessage();

            await _client.EnqueueAsync(message1);
            await _client.EnqueueAsync(message2);
            await _client.EnqueueAsync(message3);

            var dequeuedMessage = _client.DequeueAsync().Result;

            Assert.Equal(message1.MessageID, dequeuedMessage.MessageID);
        }

        [Fact]
        public async Task QueueClient_EnqueueObjectAndDequeue()
        {
            var msg = new MockMessage()
            {
                Description = "test"
            };

            await _client.EnqueueAsync(msg);

            var dequeuedMessage = (MockMessage)_client.DequeueAsync().Result;

            Assert.Equal(msg.MessageID, dequeuedMessage.MessageID);
            Assert.Equal(msg.Description, dequeuedMessage.Description);

        }

        [Fact]
        public async Task QueueClient_DequeueAllMessages() {
            await _client.EnqueueAsync(new MockMessage { Description = "message1" });
            await _client.EnqueueAsync(new MockMessage { Description = "message2" });
            await _client.EnqueueAsync(new MockMessage { Description = "message3" });

            var messageList = await _client.DequeueAll();
            var message0 = messageList[0] as MockMessage;
            var message1 = messageList[1] as MockMessage;
            var message2 = messageList[2] as MockMessage;

            Assert.NotNull(messageList);
            Assert.Equal(3, messageList.Count);
            Assert.Equal("message1", message0.Description);
            Assert.Equal("message2", message1.Description);
            Assert.Equal("message3", message2.Description);
        }

        public void Dispose() {
            _client.ClearQueue();
        }
    }

}
