
using Resource.Model;

namespace Resource.Core.Abstracts.IProviders
{
    public interface ISystemProvider
    {
        Task<Model.System?> GetSystemAsync(string systemCode);

        Task<bool> ExistAsync(string systemCode);

        Task<Model.System[]> GetSystemsAsync(SystemQueryParams queryParams);

        Task<long> GetSystemCountAsync(SystemQueryParams queryParams);
    }
}