namespace Basket.Api.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

public record StoreBasketResult(string username);

public class StoreBasketCommandHandler : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    //private readonly IBasketRepository _basketRepository;

    //public StoreBasketCommandHandler(IBasketRepository basketRepository)
    //{
    //    _basketRepository = basketRepository;
    //}

    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        ShoppingCart cart = command.Cart;
        //var basket = await _basketRepository.UpdateBasketAsync(command.Cart);
        //return new StoreBasketResult(basket != null);
        return new StoreBasketResult("swn");
    }
}

