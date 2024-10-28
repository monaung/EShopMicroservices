using Carter;
using Catalog.API.Products.CreateProduct;

var builder = WebApplication.CreateBuilder(args);

//before: build: add services to container (DI)
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});


var app = builder.Build();

//after: configure the HTTP request pipeline
app.MapCarter();

app.Run();
