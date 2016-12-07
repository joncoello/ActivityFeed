using ActivityFeed.Domain.Models;
using ActivityFeed.Domain.Repositories;
using ActivityFeed.Domain.Services;
using ActivityFeed.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace ActivityFeed.Api.Api {
    [Route("api/activities")]
    public class ActivitiesController : ApiController
    {
        private ActivityFeedService _service;
        public ActivitiesController(IActivityFeedRepository activityFeedRepository) {
            _service = new ActivityFeedService(activityFeedRepository);
        }

        public ActivitiesController() {
            _service = new ActivityFeedService(new AzureTableStorageRepository());
        }
        public async Task<List<ActivityFeedEntry>> Get() {
            var result = _service.GetAll();
            return result.ToList();
        }
    }
}