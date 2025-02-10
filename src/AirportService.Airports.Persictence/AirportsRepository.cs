using AirportService.Airports.AppServices;
using AirportService.Airports.AppServices.Models;
using Microsoft.EntityFrameworkCore;

namespace AirportService.Airports.Persictence;

public class AirportsRepository : IAirportsRepository
{
    private AirportsContext _airportsContext;

    public AirportsRepository(AirportsContext context)
    {
        _airportsContext = context;
    }

    public async Task Create(Airport airport, CancellationToken token = default)
    {
        _airportsContext.Airports.Add(airport);
        await _airportsContext.SaveChangesAsync(token);
    }

    public async Task<Airport?> GetByIATA(string iataCode, CancellationToken token = default)
    {
        var airport = await _airportsContext.Airports.FirstOrDefaultAsync(x => x.Code == iataCode, token);
        return airport;
    }
}