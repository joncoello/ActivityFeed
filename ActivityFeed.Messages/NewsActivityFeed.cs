using Bcl.Azure.ServiceBus;

namespace ActivityFeed.Messages {
    public class NewsActivityFeed : MessageBase
    {
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
