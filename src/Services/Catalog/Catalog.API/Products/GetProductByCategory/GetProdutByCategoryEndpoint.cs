﻿using Carter;
using Catalog.API.Models;
using Mapster;
using MediatR;

namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryResponse(IEnumerable<Product> Products);
    public class GetProdutByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByCategoryQuery(category));

                var response = result.Adapt<GetProductByCategoryResponse>();

                return Results.Ok(response);

            })
             .WithName("GeProductByCategory")
             .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("Get Product By Category")
             .WithSummary("Get Product By Category");
        }
    }
}