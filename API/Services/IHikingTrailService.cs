using ActivityApp.Contracts;

namespace ActivityApp.Services
{
    public interface IHikingTrailService
    {
        public Task<HikingTrailResponse> GetById(Guid Id);
        public Task<Guid> Create(HikingTrailRequest hikingTrailRequest);
        public Task<Guid> Update(Guid id, HikingTrailRequest hikingTrailRequest);
    }
}
