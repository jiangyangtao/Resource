using Resource.Model;

namespace Resource.Core.Abstracts.IProviders
{
    public interface IDeployeProvider
    {
        Task DeployeAsync(string applicationCode, string serverInstanceId);

        Task UnDeployeAsync(string applicationCode, string serverInstanceId);

        Task<ServerDeploye[]> GetServerDeployesAsync(string applicationCode);

        Task<Application[]> GetApplicationDeployesAsync(string serverInstanceId);
    }
}
