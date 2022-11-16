using Contributers.API;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
});

builder.Services.Configure<GitHubCredentials>(builder.Configuration.GetSection("GitHubCredentials"));

// Add services to the container.

builder.Services.AddMediatR(typeof(Program));

builder.Services.AddControllers();

builder.Services.AddSingleton<GitHubService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
