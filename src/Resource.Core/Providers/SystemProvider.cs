using Resource.Abstractions.IProviders;
using Yangtao.Hosting.Repository.Abstractions;

namespace Resource.Core.Providers
{
    internal class SystemProvider : ISystemProvider
    {
        private readonly IEntityRepositoryProvider<Models.System> _systemRepository;

        public SystemProvider(IEntityRepositoryProvider<Models.System> systemRepository)
        {
            _systemRepository = systemRepository;
        }
    }
}
