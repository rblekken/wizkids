using Wizkids.Api.Client.Prediction;
using Wizkids.Api.Services;
using Microsoft.EntityFrameworkCore;
using Wizkids.Api.DataAccess;
using Wizkids.Api.Options;

var builder = WebApplication.CreateBuilder(args);
var settings = builder.Configuration.GetSection("Database").Get<DatabaseOptions>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IPredictionClient, PredictionClient>();
builder.Services.AddSingleton<IPredictionService, PredictionService>();
builder.Services.Configure<PredictionClientOptions>(builder.Configuration.GetSection("Clients:Prediction"));
builder.Services.AddDbContext<DictionaryContext>(options => {
    options.UseSqlite($"Datasource={settings.Datasource}");
}, ServiceLifetime.Singleton);
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();