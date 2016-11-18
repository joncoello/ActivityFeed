using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bcl.Azure.ServiceBus;

namespace Bcl.Azure.ServiceBusTests
{
    [TestClass]
    public class QueueClientTests
    {
        [TestMethod]
        public void QueueClient_Create()
        {
            var client = new QueueClient();
        }

        [TestMethod]
        public void QueueClient_Enqueue()
        {
            var client = new QueueClient();
            client.Enqueue("blah");
        }

        [TestMethod]
        public void QueueClient_Dequeue()
        {
            var client = new QueueClient();
            var msg = client.Dequeue();
        }

        [TestMethod]
        public void QueueClient_EnqueueAndDequeue()
        {
            var client = new QueueClient();

            client.Enqueue("blah");

            var msg = client.Dequeue();

            Assert.AreEqual("blah", msg);

        }

        [TestMethod]
        public void QueueClient_EnqueueMultiAndDequeueFirst()
        {
            var client = new QueueClient();

            client.Enqueue("blah1");
            client.Enqueue("blah2");
            client.Enqueue("blah3");

            var msg = client.Dequeue();

            Assert.AreEqual("blah1", msg);
        }

    }

}
