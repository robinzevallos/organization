using MediatR;

namespace Application.UserOrganizations.Commands.CreateUserOrganization;

public record CreateUserOrganizationCommand : IRequest<int>
{
    public string UserId { get; init; }

    public string SlugTenant { get; init; }
}
