using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Resource.Repository.Abstractions;
using System.Reflection;
using Yangtao.Hosting.Extensions;

namespace Resource.Repository
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, string connectionString)
        {
            if (connectionString.IsNullOrEmpty()) throw new ArgumentNullException(connectionString);

            services.AddHttpContextAccessor();

            services.AddDbContext<ResourceDbContext>(options =>
            {
                var serverVersion = ServerVersion.AutoDetect(connectionString);
                options.UseLazyLoadingProxies().UseMySql(connectionString, serverVersion);
            });

            var registerMethod = typeof(ServiceCollectionExtensions).GetMethod(nameof(RegisterRepository), BindingFlags.Static | BindingFlags.NonPublic);
            var entityTypes = ResourceDbContext.GetEntityTypes();
            foreach (var type in entityTypes)
            {
                var method = registerMethod.MakeGenericMethod(type);
                var r = method.GetGenericMethodDefinition();
                method.Invoke(null, new object[] { services });
            }

            return services;
        }

        private static void RegisterRepository<TEntity>(IServiceCollection services) where TEntity : BaseEntity
        {
            services.AddScoped<IRepository<TEntity>, Repository<TEntity>>();
        }
    }
}
