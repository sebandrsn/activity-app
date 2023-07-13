using ActivityApp.Services;

namespace ActivityApp
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IWebHostEnvironment env) 
        {
            services.AddScoped<IHikingTrailService, HikingTrailService>();

            if (env.IsDevelopment())
            {
                services.AddCors(options =>
                {
                    options.AddPolicy("localhost", policy =>
                    {
                        policy
                        .WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
                });
            }

            return services;
        }
    }
}
