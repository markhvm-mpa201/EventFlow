using EventFlow.Core.Entities.Common;

namespace EventFlow.Core.Entities;

public class Event : BaseAuditabelEntity
{
    public string Name { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public Guid CategoryId { get; set; }

    public Category Category { get; set; } = null!;
}
