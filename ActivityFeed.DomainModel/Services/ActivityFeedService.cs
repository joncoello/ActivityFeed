using Bcl.Azure.Storage;
using System.Collections.Generic;
using ActivityFeed.Domain.Models;

namespace ActivityFeed.Domain.Services {
    public class ActivityFeedService {

        //private TableStorage _storage;
        private IStorageRepository _storageRepository;

        public ActivityFeedService(IStorageRepository activityRepository) {
            //_storage = new TableStorage();
            _storageRepository = activityRepository;
        }

        public IEnumerable<ActivityFeedEntry> GetAll() {
            //var result = _activityRepository.Retrieve<ActivityFeedEntry>();
            var result = _storageRepository.Retrieve();
            return result;
        }
        
    }
}
