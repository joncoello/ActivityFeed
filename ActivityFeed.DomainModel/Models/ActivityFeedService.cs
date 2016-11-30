using Bcl.Azure.Storage;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;
using System.Linq;

namespace ActivityFeed.DomainModel.Models {
    public class ActivityFeedService {

        private TableStorage _storage;
        public ActivityFeedService() {
            _storage = new TableStorage();
        }

        public IEnumerable<ActivityFeedEntry> GetAll() {
            List<ActivityFeedEntry> list = new List<ActivityFeedEntry>();
            var result = _storage.Retrieve();//.Select(x=> new ActivityFeedEntry { Title = x.};
            foreach (ActivityFeedEntry item in result) {
                list.Add(item);
                //yield return item;
            }
            return list;
        }
        
    }
}
