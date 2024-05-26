namespace Basket.Api.Basket.DeleteBasket;
public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;

public record DeleteBasketResult(bool IsSuccess);

public class DeleteBasketCommandHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    //private readonly IBasketRepository _basketRepository;

    //public DeleteBasketCommandHandler(IBasketRepository basketRepository)
    //{
    //    _basketRepository = basketRepository;
    //}

    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        //var basket = await _basketRepository.DeleteBasketAsync(command.UserName);
        //return new DeleteBasketResult(basket);
        return new DeleteBasketResult(true);
    }
}
