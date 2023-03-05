using MediatR;
using ActivityApp.Domain.Entities;
using ActivityApp.Application.Feature.HikingTrails.Command;
using ActivityApp.Contracts;

namespace ActivityApp.Services
{
    public class CreateHikingTrailService : ICreateHikingTrailService
    {
        private readonly IMediator _mediator;

        public CreateHikingTrailService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<HikingTrailResponse> CreateHikingTrail(HikingTrailRequest hikingTrailRequest)
        {
            var createHikingTrailCommand = new CreateHikingTrailCommand()
            {
                Name = hikingTrailRequest.Name,
                Coordinates = new Coordinates()
                {
                    Latitude = hikingTrailRequest.Latitude,
                    Longitude = hikingTrailRequest.Longitude
                }
            };

            var hikingTrail = await _mediator.Send(createHikingTrailCommand);

            var hikingTrailResponse = new HikingTrailResponse(
                hikingTrail.Id, 
                hikingTrailRequest.Name,
                hikingTrail.Coordinates.Id,
                hikingTrailRequest.Latitude,
                hikingTrailRequest.Longitude
                );

            return hikingTrailResponse;
        }
    }
}
