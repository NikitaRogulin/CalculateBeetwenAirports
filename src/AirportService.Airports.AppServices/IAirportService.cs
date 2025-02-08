using AirportService.Airports.Domain.Contracts;

namespace AirportService.Airports.AppServices;

public interface IAirportService
{
    public Task<Airport> GetAirport(string iataCode, CancellationToken token = default);
    public Task<double> CalculateDistance(Airport airport1, Airport airport2, CancellationToken token = default);
}