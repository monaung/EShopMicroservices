﻿using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Marten;

namespace Catalog.API.Products.GetProducts
{
    public record GetProductsQuery():IQuery<GetProductResult>;
    public record GetProductResult(IEnumerable<Product> Products);
    internal class GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger) 
        : IQueryHandler<GetProductsQuery, GetProductResult>
    {
        public async Task<GetProductResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsQueryHandler.Handle call with {@Query}", query);
            var products = await session.Query<Product>().ToListAsync(cancellationToken);

            return new GetProductResult(products);
        }
    }
}
