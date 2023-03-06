using ActivityApp.Services;
using Microsoft.AspNetCore.Mvc;
using ActivityApp.Contracts;

namespace ActivityApp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HikingTrailController : ControllerBase
    {
        private readonly IHikingTrailService _hikingTrailService;

        public HikingTrailController(IHikingTrailService hikingTrailService)
        {
            _hikingTrailService = hikingTrailService;
        }

        [HttpGet("{id}")]
        [ActionName(nameof(Get))]
        public async Task<ActionResult<HikingTrailResponse>> Get(Guid id)
        {
            var hikingTrail = await _hikingTrailService.GetById(id);
            return hikingTrail;
        }

        [HttpPost]
        public async Task<ActionResult<HikingTrailResponse>> Create(HikingTrailRequest hikingTrailRequest)
        {
            var hikingTrailId = await _hikingTrailService.Create(hikingTrailRequest);
            return CreatedAtAction(
                actionName: nameof(Get), 
                routeValues: new { id = hikingTrailId }, 
                value: hikingTrailId
                );
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<HikingTrailResponse>> Update(Guid id, HikingTrailRequest hikingTrailRequest)
        {
            var hikingTrail = await _hikingTrailService.Update(id, hikingTrailRequest);
            return Ok(hikingTrail);
        }
    }
}