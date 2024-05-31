namespace Domain.Common;

public class AuditableEntity : BaseEntity
{
    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }
}
