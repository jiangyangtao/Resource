﻿using Microsoft.Extensions.DependencyInjection;
using Resource.Core.Abstracts.IProviders;
using Resource.Core.Abstracts.IServices;
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
            services.AddScoped<IDeployeProvider, DeployeProvider>();
            services.AddScoped<IEnvironmentProvider, EnvironmentProvider>();
            services.AddScoped<IApplicationProvider, ApplicationProvider>();

            services.AddScoped<IServerService, ServerService>();
            services.AddScoped<ISystemService, SystemService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IEnvironmentService, EnvironmentService>();

            return services;
        }
    }
}
