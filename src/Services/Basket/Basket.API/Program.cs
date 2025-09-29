using Basket.API.Data;
using Basket.API.Models;
using BuildingBlocks.Behaviors;
using BuildingBlocks.Exceptions.Handlers;
using Carter;
using HealthChecks.UI.Client;
using Marten;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddMediatR(x =>
{
    x.RegisterServicesFromAssembly(typeof(Program).Assembly);
    x.AddOpenBehavior(typeof(ValidationBehaviors<,>));
    x.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

var databaseConnectionString = builder.Configuration.GetConnectionString("Database")!;

builder.Services.AddMarten(opts =>
{
    opts.Connection(databaseConnectionString);
    opts.Schema.For<ShoppingCart>().Identity(x => x.Username); // TODO: APÓS O CURSO MUDAR PARA USAR ID AO INVÉS DE USERNAME 
}).UseLightweightSessions();

builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.Decorate<IBasketRepository, CachedBasketRepository>();

var redisConnectionString = builder.Configuration.GetConnectionString("Redis")!;

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = redisConnectionString;
});

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddHealthChecks()
    .AddNpgSql(databaseConnectionString)
    .AddRedis(redisConnectionString);

var app = builder.Build();

app.MapCarter();

app.UseExceptionHandler(options => { });

app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();
