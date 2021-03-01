using System.Data.Entity;
using IfOfficeMap.DataAccess.Database;

namespace IfOfficeMap.DataAccess
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbContext()
        {
            
        }
        public DbContext(string connString)
            : base(connString)
        {

        }
        public DbSet<Employee> Employee { get; set; }

        public DbSet<Workplace> Workplaces { get; set; }

        public DbSet<Database.Utilities> Utilities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workplace>().HasOptional(x => x.Employee).WithMany();

            modelBuilder.Entity<Employee>().HasOptional(x => x.Workplace).WithMany();

           
            base.OnModelCreating(modelBuilder);
        }
    }
}
