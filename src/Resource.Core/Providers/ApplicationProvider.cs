using Microsoft.EntityFrameworkCore;
using Resource.Abstractions.IProviders;
using Resource.Model;
using Yangtao.Hosting.Extensions;
using Yangtao.Hosting.Repository.Abstractions;

namespace Resource.Core.Providers
{
    internal class ApplicationProvider : IApplicationProvider
    {
        private readonly IEntityRepositoryProvider<Application> _applicationRepository;
        private readonly ISystemProvider _systemProvider;

        public ApplicationProvider(IEntityRepositoryProvider<Application> applicationRepository, ISystemProvider systemProvider)
        {
            _applicationRepository = applicationRepository;
            _systemProvider = systemProvider;
        }

        public async Task<bool> ExistApplicationAsync(string systemCode)
        {
            return await _applicationRepository.Get(a => a.SystemCode == systemCode).AnyAsync();
        }

        public async Task<bool> ExistAsync(string applicationCode)
        {
            return await _applicationRepository.Get(a => a.ApplicationCode == applicationCode).AnyAsync();
        }

        public async Task<Application?> GetApplicationAsync(string applicationCode)
        {
            var application = await _applicationRepository.Get(a => a.ApplicationCode == applicationCode).FirstOrDefaultAsync();
            if (application == null) return null;

            return application;
        }

        public Task<long> GetApplicationCountAsync(ApplicationQueryParams queryParams)
        {
            var query = GetApplicateionQueryable(queryParams);
            return query.LongCountAsync();
        }

        public async Task<Application[]> GetApplicationsAsync(ApplicationQueryParams queryParams)
        {
            var query = GetApplicateionQueryable(queryParams);
            var r = await query.OrderByDescending(a => a.CreateTime).Skip(queryParams.Start).Take(queryParams.Size).ToArrayAsync();
            if (r.IsNullOrEmpty()) return Array.Empty<Application>();

            return r;
        }

        private IQueryable<Application> GetApplicateionQueryable(ApplicationQueryParams queryParams)
        {
            var query = _applicationRepository.Get();
            if (queryParams.SystemCode.NotNullAndEmpty()) query = query.Where(a => a.SystemCode == queryParams.SystemCode);
            if (queryParams.ApplicationCode.NotNullAndEmpty()) query = query.Where(a => EF.Functions.Like(a.ApplicationCode, $"%{queryParams.ApplicationCode}%"));
            if (queryParams.SystemCode.NotNullAndEmpty()) query = query.Where(a => EF.Functions.Like(a.ApplicationName, $"%{queryParams.ApplicationName}%"));

            return query;
        }
    }
}
