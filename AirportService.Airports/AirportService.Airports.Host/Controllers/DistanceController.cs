using AirportService.Airports.Api.Contracts;
using AirportService.Airports.AppServices;
using Microsoft.AspNetCore.Mvc;
using GeoCoordinatePortable;

namespace AirportService.Airports.Controllers;

[ApiController]
[Route("api/[controller]")]

public class DistanceController
{
    private readonly IAirportsService _airportsService;
    public DistanceController(IAirportsService airportsService)
    {
        _airportsService = airportsService;
    }

    [HttpGet]
    public async Task<double> CalculatingDistance(string iataCode_1, string iataCode_2, CancellationToken token = default)
    {
        var airport1 = await _airportsService.GetAirport(iataCode_1, token);
        var airport2 = await _airportsService.GetAirport(iataCode_2, token);

        if (airport1 == null || airport2 == null)
        {
            throw new AggregateException("Один из аэропортов не найден.");
        }

        return _airportsService.CalculateDistance(airport1, airport2, token);
    }
}