using ActivityApp.Api.Models;

namespace ActivityApp.Services
{
    public interface ICreateHikingTrailService
    {
        public Task<HikingTrailModel> CreateHikingTrail(HikingTrailModel hikingTrailModel);
    }
}
