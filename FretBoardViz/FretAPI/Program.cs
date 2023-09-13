using FretAPI.Services;
using FretAPI.Utils;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Create or populate the Tunings.json file as needed
        BaseTuningFileGenerator.CreateDefaultFile();

        // Add services to the container.

        builder.Services.AddControllers();

        // Register your ITuningService implementation
        /*services.AddScoped<IFretboardService, FretboardService>();
        services.AddScoped<ITuningsService, TuningsService>();
        services.AddScoped<IUserService, UserService>();*/


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

