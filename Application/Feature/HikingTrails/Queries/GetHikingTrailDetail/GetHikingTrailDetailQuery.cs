using ActivityApp.Application.Contracts;
using MediatR;

namespace ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailDetail
{
    public class GetHikingTrailDetailQuery : IRequest<HikingTrailDetailVm>
    {
        public Guid Id { get; set; }
    }

    public class GetHikingTrailDetailQueryHandler : IRequestHandler<GetHikingTrailDetailQuery, HikingTrailDetailVm>
    {
        private readonly IHikingTrailRepository _hikingTrailRepository;

        public GetHikingTrailDetailQueryHandler(IHikingTrailRepository hikingTrailRepository)
        {
            _hikingTrailRepository = hikingTrailRepository;
        }

        public async Task<HikingTrailDetailVm> Handle(GetHikingTrailDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _hikingTrailRepository.GetByIdAsync(request.Id);

            if (entity == null)
                throw new Exception(); //create NotFoundException and implement here

            var hikingTrailDTO = new HikingTrailDetailVm()
            {
                HikingTrailId = entity.Id,
                Name = entity.Name,
                Coordinates = new CoordinatesDto()
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
