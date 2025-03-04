using Microsoft.EntityFrameworkCore;
using SyncTrader.Domain.Entities;
using SyncTrader.Domain.Repositories;

namespace SyncTrader.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SyncTraderDbTestContext _context;
        public UserRepository(SyncTraderDbTestContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
