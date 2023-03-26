using ActivityApp.Application.Contracts;
using MediatR;

namespace ActivityApp.Application.Feature.HikingTrails.Command.RemoveHikingTrail
{
    public class RemoveHikingTrailCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class RemoveHikingTrailCommandHandler : IRequestHandler<RemoveHikingTrailCommand>
    {
        private readonly IHikingTrailRepository _hikingTrailRepository;
        private readonly ICoordinatesRepository _coordinatesRepository;

        public RemoveHikingTrailCommandHandler(IHikingTrailRepository hikingTrailRepository, ICoordinatesRepository coordinatesRepository)
        {
            _hikingTrailRepository = hikingTrailRepository;
            _coordinatesRepository = coordinatesRepository;
        }
        public async Task Handle(RemoveHikingTrailCommand request, CancellationToken cancellationToken)
        {
            var hikingTrail = await _hikingTrailRepository.GetByIdAsync(request.Id);

            //if null throw not found exception

            await _hikingTrailRepository.DeleteAsync(hikingTrail);
            await _coordinatesRepository.DeleteAsync(hikingTrail.Coordinates);
        }
    }
}
