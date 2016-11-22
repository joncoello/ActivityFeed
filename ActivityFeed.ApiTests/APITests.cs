using ActivityFeed.Api;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ActivityFeed.ApiTests
{
    public class APITests
    {

        [Fact]
        public void API_CanConnect()
        {

            var baseAddress = "http://localhost:6767";

            using (WebApp.Start<Startup>(baseAddress))
            {

            }

        }

        [Fact]
        public void API_HelloWorld_Get()
        {

            var baseAddress = "http://localhost:6767";

            using (WebApp.Start<Startup>(baseAddress))
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);

                    var response = client.GetAsync("/api/hello").Result;

                    response.EnsureSuccessStatusCode();

                }
            }

        }

    }
}
