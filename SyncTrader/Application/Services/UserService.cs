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
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(user => new UserDto
            {
                UserId = user.UserId,
                // Name = user.Name, no existe el name en User
                Surname = user.Surname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Amount = user.Amount
            });
        }

    }
}
