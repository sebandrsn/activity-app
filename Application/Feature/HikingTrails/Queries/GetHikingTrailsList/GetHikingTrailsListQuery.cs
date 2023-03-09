using ActivityApp.Application.Contracts;
using ActivityApp.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailsList
{
    public class GetHikingTrailsListQuery : IRequest<List<HikingTrailListVm>>
    {
    }

    public class GetHikingTrailsListQueryHandler : IRequestHandler<GetHikingTrailsListQuery, List<HikingTrailListVm>>
    {
        private readonly IHikingTrailRepository _hikingTrailRepository;
        private readonly IMapper _mapper;

        public GetHikingTrailsListQueryHandler(IHikingTrailRepository hikingTrailRepository, IMapper mapper)
        {
            _hikingTrailRepository = hikingTrailRepository;
            _mapper = mapper;
        }
        public async Task<List<HikingTrailListVm>> Handle(GetHikingTrailsListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _hikingTrailRepository.ListAllAsync();
            return _mapper.Map<IReadOnlyList<HikingTrail>, List<HikingTrailListVm>>(entities);
        }
    }
}
