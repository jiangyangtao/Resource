using Resource.Core.Abstracts.IProviders;
using Resource.Core.Abstracts.IServices;
using Yangtao.Hosting.Core.HttpErrorResult;
using Yangtao.Hosting.Extensions;
using Yangtao.Hosting.Repository.Abstractions;

namespace Resource.Core.Services
{
    internal class SystemService : ISystemService
    {
        private readonly IEntityRepositoryProvider<Model.System> _systemRepository;
        private readonly ISystemProvider _systemProvider;
        private readonly IApplicationProvider _applicationProvider;

        public SystemService(IEntityRepositoryProvider<Model.System> systemRepository, ISystemProvider systemProvider)
        {
            _systemRepository = systemRepository;
            _systemProvider = systemProvider;
        }

        public async Task AddAsymc(Model.System system)
        {
            var exist = await _systemProvider.ExistAsync(system.SystemCode);
            if (exist) HttpErrorResult.ResponseBadRequest($"{system.SystemCode} already exist");

            await _systemRepository.AddAsync(system);
        }

        public async Task RemoveAsync(string systemCode)
        {
            if (systemCode.IsNullOrEmpty()) return;

            var existApplication = await _applicationProvider.ExistApplicationAsync(systemCode);
            if (existApplication) HttpErrorResult.ResponseConflict($"{systemCode} is still in application use");

            await _systemRepository.DeleteIfExistAsync(a => a.SystemCode == systemCode);
        }

        public async Task UpdateAsymc(Model.System system)
        {
            await _systemRepository.UpdateIfExistAsync(a => a.SystemCode == system.SystemCode, a =>
            {
                a.SystemName = system.SystemName;
                a.HomePage = system.HomePage;
                a.Description = system.Description;
            });
        }
    }
}
