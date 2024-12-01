using DbAccess.Configure;
using Entities;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DbAccess.Context
{
    public class Context : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarStatus> CarsStatuses { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Repair> Repairs { get; set; }

        public DbSet<User> Users { get; set; }

        public Context(DbContextOptions<Context> builder) : base(builder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new OwnerConfiguration());
            modelBuilder.ApplyConfiguration(new CarStatusConfiguration());
            modelBuilder.ApplyConfiguration(new MechanicConfiguration());
            modelBuilder.ApplyConfiguration(new RepairConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasKey(x => new { x.UserId, x.RoleId });
        }
    }
}
