
using Resource.Model;

namespace Resource.Abstractions.IProviders
{
    public interface IApplicationProvider
    {
        Task<bool> ExistAsync(string applicationCode);

        Task<bool> ExistApplicationAsync(string systemCode);

        Task<Application[]> GetApplicationsAsync(ApplicationQueryParams queryParams);

        Task<long> GetApplicationCountAsync(ApplicationQueryParams queryParams);

        Task<Application?> GetApplicationAsync(string applicationCode);
    }
}
