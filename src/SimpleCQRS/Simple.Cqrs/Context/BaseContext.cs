using Microsoft.EntityFrameworkCore;

namespace Simple.Cqrs.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext()            
        {
            //Configuration.ProxyCreationEnabled = false;
            //Configuration.LazyLoadingEnabled = false;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Conventions.Remove<IncludeMetadataConvention>(); 
        }
    }
}
