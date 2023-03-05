using ActivityApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ActivityApp.Persistance
{
    public class ActivityAppContext : DbContext
    {
        public ActivityAppContext(DbContextOptions<ActivityAppContext> options) : base(options)
        { }

        public DbSet<HikingTrail> HikingTrails { get; set; }
        public DbSet<MountainbikeTrail> MountainbikeTrails { get; set; }
        public DbSet<CampingSpot> CampingSpots { get; set; }
        public DbSet<Coordinates> Coordinates { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
