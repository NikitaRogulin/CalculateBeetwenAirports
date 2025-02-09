using AirportService.Airports.AppServices;
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
        services.AddScoped<IAirportsService, AirportsService>();
        services.AddDbContext<AirportsContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("AirportsContext")));
        /*services.AddDbContext<AirportsContext>();*/
        services.AddScoped<IAirportsRepository, AirportsRepository>();
        
        services.AddHttpClient();
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
    
    /*static void MigrateDb(IHost app)
    {
        var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

        using var scope = scopedFactory!.CreateScope();
        var dbContext = scope.ServiceProvider.GetService<AirportsContext>();
        dbContext!.Database.Migrate();
    }*/
    private static void MigrateDb(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AirportsContext>();
            dbContext.Database.Migrate();
        }
    }
}