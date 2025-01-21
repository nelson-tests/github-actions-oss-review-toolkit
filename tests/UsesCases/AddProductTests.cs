using System.Net.Http.Json;
using Api;
using Bogus;

namespace Tests.UsesCases;

public sealed class AddProductTests(IntegrationTestsFactory factory) : IntegrationTests
{
    private readonly IntegrationTestsFactory _factory = factory;


    [Fact]
    public async Task NewPrduct_Post_StatusCode201AndId()
    {
        // Arrange
        var product = new Faker<ProductRequest>()
            .RuleFor(p => p.Name, s => s.Commerce.ProductName())
            .RuleFor(p => p.Quantity, s => s.Random.Int(1, 100))
            .Generate();


        // Act
        var act = await _factory.CreateClient()
            .PostAsync(
                "/products",
                JsonContent.Create(product));


        // Assert
        act.Should()
            .Be201Created()
            .And.Satisfy<ProductResponse>(model =>
                model.Should().Match<ProductResponse>(m =>
                    m.Name == product.Name &&
                    m.Quantity == product.Quantity));
    }
}
