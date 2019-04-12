using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCuscuzeria.Domain.Entities;

namespace MyCuscuzeria.Infrastructure.Persistence.EF.Config
{
    public class CuscuzConfiguration : IEntityTypeConfiguration<Cuscuz>
    {
        public void Configure(EntityTypeBuilder<Cuscuz> builder)
        {
            //Defines PK
            builder.HasKey(cu => cu.CuscuzId);
            //Defines NOT NULL
            builder.Property(cu => cu.CuscuzName).IsRequired();
            builder.Property(cu => cu.Description).IsRequired();
            builder.Property(cu => cu.TypeId).IsRequired();
            //Defines field Size
            builder.Property(cu => cu.CuscuzName).HasMaxLength(150);
            builder.Property(cu => cu.Description).HasMaxLength(500);

            //One-to-Many Relationship (FK)
            builder.HasMany(a => a.Accompaniments)
                .WithOne(c => c.Cuscuz);
        }
    }
}