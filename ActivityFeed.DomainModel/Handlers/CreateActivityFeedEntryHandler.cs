using ActivityFeed.Domain.Messages;
using ActivityFeed.Domain.Models;
using ActivityFeed.Domain.Repositories;

namespace ActivityFeed.Domain.Handlers {
    public class CreateActivityFeedEntryHandler 
        : MessageHandler<CreateActivityFeed> {

        private IActivityFeedRepository _repository;

        public CreateActivityFeedEntryHandler(IActivityFeedRepository activityFeedRepository) {
            _repository = activityFeedRepository;
        }

        public override void Handle(CreateActivityFeed message) {
            var activityFeedEntry = new ActivityFeedEntry{
                MessageID = message.MessageID,
                Title = message.Title,
                Description = message.Description
            };

            _repository.Add(activityFeedEntry);
        }
    }
}
