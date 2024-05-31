using Application.UserOrganizations.Commands.CreateUserOrganization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpPost("organization/associate")]
    public async Task<ActionResult<int>> Post(string slugTenant)
    {
        var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Created(string.Empty, await mediator.Send(new CreateUserOrganizationCommand { UserId = userId, SlugTenant = slugTenant }));
    }
}
