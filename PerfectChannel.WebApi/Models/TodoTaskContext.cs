using Microsoft.EntityFrameworkCore;
namespace PerfectChannel.WebApi.Models
{
    public class TodoTaskContext : DbContext
    {
        public TodoTaskContext(DbContextOptions<TodoTaskContext> options) : base(options)
        {

        }

        public DbSet<TodoTask> TodoTask { get; set; }
    }
}
