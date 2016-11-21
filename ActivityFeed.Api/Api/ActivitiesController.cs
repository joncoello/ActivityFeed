using ActivityFeed.DomainModel.Models;
using ActivityFeed.Messages;
using Bcl.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ActivityFeed.Api.Api
{
    [Route("api/activities")]
    public class ActivitiesController : ApiController
    {
        public List<MessageBase> Get() {
            //var  new List<CreateActivityFeedEntry> { new CreateActivityFeedEntry {
            //    Title = "this is great",
            //    Description = "This is a description"
            //}

            var queueClient = new CCHQueueClient("ActivityFeed");

            var message = queueClient.Dequeue();

            return new List<MessageBase> { message };
        }
    }
}
