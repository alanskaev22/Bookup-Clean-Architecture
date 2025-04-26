using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductsCatalog.DataAccess.Configurations;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        ConfigureId(builder);

        ConfigureName(builder);
    }

    private static void ConfigureId(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => new { c.TenantId, c.Id });

        builder.Property(c => c.Id)
            .ValueGeneratedNever();
    }

    private static void ConfigureName(EntityTypeBuilder<Category> builder)
    {
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasIndex(c => c.Name)
              .IsUnique();
    }
}
