using ActivityFeed.Domain.Handlers;
using ActivityFeed.Domain.Messages;
using ActivityFeed.Domain.Repositories;
using ActivityFeed.Repositories;
using Bcl.Azure.Storage;
using Bcl.Core.IoC;
using Moq;
using Xunit;

namespace ActivityFeed.DomainModel.Tests {
    public class MessageHandlerFactoryTests {
        [Fact]
        public void MessageHandlerFactory_CanCreate() {
            var containerFactory = new DependencyContainerFactory();
            var container = containerFactory.Create();
            var sut = new MessageHandlerFactory(container);

            Assert.NotNull(sut);
        }

        [Fact]
        public void MessageHandlerFactory_GetHandlerReturnsIHandlerType() {

            var containerFactory = new DependencyContainerFactory();
            var container = containerFactory.Create();
            container.RegisterType<IActivityFeedRepository, AzureTableStorageRepository>();
            container.RegisterType<IStorage, TableStorage>();

            var sut = new MessageHandlerFactory(container);

            var handler = sut.GetHandler(new CreateActivityFeed());
            Assert.Equal(typeof(CreateActivityFeedEntryHandler), handler.GetType());
        }
    }
}
