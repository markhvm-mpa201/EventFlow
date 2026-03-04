namespace EventFlow.Business.Dtos.EventDtos;

public class EventUpdateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public string CategoryName { get; set; } = string.Empty;
}