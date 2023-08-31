
namespace Resource.Abstractions.IServices
{
    public interface ISystemService
    {
        Task AddAsymc(Model.System system);

        Task UpdateAsymc(Model.System system);

        Task RemoveAsync(string systemCode);
    }
}
