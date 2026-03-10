using Microsoft.AspNetCore.Http;

namespace EventFlow.Business.Dtos;

public class EventCreateDto
{
    public string Name { get; set; } = string.Empty;

    public IFormFile Image { get; set; } = null!;

    public Guid CategoryId { get; set; }
}