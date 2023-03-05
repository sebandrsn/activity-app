using ActivityApp.Contracts;

namespace ActivityApp.Services
{
    public interface ICreateHikingTrailService
    {
        public Task<HikingTrailResponse> CreateHikingTrail(HikingTrailRequest hikingTrailRequest);
    }
}
