using Resource.Core.Abstracts.IProviders;
using Resource.Core.Abstracts.IServices;
using Resource.Model;
using Yangtao.Hosting.Core.HttpErrorResult;
using Yangtao.Hosting.Repository.Abstractions;

namespace Resource.Core.Services
{
    internal class ApplicationService : IApplicationService
    {
        private readonly IEntityRepositoryProvider<Application> _applicationRepository;
        private readonly IApplicationProvider _applicationProvider;

        public ApplicationService(IEntityRepositoryProvider<Application> applicationRepository, IApplicationProvider applicationProvider)
        {
            _applicationRepository = applicationRepository;
            _applicationProvider = applicationProvider;
        }

        public async Task AddAsync(Application application)
        {
            var exist = await _applicationProvider.ExistAsync(application.ApplicationCode);
            if (exist) HttpErrorResult.ResponseConflict($"{application.ApplicationCode} already exist");

            await _applicationRepository.AddAsync(application);
        }

        public Task RemoveAsync(string applicationCode) => _applicationRepository.DeleteIfExistAsync(a => a.ApplicationCode == applicationCode);

        public Task UpdateAsync(Application application)
        {
            return _applicationRepository.UpdateIfExistAsync(a => a.ApplicationCode == application.ApplicationCode, a =>
            {
                a.ApplicationName = application.ApplicationName;
                a.Description = application.Description;
            });
        }
    }
}
