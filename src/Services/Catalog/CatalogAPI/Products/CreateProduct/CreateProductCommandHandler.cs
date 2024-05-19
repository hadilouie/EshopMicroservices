namespace CatalogAPI.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Categories, string Description, 
    string ImageUrl, decimal Price) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
 
        // Business logic to create a product
        var product = new Product
        {
            Name = command.Name,
            Categories = command.Categories,
            Description = command.Description,
            ImageUrl = command.ImageUrl,
            Price = command.Price
        };

        //save the product to the database
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
    }
}

