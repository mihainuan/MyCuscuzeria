using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCuscuzeria.Domain.Entities;

namespace MyCuscuzeria.Infrastructure.Persistence.EF.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //Defines PK
            builder.HasKey(o => o.OrderId);
            //Defines NOT NULL
            builder.Property(o => o.UserId).IsRequired();
            builder.Property(o => o.Delivered).IsRequired();

            //One-to-Many Relationship (FK)
            builder.HasMany(co => co.Cuscuzes)
                .WithOne(o => o.Order);
            builder.HasMany(d => d.Drinks)
                .WithOne(o => o.Order);
            builder.HasMany(b => b.Beverages)
                .WithOne(o => o.Order);
            builder.HasMany(p => p.Promo)
                .WithOne(o => o.Order);



        }
    }
}