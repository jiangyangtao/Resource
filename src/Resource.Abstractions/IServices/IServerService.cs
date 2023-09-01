using Resource.Model;

namespace Resource.Abstractions.IServices
{
    public interface IServerService
    {
        Task AddAsync(Server server);

        Task UpdateAsync(Server server);

        Task RemoveAsync(string instanceId);
    }
}
