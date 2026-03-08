using EventFlow.Core.Entities;
using EventFlow.DataAccess.Contexts;
using EventFlow.DataAccess.Repositories.Abstractions;
using EventFlow.DataAccess.Repositories.Implementations.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventFlow.DataAccess.Repositories.Implementations;

internal class CategoryRepository(AppDbContext _context) : Repository<Category>(_context) ,ICategoryRepository
{
}
