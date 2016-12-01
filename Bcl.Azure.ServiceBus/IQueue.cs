using System;
using System.Threading.Tasks;

namespace Bcl.Azure.ServiceBus {
    public interface IQueue {
        Task ClearQueueAsync();
        Task<MessageBase> DequeueAsync(TimeSpan serverWaitTime);
        Task EnqueueAsync(MessageBase message);
    }
}