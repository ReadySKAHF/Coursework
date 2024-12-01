using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbAccess.Configure
{
    public class MechanicConfiguration : IEntityTypeConfiguration<Mechanic>
    {
        public void Configure(EntityTypeBuilder<Mechanic> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder
                .Property(m => m.FullName)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(m => m.Qualification)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(m => m.Experience)
                .IsRequired();

            builder
                .Property(m => m.Salary)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

        }
    }
}
