using Carter;
using Catalog.API.Models;
using Catalog.API.Products.CreateProduct;
using Mapster;
using MediatR;

namespace Catalog.API.Products.GetProducts
{
    public record GetProductsRequest();
    public record GetProductsResponse(IEnumerable<Product> products);
    public class GetProductsEntpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
               // var query = request.Adapt<GetProducstQuery>();
                var result = await sender.Send(new GetProductsQuery());

                var response = result.Adapt<GetProductsResponse>();

                return Results.Ok(response);

            }).WithName("GetProducts")
            .Produces<GetProductsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products")
            .WithDescription("Get Products"); ;
        }
    }
}
