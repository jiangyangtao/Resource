using Resource.Core.Abstracts.IProviders;
using Resource.Core.Abstracts.IServices;
using Resource.Enums;
using Yangtao.Hosting.Core.HttpErrorResult;
using Yangtao.Hosting.Repository.Abstractions;
using Environment = Resource.Model.Environment;

namespace Resource.Core.Services
{
    internal class EnvironmentService : IEnvironmentService
    {
        private readonly IEntityRepositoryProvider<Environment> _environmentRepository;
        private readonly IEnvironmentProvider _environmentProvider;

        public EnvironmentService(
            IEntityRepositoryProvider<Environment> environmentRepository,
            IEnvironmentProvider environmentProvider)
        {
            _environmentRepository = environmentRepository;
            _environmentProvider = environmentProvider;
        }

        public async Task AddAsync(Environment environment)
        {
            var exist = await _environmentProvider.ExistAsync(environment.EnvironmentCode);
            if (exist) HttpErrorResult.ResponseBadRequest($"{environment.EnvironmentCode} already exist.");

            await _environmentRepository.AddAsync(environment);
        }

        public async Task RemoveAsync(string environmentCode)
        {
            await _environmentRepository.DeleteIfExistAsync(a => a.EnvironmentCode == environmentCode);
        }

        public async Task SetEnvironmentStatus(string environmentCode, EnvironmentStatus status)
        {
            await _environmentRepository.UpdateIfExistAsync(a => a.EnvironmentCode == environmentCode, a => a.EnvironmentStatus = status);
        }

        public async Task UpdateAsync(Environment environment)
        {
            var data = await _environmentProvider.GetEnvironmentAsync(environment.EnvironmentCode);
            if (data == null) return;

            data.EnvironmentName = environment.EnvironmentName;
            data.EnvironmentType = environment.EnvironmentType;
            data.Description = environment.Description;
            await _environmentRepository.UpdatePartAsync(data, a => new
            {
                a.EnvironmentName,
                a.EnvironmentType,
                a.Description,
            });
        }
    }
}
