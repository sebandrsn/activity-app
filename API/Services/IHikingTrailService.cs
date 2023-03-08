using ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailDetail;
using ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailsList;
using ActivityApp.Contracts;

namespace ActivityApp.Services
{
    public interface IHikingTrailService
    {
        public Task<HikingTrailDetailVm> GetById(Guid Id);
        public Task<Guid> Create(HikingTrailRequest hikingTrailRequest);
        public Task<Guid> Update(Guid id, HikingTrailRequest hikingTrailRequest);
        public Task<List<HikingTrailListVm>> ListAll();
    }
}
