using ActivityFeed.Domain.Models;
using ActivityFeed.Domain.Repositories;
using ActivityFeed.Repositories.Entities;
using Bcl.Azure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ActivityFeed.Repositories {
    public class AzureTableStorageRepository : IActivityFeedRepository {
        private IStorage _tableStorage;

        public AzureTableStorageRepository(IStorage storage) {
            _tableStorage = storage;
        }
        public AzureTableStorageRepository() {
            _tableStorage = new TableStorage();
        }
        public void Add(ActivityFeedEntry entity) {
            _tableStorage.Add(new ActivityFeedEntity(
                entity.GetType().Name) {
                    Title = entity.Title,
                    Description = entity.Description
                });
        }

        public IEnumerable<ActivityFeedEntry> Retrieve() {
            var entities = _tableStorage.Retrieve<ActivityFeedEntity>();

            var activitiesDto = entities.Select(x => new ActivityFeedEntry {
                    MessageID = Guid.Parse(x.RowKey),
                    Title = x.Title,
                    Description = x.Description
                });

            return activitiesDto;
        }
    }
}
