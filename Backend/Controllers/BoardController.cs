using Kanban.Data;
using Kanban.Models;
using Kanban.DTO.Board;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardController : ControllerBase
    {
        private readonly APIContext _context;

        public BoardController(APIContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var boards = _context.Boards.ToList();
            return Ok(boards);
        }

        [HttpPost("Get")]
        public IActionResult Get([FromBody] Guid guid)
        {
            var board = _context.Boards.Find(guid);
            if (board == null)
            {
                return NotFound();
            }
            return Ok(board);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] BoardCreateDTO dto)
        {
            var newBoard = new BoardModel
            {
                Guid = Guid.NewGuid(),
                Name = dto.Name,
            };
            _context.Boards.Add(newBoard);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { guid = newBoard.Guid }, newBoard);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] BoardUpdateDTO dto)
        {
            var existingBoard = _context.Boards.Find(dto.Guid);
            if (existingBoard == null)
            {
                return NotFound();
            }
            existingBoard.Name = dto.Name;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromBody] Guid guid)
        {
            var board = _context.Boards.Find(guid);
            if (board == null)
            {
                return NotFound();
            }
            _context.Boards.Remove(board);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
