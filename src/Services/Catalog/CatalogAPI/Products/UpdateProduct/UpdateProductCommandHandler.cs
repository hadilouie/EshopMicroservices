﻿namespace CatalogAPI.Products.UpdateProduct;
public record UpdateProductCommand(Guid Id, string Name, string ImageUrl,
    string Description, decimal Price, List<string> Categories) :
    ICommand<UpdateProductResult>;

public record UpdateProductResult(bool IsSuccess);
internal class UpdateProductCommandHandler(IDocumentSession session)
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = session.Load<Product>(command.Id);

        if (product is null)
        {
            throw new ProductNotFoundException(command.Id);
        }

        product.Name = command.Name;
        product.Description = command.Description;
        product.Price = command.Price;
        product.Categories = command.Categories;
        product.ImageUrl = command.ImageUrl;

        session.Update(product);

        await session.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);

    }
}

