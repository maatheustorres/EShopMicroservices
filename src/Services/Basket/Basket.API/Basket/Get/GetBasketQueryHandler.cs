using Basket.API.Models;
using BuildingBlocks.CQRS;

namespace Basket.API.Basket.Get;

public record GetBasketQuery(string Username) : IQuery<GetBasketResult>;
public record GetBasketResult(ShoppingCart ShoppingCart);

public class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        return new GetBasketResult(new ShoppingCart("issoai"));
    }
}