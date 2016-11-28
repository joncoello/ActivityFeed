using Xunit;

namespace Bcl.Azure.Storage.IntegrationTests {
    public class TableStorageTests
    {
        [Fact]
        public void AddAndRetrive() {
            var sut = new TableStorage();
            BaseEntity entity = new FakeEntity("1","1");
            sut.Add(entity);
        }
    }

    public class FakeEntity : BaseEntity {
        public FakeEntity(string partitionKey, string rowKey) 
            : base(partitionKey, rowKey) { }

        public FakeEntity() {}

        public int MyProperty1 { get; set; }
        public string MyProperty2 { get; set; }
    }
}
