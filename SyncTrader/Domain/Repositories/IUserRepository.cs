using SyncTrader.Application.Dtos;
using SyncTrader.Domain.Entities;

namespace SyncTrader.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> CreateUserAsync(CreateUserDto userDto);
        Task<User> GetUserByIdAsync(int id);
    }
}
