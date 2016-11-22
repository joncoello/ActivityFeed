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
        public void CreateEntryAsync(CreateActivityFeedEntry entry)
        {
            var queueClient = new CCHQueueClient("ActivityFeed");
            queueClient.EnqueueAsync(entry);
        }
    }
}
