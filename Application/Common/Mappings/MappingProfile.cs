using ActivityApp.Application.Feature.HikingTrails.Command.CreateHikingTrail;
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
            CreateMap<HikingTrail, HikingTrailDetailVm>();
            CreateMap<HikingTrail, HikingTrailListVm>();
            CreateMap<HikingTrail, HikingTrailDto>();
            CreateMap<HikingTrail, CreateHikingTrailCommand>().ReverseMap();

            CreateMap<Coordinates, CoordinatesDto>();
        }
    }
}
