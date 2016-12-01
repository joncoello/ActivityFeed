using ActivityFeed.Domain.Models;
using Bcl.Azure.Storage;

namespace ActivityFeed.Domain.Handlers {
    public class CreateActivityFeedEntryHandler 
        : MessageHandler<CreateActivityFeedEntry> {

        private IStorage _storage;

        public CreateActivityFeedEntryHandler() {
            _storage = new TableStorage();
        }

        public CreateActivityFeedEntryHandler(IStorage storage) {
            _storage = storage;
        }
        public override void Handle(CreateActivityFeedEntry message) {
            var activityFeedEntry = new ActivityFeedEntry(
                message.GetType().Name,
                message.MessageID.ToString()) {
                Title = message.Title,
                Description = message.Description,
                LongDescription = message.LongDescription
            };

            _storage.Add(activityFeedEntry);
        }
    }
}
