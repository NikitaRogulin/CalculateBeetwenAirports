using AirportService.Airports.Domain;
using AirportService.Airports.Persictence;
using Microsoft.EntityFrameworkCore;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var services = builder.Services;
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<AirportsContext>();
        services.AddScoped<IAirportsRepository, AirportsRepository>();

        var app = builder.Build();
        
        MigrateDb(app);
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
    
    static void MigrateDb(IHost app)
    {
        var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

        using var scope = scopedFactory!.CreateScope();
        var dbContext = scope.ServiceProvider.GetService<AirportsContext>();
        dbContext!.Database.Migrate();
    }
}