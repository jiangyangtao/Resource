
using Resource.Model;

namespace Resource.Core.Abstracts.IServices
{
    public interface IApplicationService
    {
        Task AddAsync(Application application);

        Task UpdateAsync(Application application);

        Task RemoveAsync(string applicationCode);
    }
}
