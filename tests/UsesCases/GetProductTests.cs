using Api;

namespace Tests.UsesCases;

public sealed class GetProductTests(IntegrationTestsFactory factory) : IntegrationTests
{
    private readonly IntegrationTestsFactory _factory = factory;


    [Fact]
    public async Task ProductId_Get_StatusCode200AndProduct()
    {
        // Arrange
        var id = Guid.NewGuid();


        // Act
        var act = await _factory.CreateClient()
            .GetAsync($"/products/{id}");


        // Assert
        act.Should()
            .Be200Ok()
            .And.Satisfy<ProductResponse>(model =>
                model.Should().Match<ProductResponse>(m => !string.IsNullOrWhiteSpace(m.Name)));
    }
}
