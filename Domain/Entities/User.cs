using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser
{
    public ICollection<UserOrganization> UserOrganizations { get; set; }
}
