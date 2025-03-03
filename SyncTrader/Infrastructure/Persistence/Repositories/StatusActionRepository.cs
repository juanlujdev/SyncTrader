using Microsoft.EntityFrameworkCore;
using SyncTrader.Domain.Entities;
using SyncTrader.Domain.Repositories;

namespace SyncTrader.Infrastructure.Persistence.Repositories
{
    public class StatusActionRepository : IStatusActionRepository
    {
        private readonly SyncTraderDbTestContext _context;

        public StatusActionRepository(SyncTraderDbTestContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StatusAction>> GetAllAsync()
        {
            return await _context.StatusActions.ToListAsync();
        }
    }
}
