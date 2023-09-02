
using Resource.Model;

namespace Resource.Core.Abstracts.IProviders
{
    public interface IApplicationProvider
    {
        Task<bool> ExistAsync(string applicationCode);

        Task<bool> ExistApplicationAsync(string systemCode);

        Task<Application[]> GetApplicationsAsync(ApplicationQueryParams queryParams);

        Task<long> GetApplicationCountAsync(ApplicationQueryParams queryParams);

        Task<Application?> GetApplicationAsync(string applicationCode);

        Task<Application[]> GetApplicationsAsync(string[] applicationCodes);
    }
}
