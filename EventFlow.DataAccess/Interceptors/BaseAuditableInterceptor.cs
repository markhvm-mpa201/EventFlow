using EventFlow.Core.Entities.Common;
using EventFlow.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EventFlow.DataAccess.Interceptors;

internal class BaseAuditableInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateAuditColumns(eventData);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateAuditColumns(eventData);

        return base.SavingChanges(eventData, result);
    }

    private static void UpdateAuditColumns(DbContextEventData eventData)
    {
        if (eventData.Context is AppDbContext appDbContext)
        {
            var entries = appDbContext.ChangeTracker.Entries<BaseAuditabelEntity>().ToList();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "Lol";
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = "Lol";
                        entry.Entity.UpdatedDate = DateTime.UtcNow;
                        break;

                    case EntityState.Deleted:
                        entry.Entity.DeletedBy = "Lol";
                        entry.Entity.DeletedDate = DateTime.UtcNow;
                        entry.Entity.IsDeleted = true;
                        entry.State = EntityState.Modified;
                        break;
                }
            }
        }
    }
}
