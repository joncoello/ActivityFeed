using Bcl.Repositories.DataTransferObjects;
using System.Collections.Generic;

namespace Bcl.Repositories {
    public interface IRepository
    {
        void Add(ActivityFeedDto messsage);
        //void Delete(Guid id);
        IEnumerable<ActivityFeedDto> Retrieve();
    }
}
