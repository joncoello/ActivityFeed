using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Bcl.Azure.Storage {
    public class TableStorage : IStorage {
        private CloudTable _table;

        public TableStorage() {
            Create();
        }

        public void Add<T>(T entity) where T : BaseEntity{
            TableOperation insertOperation = TableOperation.Insert(entity);
            _table.Execute(insertOperation);
        }

        public void Delete<T>(T entity) where T : BaseEntity {
            TableOperation deleteOperation = TableOperation.Delete(entity);
            _table.Execute(deleteOperation);
        }

        public IEnumerable<T> Retrieve<T>() where T : BaseEntity, new() {
            var tableQuery = new TableQuery<T>();
            var entities = _table.ExecuteQuery(tableQuery);
            return entities;
        }

        protected virtual void Create() {
            try {
                StorageCredentials creds = new StorageCredentials(
                    "tablestoragecch",
                    "DVtEFbTbw/DMnrQl6Q62X8oNQp47sBqQKbwQgJsPAOPbrA0E3duTFjgtydOuOhIv2aJL3B57uot5gF6JVDfmSg==");

                CloudStorageAccount account = new CloudStorageAccount(creds, useHttps: true);

                CloudTableClient client = account.CreateCloudTableClient();

                _table = client.GetTableReference("Fakes");
                _table.CreateIfNotExists();
            }
            catch (Exception ex) {
                throw ex;
            }
        }

       
    }
}
