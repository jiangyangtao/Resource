using Resource.Repository.Abstractions;

namespace Resource.Core.Providers
{
    internal class SystemProvider
    {
        private readonly IRepository<Repository.Models.System> _systemRepository;

        public SystemProvider(IRepository<Repository.Models.System> systemRepository)
        {
            _systemRepository = systemRepository;
        }
    }
}
