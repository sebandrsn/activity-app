using MediatR;
using ActivityApp.Domain.Entities;
using ActivityApp.Contracts;
using ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailDetail;
using ActivityApp.Application.Feature.HikingTrails.Command.CreateHikingTrail;
using ActivityApp.Application.Feature.HikingTrails.Command.UpdateHikingTrail;
using ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailsList;

namespace ActivityApp.Services
{
    public class HikingTrailService : IHikingTrailService
    {
        private readonly IMediator _mediator;

        public HikingTrailService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<HikingTrailDetailVm> GetById(Guid Id)
        {
            var command = new GetHikingTrailDetailQuery()
            {
                Id = Id
            };
            var hikingTrailDetailVm = await _mediator.Send(command);

            return hikingTrailDetailVm;
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

        public async Task<Guid> Update(Guid id, HikingTrailRequest hikingTrailRequest)
        {
            var command = new UpdateHikingTrailCommand()
            {
                Id = id, 
                Name = hikingTrailRequest.Name,
                Latitude = hikingTrailRequest.Latitude,
                Longitude= hikingTrailRequest.Longitude,
                Length = hikingTrailRequest.Length
            };

            var hikingTrailGuid = await _mediator.Send(command);

            return hikingTrailGuid;
        }

        public async Task<List<HikingTrailListVm>> ListAll()
        {
            var command = new GetHikingTrailsListQuery();
            var hikingTrails = await _mediator.Send(command);

            return hikingTrails;
        }
    }
}
