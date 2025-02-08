namespace AirportService.Airports.Domain.Contracts;

public class Airport
{
    public int Id { get; set; }
    public string Code { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}