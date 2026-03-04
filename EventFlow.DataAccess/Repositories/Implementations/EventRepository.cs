using EventFlow.Core.Entities;
using EventFlow.DataAccess.Contexts;
using EventFlow.DataAccess.Repositories.Abstractions;
using EventFlow.DataAccess.Repositories.Implementations.Generic;

namespace EventFlow.DataAccess.Repositories.Implementations;

internal class EventRepository(AppDbContext _context) : Repository<Event>(_context) ,IEventRepository
{
}
