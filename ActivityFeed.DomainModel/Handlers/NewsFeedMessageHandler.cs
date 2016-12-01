using ActivityFeed.Domain.Models;
using Bcl.Azure.Storage;

namespace ActivityFeed.Domain.Handlers {
    public class NewsFeedMessageHandler : MessageHandler<NewsActivityFeed> {
        //ToDo
        // this class can be made generic by
        // using automapper to map different message types
        private IStorage _storage;

        public NewsFeedMessageHandler() {
            _storage = new TableStorage();
        }

        public NewsFeedMessageHandler(IStorage storage) {
            _storage = storage;
        }
        public override void Handle(NewsActivityFeed message) {
            var activityFeedEntry = new ActivityFeedEntry(
                message.GetType().Name,
                message.MessageID.ToString()) {
                Title = message.Title,
                Description = message.Description,
            };

            _storage.Add(activityFeedEntry);
        }
    }
}