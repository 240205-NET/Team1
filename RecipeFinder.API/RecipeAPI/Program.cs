using Microsoft.Extensions.Configuration;
using RecipeAPI.Model;
using RecipeAPI.Repository;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

string connectionString = configuration.GetConnectionString("MyDatabase");

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<UserRepository>(sp => new UserRepository(connectionString, sp.GetRequiredService<ILogger<UserRepository>>()));

builder.Services.AddSingleton<MealRepository>(sp => new MealRepository(connectionString, sp.GetRequiredService<ILogger<MealRepository>>()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();