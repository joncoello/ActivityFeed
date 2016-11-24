﻿using Bcl.Azure.ServiceBus;

namespace ActivityFeed.Messages {
    public class CreateActivityFeedEntry : MessageBase
    {
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
