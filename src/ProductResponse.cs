namespace Api;

public sealed record ProductResponse
{
    public Guid Id { get; init; } = default!;
    public string Name { get; init; } = default!;
    public int Quantity { get; init; } = default!;
}
