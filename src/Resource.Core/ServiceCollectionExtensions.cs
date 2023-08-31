using Microsoft.Extensions.DependencyInjection;
using Resource.Abstractions.IProviders;
using Resource.Abstractions.IServices;
using Resource.Core.Providers;
using Resource.Core.Services;
using Yangtao.Hosting.Repository.MySql;

namespace Resource.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddResourceCore(this IServiceCollection services)
        {
            services.AddRepository();

            services.AddScoped<IServerProvider, ServerProvider>();
            services.AddScoped<ISystemProvider, SystemProvider>();
            services.AddScoped<IApplicationProvider, ApplicationProvider>();

            services.AddScoped<IServerService, ServerService>();
            services.AddScoped<ISystemService, SystemService>();
            services.AddScoped<IApplicationService, ApplicationService>();

            return services;
        }
    }
}
