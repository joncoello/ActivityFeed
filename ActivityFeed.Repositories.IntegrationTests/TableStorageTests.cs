using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Linq;
using System.Threading;
using Xunit;

namespace Bcl.Azure.Storage.IntegrationTests {
    public class TableStorageTests : IDisposable
    {
        private TableEntity _entity;
        private TableStorage _sut;
        public TableStorageTests() {
            _sut = new TableStorage();
            _entity = new FakeEntity("1", "2");

        }
        [Fact]
        public void TableStorageTests_AddAndRetrieve() {
            _sut.Add(_entity);

            Thread.Sleep(5000);

            var results = _sut.Retrieve<FakeEntity>().ToList();

            Assert.Equal(_entity.RowKey, results[0].RowKey);
        }

        public void Dispose() {
            _sut.Delete(_entity);
        }
    }

    public class FakeEntity : TableEntity {
        public FakeEntity(string partitionKey, string rowKey) 
            : base(partitionKey, rowKey) { }

        public FakeEntity() {}

        public int MyProperty1 { get; set; }
        public string MyProperty2 { get; set; }
    }
}
