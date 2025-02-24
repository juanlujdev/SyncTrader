using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SyncTrader.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SyncTrader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusActionController : ControllerBase
    {
        private readonly SyncTraderDbTestContext _context;
        public StatusActionController(SyncTraderDbTestContext context)
        {
            _context = context;
        }
        // GET: api/<StatusActionController>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _context.ActionTypes.ToListAsync();
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET api/<StatusActionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StatusActionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StatusActionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StatusActionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
