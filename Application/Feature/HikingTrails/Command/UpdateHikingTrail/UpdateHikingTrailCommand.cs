using ActivityApp.Application.Contracts;
using MediatR;

namespace ActivityApp.Application.Feature.HikingTrails.Command.UpdateHikingTrail
{
    public class UpdateHikingTrailCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Length { get; set; }
    }

    public class UpdateHikingTrailCommandHandler : IRequestHandler<UpdateHikingTrailCommand, Guid>
    {
        private readonly IHikingTrailRepository _hikingTrailRepository;

        public UpdateHikingTrailCommandHandler(IHikingTrailRepository hikingTrailRepository)
        {
            _hikingTrailRepository = hikingTrailRepository;
        }

        public async Task<Guid> Handle(UpdateHikingTrailCommand request, CancellationToken cancellationToken)
        {
            var hikingTrail = await _hikingTrailRepository.GetByIdAsync(request.Id);

            //If not found, implement NotFoundException here

            if (hikingTrail != null)
            {
                if (request.Name != null && hikingTrail.Name != request.Name)
                {
                    hikingTrail.Name = request.Name;
                }

                if (request.Longitude != null && hikingTrail.Coordinates.Longitude != request.Longitude)
                {
                    hikingTrail.Coordinates.Longitude = request.Longitude;
                }

                if (request.Latitude != null && hikingTrail.Coordinates.Latitude != request.Latitude)
                {
                    hikingTrail.Coordinates.Latitude = request.Latitude;
                }

                if (request.Length != null && hikingTrail.Length != request.Length)
                {
                    hikingTrail.Length = request.Length;
                }

                await _hikingTrailRepository.UpdateAsync(hikingTrail);
            }

            return hikingTrail.Id;
        }
    }
}
