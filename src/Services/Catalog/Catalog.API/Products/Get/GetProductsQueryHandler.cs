using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Marten;
using Marten.Pagination;

namespace Catalog.API.Products.Get;

public record GetProductsQuery(int? Page = 1, int? PageSize = 10) : IQuery<GetProductsResult>;
public record GetProductsResult(IEnumerable<Product> Products);
public sealed class GetProductsQueryHandler(
    IDocumentSession session) : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var produts = await session
            .Query<Product>()
            .ToPagedListAsync(query.Page ?? 1, query.PageSize ?? 10, cancellationToken);

        return new GetProductsResult(produts);
    }
}
