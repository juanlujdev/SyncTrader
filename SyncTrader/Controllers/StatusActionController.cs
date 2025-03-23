using Microsoft.AspNetCore.Mvc;
using SyncTrader.Application.Interfaces;


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