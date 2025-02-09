using System.Text.Json;
using AirportService.Airports.Api.Contracts;
using AirportService.Airports.Domain;
using AirportService.Airports.Domain.Contracts;
using GeoCoordinatePortable;
namespace AirportService.Airports.AppServices;

public class AirportsService : IAirportsService
{
    private const double multiplier = 0.000621371;
    
    private readonly IAirportsRepository _airportsRepository;
    private readonly HttpClient _httpClient;
    
    public AirportsService(IAirportsRepository airportsRepository, HttpClient httpClient)
    {
        _airportsRepository = airportsRepository;
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri($"{WebRoutes.BasePath}");
    }
    public async Task<Airport> GetAirport(string iataCode, CancellationToken token = default)
    {
        var airport = await _airportsRepository.GetByIATA(iataCode, token);
        if (airport != null)
        {
            return airport;
        }

        var response = await _httpClient.GetStringAsync($"airports/{iataCode}", token);
        airport = JsonSerializer.Deserialize<Airport>(response);
        
        _airportsRepository.Create(airport,token);
        return airport;
    }
    public double CalculateDistance(Airport airport1, Airport airport2, CancellationToken token = default)
    {
        var coordinate1 =  new GeoCoordinate(airport1.Latitude, airport1.Longitude);
        var coordinate2 =  new GeoCoordinate(airport2.Latitude, airport2.Longitude);

        var distanceInMeters = coordinate1.GetDistanceTo(coordinate2);
        return distanceInMeters * multiplier;
    }
}