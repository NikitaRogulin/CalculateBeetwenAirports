using System.Text.Json.Serialization;
namespace AirportService.Airports.AppServices.Models;

public class Location
{
    [JsonPropertyName("lat")]public double Latitude { get; set; }
    [JsonPropertyName("lon")]public double Longitude { get; set; }
}