using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AirportService.Airports.Persictence;

/*public class BloggingContextFactory : IDesignTimeDbContextFactory<AirportsContext>
{
    public AirportsContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("AirportsContext");

        var optionsBuilder = new DbContextOptionsBuilder<AirportsContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new AirportsContext(optionsBuilder.Options);
    }
}*/