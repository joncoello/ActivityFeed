using System;
using ActivityFeed.DomainModel.Models;
using ActivityFeed.Messages;
using Bcl.Azure.Storage;

namespace ActivityFeed.DomainModel.Handlers {
    public class NewsFeedMessageHandler : MessageHandler<NewsActivityFeed> {
        //public override void Handle(NewsActivityFeed message) {
        //    var activityFeedEntry = new ActivityFeedEntry(
        //        message.GetType().Name,
        //        message.MessageID.ToString()) {
        //    };

        //    var storage = new TableStorage();
        //    storage.Add(activityFeedEntry);
        //}
        public override void Handle(NewsActivityFeed message) {
            var activityFeedEntry = new ActivityFeedEntry(
                message.GetType().Name,
                message.MessageID.ToString()) {
                Title = message.Title,
                Description = message.Description
            };

            var storage = new TableStorage();
            storage.Add(activityFeedEntry);
        }
    }
}