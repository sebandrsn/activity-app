using ActivityApp.Services;
using Microsoft.AspNetCore.Mvc;
using ActivityApp.Contracts;
using ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailDetail;
using ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailsList;

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
        public async Task<ActionResult<HikingTrailDetailVm>> Get(Guid id)
        {
            var hikingTrail = await _hikingTrailService.GetById(id);
            return hikingTrail;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(HikingTrailRequest hikingTrailRequest)
        {
            var hikingTrailId = await _hikingTrailService.Create(hikingTrailRequest);
            return CreatedAtAction(
                actionName: nameof(Get), 
                routeValues: new { id = hikingTrailId }, 
                value: hikingTrailId
                );
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> Update(Guid id, HikingTrailRequest hikingTrailRequest)
        {
            var hikingTrail = await _hikingTrailService.Update(id, hikingTrailRequest);
            return Ok(hikingTrail);
        }

        [HttpGet]
        public async Task<ActionResult<List<HikingTrailListVm>>> ListAll()
        {
            var hikingTrails = await _hikingTrailService.ListAll();
            return Ok(hikingTrails);
        }
    }
}