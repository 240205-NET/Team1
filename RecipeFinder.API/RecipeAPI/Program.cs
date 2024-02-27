using Microsoft.Extensions.Configuration;
using RecipeFinder.DTO;
using RecipeFinder.Logic.Model;

var builder = WebApplication.CreateBuilder(args);




;
//await File.ReadAllTextAsync("../.connectionString") ?? throw new ArgumentNullException(nameof(connectionString));
string connectionString = builder.Configuration.GetConnectionString("MyDatabase") ?? throw new ArgumentNullException(nameof(connectionString));
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = new ConfigurationBuilder.
    SetBasePath(builder.Environment.ContentRootPath).
    AddJsonFile("appsettings.json").
    Build();

builder.Services.AddSingleton<MealAccess>(config);
builder.Services.AddSingleton<MealPlanAccess>(config);
builder.Services.AddSingleton<UserAccess>(config);

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
