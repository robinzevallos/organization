using Infrastructure.Context;
using MediatR;

namespace Application.Products.Queries.GetProduct;

public class GetProductQueryHandler(ApplicationDbContext context) : IRequestHandler<GetProductQuery, ProductDto>
{
    public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await context.Products
            .FindAsync([request.Id], cancellationToken);

        return new()
        {
            Description = product.Description,
            Name = product.Name,
            Price = product.Price
        };
    }
}
