using Bcl.Repositories.DataTransferObjects;
using System.Collections.Generic;

namespace Bcl.Repositories {
    //public interface IReadRepository<out T> where T : IMessage
    //{
    //    IEnumerable<T> Retrieve();
    //}

    //public interface IWriteRepository<in T> where T : IMessage {
    //    void Add(T messsage);
    //}

    public interface IRepository<T> where T : IMessage {
        void Add(T messsage);
        IEnumerable<T> Retrieve();
    }
}
