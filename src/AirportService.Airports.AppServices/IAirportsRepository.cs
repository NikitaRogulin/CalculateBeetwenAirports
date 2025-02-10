using AirportService.Airports.AppServices.Models;

namespace AirportService.Airports.AppServices;
public interface IAirportsRepository
{
    public Task Create(Airport airport, CancellationToken token = default);
    public Task<Airport?> GetByIATA(string iataCode, CancellationToken token = default);
}