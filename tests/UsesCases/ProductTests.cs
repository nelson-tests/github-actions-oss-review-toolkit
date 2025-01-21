using System.Net.Http.Json;
using Api;
using Bogus;

namespace Tests.UsesCases;

public sealed class UpdateProductTests(IntegrationTestsFactory factory) : IntegrationTests
{
    private readonly IntegrationTestsFactory _factory = factory;


    [Fact]
    public async Task ProductId_Put_StatusCode204()
    {
        // Arrange
        var id = Guid.NewGuid();

        var product = new Faker<ProductRequest>()
            .RuleFor(p => p.Name, s => s.Commerce.ProductName())
            .RuleFor(p => p.Quantity, s => s.Random.Int(1, 100))
            .Generate();


        // Act
        var act = await _factory.CreateClient()
            .PutAsync(
                $"/products/{id}",
                JsonContent.Create(product));


        // Assert
        act.Should().Be204NoContent();
    }
}
