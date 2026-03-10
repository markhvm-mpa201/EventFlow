using AutoMapper;
using EventFlow.Business.Dtos.UserDtos;
using EventFlow.Core.Entities;

namespace EventFlow.Business.Profiles;

internal class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<AppUser, RegisterDto>().ReverseMap();
    }
}
