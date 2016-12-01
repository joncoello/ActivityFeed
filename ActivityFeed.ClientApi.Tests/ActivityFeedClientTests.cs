using ActivityFeed.Domain.Models;
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
            await _sut.SendAsync(message);
        }
    }
}
