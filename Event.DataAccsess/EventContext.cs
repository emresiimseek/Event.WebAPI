using Event.DataAccsess.Configurations;
using Event.Entities.Concrete;
using Event.Entities.DTOs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.DataAccsess
{
    public class EventContext : DbContext
    {

        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {
        }

        public DbSet<UsersRole> UsersRoles { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Role> Roles{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

    }
}
