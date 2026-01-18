using Microsoft.EntityFrameworkCore;

namespace Kanban.Data
{
    public class APIContext : DbContext
    {
        public DbSet<Models.TaskModel> Tasks { get; set; }
        public DbSet<Models.BoardModel> Boards { get; set; }
        public DbSet<Models.LabelModel> Labels { get; set; }

        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {
        }
    }
}
