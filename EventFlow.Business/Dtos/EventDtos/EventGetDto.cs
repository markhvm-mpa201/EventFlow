namespace EventFlow.Business.Dtos.EventDtos;

public class EventGetDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public string CategoryName { get; set; } = string.Empty;
}