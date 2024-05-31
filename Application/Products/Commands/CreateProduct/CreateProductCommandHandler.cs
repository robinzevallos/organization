using Domain.Entities;
using Infrastructure.Context;
using MediatR;

namespace Application.Products.Commands.CreateProduct;

public record CreateProductCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateProductCommand, int>
{
    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price
        };

        context.Products.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
