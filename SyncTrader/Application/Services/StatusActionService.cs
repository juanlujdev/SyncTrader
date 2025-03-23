using SyncTrader.Application.Dtos;
using SyncTrader.Application.Interfaces;
using SyncTrader.Domain.Repositories;

namespace SyncTrader.Application.Services
{
    public class StatusActionService : IStatusActionService
    {
        private readonly IStatusActionRepository _statusActionRepository;

        public StatusActionService(IStatusActionRepository statusActionRepository)
        {
            _statusActionRepository = statusActionRepository;
        }

        public async Task<IEnumerable<StatusActionDto>> GetAllStatusActionsAsync()
        {
            var statusActions = await _statusActionRepository.GetAllAsync();
            return statusActions.Select(sa => new StatusActionDto
            {
                StatusActionId = sa.StatusActionId,
                StatusActionName = sa.StatusActionName
            });
        }
    }
}