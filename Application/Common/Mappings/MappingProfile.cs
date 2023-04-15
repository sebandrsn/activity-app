using ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailDetail;
using ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailsList;
using ActivityApp.Domain.Entities;
using AutoMapper;

namespace ActivityApp.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HikingTrail, HikingTrailDetailVm>().ReverseMap();
            CreateMap<HikingTrail, HikingTrailListVm>().ReverseMap();
            CreateMap<Coordinates, CoordinatesDto>().ReverseMap();
        }
    }
}
