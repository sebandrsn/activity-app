using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ActivityApp.Persistance.Repositories;
using ActivityApp.Application.Contracts;
using Microsoft.Extensions.Configuration;

namespace ActivityApp.Persistance
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ActivityApp");
            services.AddDbContext<ActivityAppContext>(options => 
                options.UseNpgsql(connectionString));

            services.AddScoped<IHikingTrailRepository, HikingTrailRepository>();
            services.AddScoped<ICoordinatesRepository, CoordinatesRepository>();

            return services;
        }
    }
}
