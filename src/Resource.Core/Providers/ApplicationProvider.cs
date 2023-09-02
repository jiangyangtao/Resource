using Microsoft.EntityFrameworkCore;
using Resource.Core.Abstracts.IProviders;
using Resource.Model;
using Yangtao.Hosting.Extensions;
using Yangtao.Hosting.Repository.Abstractions;

namespace Resource.Core.Providers
{
    internal class ApplicationProvider : IApplicationProvider
    {
        private readonly IEntityRepositoryProvider<Application> _applicationRepository;

        public ApplicationProvider(IEntityRepositoryProvider<Application> applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public Task<bool> ExistApplicationAsync(string systemCode) => _applicationRepository.Get(a => a.SystemCode == systemCode).AnyAsync();

        public Task<bool> ExistAsync(string applicationCode) => _applicationRepository.Get(a => a.ApplicationCode == applicationCode).AnyAsync();

        public Task<Application?> GetApplicationAsync(string applicationCode) => _applicationRepository.Get(a => a.ApplicationCode == applicationCode).FirstOrDefaultAsync();

        public Task<long> GetApplicationCountAsync(ApplicationQueryParams queryParams)
        {
            var query = queryParams.GetApplicationQueryable(_applicationRepository);
            return query.LongCountAsync();
        }

        public async Task<Application[]> GetApplicationsAsync(ApplicationQueryParams queryParams)
        {
            var query = queryParams.GetApplicationQueryable(_applicationRepository);
            var r = await query.OrderByDescending(a => a.CreateTime).Skip(queryParams.Start).Take(queryParams.Size).ToArrayAsync();
            if (r.IsNullOrEmpty()) return Array.Empty<Application>();

            return r;
        }
    }
}
