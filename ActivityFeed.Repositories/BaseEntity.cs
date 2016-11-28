using Microsoft.WindowsAzure.Storage.Table;

namespace Bcl.Azure.Storage {
    public class BaseEntity : TableEntity {
        public BaseEntity(string partitionKey, string rowKey ) 
            : base(partitionKey, rowKey) {}
        public BaseEntity() {

        }
    }
}
