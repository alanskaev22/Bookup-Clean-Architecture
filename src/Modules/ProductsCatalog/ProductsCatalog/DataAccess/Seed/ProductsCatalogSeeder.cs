using Microsoft.EntityFrameworkCore;
using Shared.DataAccess.Seed;

namespace ProductsCatalog.DataAccess.Seed;

public class ProductsCatalogSeeder(ProductsCatalogDbContext dbContext) : IDataSeeder
{
    public async Task SeedAllAsync()
    {
        if (!await dbContext.Products.AnyAsync())
        {
            await dbContext.Products.AddRangeAsync(InitialData.Products);
            await dbContext.SaveChangesAsync();
        }
    }
}
