using Domain.Entities;
using Infrastructure.Context;
using MediatR;

namespace Application.UserOrganizations.Commands.CreateUserOrganization;

public class CreateUserOrganizationCommandHandler(AdminDbContext context) : IRequestHandler<CreateUserOrganizationCommand, int>
{
    public async Task<int> Handle(CreateUserOrganizationCommand request, CancellationToken cancellationToken)
    {
        var organization = context.Organizations.FirstOrDefault(x => x.SlugTenant == request.SlugTenant) ?? throw new Exception("slugTenant no es válido");

        var userOrganization = new UserOrganization
        {
            UserId = request.UserId,
            OrganizationId = organization.Id
        };

        context.UserOrganizations.Add(userOrganization);

        await context.SaveChangesAsync(cancellationToken);

        return userOrganization.Id;
    }
}
