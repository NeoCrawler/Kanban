namespace Kanban.DTO.Board
{
    public class BoardUpdateDTO
    {
        public Guid Guid { get; set; }
        public string Name { get; set; } = default!;
    }
}
