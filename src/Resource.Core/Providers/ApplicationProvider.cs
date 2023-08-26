using Resource.Abstractions.IProviders;
using Resource.Models;
using Yangtao.Hosting.Repository.Abstractions;

namespace Resource.Core.Providers
{
    internal class ApplicationProvider: IApplicationProvider
    {
        private readonly IEntityRepositoryProvider<Application> _applicationRepository;

        public ApplicationProvider(IEntityRepositoryProvider<Application> applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }
    }
}
