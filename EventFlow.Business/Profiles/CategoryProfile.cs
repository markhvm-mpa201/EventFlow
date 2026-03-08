using AutoMapper;
using EventFlow.Business.Dtos.CategoryDtos;
using EventFlow.Core.Entities;

namespace EventFlow.Business.Profiles;

internal class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        CreateMap<Category, CategoryGetDto>().ReverseMap();
        CreateMap<Category, CategoryUpdateDto>().ReverseMap();
    }
}
