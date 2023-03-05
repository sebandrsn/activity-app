using ActivityApp.Services;
using Microsoft.AspNetCore.Mvc;
using ActivityApp.Contracts;

namespace ActivityApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HikingTrailController : ControllerBase
    {
        private readonly ICreateHikingTrailService _createHikingTrailService;

        public HikingTrailController(ICreateHikingTrailService createHikingTrailService)
        {
            _createHikingTrailService = createHikingTrailService;
        }

        [HttpPost(Name = "AddHikingTrail")]
        public async Task<ActionResult<HikingTrailRequest>> Add(HikingTrailRequest hikingTrailRequest)
        {
            var hikingTrailService = await _createHikingTrailService.CreateHikingTrail(hikingTrailRequest);

            return Ok(hikingTrailService);
        }
    }
}