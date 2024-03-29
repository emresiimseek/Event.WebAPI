﻿using Event.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.DataAccsess.Configurations
{
    class EventConfiguration : IEntityTypeConfiguration<Activity>
    {

        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseMySqlIdentityColumn();
            builder.Property(e => e.Title).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(250).IsRequired();
            builder.Property(e => e.EventDate).HasColumnType("datetime").IsRequired();




        }
    }
}
