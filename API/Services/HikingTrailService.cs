using MediatR;
using ActivityApp.Domain.Entities;
using ActivityApp.Contracts;
using ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailDetail;
using ActivityApp.Application.Feature.HikingTrails.Command.CreateHikingTrail;
using ActivityApp.Application.Feature.HikingTrails.Command.UpdateHikingTrail;
using ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailsList;
using ActivityApp.Application.Feature.HikingTrails.Command.RemoveHikingTrail;

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
            var query = new GetHikingTrailDetailQuery()
            {
                Id = Id
            };
            var hikingTrailDetailVm = await _mediator.Send(query);

            return hikingTrailDetailVm;
        }

        public async Task<CreateHikingTrailCommandResponse> Create(HikingTrailRequest hikingTrailRequest)
        {
            var command = new CreateHikingTrailCommand()
            {
                Name = hikingTrailRequest.Name,
                Coordinates = new Coordinates()
                {
                    Latitude = hikingTrailRequest.Latitude,
                    Longitude = hikingTrailRequest.Longitude
                },
                Length = hikingTrailRequest.Length,
                Description = hikingTrailRequest.Description
            };

            var createHikingTrailCommandResponse = await _mediator.Send(command);

            return createHikingTrailCommandResponse;
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
            var query = new GetHikingTrailsListQuery();
            var hikingTrails = await _mediator.Send(query);

            return hikingTrails;
        }

        public async Task Remove(Guid id)
        {
            var command = new RemoveHikingTrailCommand()
            {
                Id = id
            };

            await _mediator.Send(command);
        }
    }
}
