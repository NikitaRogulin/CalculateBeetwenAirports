using System.Text.Json.Serialization;
namespace AirportService.Airports.Domain.Contracts;

public class AirPortDto
{
    [JsonPropertyName("iata")]public string Code { get; set; }
    [JsonPropertyName("location")]public Location Location { get; set; }
}