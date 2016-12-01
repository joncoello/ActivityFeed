using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bcl.Azure.Storage {
    public interface IStorage {
        void Add<T>(T entity) where T : BaseEntity;
        void Delete<T>(T entity) where T : BaseEntity;
        IEnumerable<T> Retrieve<T>() where T: BaseEntity, new();
    }
}