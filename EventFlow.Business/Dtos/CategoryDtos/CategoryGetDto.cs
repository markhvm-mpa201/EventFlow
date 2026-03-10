namespace EventFlow.Business.Dtos;

public class CategoryGetDto
{
    public Guid Id {  get; set; }
    public string Name { get; set; } = string.Empty;
    public List<EventGetDto> Events { get; set; } = [];
}
