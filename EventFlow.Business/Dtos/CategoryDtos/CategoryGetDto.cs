using EventFlow.Business.Dtos.EventDtos;

namespace EventFlow.Business.Dtos.CategoryDtos;

public class CategoryGetDto
{
    public Guid Id {  get; set; }
    public string Name { get; set; } = string.Empty;
    public List<EventGetDto> Events { get; set; } = [];
}
