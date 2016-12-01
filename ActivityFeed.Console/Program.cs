using ActivityFeed.Domain.Handlers;
using ActivityFeed.Domain.Models;
using Bcl.Azure.ServiceBus;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ActivityFeed.Console {
    public class Program
    {
        private static IQueue _queueClient;
        private const double ServerWaitTimeInSeconds = 5;

        public static void Main(string[] args)
        {
            //ToDo
            // load type into app domain - replace with MEF
            var msg1 = new NewsActivityFeed();
            var msg2 = new CreateActivityFeedEntry();

            //Debugger.Launch();
            //IoC
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

                    try {
                        var handler = new MessageHandlerFactory()
                                        .GetHandler(message);
                        handler.Handle(message);
                    }
                    //ToDo
                    // could introduce transient custom user exception
                    // to handle exception and action the message
                    // dead letter???
                    // log it
                    // move on
                    catch (ArgumentNullException) {}
                    catch (ArgumentException) {}
                }
            }).Wait();
        }
    }
}
