using ActivityFeed.Domain.Models;
using ActivityFeed.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace ActivityFeed.Api.Api {
    [Route("api/activities")]
    public class ActivitiesController : ApiController
    {
        private ActivityFeedService _service;

        public ActivitiesController() {
            _service = new ActivityFeedService();
        }
        public async Task<List<ActivityFeedEntry>> Get() {
            var result = _service.GetAll();
            return result.ToList();
        }
    }
}