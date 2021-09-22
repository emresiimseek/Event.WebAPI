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

        public DbSet<Users_Role> UsersRoles { get; set; }
        public DbSet<User_Activity> UsersEvents { get; set; }
        public DbSet<Activitys_Category> ActivitysCategories { get; set; }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_Activity>().HasKey(UsersEvent => new { UsersEvent.ActivityId, UsersEvent.UserId });

            modelBuilder.Entity<Activitys_Category>().HasKey(EventsCategory => new { EventsCategory.CategoryId, EventsCategory.ActivityId });

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }

    }
}
