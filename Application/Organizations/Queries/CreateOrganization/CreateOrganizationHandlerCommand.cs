using Infrastructure.Context;
using MediatR;
using Domain.Entities;

namespace Application.Organizations.Queries.CreateOrganization;

public class CreateOrganizationHandlerCommand(AdminDbContext context) : IRequestHandler<CreateOrganizationCommand, int>
{
    public async Task<int> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
    {
        var entity = new Organization
        {
            Name = request.Name,
            SlugTenant = request.SlugTenant
        };

        context.Organizations.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
