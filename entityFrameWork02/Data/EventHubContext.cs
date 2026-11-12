using entityFrameWork02.Data.Configurations;
using entityFrameWork02.Models;
using Microsoft.EntityFrameworkCore;
namespace entityFrameWork02.Data
{
    public class EventHubContext : DbContext
    {
        public DbSet<Organizer> Organizers => Set<Organizer>();
        public DbSet<OrganizerProfile> OrganizerProfiles => Set<OrganizerProfile>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<Attendee> Attendees => Set<Attendee>();
        public DbSet<Badge> Badges => Set<Badge>();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EventHubDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganizerProfile>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Biography).HasMaxLength(1000);
                entity.Property(p => p.WebsiteUrl).HasMaxLength(300);
                entity.Property(p => p.LogoUrl).HasMaxLength(300);


                entity.HasOne(p => p.Organizer)
                .WithOne(o => o.Profile)
                .HasForeignKey<OrganizerProfile>(p => p.OrganizerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasOne(e => e.Organizer)
                    .WithMany(o => o.Events)
                    .HasForeignKey(e => e.OrganizerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.ApplyConfiguration(new BadgeConfiguration());

        }

    }
}
