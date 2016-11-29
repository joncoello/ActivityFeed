using ActivityFeed.DomainModel.Handlers;
using ActivityFeed.DomainModel.Models;
using Bcl.Azure.ServiceBus;
using Bcl.Azure.Storage;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ActivityFeed.Console {
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
            Task.Run(async () => {
                MessageBase message = null;
                while (true) {
                    try {
                        message = await _queueClient.DequeueAsync(
                                        TimeSpan.FromSeconds(ServerWaitTimeInSeconds));
                    }
                    catch (ArgumentNullException e) {

                        //log error
                        continue;
                    }

                    if (message == null) {

                        if (args.Length > 0 && args[0] == "-exitNoMessage") {
                            return;
                        }
                        continue;
                    }



                    // get Message handler
                    // call message handler's handle oto handle message and add to the table storage

                    var handler = new MessageHandlerFactory()
                        .GetHandler(message);

                    handler.Handle(message);

                    //temporary - could do this 
                   
                    //var activityFeedEntry = new ActivityFeedEntry(
                    //    message.GetType().Name,
                    //    message.MessageID.ToString()) {

                    //};

                    //var storage = new TableStorage();
                    //storage.Add(activityFeedEntry);
                }
            }).Wait();

        }

    }
}
