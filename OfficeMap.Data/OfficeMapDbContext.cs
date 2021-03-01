using Microsoft.EntityFrameworkCore;
using OfficeMap.Data.Models;

namespace OfficeMap.Data
{
    public class OfficeMapDbContext : DbContext
    {
        public OfficeMapDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Floor> Floors { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<ObjectAttribute> ObjectAttributes { get; set; }
        public DbSet<SvgType> SvgTypes { get; set; }
        public DbSet<Object> Objects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ObjectType> ObjectTypes { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<WorkplaceChange> WorkplacesChanges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasIndex(u => u.UserIdentity)
                .IsUnique();
        }
    }
}
