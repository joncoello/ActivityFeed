using Owin;
using System.Web.Http;

namespace ActivityFeed.Api {
    public class Startup
    {
        public void Configuration(IAppBuilder app) {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);
        }
    }
}