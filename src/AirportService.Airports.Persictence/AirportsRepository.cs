using AirportService.Airports.Domain;
using AirportService.Airports.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AirportService.Airports.Persictence;

public class AirportsRepository : IAirportsRepository
{
    private AirportsContext _airportsContext;

    public AirportsRepository(AirportsContext context)
    {
        _airportsContext = context;
    }
    
    public void Create(Airport airport, CancellationToken token = default)
    {
        _airportsContext.Airports.Add(airport);
        _airportsContext.SaveChangesAsync(token);
    }

    public Task<Airport?> GetByIATA(string iataCode, CancellationToken token = default)
    {
       var airport = _airportsContext.Airports.FirstOrDefaultAsync(x => x.Code == iataCode);
       return airport;
    }
}