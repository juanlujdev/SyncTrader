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

        public async Task<User> CreateUserAsync(CreateUserDto userDto)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == userDto.Email);
            if (existingUser != null)
            {
                throw new ArgumentException($"User with email {userDto.Email} already exists");
            }
            
            var user = new User
            {
                Name = userDto.Name,
                Surname = userDto.Surname,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                RegistrationDate = userDto.RegistrationDate,
                ActuallyUser = userDto.ActuallyUser,
                Admin = userDto.Admin,
                Amount = userDto.Amount,
                Password = userDto.Password,
                BrokerId = userDto.BrokerId,
                AutomaticAction = userDto.AutomaticAction,
                UserMaster = userDto.UserMaster
            };

            await _context.Users.AddAsync(user);
            return user;
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
