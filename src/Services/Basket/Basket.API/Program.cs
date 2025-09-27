using Basket.API.Models;
using BuildingBlocks.Behaviors;
using Carter;
using Marten;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddMediatR(x =>
{
    x.RegisterServicesFromAssembly(typeof(Program).Assembly);
    x.AddOpenBehavior(typeof(ValidationBehaviors<,>));
    x.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    opts.Schema.For<ShoppingCart>().Identity(x => x.Username); // TODO: APÓS O CURSO MUDAR PARA USAR ID AO INVÉS DE USERNAME 
}).UseLightweightSessions();

var app = builder.Build();

app.MapCarter();

app.Run();
