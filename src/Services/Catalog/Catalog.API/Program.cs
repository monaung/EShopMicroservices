using Carter;
using Catalog.API.Products.CreateProduct;
using Marten;

var builder = WebApplication.CreateBuilder(args);

//before: build: add services to container (DI)
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddMarten(option =>
{
    option.Connection(builder.Configuration.GetConnectionString("Database")!);
 
}).UseLightweightSessions();

var app = builder.Build();

//after: configure the HTTP request pipeline
app.MapCarter();

app.Run();
