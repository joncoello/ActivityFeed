using Bcl.Azure.ServiceBus;

namespace ActivityFeed.Domain.Models {
    public class NewsActivityFeed : MessageBase
    {
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
