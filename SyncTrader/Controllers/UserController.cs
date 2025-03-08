using Microsoft.AspNetCore.Mvc;
using SyncTrader.Application.Dtos;
using SyncTrader.Application.Interfaces;

namespace SyncTrader.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateUserDto user)
        {
            var userCreated = await _userService.CreateUserAsync(user);

            if (userCreated == null)
            {
                return Conflict(new { message = "El usuario ya existe o hubo un error en la creación." });
            }

            return Ok(userCreated);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound(new { message = "Usuario no encontrado" });
            }

            return Ok(user);
        }

    }
}
