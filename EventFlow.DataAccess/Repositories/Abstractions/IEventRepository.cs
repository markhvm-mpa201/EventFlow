using EventFlow.Core.Entities;
using EventFlow.DataAccess.Repositories.Abstractions.Generic;

namespace EventFlow.DataAccess.Repositories.Abstractions;

public interface IEventRepository : IRepository<Event>
{
}
