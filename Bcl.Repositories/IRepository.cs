using Bcl.Repositories.DataTransferObjects;
using System.Collections.Generic;

namespace Bcl.Repositories {
    //public interface IReadRepository<out T>{
    //    IEnumerable<T> Retrieve();
    //}

    //public interface IWriteRepository<in T>{
    //    void Add(T messsage);
    //}

    public interface IRepository<T>{
        void Add(T messsage);
        IEnumerable<T> Retrieve();
    }
}
