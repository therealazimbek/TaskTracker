using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    [Route("api/Projects/{id:int}/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Projects/1/Tasks/
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Models.Task>>> GetTasks(int id)
        {
            if (!ProjectExists(id))
            {
                return BadRequest();
            }
            var tasks = await _context.Tasks.Where(t => t.ProjectId == id).ToArrayAsync();
            return tasks;
        }
        
        // GET: api/Projects/1/Tasks/5
        [HttpGet("{taskId}")]
        public async Task<ActionResult<Models.Task>> GetTask(int id, int taskId)
        {
            if (!ProjectExists(id))
            {
                return BadRequest();
            }
            var task = await _context.Tasks.FindAsync(taskId);
            
            if (task == null || id != task.ProjectId)
            {
                return NotFound();
            }

            return task;
        }
        
        // PUT: api/Projects/1/Tasks/5
        [HttpPut("{taskId}")]
        public async Task<IActionResult> PutTask(int id, int taskId, Models.Task task)
        {
            if (!ProjectExists(id) || id != task.ProjectId)
            {
                return BadRequest();
            }
            
            if (taskId != task.Id)
            {
                return BadRequest();
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(taskId))
                {
                    return NotFound();
                }

                throw;
            }

            return Ok(task);
        }
        
        // POST: api/Projects/Tasks
        [HttpPost("")]
        public async Task<ActionResult<Models.Task>> PostTask(int id, Models.Task task)
        {
            if (!ProjectExists(id) || id != task.ProjectId)
            {
                return BadRequest();
            }
            var project = (await _context.Projects.FindAsync(id))!;
            project.Tasks.Add(task);
            _context.Projects.Update(project);

            _context.Tasks.Add(task);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = project.Id, taskId = task.Id }, task);
        }
        
        // DELETE: api/Projects/Tasks/5
        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteTask(int id, int taskId)
        {
            if (!ProjectExists(id))
            {
                return BadRequest();
            }

            var task = await _context.Tasks.FindAsync(taskId);
            
            if (task == null || id != task.ProjectId)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }
       

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
        
        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
