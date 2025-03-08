using Microsoft.EntityFrameworkCore;
using SyncTrader.Application.Dtos;
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

        public Task<User> CreateUserAsync(CreateUserDto userDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
