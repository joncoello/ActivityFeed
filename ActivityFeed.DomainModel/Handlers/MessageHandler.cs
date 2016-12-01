namespace ActivityFeed.Domain.Handlers {
    public abstract class MessageHandler<T> : IHandler {
        public abstract void Handle(T message);
        public void Handle(object message) {
            Handle((T)message);
        }
    }
}