using Api;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests;

public sealed class IntegrationTestsFactory : WebApplicationFactory<ProductRequest> { }

public abstract class IntegrationTests : IClassFixture<IntegrationTestsFactory> { }
