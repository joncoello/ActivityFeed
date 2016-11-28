using Bcl.Azure.ServiceBus;
using System.Threading.Tasks;

namespace ActivityFeed.ClientApi {
    public class ActivityFeedClient
    {
        public async Task SendAsync(MessageBase entry)
        {
            var queueClient = new CCHQueueClient("ActivityFeed");
            await queueClient.EnqueueAsync(entry);
        }
    }
}
