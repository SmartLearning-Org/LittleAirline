using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace LittleAirline.Models
{
    internal class AppDbContext : DbContext
    {

        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<FlightPilot> FlightPilots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=airline.db")
            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
            .EnableSensitiveDataLogging();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the many-to-many relationship
            modelBuilder.Entity<FlightPilot>()
                .HasKey(fp => new { fp.FlightId, fp.PilotId });

            modelBuilder.Entity<FlightPilot>()
                .HasOne(fp => fp.Flight)
                .WithMany(f => f.FlightPilots)
                .HasForeignKey(fp => fp.FlightId);

            modelBuilder.Entity<FlightPilot>()
                .HasOne(fp => fp.Pilot)
                .WithMany(p => p.FlightPilots)
                .HasForeignKey(fp => fp.PilotId);

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;

            var aircraftsFilePath = Path.Combine(basePath, "aircrafts.json");
            var aircrafts = JsonSerializer.Deserialize<List<Aircraft>>(File.ReadAllText(aircraftsFilePath));
            modelBuilder.Entity<Aircraft>().HasData(aircrafts);

            var pilotsFilePath = Path.Combine(basePath, "unique_pilots.json");
            var pilots = JsonSerializer.Deserialize<List<Pilot>>(File.ReadAllText(pilotsFilePath));
            modelBuilder.Entity<Pilot>().HasData(pilots);

            var flightsFilePath = Path.Combine(basePath, "flights.json");
            var flights = JsonSerializer.Deserialize<List<Flight>>(File.ReadAllText(flightsFilePath));
            modelBuilder.Entity<Flight>().HasData(flights);

            var flightPilotsFilePath = Path.Combine(basePath, "flightPilot.json");
            var flightPilots = JsonSerializer.Deserialize<List<FlightPilot>>(File.ReadAllText(flightPilotsFilePath));
            modelBuilder.Entity<FlightPilot>().HasData(flightPilots);
        }
    }
}
