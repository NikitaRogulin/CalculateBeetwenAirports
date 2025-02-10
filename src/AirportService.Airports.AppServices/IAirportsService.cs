using AirportService.Airports.AppServices.Models;

namespace AirportService.Airports.AppServices;

public interface IAirportsService
{
    public Task<Airport> GetAirport(string iataCode, CancellationToken token = default);
    public double CalculateDistance(Airport airport1, Airport airport2, CancellationToken token = default);
}