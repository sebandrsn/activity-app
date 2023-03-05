using ActivityApp.Services;
using Microsoft.AspNetCore.Mvc;
using ActivityApp.Contracts;

namespace ActivityApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HikingTrailController : ControllerBase
    {
        private readonly IHikingTrailService _hikingTrailService;

        public HikingTrailController(IHikingTrailService hikingTrailService)
        {
            _hikingTrailService = hikingTrailService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HikingTrailResponse>> Get(Guid id)
        {
            var hikingTrail = await _hikingTrailService.GetById(id);
            return hikingTrail;
        }

        [HttpPost]
        public async Task<ActionResult<HikingTrailResponse>> Add(HikingTrailRequest hikingTrailRequest)
        {
            var hikingTrail = await _hikingTrailService.Create(hikingTrailRequest);
            return Ok(hikingTrail);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<HikingTrailResponse>> Update(Guid id, HikingTrailRequest hikingTrailRequest)
        {
            var hikingTrail = await _hikingTrailService.Update(id, hikingTrailRequest);
            return Ok(hikingTrail);
        }
    }
}