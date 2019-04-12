using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCuscuzeria.Domain.Entities;

namespace MyCuscuzeria.Infrastructure.Persistence.EF.Config
{
    public class TypeConfiguration : IEntityTypeConfiguration<Type>
    {
        public void Configure(EntityTypeBuilder<Type> builder)
        {
            //Defines PK
            builder.HasKey(t => t.TypeId);
            //Defines NOT NULL
            builder.Property(t => t.TypeName).IsRequired();
            builder.Property(t => t.Description).IsRequired();
            //Defines field Size
            builder.Property(t => t.TypeName).HasMaxLength(150);
            builder.Property(t => t.Description).HasMaxLength(500);
        }
    }
}