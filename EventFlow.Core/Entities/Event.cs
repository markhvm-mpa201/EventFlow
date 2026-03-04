using EventFlow.Core.Entities.Common;

namespace EventFlow.Core.Entities;

public class Event : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public Guid CategoryId { get; set; }

    public Category Category { get; set; } = null!;
}
