using Bcl.Azure.ServiceBus;

namespace ActivityFeed.Domain.Models {
    public class CreateActivityFeedEntry : MessageBase
    {
        public string Description { get; set; }
        public string Title { get; set; }

        public string LongDescription { get; set; }
    }
}
