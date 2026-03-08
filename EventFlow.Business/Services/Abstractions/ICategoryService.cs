using EventFlow.Business.Dtos.CategoryDtos;

namespace CaegoryFlow.Business.Services.Abstractions;

public interface ICategoryService
{
    Task<ResultDto> CreateAsync(CategoryCreateDto dto);
    Task<ResultDto> UpdateAsync(CategoryUpdateDto dto);
    Task<ResultDto> DeleteAsync(Guid id);
    Task<ResultDto<List<CategoryGetDto>>> GetAllAsync();
    Task<ResultDto<CategoryGetDto>> GetByIdAsync(Guid id);
}
