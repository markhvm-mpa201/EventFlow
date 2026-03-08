namespace EventFlow.Core.Entities.Common;

public abstract class BaseAuditabelEntity : BaseEntity
{
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string? DeletedBy { get; set; }
    public DateTime? DeletedDate { get; set; }

    public bool IsDeleted { get; set; } = false;
}