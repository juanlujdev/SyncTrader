using SyncTrader.Application.Dtos;

namespace SyncTrader.Application.Interfaces
{
    public interface IStatusActionService
    {
        Task<IEnumerable<StatusActionDto>> GetAllStatusActionsAsync();
    }
}
