using Microsoft.AspNetCore.Http;

namespace EventFlow.Business.Dtos;

public class EventCreateDto
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public IFormFile Image { get; set; } = null!;

    public decimal Price { get; set; }

    public Guid CategoryId { get; set; }
}