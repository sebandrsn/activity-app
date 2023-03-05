using ActivityApp.Contracts;

namespace ActivityApp.Services
{
    public interface IHikingTrailService
    {
        public Task<HikingTrailResponse> GetById(Guid Id);
        public Task<HikingTrailResponse> Create(HikingTrailRequest hikingTrailRequest);
        public Task<HikingTrailResponse> Update(Guid id, HikingTrailRequest hikingTrailRequest);
    }
}
