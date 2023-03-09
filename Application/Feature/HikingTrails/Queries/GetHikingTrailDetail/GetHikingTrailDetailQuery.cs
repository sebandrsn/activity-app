using ActivityApp.Application.Contracts;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetHikingTrailDetailQueryHandler(IHikingTrailRepository hikingTrailRepository, IMapper mapper)
        {
            _hikingTrailRepository = hikingTrailRepository;
            _mapper = mapper;
        }

        public async Task<HikingTrailDetailVm> Handle(GetHikingTrailDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _hikingTrailRepository.GetByIdAsync(request.Id);

            if (entity == null)
                throw new Exception(); //create NotFoundException and implement here

            return _mapper.Map<HikingTrailDetailVm>(entity); ;
        }
    }
}
