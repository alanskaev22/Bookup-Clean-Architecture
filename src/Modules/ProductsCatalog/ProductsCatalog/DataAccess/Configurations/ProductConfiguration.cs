using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductsCatalog.DataAccess.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        ConfigureId(builder);

        ConfigureName(builder);

        ConfigureDescription(builder);

        ConfigurePrice(builder);

        ConfigureCategory(builder);

        ConfigureMediaResource(builder);
    }

    private static void ConfigureId(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever();
    }

    private static void ConfigureName(EntityTypeBuilder<Product> builder) => builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150);

    private static void ConfigureDescription(EntityTypeBuilder<Product> builder) => builder.Property(p => p.Description)
                .HasMaxLength(500);

    private static void ConfigurePrice(EntityTypeBuilder<Product> builder) =>
        builder.OwnsOne(p => p.Price, priceBuilder =>
        {
            priceBuilder.Property(p => p.Amount)
                .HasColumnName("PriceAmount")
                .IsRequired();

            priceBuilder.Property(p => p.Currency)
                .HasColumnName("Currency")
                .IsRequired()
                .HasMaxLength(3);
        });

    private static void ConfigureCategory(EntityTypeBuilder<Product> builder)
    {
        builder.HasMany(p => p.Categories)
                       .WithMany(c => c.Products)
                       .UsingEntity(j => j.ToTable("ProductCategories"));

        builder.Navigation(p => p.Categories)
               .UsePropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureMediaResource(EntityTypeBuilder<Product> builder)
    {
        builder.HasMany<MediaResource>()
                       .WithOne()
                       .HasForeignKey("ProductId")
                       .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(p => p.Media)
               .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
