﻿using ActivityApp.Application.Common.Exceptions;
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
        private readonly IMapper _mapper;
        private readonly IHikingTrailRepository _hikingTrailRepository;

        public GetHikingTrailDetailQueryHandler(IHikingTrailRepository hikingTrailRepository, IMapper mapper)
        {
            _mapper = mapper;
            _hikingTrailRepository = hikingTrailRepository;
        }

        public async Task<HikingTrailDetailVm> Handle(GetHikingTrailDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _hikingTrailRepository.GetByIdAsync(request.Id);

            if (entity == null) throw new NotFoundException("Hiking trail", request.Id);

            return _mapper.Map<HikingTrailDetailVm>(entity);
        }
    }
}
