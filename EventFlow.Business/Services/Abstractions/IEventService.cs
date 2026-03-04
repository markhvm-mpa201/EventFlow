using EventFlow.Business.Dtos.EventDtos;

namespace EventFlow.Business.Services.Abstractions;

public interface IEventService
{
    Task CreateAsync(EventCreateDto dto);
    Task UpdateAsync(EventUpdateDto dto);
    Task DeleteAsync(Guid id);
    Task<List<EventGetDto>> GetAllAsync();
    Task<EventGetDto> GetAsync(Guid id);
}
