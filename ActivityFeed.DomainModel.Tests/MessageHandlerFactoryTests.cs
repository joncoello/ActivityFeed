using ActivityFeed.DomainModel.Handlers;
using ActivityFeed.Messages;
using Xunit;

namespace ActivityFeed.DomainModel.Tests {
    public class MessageHandlerFactoryTests {
        [Fact]
        public void CanCreate() {
            var sut = new MessageHandlerFactory();

            Assert.NotNull(sut);
        }

        [Fact]
        public void GetHandlerReturnsIHandlerType() {
            var sut = new MessageHandlerFactory();
            var handler = sut.GetHandler(new NewsActivityFeed());
            Assert.Equal(typeof(NewsFeedMessageHandler), handler.GetType());
        }
    }
}
