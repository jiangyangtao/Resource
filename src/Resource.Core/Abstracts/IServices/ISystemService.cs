
namespace Resource.Core.Abstracts.IServices
{
    public interface ISystemService
    {
        Task AddAsymc(Model.System system);

        Task UpdateAsymc(Model.System system);

        Task RemoveAsync(string systemCode);
    }
}
