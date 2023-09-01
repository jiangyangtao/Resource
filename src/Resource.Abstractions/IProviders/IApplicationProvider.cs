
namespace Resource.Abstractions.IProviders
{
    public interface IApplicationProvider
    {
        Task<bool> ExistApplicationAsync(string systemCode);
    }
}
