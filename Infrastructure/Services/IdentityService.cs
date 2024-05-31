using Domain.Entities;
using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services;

public class IdentityService(SignInManager<User> signInManager, UserManager<User> userManager, AdminDbContext context, IConfiguration configuration)
{
    public async Task<SignInResponse> SignIn(SignInRequest model)
    {
        var result = await signInManager.PasswordSignInAsync(
            userName: model.Username,
            password: model.Password,
            isPersistent: false,
            lockoutOnFailure: true);

        if (!result.Succeeded)
        {
            throw new Exception("Invalid login attempt.");
        }

        var userOrganizations = context.UserOrganizations
            .Include(x => x.Organization)
            .Where(x => x.User.UserName == model.Username);

        return new()
        {
            AccessToken = await GetTokenAsync(model.Username),
            Tenants = [.. userOrganizations.Select(x => new SignInResponse.Tenant { SlugTenant = x.Organization.SlugTenant })],
        };
    }

    public async Task<CreateResponse> Create(CreateUserRequest model)
    {
        var errors = new List<IdentityError>();

        if (model.Password != model.ConfirmPassword)
        {
            errors.Add(new IdentityError { Description = "Passwords do not match." });
        }

        var user = new User
        {
            UserName = model.Username,
        };

        var result = await userManager.CreateAsync(user, model.Password);

        errors.AddRange(result.Errors);


        return new()
        {
            Succeeded = result.Succeeded,
            Errors = errors,
        };
    }

    public async Task<string> GetTokenAsync(string username)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var user = await userManager.FindByNameAsync(username);
        var roles = await userManager.GetRolesAsync(user);

        var claims = new List<Claim> 
        { 
            new(ClaimTypes.NameIdentifier, user.Id),
            new(ClaimTypes.Name, user.UserName),
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]!);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims.ToArray()),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
