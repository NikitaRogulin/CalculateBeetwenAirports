using System.Text.Json.Serialization;
namespace AirportService.Airports.AppServices.Models;

public class AirportData
{
    [JsonPropertyName("iata")]public string Code { get; set; }
    [JsonPropertyName("location")]public Location Location { get; set; }
}