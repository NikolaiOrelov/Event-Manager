using EventManager.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Data
{
    public class EventManagerDbContext : IdentityDbContext
    {
        public EventManagerDbContext(DbContextOptions<EventManagerDbContext> options) 
            : base(options) { }

        public DbSet<Event> Events { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Address> Addresses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationData.connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserEvent>()
                .HasKey(ue => new { ue.UserId, ue.EventId});


            builder.Entity<UserEvent>()
                    .HasOne(ue => ue.User)
                    .WithMany(u => u.UserEvent)
                    .HasForeignKey(ue => ue.UserId);

            builder.Entity<UserEvent>()
                .HasOne(ue => ue.Event)
                .WithMany(e => e.UserEvent)
                .HasForeignKey(ue => ue.EventId);
            
        }
    }
}
