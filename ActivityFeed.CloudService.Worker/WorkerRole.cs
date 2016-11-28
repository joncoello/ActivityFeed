//using System;
//using Microsoft.WindowsAzure.ServiceRuntime;
//using Bcl.Azure.ServiceBus;
//using Bcl.Azure.Storage;

//namespace ActivityFeed.CloudService.Worker {
//    public class WorkerRole : RoleEntryPoint {
//        private CCHQueueClient _queueClient;
//        private const double ServerWaitTimeInSeconds = 5;
//        public WorkerRole() {
//            //ToDo: IoC 
//            _queueClient = new CCHQueueClient("ActivityFeed");
//        }
//        public override async void Run() {
//            while (true) {
//                var message = await _queueClient.DequeueAsync(
//                    TimeSpan.FromSeconds(ServerWaitTimeInSeconds));

//                if (message == null)
//                    continue;

//                // get Message handler
//                // call message handler's handle oto handle message and add to the table storage

//                //temporary - could do this 
//                //var storage = new TableStorage();
//                //storage.Add(message);
//            }
//        }

//        public override bool OnStart() {
//            return base.OnStart();
//        }

//        public override void OnStop() {
//            base.OnStop();
//        }
//    }
//}
