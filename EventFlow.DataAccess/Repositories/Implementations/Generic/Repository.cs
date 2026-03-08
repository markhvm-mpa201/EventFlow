using EventFlow.Core.Entities.Common;
using EventFlow.DataAccess.Contexts;
using EventFlow.DataAccess.Repositories.Abstractions.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EventFlow.DataAccess.Repositories.Implementations.Generic;

internal class Repository<T>(AppDbContext _context) : IRepository<T> where T : BaseEntity
{
    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public IQueryable<T> GetAll(bool ignoreQueryFilter = false)
    {
        var query = _context.Set<T>().AsQueryable();

        if (ignoreQueryFilter)
            query = query.IgnoreQueryFilters();

        return query;
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        return entity;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> expression) 
    {
        var entity = await _context.Set<T>().FirstOrDefaultAsync(expression);
        return entity;
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        var entity = await _context.Set<T>().AnyAsync(expression);
        return entity;
    }
}
