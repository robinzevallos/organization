using Domain.Common;

namespace Domain.Entities;

public class UserOrganization : BaseEntity
{
    public string UserId { get; set; }

    public User User { get; set; }

    public int OrganizationId { get; set; }

    public Organization Organization { get; set; }
}
