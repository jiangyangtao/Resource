using Resource.Enums;
using Environment = Resource.Model.Environment;

namespace Resource.Core.Abstracts.IServices
{
    public interface IEnvironmentService
    {
        Task AddAsync(Environment environment);

        Task UpdateAsync(Environment environment);

        Task RemoveAsync(string environmentCode);

        Task SetEnvironmentStatus(string environmentCode, EnvironmentStatus status);
    }
}
