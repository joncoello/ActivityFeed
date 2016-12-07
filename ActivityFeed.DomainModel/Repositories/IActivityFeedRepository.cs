using ActivityFeed.Domain.Models;
using System.Collections.Generic;

namespace ActivityFeed.Domain.Repositories {
    public interface IActivityFeedRepository
    {
        void Add(ActivityFeedEntry messsage);
        //void Delete(Guid id);
        IEnumerable<ActivityFeedEntry> Retrieve();
    }
}
