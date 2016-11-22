using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ActivityFeed.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app) {

            var config = new HttpConfiguration();

            // web api
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);

        }
    }
}