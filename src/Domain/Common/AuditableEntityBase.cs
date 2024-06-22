namespace Domain.Common;

public abstract record AuditableEntityBase : EntityBase
{
    public DateTimeOffset CreatedAt { get; set; }

    public long CreatedBy { get; set; }

    public DateTimeOffset LastUpdatedAt { get; set; }

    public long LastUpdatedBy { get; set; }
}
