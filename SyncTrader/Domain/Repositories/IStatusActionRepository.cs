using SyncTrader.Domain.Entities;

namespace SyncTrader.Domain.Repositories
{
    public interface IStatusActionRepository
    {
        Task<IEnumerable<StatusAction>> GetAllAsync();
    }
}
