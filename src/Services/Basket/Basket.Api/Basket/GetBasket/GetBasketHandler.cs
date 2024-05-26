
namespace Basket.Api.Basket.GetBasket;

public record GetBasketQuery(string UserName) : IQuery<GetBasketResutl>;

public record GetBasketResutl(ShoppingCart Cart);


public class GetBasketQueryHandler(IBasketRepository repository) : IQueryHandler<GetBasketQuery, GetBasketResutl>
{
    public async Task<GetBasketResutl> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        var basket = await repository.GetBasketAsync(query.UserName);

        return new GetBasketResutl(basket);
    }
}

