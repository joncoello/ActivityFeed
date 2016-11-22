using Bcl.Azure.ServiceBus;
using System.Collections.Generic;
using System.Web.Http;

namespace ActivityFeed.Api.Api {
    [Route("api/activities")]
    public class ActivitiesController : ApiController
    {
        public List<MessageBase> Get() {
            var queueClient = new CCHQueueClient("ActivityFeed");
            var messageList = queueClient.DequeueAll();
            return messageList;
        }
    }
}