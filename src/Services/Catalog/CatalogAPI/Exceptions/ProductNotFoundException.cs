using BuildingBlocks.Exceptions;

namespace CatalogAPI.Exceptions;

public class ProductNotFoundException: NotFoundException
{
    public ProductNotFoundException(Guid productId)
        : base($"Product with id {productId} was not found.")
    {
    }

}
