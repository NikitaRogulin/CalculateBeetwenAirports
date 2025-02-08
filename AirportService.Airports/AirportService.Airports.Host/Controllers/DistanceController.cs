using AirportService.Airports.AppServices;
using Microsoft.AspNetCore.Mvc;
using GeoCoordinatePortable;

namespace AirportService.Airports.Controllers;

[ApiController]
public class DistanceController
{
    private readonly IAirportService _airportService;
    public DistanceController(IAirportService airportService)
    {
        _airportService = airportService;
    }

    [HttpGet]
    public async Task<double> CalculatingDistance(string iataCode_1, string iataCode_2, CancellationToken token = default)
    {
        var airport1 = await _airportService.GetAirport(iataCode_1);
        var airport2 = await _airportService.GetAirport(iataCode_2);

        if (airport1 == null || airport2 == null)
        {
            throw new AggregateException("Один из аэропортов не найден.");
        }

        var distance = await _airportService.CalculateDistance(airport1, airport2, token);
        return distance;
    }
}