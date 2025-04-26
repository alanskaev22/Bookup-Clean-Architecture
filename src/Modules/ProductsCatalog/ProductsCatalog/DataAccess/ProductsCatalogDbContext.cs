using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ProductsCatalog.DataAccess;

public class ProductsCatalogDbContext(DbContextOptions<ProductsCatalogDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<MediaResource> ProductMediaResources => Set<MediaResource>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(nameof(ProductsCatalog));
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
