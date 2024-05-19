
namespace CatalogAPI.Products.GetProductById;

public record GetProductByIdResponse(Product Product);

public class GetProductByEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (ISender sender, Guid id) =>
        {
            var query = new GetProductByIdQuery(id);

            var result = await sender.Send(query);

            var response = result.Adapt<GetProductByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetProductById")
        .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product by Id")
        .WithDescription("Get Product by Id");
    }
}

