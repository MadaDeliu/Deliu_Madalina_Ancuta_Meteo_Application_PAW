using Microsoft.EntityFrameworkCore;
using MeteoApplicationMVC.Models;
using static System.Collections.Specialized.BitVector32;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MeteoApplicationMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<WeatherData> MeteoData { get; set; }
        public DbSet<FavoriteLocation> FavoriteLocations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<SevereWeatherEvent> SevereWeatherEvents { get; set; }
        public DbSet<Meteorologist> Meteorologists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // definim relația între tabele
            modelBuilder.Entity<WeatherData>()
                .HasOne(w => w.Station)
                .WithMany(s => s.WeatherData)
                .HasForeignKey(w => w.StationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SevereWeatherEvent>()
                .HasOne(e => e.City)
                .WithMany(c => c.SevereWeatherEvents)
                .HasForeignKey(e => e.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Meteorologist>()
                .HasOne(m => m.Station)
                .WithMany(s => s.Meteorologists)
                .HasForeignKey(m => m.StationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FavoriteLocation>()
                .HasOne(f => f.User)
                .WithMany(u => u.FavoriteLocations)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FavoriteLocation>()
                .HasOne(f => f.City)
                .WithMany(c => c.FavoriteLocations)
                .HasForeignKey(f => f.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.User)
                .WithMany(u => u.Contacts)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Alert>()
                .HasOne(a => a.City)
                .WithMany(c => c.Alerts)
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Alert>()
                .HasOne(a => a.User)
                .WithMany(u => u.Alerts)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Contact>()
            .HasOne(c => c.User)
            .WithMany(u => u.Contacts)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Station>()
                .HasOne(s => s.City)
                .WithMany(c => c.Stations)
                .HasForeignKey(s => s.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
