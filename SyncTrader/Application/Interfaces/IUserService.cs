using SyncTrader.Application.Dtos;

namespace SyncTrader.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> CreateUserAsync(CreateUserDto userDto);
        Task<UserDto> GetUserByIdAsync(int id);
    }
}
