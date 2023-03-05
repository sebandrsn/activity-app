using ActivityApp.Services;

namespace ActivityApp
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            services.AddScoped<IHikingTrailService, HikingTrailService>();

            return services;
        }
    }
}
