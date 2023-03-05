using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ActivityApp.Persistance.Repositories;
using ActivityApp.Application.Contracts;

namespace ActivityApp.Persistance
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<ActivityAppContext>(options => 
                options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ActivityApp;"));

            services.AddScoped<IHikingTrailRepository, HikingTrailRepository>();
            services.AddScoped<ICoordinatesRepository, CoordinatesRepository>();

            return services;
        }
    }
}
