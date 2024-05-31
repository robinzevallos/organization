using MediatR;

namespace Application.Products.Queries.GetListProducts;

public record GetListProductsQuery : IRequest<ListProductDto[]>
{

}
