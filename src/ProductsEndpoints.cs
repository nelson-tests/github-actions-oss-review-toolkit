using Bogus;

namespace Api;

internal static class ProductsEndpoints
{
    public static void MapProductsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/products");

        group.MapGet("", () =>
        {
            var products = new Faker<ProductResponse>()
                .RuleFor(p => p.Id, s => s.Random.Guid())
                .RuleFor(p => p.Name, s => s.Commerce.ProductName())
                .RuleFor(p => p.Quantity, s => s.Random.Int(1, 100))
                .Generate(100);

            return Results.Ok(products);
        });

        group.MapGet("{id:guid}", (Guid id) =>
        {
            var product = new Faker<ProductResponse>()
                .RuleFor(p => p.Id, id)
                .RuleFor(p => p.Name, s => s.Commerce.ProductName())
                .RuleFor(p => p.Quantity, s => s.Random.Int(1, 100))
                .Generate();

            return Results.Ok(product);
        }).WithName("GetProduct");

        group.MapPost("", (ProductRequest request) =>
        {
            var product = new ProductResponse
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Quantity = request.Quantity
            };

            return Results.CreatedAtRoute(
                "GetProduct",
                new { id = product.Id.ToString() },
                product);
        });

        group.MapPut("{id:guid}", (Guid id, ProductRequest request)
            => Results.NoContent());

        group.MapDelete("{id:guid}", (Guid id)
            => Results.NoContent());
    }
}
