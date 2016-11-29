using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Bcl.Azure.Storage {
    public class TableStorage {
        private CloudTable _table;

        public TableStorage() {
            Create();
        }

        public void Add(TableEntity entity) {
            TableOperation insertOperation = TableOperation.Insert(entity);
            _table.Execute(insertOperation);
        }

        public void Delete(TableEntity entity) {
            TableOperation deleteOperation = TableOperation.Delete(entity);
            _table.Execute(deleteOperation);
        }

        public IEnumerable<TableEntity> Retrieve() {
            var tableQuery = new TableQuery<TableEntity>();
            var entities = _table.ExecuteQuery(tableQuery);
            return entities;
        }

        private void Create() {
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
