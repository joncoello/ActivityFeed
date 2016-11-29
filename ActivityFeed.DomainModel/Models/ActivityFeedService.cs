using Bcl.Azure.Storage;
using System.Collections.Generic;
using System.Linq;

namespace ActivityFeed.DomainModel.Models {
    public class ActivityFeedService {
        private TableStorage _storage;
        public ActivityFeedService() {
            _storage = new TableStorage();
        }

        public IEnumerable<ActivityFeedEntry> GetAll() {
            return _storage.Retrieve() as IEnumerable<ActivityFeedEntry>;
        }
    }
}
