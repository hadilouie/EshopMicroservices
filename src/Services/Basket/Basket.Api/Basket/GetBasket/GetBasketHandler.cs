

namespace Basket.Api.Basket.GetBasket;

public record GetBasketQuery(string UserName) : IQuery<GetBasketResutl>;

public record GetBasketResutl(ShoppingCart cart);


public class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, GetBasketResutl>
{
    //private readonly IBasketRepository _basketRepository;

    //public GetBasketQueryHandler(IBasketRepository basketRepository)
    //{
    //    _basketRepository = basketRepository;
    //}

    public async Task<GetBasketResutl> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        //var basket = await _basketRepository.GetBasketAsync(query.UserName);
        //var result = new GetBasketResutl(basket ?? new ShoppingCart(query.UserName));
        //return result;

        return new GetBasketResutl(new ShoppingCart(query.UserName));
    }
}

