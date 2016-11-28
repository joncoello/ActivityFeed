using Bcl.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityFeed.CloudService.Worker
{
    public class Program
    {

        private static CCHQueueClient _queueClient;
        private const double ServerWaitTimeInSeconds = 5;

        public static void Main(string[] args)
        {

            // load type into app domain - replace with MEF
            var msg = new ActivityFeed.Messages.NewsActivityFeed();


            Debugger.Launch();

            _queueClient = new CCHQueueClient("ActivityFeed");

            while (true)
            {
                var message = _queueClient.DequeueAsync(
                    TimeSpan.FromSeconds(ServerWaitTimeInSeconds));

                if (message == null)
                {

                    if (args.Length > 0 && args[0] == "-exitNoMessage")
                    {
                        return;
                    }

                    continue;
                }

                // get Message handler
                // call message handler's handle oto handle message and add to the table storage

                //temporary - could do this 
                //var storage = new TableStorage();
                //storage.Add(message);
            }

        }

    }
}
