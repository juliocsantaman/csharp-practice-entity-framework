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
            var theTasks = await _context.TheTasks.Include(tt => tt.Category).ToListAsync<TheTask>();

            return Ok(new { results = new { data = theTasks }, error = false });
        }

        // GET: api/TheTask/id
        [HttpGet("{id}")]
        public async Task<ActionResult<TheTask>> GetTheTask(Guid id)
        {
            var theTask = await _context.TheTasks.Include(tt => tt.Category).FirstOrDefaultAsync(tt => tt.Id == id);

            if(theTask == null)
            {
                return NotFound(new { results = new { data = new { } }, error = true });
            }

            return Ok(new { results = new { data = theTask }, error = false });
        }

        [HttpPost]
        public async Task<ActionResult<TheTask>> PostTheTask(TheTask theTask)
        {
            theTask.Id = Guid.NewGuid();
            theTask.CreatedAt = DateTime.Now;
            // theTask.Category = new Category { Id = theTask.CategoryId, Name = "Electronic", Description = "About electronic for different situations" };
            
            await _context.AddAsync(theTask);

            await _context.SaveChangesAsync();


            var createdTask = await _context.TheTasks.Include(tt => tt.Category).FirstOrDefaultAsync(tt => tt.Id == theTask.Id);


            return Ok(new { results = new { data = createdTask }, error = false });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TheTask>> PutTheTask(Guid id, TheTask theTask)
        {
            var currentTheTask = await _context.TheTasks.FindAsync(id);

            if (currentTheTask == null)
            {
                return NotFound("Not found");
            }

            currentTheTask.CategoryId = theTask.CategoryId;
            currentTheTask.Title = theTask.Title;
            currentTheTask.Description = theTask.Description;
            currentTheTask.Priority = theTask.Priority;
            currentTheTask.Summary = theTask.Summary;

            await _context.SaveChangesAsync();

            var updatedTask = await _context.TheTasks.Include(tt => tt.Category).FirstOrDefaultAsync(tt => tt.Id == currentTheTask.Id);


            return Ok(new { results = new { data = updatedTask }, error = false });
        }

    }
}
