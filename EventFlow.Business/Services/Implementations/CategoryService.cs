using AutoMapper;
using CaegoryFlow.Business.Services.Abstractions;
using EventFlow.Business.Dtos.CategoryDtos;
using EventFlow.Business.Exceptions;
using EventFlow.Core.Entities;
using EventFlow.DataAccess.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Business.Services.Implementations;

internal class CategoryService(ICategoryRepository _repository, IMapper _mapper) : ICategoryService
{
    public async Task<ResultDto> CreateAsync(CategoryCreateDto dto)
    {
        var isExistCategory = await _repository.AnyAsync(c => c.Name == dto.Name);

        if (isExistCategory)
            throw new AlreadyExistException();

        var Category = _mapper.Map<Category>(dto);

        await _repository.AddAsync(Category);
        await _repository.SaveChangesAsync();

        return new("Created");
    }

    public async Task<ResultDto> DeleteAsync(Guid id)
    {
        var category = await _repository.GetAsync(x => x.Id == id);

        if (category is null)
            throw new NotFoundException();

        _repository.Delete(category);
        await _repository.SaveChangesAsync();

        return new("Deleted");
    }

    public async Task<ResultDto<List<CategoryGetDto>>> GetAllAsync()
    {
        var categories = await _repository.GetAll().Include(x => x.Events).ToListAsync();

        var dtos = _mapper.Map<List<CategoryGetDto>>(categories);

        return new(dtos);
    }

    public async Task<ResultDto<CategoryGetDto>> GetByIdAsync(Guid id)
    {
        var category = await _repository.GetAsync(x => x.Id == id);

        if (category is null)
            throw new NotFoundException();

        var dto = _mapper.Map<CategoryGetDto>(category);

        return new(dto);
    }

    public async Task<ResultDto> UpdateAsync(CategoryUpdateDto dto)
    {
        var category = await _repository.GetByIdAsync(dto.Id);

        if (category is null)
            throw new NotFoundException();

        var isExistCategory = await _repository.AnyAsync
            (c => c.Name.ToLower() == dto.Name.ToLower() && c.Id != dto.Id);

        if (isExistCategory)
            throw new AlreadyExistException();

        category = _mapper.Map(dto, category);

        _repository.Update(category);

        await _repository.SaveChangesAsync();

        return new("Updated");
    }
}