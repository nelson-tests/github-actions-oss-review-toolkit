using Api;

namespace Tests.UsesCases;

public sealed class GetProductsTests(IntegrationTestsFactory factory) : IntegrationTests
{
    private readonly IntegrationTestsFactory _factory = factory;


    [Fact]
    public async Task All_Get_StatusCode200And100Products()
    {
        // Arrange && Act
        var act = await _factory.CreateClient()
            .GetAsync("/products");


        // Assert
        act.Should()
            .Be200Ok()
            .And.Satisfy<IEnumerable<ProductResponse>>(model =>
                model.Should().HaveCount(100));
    }
}
