using Contributers.API;
using MediatR;
using Octokit;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
});

// Add services to the container.

builder.Services.AddMediatR(typeof(Program));

builder.Services.AddControllers();

var gitHubClient = new GitHubClient(new ProductHeaderValue("GitHubClient"));

var username = builder.Configuration["GitHubCredentials:Username"];
var password = builder.Configuration["GitHubCredentials:Password"];
var basicAuth = new Credentials(username, password);
gitHubClient.Credentials = basicAuth;

builder.Services.AddSingleton<IGitHubClient>(gitHubClient);

builder.Services.AddSingleton<GitHubService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
