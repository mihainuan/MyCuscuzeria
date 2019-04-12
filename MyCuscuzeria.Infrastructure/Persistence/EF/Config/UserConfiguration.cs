using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.ValueObjects;

namespace MyCuscuzeria.Infrastructure.Persistence.EF.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        //Mapping DB fields configurations for Database (EntityFramework 6)
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Defines TableName
            builder.ToTable("Clients");

            //Defines PK
            builder.HasKey(u => u.UserId);
            //Defines Column Name
            builder.Property(u => u.Username).HasColumnName("Name");

            //Mapeando objetos de valor
            builder.OwnsOne<FullName>(x => x.Fullname, cb =>
                {
                    cb.Property(x => x.FirstName).HasMaxLength(50).HasColumnName("FirstName").IsRequired();
                    cb.Property(x => x.LastName).HasMaxLength(50).HasColumnName("LastName").IsRequired();
                });

            //Defines NOT NULL
            builder.Property(u => u.Username).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Phone).IsRequired();
            //Defines field Size
            builder.Property(u => u.Username).HasMaxLength(150);
            builder.Property(u => u.Password).HasMaxLength(50);
            builder.Property(u => u.Email).HasMaxLength(100);
            builder.Property(u => u.Phone).HasMaxLength(150);
            builder.Property(u => u.UrlImg).HasMaxLength(500);


            //Populating with sample Data
            //builder.HasData(
            //    new User() { UserId = 1, CreatedAt = DateTime.Now, Username = "mihai", LastOrder = DateTime.Today, Email = "mihai@email.com", Phone = "+55719988-7733", Password = "SZ@111222" },
            //    new User() { UserId = 2, CreatedAt = DateTime.Now, Username = "yjqom", LastOrder = DateTime.Today, Email = "yjqom@email.com", Phone = "+55719988-7733", Password = "SZ@111222" },
            //    new User() { UserId = 3, CreatedAt = DateTime.Now, Username = "ojbzg ", LastOrder = DateTime.Today, Email = "ojbzg@email.com", Phone = "+55719988-7733", Password = "SZ@111222" },
            //    new User() { UserId = 4, CreatedAt = DateTime.Now, Username = "sgdxp", LastOrder = DateTime.Today, Email = "sgdxp@email.com", Phone = "+55719988-7733", Password = "SZ@111222" },
            //    new User() { UserId = 5, CreatedAt = DateTime.Now, Username = "tkolf", LastOrder = DateTime.Today, Email = "tkolf@email.com", Phone = "+55719988-7733", Password = "SZ@111222" },
            //    new User() { UserId = 6, CreatedAt = DateTime.Now, Username = "jkgvb", LastOrder = DateTime.Today, Email = "jkgvb@email.com", Phone = "+55719988-7733", Password = "SZ@111222" },
            //    new User() { UserId = 7, CreatedAt = DateTime.Now, Username = "wkint", LastOrder = DateTime.Today, Email = "wkint@email.com", Phone = "+55719988-7733", Password = "SZ@111222" },
            //    new User() { UserId = 8, CreatedAt = DateTime.Now, Username = "zeozf", LastOrder = DateTime.Today, Email = "zeozf@email.com", Phone = "+55719988-7733", Password = "SZ@111222" },
            //    new User() { UserId = 9, CreatedAt = DateTime.Now, Username = "ywabo", LastOrder = DateTime.Today, Email = "ywabo@email.com", Phone = "+55719988-7733", Password = "SZ@111222" },
            //    new User() { UserId = 10, CreatedAt = DateTime.Now, Username = "qcrlf", LastOrder = DateTime.Today, Email = "qcrlf@email.com", Phone = "+55719988-7733", Password = "SZ@111222" },
            //    new User() { UserId = 11, CreatedAt = DateTime.Now, Username = "wfqyd", LastOrder = DateTime.Today, Email = "wfqyd@email.com", Phone = "+55719988-7733", Password = "SZ@111222" },
            //    new User() { UserId = 12, CreatedAt = DateTime.Now, Username = "ekspr", LastOrder = DateTime.Today, Email = "ekspr@email.com", Phone = "+55719988-7733", Password = "SZ@111222" }
            //);
        }
    }
}