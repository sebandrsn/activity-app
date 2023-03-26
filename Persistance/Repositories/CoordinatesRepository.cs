using ActivityApp.Application.Contracts;
using ActivityApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ActivityApp.Persistance.Repositories
{
    public class CoordinatesRepository : ICoordinatesRepository
    {
        private readonly ActivityAppContext _dbContext;

        public CoordinatesRepository(ActivityAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Coordinates> AddAsync(Coordinates entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Coordinates entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Coordinates?> GetByIdAsync(Guid id)
        {
            var coordinates = await _dbContext.Coordinates.FindAsync(id);
            return coordinates;
        }

        public async Task<IReadOnlyList<Coordinates>> ListAllAsync()
        {
            var coordinates = await _dbContext.Coordinates.ToListAsync();
            return coordinates;
        }

        public async Task<Coordinates?> UpdateAsync(Coordinates entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
