using ActivityApp.Application.Feature.HikingTrails.Command.CreateHikingTrail;
using ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailDetail;
using ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailsList;
using ActivityApp.Contracts;

namespace ActivityApp.Services
{
    public interface IHikingTrailService
    {
        public Task<HikingTrailDetailVm> GetById(Guid Id);
        public Task<CreateHikingTrailCommandResponse> Create(HikingTrailRequest hikingTrailRequest);
        public Task<Guid> Update(Guid id, HikingTrailRequest hikingTrailRequest);
        public Task<List<HikingTrailListVm>> ListAll();
        public Task Remove(Guid id);
    }
}
