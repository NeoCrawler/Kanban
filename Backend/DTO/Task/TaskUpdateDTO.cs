namespace Kanban.DTO.Task
{
    public class TaskUpdateDTO
    {
        public Guid Guid { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string LabelId { get; set; } = default!;
    }
}
