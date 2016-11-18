using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcl.Azure.ServiceBus
{
    public class CCHQueueClient
    {

        private QueueClient _queueClient;
        private NamespaceManager _namespaceManager;

        public CCHQueueClient(string queueName)
        {
            string queueConnectionString = "Endpoint=sb://wkemailservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=8/Du+d6qMBX96ZF+jAg0XB/zGoN1CoEq5ss481xIp9Y=";
            //string queueName = "emailmessagequeue";
            _namespaceManager = NamespaceManager.CreateFromConnectionString(queueConnectionString);
            if (!_namespaceManager.QueueExists(queueName))
            {
                try
                {
                    _namespaceManager.CreateQueue(queueName);

                }
                catch (MessagingEntityAlreadyExistsException)
                {
                }
            }
            _queueClient = QueueClient.CreateFromConnectionString(queueConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
        }

        public void ClearQueue() {
            while (true)
            {
                var msg = _queueClient.Receive(TimeSpan.FromSeconds(1));
                if (msg == null)
                {
                    break;
                }
            }
        }

        public void Enqueue(MessageBase message)
        {
            var serialisedMessage = JsonConvert.SerializeObject(message);
            _queueClient.Send(new BrokeredMessage(serialisedMessage));
        }

        public MessageBase Dequeue()
        {
            var bm = _queueClient.Receive();

            var serialisedMessage = bm.GetBody<string>();

            var messageObject = (JObject)JsonConvert.DeserializeObject(serialisedMessage);

            var typeName = messageObject["TypeName"].ToString();

            // by on using the short name of the type we can serialise and deserialise
            // from and to different types as long as members match
            // we just find the first type in the current appdomain with the same name
            var type =
                AppDomain.CurrentDomain.GetAssemblies() // get all load assemblies
                .Select(a => a.GetTypes() // get all types
                .FirstOrDefault(t => t.Name == typeName)) // get matching names
                .FirstOrDefault(t => t != null); // get first where one exists

            var message = (MessageBase)messageObject.ToObject(type);
            return message;

        }
    }
}
