using System;

namespace ActivityFeed.Domain.Models {
    public class ActivityFeedEntry
    {
        public Guid MessageID { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
