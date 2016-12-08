using ActivityFeed.Api;
using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;
using Xunit;

namespace ActivityFeed.ApiTests
{
    public class APITests
    {
        [Fact]
        public void API_HelloWorld()
        {
            var baseAddress = "http://localhost:6767";
            using (WebApp.Start<Startup>(baseAddress))
            {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(baseAddress);

                var response = httpClient.GetAsync("/api/hello").Result;
                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;
                Assert.Equal("\"hello world\"", content);
            }

        }
    }
}
