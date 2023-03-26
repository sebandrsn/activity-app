using ActivityApp.Application.Contracts;
using ActivityApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ActivityApp.Persistance.Repositories
{
    public class HikingTrailRepository : IHikingTrailRepository
    {
        private ActivityAppContext _dbContext;

        public HikingTrailRepository(ActivityAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HikingTrail> AddAsync(HikingTrail entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(HikingTrail entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<HikingTrail?> GetByIdAsync(Guid id)
        {
            return await _dbContext.HikingTrails
                .Include(ht => ht.Coordinates)
                .FirstOrDefaultAsync(ht => ht.Id == id);
        }

        public async Task<IReadOnlyList<HikingTrail>> ListAllAsync()
        {
            return await _dbContext.HikingTrails.ToListAsync();
        }

        public async Task<HikingTrail?> UpdateAsync(HikingTrail entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
