using ActivityApp.Application.Contracts;
using ActivityApp.Application.DTOs;
using MediatR;

namespace ActivityApp.Application.Feature.HikingTrails.Queries
{
    public class GetHikingTrailDetailQuery : IRequest<HikingTrailDTO>
    {
        public Guid Id { get; set; }
    }

    public class GetHikingTrailDetailQueryHandler : IRequestHandler<GetHikingTrailDetailQuery, HikingTrailDTO>
    {
        private readonly IHikingTrailRepository _hikingTrailRepository;

        public GetHikingTrailDetailQueryHandler(IHikingTrailRepository hikingTrailRepository)
        {
            _hikingTrailRepository = hikingTrailRepository;
        }

        public async Task<HikingTrailDTO> Handle(GetHikingTrailDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _hikingTrailRepository.GetByIdAsync(request.Id);

            if (entity == null)
                throw new Exception(); //create NotFoundException and implement here

            var hikingTrailDTO = new HikingTrailDTO()
            {
                Id = entity.Id,
                Name = entity.Name,
                Coordinates = new CoordinatesDTO() 
                { 
                    Id = entity.Coordinates.Id, 
                    Latitude = entity.Coordinates.Latitude, 
                    Longitude = entity.Coordinates.Longitude
                },
                Length = entity.Length,
            };

            return hikingTrailDTO;
        }
    }
}
