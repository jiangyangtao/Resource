using Microsoft.EntityFrameworkCore;
using Resource.Core.Abstracts.IProviders;
using Resource.Model;
using Yangtao.Hosting.Extensions;
using Yangtao.Hosting.Repository.Abstractions;
using Environment = Resource.Model.Environment;

namespace Resource.Core.Providers
{
    internal class EnvironmentProvider : IEnvironmentProvider
    {
        private readonly IEntityRepositoryProvider<Environment> _environmentRepository;
        private readonly IServerProvider _serverProvider;

        public EnvironmentProvider(
            IEntityRepositoryProvider<Environment> environmentRepository,
            IServerProvider serverProvider)
        {
            _environmentRepository = environmentRepository;
            _serverProvider = serverProvider;
        }

        public async Task<bool> ExistAsync(string environmentCode)
        {
            if (environmentCode.IsNullOrEmpty()) return false;

            return await _environmentRepository.Get(a => a.EnvironmentCode == environmentCode).AnyAsync();
        }

        public Task<Environment?> GetEnvironmentAsync(string environmentCode)
        {
            if (environmentCode.IsNullOrEmpty()) return null;

            return _environmentRepository.Get(a => a.EnvironmentCode == environmentCode).FirstOrDefaultAsync();
        }

        public Task<long> GetEnvironmentCountAsync(EnvironmentQueryParams queryParams)
        {
            var query = queryParams.GetEnvironmentQueryable(_environmentRepository);
            return query.LongCountAsync();
        }

        public async Task<Environment[]> GetEnvironmentsAsync(EnvironmentQueryParams queryParams)
        {
            var query = queryParams.GetEnvironmentQueryable(_environmentRepository);
            var r = await query.OrderByDescending(a => a.CreateTime).Skip(queryParams.Start).Take(queryParams.Size).ToArrayAsync();
            if (r.IsNullOrEmpty()) return Array.Empty<Environment>();

            return r;
        }
    }
}
