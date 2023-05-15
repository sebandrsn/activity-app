using ActivityApp.Services;
using Microsoft.AspNetCore.Mvc;
using ActivityApp.Contracts;
using ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailDetail;
using ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailsList;
using ActivityApp.Application.Feature.HikingTrails.Command.CreateHikingTrail;

namespace ActivityApp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HikingTrailController : ControllerBase
    {
        private readonly IHikingTrailService _hikingTrailService;

        public HikingTrailController(IHikingTrailService hikingTrailService)
        {
            _hikingTrailService = hikingTrailService ?? throw new ArgumentNullException(nameof(hikingTrailService));
        }

        [HttpGet("{id:guid}")]
        [ActionName(nameof(Get))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HikingTrailDetailVm>> Get(Guid id)
        {
            var hikingTrail = await _hikingTrailService.GetById(id);
            return hikingTrail;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateHikingTrailCommandResponse>> Create(HikingTrailRequest hikingTrailRequest)
        {
            var createHikingTrailCommandResponse = await _hikingTrailService.Create(hikingTrailRequest);

            if (!createHikingTrailCommandResponse.Success)
            {
                return BadRequest(createHikingTrailCommandResponse);
            }

            return CreatedAtAction(
                actionName: nameof(Get),
                routeValues: new { id = createHikingTrailCommandResponse.HikingTrail.Id },
                value: createHikingTrailCommandResponse
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

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _hikingTrailService.Remove(id);

            return Ok();
        }
    }
}