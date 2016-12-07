using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace ActivityFeed.Repositories.Entities {
    public class ActivityFeedEntity : TableEntity {
        public ActivityFeedEntity(string partitionKey)
            : base(partitionKey, Guid.NewGuid().ToString()){
        }
        public ActivityFeedEntity() {
        }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}