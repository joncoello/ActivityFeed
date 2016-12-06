using ActivityFeed.Domain.Messages;
using Bcl.Repositories;
using Bcl.Repositories.DataTransferObjects;

namespace ActivityFeed.Domain.Handlers {
    public class CreateActivityFeedEntryHandler 
        : MessageHandler<CreateActivityFeed> {

        private IRepository _repository;

        public CreateActivityFeedEntryHandler() {
            _repository = new AzureTableStorageRepository();
            //var repo = ioc_container.Resolve<IRepo>();
        }

        public CreateActivityFeedEntryHandler(IRepository storage) {
            _repository = storage;
        }
        public override void Handle(CreateActivityFeed message) {
            var activityFeedEntry = new ActivityFeedDto(
                message.GetType().Name,
                message.MessageID.ToString()) {
                Title = message.Title,
                Description = message.Description
            };

            _repository.Add(activityFeedEntry);
        }
    }
}
