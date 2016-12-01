using Bcl.Azure.Storage;
using System.Collections.Generic;
using ActivityFeed.Domain.Models;

namespace ActivityFeed.Domain.Services {
    public class ActivityFeedService {

        private TableStorage _storage;
        public ActivityFeedService() {
            _storage = new TableStorage();
        }

        public IEnumerable<ActivityFeedEntry> GetAll() {
            var result = _storage.Retrieve<ActivityFeedEntry>();
            return result;
        }
        
    }
}
