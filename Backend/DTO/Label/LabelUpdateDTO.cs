namespace Kanban.DTO.Label
{
    public class LabelUpdateDTO
    {
        public Guid Guid { get; set; }
        public string Name { get; set; } = default!;
        public string Color { get; set; } = default!;
    }
}
