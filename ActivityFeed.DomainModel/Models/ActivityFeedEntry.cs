using Bcl.Azure.Storage;

namespace ActivityFeed.Domain.Models {
    public class ActivityFeedEntry : BaseEntity
    {

        public ActivityFeedEntry(string partitionKey, string rowKey)
            : base(partitionKey, rowKey){
        }

        public ActivityFeedEntry() {
        }

        public string Description { get; set; }
        public string Title { get; set; }
    }
}
