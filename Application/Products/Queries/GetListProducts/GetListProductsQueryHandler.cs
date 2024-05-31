using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.Queries.GetListProducts;

public class GetListProductsQueryHandler(ApplicationDbContext context) : IRequestHandler<GetListProductsQuery, ListProductDto[]>
{
    public async Task<ListProductDto[]> Handle(GetListProductsQuery request, CancellationToken cancellationToken)
    {
        return await context.Products
            .Select(p => new ListProductDto 
            { 
                Name = p.Name 
            })
            .ToArrayAsync(cancellationToken);
    }
}
