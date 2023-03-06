using ActivityApp.Application.Contracts;
using ActivityApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ActivityApp.Persistance.Repositories
{
    public class HikingTrailRepository : IHikingTrailRepository
    {
        private ActivityAppContext _context;

        public HikingTrailRepository(ActivityAppContext context)
        {
            _context = context;
        }

        public async Task<HikingTrail> AddAsync(HikingTrail entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<HikingTrail?> GetByIdAsync(Guid id)
        {
            return await _context.HikingTrails
                .Include(ht => ht.Coordinates)
                .FirstOrDefaultAsync(ht => ht.Id == id);
        }

        public async Task<HikingTrail?> UpdateAsync(HikingTrail entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
