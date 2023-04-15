using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ActivityApp.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(conf => conf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
