using Event.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace Event.DataAccsess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).UseMySqlIdentityColumn();
            builder.Property(u => u.BirthDate).HasColumnType("datetime").IsRequired();
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(200);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(200);
            builder.Property(u => u.Gender).IsRequired();
            builder.Property(u => u.Password).HasMaxLength(100).IsRequired();
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);

        }
    }
}
