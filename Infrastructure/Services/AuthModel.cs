using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services;

public readonly struct SignInRequest
{
    public string Username { get; init; }
    public string Password { get; init; }
}

public readonly struct SignInResponse
{
    public string? AccessToken { get; init; }
    public Tenant[] Tenants { get; init; }

    public readonly struct Tenant
    {
        public string SlugTenant { get; init; }
    }
}

public struct CreateUserRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

public struct CreateResponse
{
    public bool Succeeded { get; set; }
    public IEnumerable<IdentityError> Errors { get; set; }
}
