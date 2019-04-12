using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCuscuzeria.Domain.Entities;

namespace MyCuscuzeria.Infrastructure.Persistence.EF.Config
{
    public class CuscuzeiroConfiguration : IEntityTypeConfiguration<Cuscuzeiro>
    {
        public void Configure(EntityTypeBuilder<Cuscuzeiro> builder)
        {
            //Defines PK
            builder.HasKey(co => co.CuscuzeiroId);
            //Defines Column Name
            builder.Property(co => co.Age).HasColumnName("YearsOfExperience");
            //Defines NOT NULL
            builder.Property(co => co.CuscuzeiroName).IsRequired();
            //Defines field Size
            builder.Property(co => co.CuscuzeiroName).HasMaxLength(150);
            builder.Property(co => co.UrlImg).HasMaxLength(500);

            //One-to-One Relationship (FK)
            builder.HasOne(co => co.Order)
                .WithOne(o => o.Cuscuzeiro)
                .HasForeignKey<Order>(o => o.CuscuzeiroId);
        }
    }
}