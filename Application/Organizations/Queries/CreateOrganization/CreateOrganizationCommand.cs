using MediatR;

namespace Application.Organizations.Queries.CreateOrganization;

public record CreateOrganizationCommand : IRequest<int>
{
    public string Name { get; set; }

    public string SlugTenant { get; set; }
}
