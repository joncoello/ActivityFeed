using ActivityFeed.DomainModel.Models;
using ActivityFeed.Messages;
using Bcl.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityFeed.ClientApi
{
    public class ActivityFeedClient
    {
        public async Task CreateEntryAsync(MessageBase entry)
        {
            var queueClient = new CCHQueueClient("ActivityFeed");
            await queueClient.EnqueueAsync(entry);
        }

        public async Task<MessageBase> ReceiveMessageAsync(TimeSpan serverWaitTime) {
            var queueClient = new CCHQueueClient("ActivityFeed");
            return await queueClient.DequeueAsync(serverWaitTime);
        }
    }
}
