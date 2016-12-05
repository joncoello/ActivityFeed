using Bcl.Azure.ServiceBus;

namespace ActivityFeed.Domain.Messages {
    public class CreateActivityFeed : MessageBase
    {
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
