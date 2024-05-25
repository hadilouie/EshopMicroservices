
namespace CatalogAPI.Products.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Categories).NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Describtion is required");
        RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("ImageUrl is rquired");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}

