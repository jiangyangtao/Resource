
namespace Resource.Abstractions.IProviders
{
    public interface ISystemProvider
    {
        Task<Model.System> GetSystemAsync(string systemCode);

        Task<Model.System[]> GetSystemsAsync(string systemCode, string systemName, int start, int size);

        Task<long> GetSystemCountAsync(string systemCode, string systemName);
    }
} 