using ActivityFeed.Domain.Messages;
using System.Threading.Tasks;
using Xunit;

namespace ActivityFeed.ClientApi.IntegrationTests {
    public class ActivityFeedClientTests {
        private ActivityFeedClient _sut;

        public ActivityFeedClientTests() {
            _sut = new ActivityFeedClient();
        }

        [Fact]
        public async Task ClientApi_EnqueueAndDequeue() {
            var message = new CreateActivityFeed {
                Title = "Test activity",
                Description = "Test description"
            };
            await _sut.SendAsync(message);
        }
    }
}
