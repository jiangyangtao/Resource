using Resource.Model;
using Environment = Resource.Model.Environment;

namespace Resource.Core.Abstracts.IProviders
{
    public interface IEnvironmentProvider
    {
        Task<bool> ExistAsync(string environmentCode);

        Task<Environment[]> GetEnvironmentsAsync(EnvironmentQueryParams queryParams);

        Task<long> GetEnvironmentCountAsync(EnvironmentQueryParams queryParams);

        Task<Environment?> GetEnvironmentAsync(string environmentCode);
    }
}
