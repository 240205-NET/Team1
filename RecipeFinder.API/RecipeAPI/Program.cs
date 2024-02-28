using Microsoft.Extensions.Configuration;
using RecipeFinder.DTO;
using RecipeFinder.Logic.Model;
using Microsoft.Extensions.Configuration.Json;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException(nameof(connectionString));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton(new RecipeRepository(configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
