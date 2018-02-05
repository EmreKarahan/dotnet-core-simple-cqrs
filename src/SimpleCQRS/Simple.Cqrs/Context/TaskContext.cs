using Microsoft.EntityFrameworkCore;
using Simple.Cqrs.Aggregate;

namespace Simple.Cqrs.Context
{
    public class TaskContext : BaseContext
    {
        public TaskContext()            
        {
        }
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
            base.OnModelCreating(modelBuilder); 
        } 
    }
}
