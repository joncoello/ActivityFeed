using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Net.Http;
using System.Collections.Generic;
using ActivityFeed.DomainModel.Models;
using ActivityFeed.ClientApi;
using Microsoft.Owin.Hosting;
using ActivityFeed.Api;
using ActivityFeed.Messages;

namespace ActivityFeed.IntegrationTests
{
    [TestClass]
    public class EndToEnd
    {
        [TestMethod]
        public void SendActivityToClientApiAndSeeActivityThroughAPI()
        {

            var client = new ActivityFeedClient();

            var entry = new CreateActivityFeedEntry()
            {
                Title = "this is great",
                Description = "blah blah blah"
            };

            client.CreateEntryAsync(entry);

            Thread.Sleep(5000);

            var baseAddress = "http://localhost:6767";

            using (WebApp.Start<Startup>(baseAddress))
            {
                
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(baseAddress);

                var response = httpClient.GetAsync("/api/activities").Result;
                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;

                var activities = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ActivityFeedEntry>>(content);

                Assert.AreEqual(entry, activities[0]);

            }

        }
    }
}
