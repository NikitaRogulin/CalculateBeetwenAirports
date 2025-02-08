using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AirportService.Airports.Persictence.Migrations;

public class BloggingContextFactory : IDesignTimeDbContextFactory<AirportsContext>
{
    public AirportsContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AirportsContext>();
        optionsBuilder.UseNpgsql("AirportsContext");

        return new AirportsContext(optionsBuilder.Options);
    }
}