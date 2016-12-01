using ActivityFeed.Domain.Handlers;
using ActivityFeed.Domain.Messages;
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
            var handler = sut.GetHandler(new CreateActivityFeed());
            Assert.Equal(typeof(CreateActivityFeedEntryHandler), handler.GetType());
        }
    }
}
