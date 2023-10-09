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

        // Register your data access classes
        // TODO: Compare the differences between AddSingleton and AddScope.
        builder.Services.AddSingleton<IFretboardData, FretboardData>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

		// Add CORS services
		builder.Services.AddCors(options =>
		{
			options.AddPolicy("AllowSpecificOrigin", builder =>
			{
				builder.WithOrigins("http://localhost:3000")
					   .AllowAnyHeader()
					   .AllowAnyMethod();
			});
		});

		builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

		var app = builder.Build();

		app.UseCors("AllowSpecificOrigin");
		// Configure the HTTP request pipeline.
		app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

		app.UseHsts();
		app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}

