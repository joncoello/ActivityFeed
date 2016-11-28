using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Bcl.Azure.Storage {
    public class TableStorage {
        private CloudTable _table;

        public TableStorage() {
            Create();
        }

        public void Add(BaseEntity entity) {
            TableOperation insertOperation = TableOperation.Insert(entity);
            _table.Execute(insertOperation);
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

                Console.WriteLine(_table.Uri.ToString());
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }


    }
}
