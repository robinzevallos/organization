using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IdentityService identityService) : ControllerBase
{
    [HttpPost(nameof(SignIn))]
    public async Task<ActionResult<SignInResponse>> SignIn(SignInRequest model)
    {
        return Ok(await identityService.SignIn(model));
    }

    [HttpPost(nameof(SignUp))]
    public async Task<ActionResult<CreateResponse>> SignUp(CreateUserRequest model)
    {
        return Ok(await identityService.Create(model));
    }
}
