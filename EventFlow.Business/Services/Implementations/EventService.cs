using AutoMapper;
using EventFlow.Business.Dtos.EventDtos;
using EventFlow.Business.Exceptions;
using EventFlow.Business.Services.Abstractions;
using EventFlow.Core.Entities;
using EventFlow.DataAccess.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Business.Services.Implementations;

internal class EventService(IEventRepository _repository, IMapper _mapper) : IEventService
{
    public async Task CreateAsync(EventCreateDto dto)
    {
        var Event = _mapper.Map<Event>(dto);

        await _repository.AddAsync(Event);
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var Event = await _repository.GetByIdAsync(id);

        if (Event is null)
            throw new NotFoundException("Event not found");

        _repository.Delete(Event);
        await _repository.SaveChangesAsync();
    }

    public async Task<List<EventGetDto>> GetAllAsync()
    {
        var events = await _repository.GetAll().Include(x=>x.Category).ToListAsync();

        var dtos = _mapper.Map<List<EventGetDto>>(events);

        return dtos;
    }

    public async Task<EventGetDto> GetAsync(Guid id)
    {
        var Event = await _repository.GetByIdAsync(id);

        if (Event is null)
            throw new NotFoundException("Event not found");

        var dto = _mapper.Map<EventGetDto>(Event);

        return dto;
    }

    public async Task UpdateAsync(EventUpdateDto dto)
    {
        var Event = await _repository.GetByIdAsync(dto.Id);

        if (Event is null)
            throw new NotFoundException("Event not found");

        Event = _mapper.Map(dto, Event);

        _repository.Update(Event);

        await _repository.SaveChangesAsync();
    }
}
