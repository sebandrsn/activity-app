using ActivityApp.Application.Interfaces;
using ActivityApp.Domain;
using ActivityApp.Domain.Entities;

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
            return await _context.FindAsync<HikingTrail>(id);
        }
    }
}
