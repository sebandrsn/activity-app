using ActivityApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace ActivityApp.Persistance
{
    public class ActivityAppContext : DbContext
    {
        public ActivityAppContext(DbContextOptions<ActivityAppContext> options) : base(options)
        { }

        public DbSet<Resort> Resorts { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
