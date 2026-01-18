using System.ComponentModel.DataAnnotations;

namespace Kanban.Models
{
    public class TaskModel
    {
        [Key]
        public Guid Guid { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string LabelId { get; set; } = default!;
    }
}
