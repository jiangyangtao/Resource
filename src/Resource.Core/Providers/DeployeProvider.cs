using Microsoft.EntityFrameworkCore;
using Resource.Core.Abstracts.IProviders;
using Resource.Model;
using Yangtao.Hosting.Core.HttpErrorResult;
using Yangtao.Hosting.Repository.Abstractions;

namespace Resource.Core.Providers
{
    internal class DeployeProvider : IDeployeProvider
    {
        private readonly IEntityRepositoryProvider<Deploye> _deployeRepository;
        private readonly IApplicationProvider _applicationProvider;
        private readonly IServerProvider _serverProvider;

        public DeployeProvider(
            IEntityRepositoryProvider<Deploye> deployeRepository,
            IApplicationProvider applicationProvider,
            IServerProvider serverProvider)
        {
            _deployeRepository = deployeRepository;
            _applicationProvider = applicationProvider;
            _serverProvider = serverProvider;
        }

        public async Task DeployeAsync(string applicationCode, string serverInstanceId)
        {
            var existApplication = await _applicationProvider.ExistAsync(applicationCode);
            if (existApplication == false) HttpErrorResult.ResponseBadRequest($"{applicationCode} not exist.");

            var existServer = await _serverProvider.ExistAsync(serverInstanceId);
            if (existServer == false) HttpErrorResult.ResponseBadRequest($"{serverInstanceId} not exist.");

            await _deployeRepository.AddAsync(new Deploye
            {
                ApplicationCode = applicationCode,
                ServerInstanceId = serverInstanceId,
            });
        }

        public async Task UnDeployeAsync(string applicationCode, string serverInstanceId)
        {
            var deploye = await _deployeRepository.Get(a => a.ApplicationCode == applicationCode && a.ServerInstanceId == serverInstanceId).FirstOrDefaultAsync();
            if (deploye == null) return;

            await _deployeRepository.DeleteAsync(deploye);
        }
    }
}
