using ActivityApp.Application.Contracts;
using MediatR;

namespace ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailsList
{
    public class GetHikingTrailsListQuery : IRequest<List<HikingTrailListVm>>
    {
    }

    public class GetHikingTrailsListQueryHandler : IRequestHandler<GetHikingTrailsListQuery, List<HikingTrailListVm>>
    {
        private readonly IHikingTrailRepository _hikingTrailRepository;

        public GetHikingTrailsListQueryHandler(IHikingTrailRepository hikingTrailRepository)
        {
            _hikingTrailRepository = hikingTrailRepository;
        }
        public async Task<List<HikingTrailListVm>> Handle(GetHikingTrailsListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _hikingTrailRepository.ListAllAsync();
            var hikingTrails = new List<HikingTrailListVm>();

            foreach (var entity in entities)
            {
                var trail = new HikingTrailListVm()
                {
                    HikingTrailId = entity.Id,
                    Name = entity.Name
                };
                hikingTrails.Add(trail);
            }

            return hikingTrails;
        }
    }
}
