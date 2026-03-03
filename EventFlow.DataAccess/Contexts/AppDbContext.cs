using EventFlow.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.DataAccess.Contexts;

internal class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Event> Events { get; set; }
    public DbSet<Category> Categories { get; set; }
}
