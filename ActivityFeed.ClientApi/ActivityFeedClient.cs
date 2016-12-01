using Bcl.Azure.ServiceBus;
using System.Threading.Tasks;

namespace ActivityFeed.ClientApi {
    public class ActivityFeedClient
    {
        private IQueue _queueClient;
        public ActivityFeedClient(IQueue queueClient) {
            _queueClient = queueClient;
        }

        public ActivityFeedClient() {
            //IoC
            _queueClient = new CCHQueueClient("ActivityFeed");
        }

        public async Task SendAsync(MessageBase entry)
        {
            await _queueClient.EnqueueAsync(entry);
        }
    }
}
