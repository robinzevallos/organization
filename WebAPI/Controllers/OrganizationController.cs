using Application.Organizations.Queries.CreateOrganization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrganizationController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateOrganizationCommand command)
    {
        return Created(string.Empty, await mediator.Send(command));
    }
}
