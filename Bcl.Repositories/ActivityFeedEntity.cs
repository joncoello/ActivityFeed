using Microsoft.WindowsAzure.Storage.Table;

namespace Bcl.Repositories {
    public class ActivityFeedEntity : TableEntity {
        public ActivityFeedEntity(string partitionKey, string rowKey)
            : base(partitionKey, rowKey){
        }
        public ActivityFeedEntity() {
        }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}