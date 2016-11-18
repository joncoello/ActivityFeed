using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Bcl.Azure.ServiceBusTests
{
    class UseServiceBusAttribute : BeforeAfterTestAttribute
    {
        public override void Before(MethodInfo methodUnderTest)
        {
            string queueConnectionString = "Endpoint=sb://wkemailservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=8/Du+d6qMBX96ZF+jAg0XB/zGoN1CoEq5ss481xIp9Y=";
            string queueName = "emailmessagequeue";
            var queueClient = QueueClient.CreateFromConnectionString(queueConnectionString, queueName);
            while(queueClient.Receive() != null) { };
        }

    }
}
