using System.ComponentModel.DataAnnotations;

namespace Kanban.Models
{
    public class LabelModel
    {
        [Key]
        public Guid Guid { get; set; }
        public string Name { get; set; } = default!;
        public string Color { get; set; } = default!;
    }
}
