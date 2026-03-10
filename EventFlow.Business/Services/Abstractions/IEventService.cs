namespace EventFlow.Business.Services.Abstractions;

public interface IEventService
{
    Task<ResultDto> CreateAsync(EventCreateDto dto);
    Task<ResultDto> UpdateAsync(EventUpdateDto dto);

    Task<ResultDto<EventUpdateDto>> GetUpdatedDtoAsync(Guid id);
    Task<ResultDto> DeleteAsync(Guid id);
    Task<ResultDto<List<EventGetDto>>> GetAllAsync();
    Task<ResultDto<EventGetDto>> GetByIdAsync(Guid id);
}
