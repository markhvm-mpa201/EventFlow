using Microsoft.AspNetCore.Http;

namespace EventFlow.Business.Dtos;
public class EventUpdateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public IFormFile? Image { get; set; }

    public Guid CategoryId { get; set; }
}