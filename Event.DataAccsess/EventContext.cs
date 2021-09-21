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
        public DbSet<Event.Entities.Concrete.Event> Events { get; set; }
        public DbSet<UsersEvent> UsersEvents { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersEvent>().HasKey(UsersEvent => new { UsersEvent.EventId, UsersEvent.UserId });

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
        }

    }
}
