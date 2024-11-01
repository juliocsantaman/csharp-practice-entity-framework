using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheTasksController : ControllerBase
    {
        private readonly TheTaskContext _context;

        public TheTasksController(TheTaskContext context)
        {
            _context = context;
        }

        // GET: api/TheTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TheTask>>> GetTheTasks()
        {
            return await _context.TheTasks.ToListAsync();
        }

        // GET: api/TheTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TheTask>> GetTheTask(Guid id)
        {
            var theTask = await _context.TheTasks.FindAsync(id);

            if (theTask == null)
            {
                return NotFound();
            }

            return theTask;
        }

        // PUT: api/TheTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTheTask(Guid id, TheTask theTask)
        {
            if (id != theTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(theTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TheTaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TheTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TheTask>> PostTheTask(TheTask theTask)
        {
            _context.TheTasks.Add(theTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTheTask", new { id = theTask.Id }, theTask);
        }

        // DELETE: api/TheTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheTask(Guid id)
        {
            var theTask = await _context.TheTasks.FindAsync(id);
            if (theTask == null)
            {
                return NotFound();
            }

            _context.TheTasks.Remove(theTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TheTaskExists(Guid id)
        {
            return _context.TheTasks.Any(e => e.Id == id);
        }
    }
}
