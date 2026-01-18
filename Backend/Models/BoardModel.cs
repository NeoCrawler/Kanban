using System.ComponentModel.DataAnnotations;

namespace Kanban.Models
{
    public class BoardModel
    {
        [Key]
        public Guid Guid { get; set; }
        public string Name { get; set; } = default!;
    }
}
