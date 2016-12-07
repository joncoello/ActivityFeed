using System.Collections.Generic;
using ActivityFeed.Domain.Models;
using System.Linq;
using ActivityFeed.Domain.Repositories;

namespace ActivityFeed.Domain.Services {
    public class ActivityFeedService {
        private IActivityFeedRepository _storageRepository;

        public ActivityFeedService(IActivityFeedRepository activityFeedRepository) {
            _storageRepository = activityFeedRepository;
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
