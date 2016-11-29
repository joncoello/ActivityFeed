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
using System.Diagnostics;

namespace ActivityFeed.IntegrationTests {

    public class EndToEnd 
    {
        [Fact]
        public async Task SendActivityToClientApiAndSeeActivityThroughAPI()
        {
            var client = new ActivityFeedClient();
            var entry = new NewsActivityFeed {
                Title = "News feed 1",
                Description = "This is news feed 1"
            };
            await client.SendAsync(entry);

            var p = Process.Start("ActivityFeed.Console.exe", "-exitNoMessage");
            p.WaitForExit();
            

            var baseAddress = "http://localhost:6767";
            using (WebApp.Start<Startup>(baseAddress))
            {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(baseAddress);
                var response = httpClient.GetAsync("/api/activities").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                var activities = JsonConvert.DeserializeObject<List<ActivityFeedEntry>>(content);
                
                Assert.Equal(1, activities.Count);
            }
        }
    }
}
