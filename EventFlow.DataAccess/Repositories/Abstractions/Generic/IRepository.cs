using EventFlow.Core.Entities.Common;

namespace EventFlow.DataAccess.Repositories.Abstractions.Generic;

internal interface IRepository<T> where T : BaseEntity
{
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    IQueryable<T> GetAll();
    Task<T?> GetByIdAsync(Guid id);

    Task<int> SaveChangesAsync();
}
