namespace Tests.UsesCases;

public sealed class DeleteProductTests(IntegrationTestsFactory factory) : IntegrationTests
{
    private readonly IntegrationTestsFactory _factory = factory;


    [Fact]
    public async Task ProductId_Delete_StatusCode204()
    {
        // Arrange
        var id = Guid.NewGuid();


        // Act
        var act = await _factory.CreateClient()
            .DeleteAsync($"/products/{id}");


        // Assert
        act.Should().Be204NoContent();
    }
}
