using ActivityApp.Services;
using Microsoft.AspNetCore.Mvc;
using ActivityApp.Api.Models;

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
        public async Task<ActionResult<HikingTrailModel>> Add([FromBody] HikingTrailModel hikingTrailModel)
        {
            var hikingTrailService = await _createHikingTrailService.CreateHikingTrail(hikingTrailModel);

            return Ok(hikingTrailService);
        }
    }
}