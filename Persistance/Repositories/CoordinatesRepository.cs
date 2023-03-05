using ActivityApp.Application.Contracts;
using ActivityApp.Domain.Entities;

namespace ActivityApp.Persistance.Repositories
{
    internal class CoordinatesRepository : ICoordinatesRepository
    {
        private ActivityAppContext _activityAppContext;

        public CoordinatesRepository(ActivityAppContext activityAppContext)
        {
            _activityAppContext = activityAppContext;
        }

        public async Task<Coordinates> AddAsync(Coordinates entity)
        {
            await _activityAppContext.AddAsync(entity);
            await _activityAppContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Coordinates?> GetByIdAsync(Guid id)
        {
            var coordinates = await _activityAppContext
                .Set<Coordinates>()
                .FindAsync(id);

            return coordinates;
        }
    }
}
