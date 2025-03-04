using SyncTrader.Domain.Entities;

namespace SyncTrader.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
    }
}
