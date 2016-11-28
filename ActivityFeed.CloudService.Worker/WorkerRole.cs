using System;
using Microsoft.WindowsAzure.ServiceRuntime;
using ActivityFeed.ClientApi;


namespace ActivityFeed.CloudService.Worker {
    public class WorkerRole : RoleEntryPoint {
        private ActivityFeedClient _activityFeedClient;
        //private ;
        private const double ServerWaitTimeInSeconds = 5;
        public WorkerRole() {
            //ToDo: IoC 
            _activityFeedClient = new ActivityFeedClient();
        }
        public override async void Run() {
            while (true) {
                var message = await _activityFeedClient.ReceiveMessageAsync(
                    TimeSpan.FromSeconds(ServerWaitTimeInSeconds));

                if (message == null)
                    continue;

                // get Message handler

                // call message handler's handle
            }
        }

        public override bool OnStart() {
            return base.OnStart();
        }

        public override void OnStop() {
            base.OnStop();
        }
    }
}
