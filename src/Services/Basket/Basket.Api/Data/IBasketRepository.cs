﻿namespace Basket.Api.Data;

public interface IBasketRepository
{
    Task<ShoppingCart> GetBasketAsync(string userName, CancellationToken cancellationToken = default);
    Task<ShoppingCart> StoreBasketAsync(ShoppingCart basket, CancellationToken cancellationToken = default);
    Task<ShoppingCart> DeleteBasketAsync(ShoppingCart basket, CancellationToken cancellationToken = default);
}
