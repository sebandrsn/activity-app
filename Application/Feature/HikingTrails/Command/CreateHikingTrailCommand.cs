using ActivityApp.Application.Contracts;
using ActivityApp.Domain.Entities;
using MediatR;

namespace ActivityApp.Application.Feature.HikingTrails.Command
{
    public class CreateHikingTrailCommand : IRequest<Guid>
    {
        public string Name { get; set; } = null!;
        public Address Address { get; set; } = null!;
        public Coordinates Coordinates { get; set; } = null!;
    }

    public class CreateHikingTrailCommandHandler : IRequestHandler<CreateHikingTrailCommand, Guid>
    {
        private readonly IHikingTrailRepository _hikingTrailRepository;
        public CreateHikingTrailCommandHandler(IHikingTrailRepository hikingTrailRepository)
        {
            _hikingTrailRepository = hikingTrailRepository;
        }
        public async Task<Guid> Handle(CreateHikingTrailCommand request, CancellationToken cancellationToken)
        {
            var hikingTrail = new HikingTrail()
            {
                Name = request.Name,
                Coordinates = request.Coordinates
            };

            var entity = await _hikingTrailRepository.AddAsync(hikingTrail);

            //implement unit of work pattern

            return entity.Id;
        }
    }
}
