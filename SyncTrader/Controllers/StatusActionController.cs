using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SyncTrader.Application.Interfaces;
using SyncTrader.Infrastructure.Persistence;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SyncTrader.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusActionController : ControllerBase
    {
        private readonly IStatusActionService _statusActionService;

        public StatusActionController(IStatusActionService statusActionService)
        {
            _statusActionService = statusActionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var statusActions = await _statusActionService.GetAllStatusActionsAsync();
            return Ok(statusActions);
        }
    }
}
