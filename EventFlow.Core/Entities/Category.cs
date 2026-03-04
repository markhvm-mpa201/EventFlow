using EventFlow.Core.Entities.Common;

namespace EventFlow.Core.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<Event> Events { get; set; } = [];
}
