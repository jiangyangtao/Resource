using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore;
using Resource.Repository.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Yangtao.Hosting.Extensions;

namespace Resource.Repository
{
    internal class ResourceDbContext : DbContext
    {
        public ResourceDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var types = GetEntityTypes();
            foreach (var t in types)
            {
                if (t.IsAbstract) continue;

                var r = modelBuilder.Entity(t);

                var tableAttribute = t.GetCustomAttribute<TableAttribute>();
                if (tableAttribute != null) r.ToTable(tableAttribute.Name);
            }

            base.OnModelCreating(modelBuilder);
        }

        public static Type[] GetEntityTypes()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var modelType = typeof(BaseEntity);
            var entityTypes = assemblies.SelectMany(assemblie => assemblie.GetTypes().Where(t => t.BaseType != null && t.BaseType == modelType)).ToArray();
            return entityTypes.Where(a => a.HasInterface<IProxyTargetAccessor>() == false).ToArray();  // 去除懒加载创建的实体代理
        }
    }
}
