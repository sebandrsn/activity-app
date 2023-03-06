using MediatR;
using ActivityApp.Domain.Entities;
using ActivityApp.Application.Feature.HikingTrails.Command;
using ActivityApp.Contracts;
using ActivityApp.Application.Feature.HikingTrails.Queries;
using ActivityApp.Application.DTOs;

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

            var hikingTrailResponse = new HikingTrailResponse()
            {
                HikingTrailId = hikingTrailDTO.Id,
                Name = hikingTrailDTO.Name,
                CoordinatesId = hikingTrailDTO.Coordinates.Id,
                Latitude = hikingTrailDTO.Coordinates.Latitude,
                Longitude = hikingTrailDTO.Coordinates.Longitude,
                Length = hikingTrailDTO.Length
            };

            return hikingTrailResponse;
        }

        public async Task<Guid> Create(HikingTrailRequest hikingTrailRequest)
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

            var hikingTrailId = await _mediator.Send(command);

            return hikingTrailId;
        }

        public async Task<HikingTrailResponse> Update(Guid id, HikingTrailRequest hikingTrailRequest)
        {
            var hikingTrailDTO = new HikingTrailDTO()
            {
                Id = id,
                Name = hikingTrailRequest.Name,
                Coordinates = new CoordinatesDTO()
                {
                    Latitude = hikingTrailRequest.Latitude,
                    Longitude = hikingTrailRequest.Longitude
                },
                Length = hikingTrailRequest.Length
            };

            var command = new UpdateHikingTrailCommand()
            {
                HikingTrailDTO = hikingTrailDTO
            };

            await _mediator.Send(command);

            return new HikingTrailResponse(
                hikingTrailDTO.Id,
                hikingTrailDTO.Name,
                hikingTrailDTO.Coordinates.Id,
                hikingTrailDTO.Coordinates.Latitude,
                hikingTrailDTO.Coordinates.Longitude,
                hikingTrailDTO.Length
                );

        }
    }
}
