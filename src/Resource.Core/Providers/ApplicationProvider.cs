using Resource.Abstractions.IProviders;
using Resource.Repository.Abstractions;
using Resource.Repository.Models;

namespace Resource.Core.Providers
{
    internal class ApplicationProvider: IApplicationProvider
    {
        private readonly IRepository<Application> _applicationRepository;

        public ApplicationProvider(IRepository<Application> applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }
    }
}
