namespace Application.Products.Queries.GetProduct;

public record ProductDto
{
    public string Name { get; init; }

    public string Description { get; init; }

    public decimal Price { get; init; }
}
