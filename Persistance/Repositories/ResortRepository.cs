using ActivityApp.Application.Interfaces;
using ActivityApp.Domain;

namespace ActivityApp.Persistance.Repositories
{
    public class ResortRepository : IResortRepository
    {
        private ActivityAppContext _context;

        public ResortRepository(ActivityAppContext context)
        {
            _context = context;
        }

        public async Task<Resort> AddAsync(Resort entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Resort?> GetByIdAsync(Guid id)
        {
            return await _context.FindAsync<Resort>(id);
        }
    }
}
