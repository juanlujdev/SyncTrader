using SyncTrader.Application.Dtos;
using SyncTrader.Application.Interfaces;
using SyncTrader.Domain.Repositories;

namespace SyncTrader.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserDto> CreateUserAsync(CreateUserDto userDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            //TODO: Mapear al userDto
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
