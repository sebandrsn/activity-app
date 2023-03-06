using ActivityApp.Application.Contracts;
using ActivityApp.Application.DTOs;
using MediatR;

namespace ActivityApp.Application.Feature.HikingTrails.Command
{
    public class UpdateHikingTrailCommand : IRequest<Guid>
    {
        public HikingTrailDTO HikingTrailDTO { get; set; }
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
            var hikingTrail = await _hikingTrailRepository.GetByIdAsync(request.HikingTrailDTO.Id);

            //If not found, implement NotFoundException here

            if (hikingTrail != null)
            {
                if (request.HikingTrailDTO.Name != null && hikingTrail.Name != request.HikingTrailDTO.Name)
                {
                    hikingTrail.Name = request.HikingTrailDTO.Name;
                }

                if (request.HikingTrailDTO.Coordinates.Longitude != null && hikingTrail.Coordinates.Longitude != request.HikingTrailDTO.Coordinates.Longitude)
                {
                    hikingTrail.Coordinates.Longitude = request.HikingTrailDTO.Coordinates.Longitude;
                }

                if (request.HikingTrailDTO.Coordinates.Latitude != null && hikingTrail.Coordinates.Latitude != request.HikingTrailDTO.Coordinates.Latitude)
                {
                    hikingTrail.Coordinates.Latitude = request.HikingTrailDTO.Coordinates.Latitude;
                }

                if (request.HikingTrailDTO.Length != null && hikingTrail.Length != request.HikingTrailDTO.Length)
                {
                    hikingTrail.Length = request.HikingTrailDTO.Length;
                }

                await _hikingTrailRepository.UpdateAsync(hikingTrail);
            }
            
            return hikingTrail.Id;
        }
    }
}
