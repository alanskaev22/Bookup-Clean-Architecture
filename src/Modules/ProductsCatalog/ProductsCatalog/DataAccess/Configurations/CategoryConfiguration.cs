using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsCatalog.Products.Domain;

namespace ProductsCatalog.DataAccess.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        ConfigureId(builder);

        ConfigureProducts(builder);

        ConfigureName(builder);
    }

    private static void ConfigureId(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => new { c.TenantId, c.Id });

        builder.Property(c => c.Id)
            .ValueGeneratedNever();
    }

    private static void ConfigureProducts(EntityTypeBuilder<Category> builder) => builder.Navigation(p => p.Products)
               .UsePropertyAccessMode(PropertyAccessMode.Field);

    private static void ConfigureName(EntityTypeBuilder<Category> builder)
    {
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasIndex(c => c.Name);
    }
}
