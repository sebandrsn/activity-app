using MediatR;
using ActivityApp.Api.Models;
using ActivityApp.Domain.Entities;
using ActivityApp.Application.Feature.HikingTrails.Command;

namespace ActivityApp.Services
{
    public class CreateHikingTrailService : ICreateHikingTrailService
    {
        private readonly IMediator _mediator;

        public CreateHikingTrailService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<HikingTrailModel> CreateHikingTrail(HikingTrailModel hikingTrailModel)
        {
            var command = new CreateHikingTrailCommand()
            {
                Name = hikingTrailModel.Name,
                Coordinates = new Coordinates()
                {
                    Latitude = hikingTrailModel.Coordinates.Latitude,
                    Longitude = hikingTrailModel.Coordinates.Longitude
                }
            };

            var hikingTrailId = await _mediator.Send(command);
            hikingTrailModel.Id = hikingTrailId;

            return hikingTrailModel;
        }
    }
}
