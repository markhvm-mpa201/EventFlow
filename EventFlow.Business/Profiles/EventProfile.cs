using AutoMapper;
using EventFlow.Business.Dtos.EventDtos;
using EventFlow.Core.Entities;

namespace EventFlow.Business.Profiles;

internal class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<Event, EventCreateDto>().ReverseMap();
        CreateMap<Event, EventGetDto>().ReverseMap();
        CreateMap<Event, EventUpdateDto>().ReverseMap();
    }
}
