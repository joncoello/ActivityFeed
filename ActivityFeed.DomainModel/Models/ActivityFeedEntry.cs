using Microsoft.WindowsAzure.Storage.Table;

namespace ActivityFeed.DomainModel.Models {
    public class ActivityFeedEntry : TableEntity
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
