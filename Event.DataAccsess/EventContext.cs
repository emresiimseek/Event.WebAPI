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
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<User_Role> UsersRoles { get; set; }
        public DbSet<User_Activity> UserActivities { get; set; }
        public DbSet<Activity_Category> ActivitysCategories { get; set; }
        public DbSet<Activity_Like> ActivityLikes { get; set; }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User_User> UserUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_Activity>().HasKey(UsersEvent => new { UsersEvent.ActivityId, UsersEvent.UserId });
            modelBuilder.Entity<Activity_Category>().HasKey(EventsCategory => new { EventsCategory.CategoryId, EventsCategory.ActivityId });
            modelBuilder.Entity<Activity_Like>().HasKey(EventsCategory => new { EventsCategory.ActivityId, EventsCategory.UserId });


            //friends
            modelBuilder.Entity<User_User>().HasKey(uu => new { uu.UserParentId, uu.UserChildId });

            modelBuilder.Entity<User_User>()
                .HasOne(uu => uu.UserParent)
                .WithMany(uu => uu.IAmFriendsWith)
                .HasForeignKey(uu => uu.UserParentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User_User>()
                .HasOne(uu => uu.UserChild)
                .WithMany(uu => uu.AreFirendsWithMe)
                .HasForeignKey(uu => uu.UserChildId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }

    }
}
