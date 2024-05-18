using BuildingBlocks.CQRS;
using CatalogAPI.Models;
namespace CatalogAPI.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Categories, string Description, 
    string ImageUrl, decimal Price) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
 
        // Business logic to create a product
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Categories = command.Categories,
            Description = command.Description,
            ImageUrl = command.ImageUrl,
            Price = command.Price
        };

        //saave the product to the database

        return new CreateProductResult(Guid.NewGuid());
    }
}

