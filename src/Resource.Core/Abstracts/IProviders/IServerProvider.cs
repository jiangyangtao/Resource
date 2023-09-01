using Resource.Model;

namespace Resource.Core.Abstracts.IProviders
{
    public interface IServerProvider
    {
        Task<bool> ExistAsync(string instanceId);

        Task<Server[]> GetServersAsync(ServerQueryParams queryParams);

        Task<long> GetServerCountAsync(ServerQueryParams queryParams);

        Task<Server?> GetServerAsync(string instanceId);
    }
}
