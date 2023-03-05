using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ActivityApp.Application.Interfaces;
using ActivityApp.Persistance.Repositories;

namespace ActivityApp.Persistance
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<ActivityAppContext>(options => 
                options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ActivityApp;"));
            services.AddScoped<IResortRepository, ResortRepository>();

            return services;
        }
    }
}
