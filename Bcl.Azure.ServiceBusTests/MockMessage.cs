using Bcl.Azure.ServiceBus;

namespace Bcl.Azure.ServiceBusTests
{
    internal class MockMessage : MessageBase
    {
        public MockMessage()
        {
        }

        public string Description { get; set; }
    }
}