using ActivityApp.Api.Models;

namespace ActivityApp.Services
{
    public interface ICreateResortService
    {
        public Task<ResortModel> CreateResort(ResortModel resortModel);
    }
}
