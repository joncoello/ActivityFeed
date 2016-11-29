using ActivityFeed.DomainModel.Models;
using Bcl.Azure.ServiceBus;
using Bcl.Azure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace ActivityFeed.Api.Api {
    [Route("api/activities")]
    public class ActivitiesController : ApiController
    {
        public async Task<List<ActivityFeedEntry>> Get() {
            //ToDo: Remove code to get message from queueclient
            //TODo: get from table storage?
            //var queueClient = new CCHQueueClient("ActivityFeed");
            //var message = await queueClient.DequeueAsync(TimeSpan.FromSeconds(0));
            //var storage = new TableStorage();
            //var messages = storage.Retrieve();

            var service = new ActivityFeedService();
            var result = service.GetAll();

            //mapper 
            return result.ToList();// messages.ToList();
        }
    }
}