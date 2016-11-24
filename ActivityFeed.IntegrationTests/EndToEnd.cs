using System;
using System.Net.Http;
using System.Collections.Generic;
using ActivityFeed.DomainModel.Models;
using ActivityFeed.ClientApi;
using Microsoft.Owin.Hosting;
using ActivityFeed.Api;
using ActivityFeed.Messages;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace ActivityFeed.IntegrationTests {

    public class EndToEnd
    {
        [Fact]
        public async Task SendActivityToClientApiAndSeeActivityThroughAPI()
        {
            var client = new ActivityFeedClient();
            var entry = new CreateActivityFeedEntry()
            {
                Title = "this is great",
                Description = "blah blah blah"
            };

            await client.CreateEntryAsync(entry);

            var baseAddress = "http://localhost:6767";
            using (WebApp.Start<Startup>(baseAddress))
            {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(baseAddress);
                var response = httpClient.GetAsync("/api/activities").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                var activities = JsonConvert.DeserializeObject<List<ActivityFeedEntry>>(content);

                Assert.Equal(entry.Title, activities[0].Title);
            }
        }
    }
}
