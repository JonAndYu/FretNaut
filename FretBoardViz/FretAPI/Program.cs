using FretAPI.Data;
using FretAPI.DbAccess;
using FretAPI.Services;
using FretAPI.Utils;
using Microsoft.Extensions.Logging;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Create or populate the Tunings.json file as needed
        // BaseTuningFileGenerator.CreateDefaultFile();

        // Add services to the container.

        builder.Services.AddControllers();

        // Register SQL
        builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();

        // Register your services
        builder.Services.AddScoped<IFretboardService, FretboardService>();
        builder.Services.AddScoped<IUsersService, UsersService>();
        builder.Services.AddScoped<ITuningsService, TuningsService>();

        // Register your data access classes
        // TODO: Compare the differences between AddSingleton and AddScope.
        builder.Services.AddSingleton<IFretboardData, FretboardData>();
        builder.Services.AddSingleton<IUsersData, UsersData>();
        builder.Services.AddSingleton<ITuningsData, TuningsData>();


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

