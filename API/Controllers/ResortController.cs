using ActivityApp.Services;
using Microsoft.AspNetCore.Mvc;
using ActivityApp.Api.Models;

namespace ActivityApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResortController : ControllerBase
    {
        private readonly ICreateResortService _createResortService;

        public ResortController(ICreateResortService createResortService)
        {
            _createResortService = createResortService;
        }

        [HttpPost(Name = "AddResort")]
        public async Task<ActionResult<ResortModel>> Add([FromBody] ResortModel resortModel)
        {
            var resortService = await _createResortService.CreateResort(resortModel);

            return Ok(resortService);
        }
    }
}