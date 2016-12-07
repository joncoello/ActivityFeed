using ActivityFeed.Domain.Models;
using ActivityFeed.Repositories.Entities;
using Bcl.Azure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ActivityFeed.Repositories.UnitTests {
    public class AzureTableStorageRepositoryTests
    {
        [Fact]
        public void AzureTableStorageRepository_CanCreate() {
            var moqStorage = new Mock<IStorage>();
            var sut = new AzureTableStorageRepository(moqStorage.Object);

            Assert.NotNull(sut);
            Assert.IsType<AzureTableStorageRepository>(sut);
        }

        [Fact]
        public void AzureTableStorageRepository_CanAdd() {
            var moqStorage = new Mock<IStorage>();
            moqStorage.Setup(x => x.Add(It.IsAny<TableEntity>())).Verifiable();

            var sut = new AzureTableStorageRepository(moqStorage.Object);
            sut.Add(new ActivityFeedEntry{
                MessageID = new Guid(),
                Title = "title",
                Description = "description"
            });
            moqStorage.Verify();
        }

        [Fact]
        public void AzureTableStorageRepository_CanRetrieve() {
            var moqStorage = new Mock<IStorage>();
            IEnumerable<ActivityFeedEntity> fakeEntities = new List<ActivityFeedEntity> {    
                    new ActivityFeedEntity { Title = "T1", Description="D1"},
                    new ActivityFeedEntity { Title = "T2", Description="D2"},
                    new ActivityFeedEntity { Title = "T3", Description="D3"},
                };
            moqStorage.Setup(x => x.Retrieve<ActivityFeedEntity>())
                .Returns(fakeEntities);

            var sut = new AzureTableStorageRepository(moqStorage.Object);
            var result = sut.Retrieve();

            Assert.Equal(fakeEntities.Count(), result.Count());
        }

    }
}
