using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Shared.DataAccess.Interceptors;

public class AuditableEntityInterceptor(TimeProvider timeProvider) : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateEntities(DbContext? context)
    {
        if (context is null)
        {
            return;
        }

        foreach (var entry in context.ChangeTracker.Entries<IEntity>())
        {
            if (entry.State is EntityState.Added)
            {
                entry.Entity.CreatedAt = timeProvider.GetUtcNow();
                entry.Entity.CreatedBy = "askaev"; // TODO: Get the current user
            }
            if (entry.State is EntityState.Added || entry.State is EntityState.Modified || entry.HasChangedOwnedEntities())
            {
                entry.Entity.LastModifiedAt = timeProvider.GetUtcNow();
                entry.Entity.LastModifiedby = "System"; // TODO: Get the current user
            }
        }
    }
}
