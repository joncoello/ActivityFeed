using ActivityFeed.Domain.Handlers;
using ActivityFeed.Domain.Messages;
using ActivityFeed.Domain.Repositories;
using Moq;
using Xunit;

namespace ActivityFeed.DomainModel.Tests {
    public class MessageHandlerFactoryTests {
        [Fact]
        public void MessageHandlerFactory_CanCreate() {
            var mockRepo = new Mock<IActivityFeedRepository>();
            var sut = new MessageHandlerFactory(mockRepo.Object);

            Assert.NotNull(sut);
        }

        [Fact]
        public void MessageHandlerFactory_GetHandlerReturnsIHandlerType() {
            var mockRepo = new Mock<IActivityFeedRepository>();
            var sut = new MessageHandlerFactory(mockRepo.Object);

            var handler = sut.GetHandler(new CreateActivityFeed());
            Assert.Equal(typeof(CreateActivityFeedEntryHandler), handler.GetType());
        }
    }
}
