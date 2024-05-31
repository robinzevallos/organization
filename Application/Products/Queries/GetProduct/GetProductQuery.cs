using MediatR;

namespace Application.Products.Queries.GetProduct;

public record GetProductQuery : IRequest<ProductDto>
{
    public int Id { get; init; }
}
