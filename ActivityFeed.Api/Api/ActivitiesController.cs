using Bcl.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ActivityFeed.Api.Api {
    [Route("api/activities")]
    public class ActivitiesController : ApiController
    {
        public async Task<List<MessageBase>> Get() {
            //ToDo: Remove code to get message from queueclient
            //TODo: get from activity store (database, table store, etc)?
            var queueClient = new CCHQueueClient("ActivityFeed");
            var message = await queueClient.DequeueAsync(TimeSpan.FromSeconds(0));
            
            return new List<MessageBase> { message };
        }
    }
}