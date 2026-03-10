using AutoMapper;
using EventFlow.Business.Exceptions;
using EventFlow.Business.Services.Abstractions;
using EventFlow.Core.Entities;
using EventFlow.DataAccess.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Business.Services.Implementations;

internal class EventService(IEventRepository _repository, IMapper _mapper, ICloudinaryService _cloudinaryService) : IEventService
{
    public async Task<ResultDto> CreateAsync(EventCreateDto dto)
    {
        var Event = _mapper.Map<Event>(dto);

        var imagePath = await _cloudinaryService.FileCreateAsync(dto.Image);
        Event.ImagePath = imagePath;

        await _repository.AddAsync(Event);
        await _repository.SaveChangesAsync();

        return new("Created");
    }

    public async Task<ResultDto> DeleteAsync(Guid id)
    {
        var Event = await _repository.GetByIdAsync(id);

        if (Event is null)
            throw new NotFoundException();

        _repository.Delete(Event);
        await _repository.SaveChangesAsync();

        await _cloudinaryService.FileDeleteAsync(Event.ImagePath);

        return new("Deleted");
    }

    public async Task<ResultDto<List<EventGetDto>>> GetAllAsync()
    {
        var events = await _repository.GetAll().Include(x => x.Category).ToListAsync();

        var dtos = _mapper.Map<List<EventGetDto>>(events);

        return new(dtos);
    }

    public async Task<ResultDto<EventGetDto>> GetByIdAsync(Guid id)
    {
        var Event = await _repository.GetByIdAsync(id);

        if (Event is null)
            throw new NotFoundException();

        var dto = _mapper.Map<EventGetDto>(Event);

        return new(dto);
    }

    public async Task<ResultDto<EventUpdateDto>> GetUpdatedDtoAsync(Guid id)
    {
        var Event = await _repository.GetByIdAsync(id);

        if (Event is null)
            throw new NotFoundException("Project is not found");

        var dto = _mapper.Map<EventUpdateDto>(Event);

        return new(dto);
    }

    public async Task<ResultDto> UpdateAsync(EventUpdateDto dto)
    {
        var Event = await _repository.GetByIdAsync(dto.Id);

        if (Event is null)
            throw new NotFoundException();

        Event = _mapper.Map(dto, Event);

        if (dto.Image is not null)
        {
            await _cloudinaryService.FileDeleteAsync(Event.ImagePath);
            var imagePath = await _cloudinaryService.FileCreateAsync(dto.Image);
            Event.ImagePath = imagePath;
        }

        _repository.Update(Event);

        await _repository.SaveChangesAsync();

        return new("Updated");
    }
}