using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcl.Azure.Storage {
    public interface IStorageRepository {
        void Add(CreateActivityFeed entity);
        void Delete(Guid id);
        IEnumerable<ActivityFeedEntry> Retrieve<T>();
    }
}
