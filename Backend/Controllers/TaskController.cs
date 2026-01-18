using Kanban.Data;
using Kanban.DTO.Task;
using Kanban.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly APIContext _context;

        public TaskController(APIContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var tasks = _context.Tasks.ToList();
            return Ok(tasks);
        }

        [HttpPost("Get")]
        public IActionResult Get([FromBody] Guid guid)
        {
            var task = _context.Tasks.Find(guid);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost("GetByLabel")]
        public IActionResult GetByLabel([FromBody] Guid labelId)
        {
            var tasks = _context.Tasks.Where(t => t.LabelId == labelId.ToString()).ToList();
            return Ok(tasks);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] TaskCreateDTO dto)
        {
            var newTask = new TaskModel
            {
                Guid = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                LabelId = dto.LabelId
            };
            _context.Tasks.Add(newTask);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { guid = newTask.Guid }, newTask);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] TaskUpdateDTO dto)
        {
            var existingTask = _context.Tasks.Find(dto.Guid);
            if (existingTask == null)
            {
                return NotFound();
            }
            existingTask.Name = dto.Name;
            existingTask.Description = dto.Description;
            existingTask.LabelId = dto.LabelId;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromBody] Guid guid)
        {
            var task = _context.Tasks.Find(guid);
            if (task == null)
            {
                return NotFound();
            }
            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

