using ActivityFeed.Domain.Messages;
using ActivityFeed.Domain.Models;
using Bcl.Repositories;

namespace ActivityFeed.Domain.Handlers {
    public class CreateActivityFeedEntryHandler 
        : MessageHandler<CreateActivityFeed> {

        private IRepository _repository;

        public CreateActivityFeedEntryHandler() {
            _repository = new AzureTableStorageRepository();
        }

        public CreateActivityFeedEntryHandler(IRepository storage) {
            _repository = storage;
        }
        public override void Handle(CreateActivityFeed message) {
            var activityFeedEntry = new ActivityFeedEntryDto(
                message.GetType().Name,
                message.MessageID.ToString()) {
                Title = message.Title,
                Description = message.Description
            };

            _repository.Add(activityFeedEntry);
        }
    }
}
