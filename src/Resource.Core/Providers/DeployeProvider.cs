using Microsoft.EntityFrameworkCore;
using Resource.Core.Abstracts.IProviders;
using Resource.Model;
using Yangtao.Hosting.Core.HttpErrorResult;
using Yangtao.Hosting.Extensions;
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
                DeployeTime = DateTime.Now,
            });
        }

        public async Task UnDeployeAsync(string applicationCode, string serverInstanceId)
        {
            var deploye = await _deployeRepository.Get(a => a.ApplicationCode == applicationCode && a.ServerInstanceId == serverInstanceId).FirstOrDefaultAsync();
            if (deploye == null) return;

            await _deployeRepository.DeleteAsync(deploye);
        }


        public async Task<Application[]> GetApplicationDeployesAsync(string serverInstanceId)
        {
            var applicationCodes = await _deployeRepository.Get(a => a.ServerInstanceId == serverInstanceId).Select(a => a.ApplicationCode).ToArrayAsync();
            if (applicationCodes.IsNullOrEmpty()) return Array.Empty<Application>();

            return await _applicationProvider.GetApplicationsAsync(applicationCodes);
        }

        public async Task<ServerDeploye[]> GetServerDeployesAsync(string applicationCode)
        {
            var serverInstanceIds = await _deployeRepository.Get(a => a.ApplicationCode == applicationCode).Select(a => a.ServerInstanceId).ToArrayAsync();

            return await _serverProvider.GetServerDeploysAsync(serverInstanceIds);
        }
    }
}
