using System.Collections.Generic;

namespace Bcl.Repositories {
    public interface IRepository
    {
        void Add(ActivityFeedEntryDto messsage);
        //void Delete(Guid id);
        IEnumerable<ActivityFeedEntryDto> Retrieve();
    }
}
