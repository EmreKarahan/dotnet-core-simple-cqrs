using Microsoft.EntityFrameworkCore;
using Simple.Cqrs.Aggregate;

namespace Simple.Cqrs.Context
{
    public class TaskContext : BaseDbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=xxx;Database=Task;Persist Security Info=True;User ID=sa;Password=xxx;MultipleActiveResultSets=True;App=Tasks");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
