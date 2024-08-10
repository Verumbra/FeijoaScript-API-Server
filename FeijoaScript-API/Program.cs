using FeijoaAPI_Server.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();

var mongoclient = new MongoClient(configuration.GetConnectionString("MongoDb"));
builder.Services.AddSingleton<IMongoClient>(mongoclient);
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IRecipeRepository, RecipeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapControllers();


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}