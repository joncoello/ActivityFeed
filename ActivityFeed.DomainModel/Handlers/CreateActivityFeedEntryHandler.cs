using ActivityFeed.Domain.Messages;
using ActivityFeed.Domain.Models;
using Bcl.Azure.Storage;

namespace ActivityFeed.Domain.Handlers {
    public class CreateActivityFeedEntryHandler 
        : MessageHandler<CreateActivityFeed> {

        private IStorageRepository _storage;

        public CreateActivityFeedEntryHandler() {
            //_storage = new TableStorage();
        }

        public CreateActivityFeedEntryHandler(IStorageRepository storage) {
            _storage = storage;
        }
        public override void Handle(CreateActivityFeed message) {
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
