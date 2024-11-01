using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheTaskController : ControllerBase
    {
        private TheTaskContext _context;

        public TheTaskController(TheTaskContext context)
        {
            _context = context;
        }

        // GET: api/TheTask
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TheTask>>> GetTheTasks()
        {
            var theTasks = await _context.TheTasks.ToListAsync<TheTask>();

            return Ok(new { results = new { data = theTasks }, error = false });
        }

        // GET: api/TheTask/id
        [HttpGet("{id}")]
        public async Task<ActionResult<TheTask>> GetTheTask(Guid id)
        {
            var theTask = await _context.TheTasks.FindAsync(id);

            if(theTask == null)
            {
                return NotFound(new { results = new { data = new { } }, error = true });
            }

            return Ok(new { results = new { data = theTask }, error = false });
        }

    }
}
