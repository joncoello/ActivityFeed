using System.Collections.Generic;
using ActivityFeed.Domain.Models;
using Bcl.Repositories;
using System.Linq;

namespace ActivityFeed.Domain.Services {
    public class ActivityFeedService {
        private IRepository _storageRepository;

        public ActivityFeedService() {
            _storageRepository = new AzureTableStorageRepository();
        }
        public ActivityFeedService(IRepository repository) {
            _storageRepository = repository;
        }

        public IEnumerable<ActivityFeedEntry> GetAll() {
            var result = _storageRepository.Retrieve();
            return result.Select(x=>new ActivityFeedEntry {
                Title = x.Title,
                Description = x.Description
            });
        }
    }
}
