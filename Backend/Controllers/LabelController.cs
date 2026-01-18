using Kanban.Data;
using Kanban.Models;
using Kanban.DTO.Label;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LabelController : ControllerBase
    {
        private readonly APIContext _context;

        public LabelController(APIContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var labels = _context.Labels.ToList();
            return Ok(labels);
        }

        [HttpPost("Get")]
        public IActionResult Get([FromBody] Guid guid)
        {
            var label = _context.Labels.Find(guid);
            if (label == null)
            {
                return NotFound();
            }
            return Ok(label);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] LabelCreateDTO dto)
        {
            var newLabel = new LabelModel
            {
                Guid = Guid.NewGuid(),
                Name = dto.Name,
                Color = dto.Color
            };

            _context.Labels.Add(newLabel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { guid = newLabel.Guid }, newLabel);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] LabelUpdateDTO dto)
        {
            var existingLabel = _context.Labels.Find(dto.Guid);
            if (existingLabel == null)
            {
                return NotFound();
            }
            existingLabel.Name = dto.Name;
            existingLabel.Color = dto.Color;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromBody] Guid guid)
        {
            var label = _context.Labels.Find(guid);
            if (label == null)
            {
                return NotFound();
            }
            _context.Labels.Remove(label);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
