using MediatR;

namespace Application.Products.Commands.CreateProduct;

public record CreateProductCommand : IRequest<int>
{
    public string Name { get; init; }

    public string Description { get; init; }

    public decimal Price { get; init; }
}
