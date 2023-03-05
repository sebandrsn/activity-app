using MediatR;
using ActivityApp.Domain.Entities;
using ActivityApp.Application.Feature.HikingTrails.Command;
using ActivityApp.Contracts;
using ActivityApp.Application.Feature.HikingTrails.Queries;

namespace ActivityApp.Services
{
    public class HikingTrailService : IHikingTrailService
    {
        private readonly IMediator _mediator;

        public HikingTrailService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<HikingTrailResponse> GetById(Guid Id)
        {
            var command = new GetHikingTrailDetailQuery()
            {
                Id = Id
            };

            var hikingTrailDTO = await _mediator.Send(command);

            var hikingTrailResponse = new HikingTrailResponse(
                hikingTrailDTO.Id,
                hikingTrailDTO.Name,
                hikingTrailDTO.Coordinates.Id,
                hikingTrailDTO.Coordinates.Latitude,
                hikingTrailDTO.Coordinates.Longitude);
            return hikingTrailResponse;
        }

        public async Task<HikingTrailResponse> Create(HikingTrailRequest hikingTrailRequest)
        {
            var command = new CreateHikingTrailCommand()
            {
                Name = hikingTrailRequest.Name,
                Coordinates = new Coordinates()
                {
                    Latitude = hikingTrailRequest.Latitude,
                    Longitude = hikingTrailRequest.Longitude
                }
            };

            var hikingTrail = await _mediator.Send(command);

            var hikingTrailResponse = new HikingTrailResponse(
                hikingTrail.Id, 
                hikingTrailRequest.Name,
                hikingTrail.Coordinates.Id,
                hikingTrailRequest.Latitude,
                hikingTrailRequest.Longitude
                );

            return hikingTrailResponse;
        }

        public Task<HikingTrailResponse> Update(Guid id, HikingTrailRequest hikingTrailRequest)
        {
            throw new NotImplementedException();
        }
    }
}
