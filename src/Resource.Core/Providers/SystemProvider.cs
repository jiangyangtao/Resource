using Microsoft.EntityFrameworkCore;
using Resource.Abstractions.IProviders;
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

        public Task<long> GetSystemCountAsync(string systemCode, string systemName)
        {
            var query = GetSystemQuery(systemCode, systemName);
            return query.LongCountAsync();
        }

        public async Task<Model.System[]> GetSystemsAsync(string systemCode, string systemName, int start, int size)
        {
            var query = GetSystemQuery(systemCode, systemName);
            var result = await query.OrderByDescending(a => a.CreateTime).Skip(start).Take(size).ToArrayAsync();
            if (result.IsNullOrEmpty()) return Array.Empty<Model.System>();

            return result;
        }

        private IQueryable<Model.System> GetSystemQuery(string systemCode, string systemName)
        {
            var query = _systemRepository.Get();
            if (systemCode.NotNullAndEmpty()) query = query.Where(a => EF.Functions.Like(a.SystemCode, $"%{systemCode}%"));
            if (systemName.NotNullAndEmpty()) query = query.Where(a => EF.Functions.Like(a.SystemName, $"%{systemName}%"));

            return query;
        }
    }
}
