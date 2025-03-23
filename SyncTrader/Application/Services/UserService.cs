using SyncTrader.Application.Dtos;
using SyncTrader.Application.Interfaces;
using SyncTrader.Domain.Repositories;
using SyncTrader.Domain.ValueObjects;

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
                var email = Email.ValidateEmail(userDto.Email);
                var phoneNumber = PhoneNumber.ValidatePhoneNumber(userDto.PhoneNumber);
                var password = Password.Create(userDto.Password.Trim());
                var user = new CreateUserDto
                {
                    Name = userDto.Name.Trim().ToUpper(),
                    Surname = userDto.Surname.Trim().ToUpper(),
                    Email = email.Value.Trim().ToUpper(),
                    PhoneNumber = phoneNumber.Value.Trim(),
                    RegistrationDate = DateTime.Now,
                    ActuallyUser = true,
                    Admin = true,
                    Amount = userDto.Amount,
                    Password = password.HashedValue,
                    //BrokerId = tendrá que buscar que broker ID tiene el usuario MASTER en la base de datos y ponerlo por defecto, y de alguna manera que se registre en la plataforma de broker y coger su token, tambien llamar a la creacion de Broker y crear un registro
                    AutomaticAction = userDto.AutomaticAction,
                    UserMaster = true
                };

                var userCreated = await _userRepository.CreateUserAsync(user);
                return new UserDto
                {
                    Name = userCreated.Name,
                    Surname = userCreated.Surname,
                    Email = userCreated.Email,
                    PhoneNumber = userCreated.PhoneNumber,
                    Amount = userCreated.Amount,
                    RegistrationDate = userCreated.RegistrationDate,
                    Admin = userCreated.Admin,
                    AutomaticAction = userCreated.AutomaticAction,
                    UserMaster = userCreated.UserMaster,
                    ActuallyUser = userCreated.ActuallyUser
                };
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException($"Error creating user {e.Message} ", e);
            }
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
            var user = await _userRepository.GetUserByIdAsync(id);
            return new UserDto
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Amount = user.Amount,
                RegistrationDate = user.RegistrationDate,
                Admin = user.Admin,
                AutomaticAction = user.AutomaticAction,
                UserMaster = user.UserMaster,
                ActuallyUser = user.ActuallyUser
            };
        }
    }
}
