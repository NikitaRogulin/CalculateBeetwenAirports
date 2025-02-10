using AirportService.Airports.Domain.Contracts;
namespace AirportService.Airports.Domain;

public interface IAirportsRepository
{
    public Task Create(Airport airport, CancellationToken token = default);
    public Task<Airport?> GetByIATA(string iataCode, CancellationToken token = default);
}