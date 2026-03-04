using EventFlow.Core.Entities;
using EventFlow.DataAccess.Repositories.Abstractions.Generic;

namespace EventFlow.DataAccess.Repositories.Abstractions;

internal interface IEventRepository : IRepository<Event>
{
}
