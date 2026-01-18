namespace Kanban.DTO.Task
{
    public class TaskCreateDTO
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string LabelId { get; set; } = default!;
    }
}
