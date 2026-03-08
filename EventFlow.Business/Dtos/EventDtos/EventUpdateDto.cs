using Microsoft.AspNetCore.Http;

namespace EventFlow.Business.Dtos.EventDtos;

public class EventUpdateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public IFormFile? Image { get; set; }

    public string CategoryName { get; set; } = string.Empty;
}