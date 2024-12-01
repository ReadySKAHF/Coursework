using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbAccess.Configure
{
    public class RepairConfiguration : IEntityTypeConfiguration<Repair>
    {
        public void Configure(EntityTypeBuilder<Repair> builder)
        {
            builder
                .HasKey(r => r.Id);

            builder
                .Property(r => r.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder
                .Property(r => r.RepairDate)
                .IsRequired();

            builder
                .Property(r => r.WorkDescription)
                .IsRequired()
                .HasMaxLength(500);

            // Relationships
            builder
                .HasOne(r => r.Car)
                .WithMany(c => c.Repairs)
                .HasForeignKey(r => r.CarId)
                .OnDelete(DeleteBehavior.Cascade);  // Убираем проблему с "SET NULL"

            builder
                .HasOne(r => r.Mechanic)
                .WithMany(m => m.Repairs)
                .HasForeignKey(r => r.MechanicId)
                .OnDelete(DeleteBehavior.Cascade);  // Или используйте Restrict в случае проблем

            builder
                .HasOne(r => r.Status)
                .WithMany(c => c.Repairs)
                .HasForeignKey(r => r.StatusId)
                .OnDelete(DeleteBehavior.Cascade);  // Убедитесь, что это Cascade
        }
    }
}   
