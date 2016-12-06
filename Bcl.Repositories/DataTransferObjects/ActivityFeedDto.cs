using System;

namespace Bcl.Repositories.DataTransferObjects {


    public class ActivityFeedDto : IMessage
    {
        public ActivityFeedDto(string partitionKey, string rowKey) {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }
        public string Description { get; set; }

        public Guid Id {
            get;
            set;
        }

        public string Title { get; set; }
        internal string PartitionKey { get; private set; }
        internal string RowKey { get; private set; }
    }

}
