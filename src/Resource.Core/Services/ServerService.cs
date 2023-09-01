using Resource.Abstractions.IProviders;
using Resource.Abstractions.IServices;
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

        public async Task RemoveAsync(string instanceId)
        {
            await _serverRepository.DeleteIfExistAsync(a => a.InstanceId == instanceId);
        }

        public async Task UpdateAsync(Server server)
        {
            await _serverRepository.UpdateIfExistAsync(a => a.InstanceId == server.InstanceId, a => a = server);
        }
    }
}
