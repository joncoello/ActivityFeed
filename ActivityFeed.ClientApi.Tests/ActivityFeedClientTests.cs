using ActivityFeed.Messages;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ActivityFeed.ClientApi.IntegrationTests {
    public class ActivityFeedClientTests {
        private ActivityFeedClient _sut;

        public ActivityFeedClientTests() {
            _sut = new ActivityFeedClient();
        }

        [Fact]
        public async Task EnqueueAndDequeue() {
            var message = new NewsActivityFeed {
                Title = "Test news activity",
                Description = "Test news description"
            };
            await _sut.CreateEntryAsync(message);

            var receivedMessage = await _sut.ReceiveMessageAsync(TimeSpan.FromSeconds(0));

            Assert.Equal(message.MessageID, receivedMessage.MessageID);
        }

        [Fact]
        public async Task DequeueEmptyReturnsNull() {
            var receivedMessage = await _sut.ReceiveMessageAsync(TimeSpan.FromSeconds(0));
            Assert.Null(receivedMessage);
        }
    }
}
