namespace EventFlow.Business.Dtos.EventDtos;

public class EventCreateDto
{
    public string Name { get; set; } = string.Empty;

    public Guid CategoryId { get; set; }
}