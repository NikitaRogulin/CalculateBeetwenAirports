namespace AirportService.Airports.Api.Contracts;

public static class WebRoutes
{
    public const string BasePath = "https://places-dev.continent.ru/";

    public static class Airport
    {
        public const string CalculateDistancePath = BasePath + "distance";
    }
}