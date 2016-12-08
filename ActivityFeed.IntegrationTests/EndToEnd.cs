using System;
using System.Net.Http;
using System.Collections.Generic;
using ActivityFeed.Domain.Models;
using ActivityFeed.ClientApi;
using Microsoft.Owin.Hosting;
using ActivityFeed.Api;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;
using System.Diagnostics;
using ActivityFeed.Domain.Messages;

namespace ActivityFeed.IntegrationTests {

    public class EndToEnd 
    {

        [Fact]
        public async Task IntegrationTests_HappyPath() {
            var client = new ActivityFeedClient();
            var entry = new CreateActivityFeed {
                Title = "create feed",
                Description = "create feed",
            };

            await client.SendAsync(entry);

            var p = Process.Start("ActivityFeed.Console.exe", "-exitNoMessage");
            p.WaitForExit();


            var baseAddress = "http://localhost:6767";
            using (WebApp.Start<Startup>(baseAddress)) {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(baseAddress);
                var response = httpClient.GetAsync("/api/activities").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                var activities = JsonConvert.DeserializeObject<List<ActivityFeedEntry>>(content);

                Assert.Equal(1, activities.Count);
                Assert.Equal(entry.Title, activities[0].Title);
                Assert.Equal(entry.Description, activities[0].Description);
            }
        }
    }
}
