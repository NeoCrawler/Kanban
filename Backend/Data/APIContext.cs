using Microsoft.EntityFrameworkCore;

namespace Kanban.Data
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {
        }
    }
}
