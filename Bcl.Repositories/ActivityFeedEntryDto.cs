using Bcl.Azure.Storage;

namespace Bcl.Repositories {
    public class ActivityFeedEntryDto
    {
        public ActivityFeedEntryDto(string partitionKey, string rowKey) {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }
        public string Description { get; set; }
        public string Title { get; set; }
        internal string PartitionKey { get; private set; }
        internal string RowKey { get; private set; }
    }
}
