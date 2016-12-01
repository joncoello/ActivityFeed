using Bcl.Azure.ServiceBus;

namespace ActivityFeed.Domain.Messages {
    public class UpdateActivityFeed : MessageBase{
        public string Description { get; set; }
        public string Title { get; set; }
        public string LongDescription { get; set; }
    }
}