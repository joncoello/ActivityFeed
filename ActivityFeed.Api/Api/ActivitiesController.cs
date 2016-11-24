using Bcl.Azure.ServiceBus;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ActivityFeed.Api.Api {
    [Route("api/activities")]
    public class ActivitiesController : ApiController
    {
        public async Task<List<MessageBase>> Get() {
            var queueClient = new CCHQueueClient("ActivityFeed");
            var messageList = await queueClient.DequeueAllAsync();
            return messageList;
        }
    }
}