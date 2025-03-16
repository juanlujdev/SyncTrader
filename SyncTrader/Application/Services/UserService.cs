using SyncTrader.Application.Dtos;
using SyncTrader.Application.Interfaces;
using SyncTrader.Domain.Entities;
using SyncTrader.Domain.Repositories;
using SyncTrader.Domain.ValueObjects;
using System.Linq.Expressions;

namespace SyncTrader.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto userDto)
        {
            try
            {
                var email = Email.ValidateEmail(userDto.Email.Value);
                var phoneNumber = PhoneNumber.ValidatePhoneNumber(userDto.PhoneNumber.Value);
                var user = new CreateUserDto
                {
                    Name = userDto.Name,
                    Surname = userDto.Surname,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    RegistrationDate = DateTime.Now,
                    ActuallyUser = true,
                    Admin = true,
                    Amount = userDto.Amount,//si viene null, ponerlo a 0
                    Password = Password.Create(userDto.Password.HashedValue),
                    //BrokerId = tendrá que buscar que broker ID tiene el usuario MASTER en la base de datos y ponerlo por defecto, y de alguna manera que se registre en la plataforma de broker y coger su token, tambien llamar a la creacion de Broker y crear un registro
                    AutomaticAction = userDto.AutomaticAction,
                    UserMaster = true
                };

                await _userRepository.CreateUserAsync(user);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException($"Error creating user {e.Message} ", e);
            }
                
            //TODO:
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => new UserDto
            {
                Name = u.Name,
                Surname = u.Surname,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Amount = u.Amount,
                RegistrationDate = u.RegistrationDate,
                Admin = u.Admin,
                AutomaticAction = u.AutomaticAction,
                UserMaster = u.UserMaster,
                ActuallyUser = u.ActuallyUser
            });
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
