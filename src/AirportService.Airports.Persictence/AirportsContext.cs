using AirportService.Airports.AppServices.Models;

namespace AirportService.Airports.Persictence;
using Microsoft.EntityFrameworkCore;

public class AirportsContext : DbContext
{
    public DbSet<Airport> Airports { get; set; }

    public AirportsContext(DbContextOptions<AirportsContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AirportConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}