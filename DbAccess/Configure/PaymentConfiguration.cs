using Entities;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbAccess.Configure
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder
                .Property(p => p.Date)
                .IsRequired();

            builder
                .Property(p => p.Rate)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder
                .Property(p => p.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // Relationships
            builder
                .HasOne(p => p.Repair)
                .WithMany()
                .HasForeignKey(p => p.RepairId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
