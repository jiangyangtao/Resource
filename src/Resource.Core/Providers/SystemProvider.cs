using Microsoft.EntityFrameworkCore;
using Resource.Core.Abstracts.IProviders;
using Resource.Model;
using Yangtao.Hosting.Extensions;
using Yangtao.Hosting.Repository.Abstractions;

namespace Resource.Core.Providers
{
    internal class SystemProvider : ISystemProvider
    {
        private readonly IEntityRepositoryProvider<Model.System> _systemRepository;

        public SystemProvider(IEntityRepositoryProvider<Model.System> systemRepository)
        {
            _systemRepository = systemRepository;
        }

        public async Task<bool> ExistAsync(string systemCode)
        {
            if (systemCode.IsNullOrEmpty()) return false;

            return await _systemRepository.Get(a => a.SystemCode == systemCode).AnyAsync();
        }

        public async Task<Model.System?> GetSystemAsync(string systemCode)
        {
            if (systemCode.IsNullOrEmpty()) return null;

            return await _systemRepository.Get(a => a.SystemCode == systemCode).FirstOrDefaultAsync();
        }

        public Task<long> GetSystemCountAsync(SystemQueryParams queryParams)
        {
            var query = queryParams.GetSystemQueryable(_systemRepository);
            return query.LongCountAsync();
        }

        public async Task<Model.System[]> GetSystemsAsync(SystemQueryParams queryParams)
        {
            var query = queryParams.GetSystemQueryable(_systemRepository);
            var result = await query.OrderByDescending(a => a.CreateTime).Skip(queryParams.Start).Take(queryParams.Size).ToArrayAsync();
            if (result.IsNullOrEmpty()) return Array.Empty<Model.System>();

            return result;
        }
    }
}
