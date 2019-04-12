using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCuscuzeria.Domain.Entities;

namespace MyCuscuzeria.Infrastructure.Persistence.EF.Config
{
    public class DrinkConfiguration : IEntityTypeConfiguration<Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> builder)
        {
            //Defines PK
            builder.HasKey(d => d.DrinkId);
            //Defines NOT NULL
            builder.Property(d => d.DrinkName).IsRequired();
            builder.Property(d => d.Description).IsRequired();
            //Defines field Size
            builder.Property(d => d.DrinkName).HasMaxLength(150);
            builder.Property(d => d.Description).HasMaxLength(500);
        }
    }
}