using Bcl.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityFeed.Messages
{
    public class CreateActivityFeedEntry : MessageBase
    {
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
