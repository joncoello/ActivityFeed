using System;
using Bcl.Azure.ServiceBus;

namespace ActivityFeed.DomainModel.Handlers {
    public interface IHandler{
        void Handle(object message);
    }

    public abstract class MessageHandler<T> : IHandler {

        public abstract void Handle(T message);
        public void Handle(object message) {
            Handle((T)message);
        }
    }
}