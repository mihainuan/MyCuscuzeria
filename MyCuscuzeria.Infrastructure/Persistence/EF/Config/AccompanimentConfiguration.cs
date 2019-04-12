using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCuscuzeria.Domain.Entities;

namespace MyCuscuzeria.Infrastructure.Persistence.EF.Config
{
    public class AccompanimentConfiguration : IEntityTypeConfiguration<Accompaniment>
    {
        public void Configure(EntityTypeBuilder<Accompaniment> builder)
        {
            //Defines PK
            builder.HasKey(a => a.AccompanimentId);
            //Defines NOT NULL
            builder.Property(a => a.AccompanimentName).IsRequired();
            builder.Property(a => a.Description).IsRequired();
            //Defines field Size
            builder.Property(a => a.AccompanimentName).HasMaxLength(150);
            builder.Property(a => a.Description).HasMaxLength(500);
        }
    }
}