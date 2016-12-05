using Bcl.Azure.Storage;
using System.Collections.Generic;
using System.Linq;

namespace Bcl.Repositories {
    public class AzureTableStorageRepository : IRepository {
        private IStorage _tableStorage;

        public AzureTableStorageRepository(IStorage storage) {
            _tableStorage = storage;
        }
        public AzureTableStorageRepository() {
            _tableStorage = new TableStorage();
        }
        public void Add(ActivityFeedEntryDto entity) {
            _tableStorage.Add(new ActivityFeedEntity(
                entity.PartitionKey, entity.RowKey) {
                    Title = entity.Title,
                    Description = entity.Description
                });
        }

        public IEnumerable<ActivityFeedEntryDto> Retrieve() {
            var entities = _tableStorage.Retrieve<ActivityFeedEntity>();

            var activitiesDto = entities.Select(x => new ActivityFeedEntryDto(
                x.PartitionKey, x.RowKey){
                    Title = x.Title,
                    Description = x.Description
                });

            return activitiesDto;
        }
    }
}
