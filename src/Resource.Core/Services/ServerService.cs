using Resource.Core.Abstracts.IProviders;
using Resource.Core.Abstracts.IServices;
using Resource.Model;
using Yangtao.Hosting.Core.HttpErrorResult;
using Yangtao.Hosting.Repository.Abstractions;

namespace Resource.Core.Services
{
    internal class ServerService : IServerService
    {
        private readonly IEntityRepositoryProvider<Server> _serverRepository;
        private readonly IServerProvider _serverProvider;

        public ServerService(IEntityRepositoryProvider<Server> serverRepository, IServerProvider serverProvider)
        {
            _serverRepository = serverRepository;
            _serverProvider = serverProvider;
        }

        public async Task AddAsync(Server server)
        {
            var exist = await _serverProvider.ExistAsync(server.InstanceId);
            if (exist) HttpErrorResult.ResponseConflict($"{server.InstanceId} already exist.");

            await _serverRepository.AddAsync(server);
        }

        public Task RemoveAsync(string instanceId) => _serverRepository.DeleteIfExistAsync(a => a.InstanceId == instanceId);

        public Task UpdateAsync(Server server) => _serverRepository.UpdateIfExistAsync(a => a.InstanceId == server.InstanceId, a => a = server);
    }
}
