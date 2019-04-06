using EventManager.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Data
{
    public class EventManagerDbContext : IdentityDbContext<User>
    {
        public EventManagerDbContext(DbContextOptions<EventManagerDbContext> options)
            : base(options) { }

        public DbSet<Event> Events { get; set; }
        
        public DbSet<Address> Addresses { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<EventList> EventLists { get; set; }
        

        /// <summary>
        /// Cobfigure database
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationData.connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Create many to many relation between Events and EventLists
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<EventsEventLists>()
                .HasKey(ee => new { ee.EventId, ee.EventListId });


            builder.Entity<EventsEventLists>()
                    .HasOne(ee => ee.Event)
                    .WithMany(e => e.EventsEventLists)
                    .HasForeignKey(ee => ee.EventId);

            builder.Entity<EventsEventLists>()
                .HasOne(ee => ee.Event)
                .WithMany(e => e.EventsEventLists)
                .HasForeignKey(ee => ee.EventId);

        }
    }
}
