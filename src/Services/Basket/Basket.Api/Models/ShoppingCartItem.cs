namespace Basket.Api.Models;

public class ShoppingCartItem
{
    public int quantity { get; set; } =default!;
    public string color { get; set; } = default!;
    public decimal price { get; set; } = default!;
    public Guid productId { get; set; } = default!;
    public string productName { get; set; } = default!;
}
