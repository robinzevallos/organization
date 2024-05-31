using Domain.Common;

namespace Domain.Entities;

public class Organization : BaseEntity
{
    public string Name { get; set; }

    public string SlugTenant { get; set; }

    public ICollection<UserOrganization> UserOrganizations { get; set; }
}
