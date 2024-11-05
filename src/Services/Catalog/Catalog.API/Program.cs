using BuildingBlocks.Behaviours;
using Carter;
using Catalog.API.Products.CreateProduct;
using FluentValidation;
using Marten;

var builder = WebApplication.CreateBuilder(args);

//before: build: add services to container (DI)
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddCarter();

builder.Services.AddMarten(option =>
{
    option.Connection(builder.Configuration.GetConnectionString("Database")!);
 
}).UseLightweightSessions();

var app = builder.Build();

//after: configure the HTTP request pipeline
app.MapCarter();

app.Run();
