﻿using System;
using Bcl.Azure.ServiceBus;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Bcl.Azure.ServiceBusTests {
    public class QueueClientTests : IDisposable
    {
        private const string QUEUE_NAME = "activityfeed";
        private CCHQueueClient _sut;

        public QueueClientTests() {
            _sut = new CCHQueueClient(QUEUE_NAME);
        }
        
        [Fact]
        [UseServiceBus]
        public async Task QueueClient_EnqueueAsync()
        {
            var msg = new MockMessage();
            await _sut.EnqueueAsync(msg);
        }

        [Fact]
        public async Task QueueClient_DequeueAysncEmptyQueue()
        {
            var msg = await _sut.DequeueAsync(TimeSpan.FromSeconds(1));
            Assert.Null(msg);
        }

        [Fact]
        public async Task QueueClient_EnqueueAndDequeue()
        {
            var msg = new MockMessage();
            await _sut.EnqueueAsync(msg);

            var msgOut = await _sut.DequeueAsync(TimeSpan.FromSeconds(1));

            Assert.Equal(msgOut.MessageID, msg.MessageID);

        }

        [Fact]
        public async Task QueueClient_EnqueueMultiAndDequeueFirst()
        {
            var message1 = new MockMessage();
            var message2 = new MockMessage();
            var message3 = new MockMessage();

            await _sut.EnqueueAsync(message1);
            await _sut.EnqueueAsync(message2);
            await _sut.EnqueueAsync(message3);

            var dequeuedMessage = await _sut.DequeueAsync(TimeSpan.FromSeconds(1));

            Assert.Equal(message1.MessageID, dequeuedMessage.MessageID);
        }

        [Fact]
        public async Task QueueClient_EnqueueObjectAndDequeue()
        {
            var msg = new MockMessage()
            {
                Description = "test"
            };

            await _sut.EnqueueAsync(msg);

            var dequeuedMessage = (MockMessage)await _sut.DequeueAsync(
                TimeSpan.FromSeconds(1));

            Assert.Equal(msg.MessageID, dequeuedMessage.MessageID);
            Assert.Equal(msg.Description, dequeuedMessage.Description);

        }

        [Fact]
        public async Task QueueClient_DequeueAllMessages() {
            var testMessages = new List<MockMessage> {
                new MockMessage(),
                new MockMessage(),
                new MockMessage()
            };

            await _sut.EnqueueAsync(testMessages[0]);
            await _sut.EnqueueAsync(testMessages[1]);
            await _sut.EnqueueAsync(testMessages[2]);

            var messageList = await _sut.DequeueAllAsync();

            Assert.NotNull(messageList);
            Assert.Equal(3, messageList.Count);
            Assert.Equal(testMessages[0].MessageID, messageList[0].MessageID);
            Assert.Equal(testMessages[1].MessageID, messageList[1].MessageID);
            Assert.Equal(testMessages[2].MessageID, messageList[2].MessageID);
        }

        public async void Dispose() {
             await _sut.ClearQueueAsync();
        }
    }

}
