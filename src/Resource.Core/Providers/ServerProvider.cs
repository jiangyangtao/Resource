﻿using Microsoft.EntityFrameworkCore;
using Resource.Core.Abstracts.IProviders;
using Resource.Model;
using Yangtao.Hosting.Extensions;
using Yangtao.Hosting.Repository.Abstractions;

namespace Resource.Core.Providers
{
    internal class ServerProvider : IServerProvider
    {
        private readonly IEntityRepositoryProvider<Server> _serverRepository;

        public ServerProvider(IEntityRepositoryProvider<Server> serverRepository)
        {
            _serverRepository = serverRepository;
        }

        public async Task<bool> ExistAsync(string instanceId)
        {
            if (instanceId.IsNullOrEmpty()) return false;

            return await _serverRepository.Get(a => a.InstanceId == instanceId).AnyAsync();
        }

        public async Task<bool> ExistServerAsync(string environmentCode)
        {
            if (environmentCode.IsNullOrEmpty()) return false;

            return await _serverRepository.Get(a => a.EnvironmentCode == environmentCode).AnyAsync();
        }

        public async Task<Server?> GetServerAsync(string instanceId)
        {
            if (instanceId.IsNullOrEmpty()) return null;

            return await _serverRepository.Get(a => a.InstanceId == instanceId).FirstOrDefaultAsync();
        }

        public Task<long> GetServerCountAsync(ServerQueryParams queryParams)
        {
            var query = queryParams.GetQueryable(_serverRepository);
            return query.LongCountAsync();
        }

        public async Task<ServerDeploye[]> GetServerDeploysAsync(string[] instanceIds)
        {
            if (instanceIds.IsNullOrEmpty()) return Array.Empty<ServerDeploye>();

            var servers = await _serverRepository.Get(a => instanceIds.Contains(a.InstanceId)).Select(a => new ServerDeploye
            {
                InstanceId = a.InstanceId,
                EnvironmentCode = a.EnvironmentCode,
                PublicIPAddress = a.PublicIPAddress,
                IntranetIPAddress = a.IntranetIPAddress,
            }).ToArrayAsync();
            if (servers.IsNullOrEmpty()) return Array.Empty<ServerDeploye>();

            return servers;
        }

        public Task<Server[]> GetServersAsync(ServerQueryParams queryParams)
        {
            var query = queryParams.GetQueryable(_serverRepository);
            return query.OrderByDescending(a => a.CreateTime).Skip(queryParams.Start).Take(queryParams.Size).ToArrayAsync();
        }
    }
}
