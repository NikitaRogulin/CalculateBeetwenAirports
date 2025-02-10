using System.Text.Json.Serialization;
namespace AirportService.Airports.Domain.Contracts;

public class Location
{
    [JsonPropertyName("lat")]public double Latitude { get; set; }
    [JsonPropertyName("lon")]public double Longitude { get; set; }
}