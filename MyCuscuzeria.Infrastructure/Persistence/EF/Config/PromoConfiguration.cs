using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCuscuzeria.Domain.Entities;

namespace MyCuscuzeria.Infrastructure.Persistence.EF.Config
{
    public class PromoConfiguration : IEntityTypeConfiguration<Promo>
    {
        public void Configure(EntityTypeBuilder<Promo> builder)
        {
            //Defines PK
            builder.HasKey(p => p.PromoId);
            //Defines Column Name
            builder.Property(p => p.PromoTitle).HasColumnName("Title");
            //Defines NOT NULL
            builder.Property(p => p.PromoTitle).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Active).IsRequired();
            //Defines field Size
            builder.Property(p => p.PromoTitle).HasMaxLength(200);
            builder.Property(p => p.Description).HasMaxLength(500);
        }
    }
}