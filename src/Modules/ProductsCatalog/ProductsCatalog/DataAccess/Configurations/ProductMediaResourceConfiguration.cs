using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductsCatalog.DataAccess.Configurations;

public class ProductMediaResourceConfiguration : IEntityTypeConfiguration<MediaResource>
{
    public void Configure(EntityTypeBuilder<MediaResource> builder)
    {
        ConfigureId(builder);

        ConfigureUrl(builder);

        ConfigureType(builder);

        ConfigureOrder(builder);

        ConfigureAltText(builder);

        ConfigureMimeType(builder);
    }

    private static void ConfigureId(EntityTypeBuilder<MediaResource> builder)
    {
        builder.HasKey(p => new { p.TenantId, p.Id });

        builder.Property(p => p.Id)
            .ValueGeneratedNever();
    }

    private static void ConfigureUrl(EntityTypeBuilder<MediaResource> builder) => builder.OwnsOne(p => p.Url, urlBuilder => urlBuilder.Property(p => p.Value)
                    .HasColumnName("Url")
                    .IsRequired()
                    .HasMaxLength(500));

    private static void ConfigureType(EntityTypeBuilder<MediaResource> builder) => builder.Property(p => p.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<MediaResourceType>(v))
                .IsRequired();

    private static void ConfigureOrder(EntityTypeBuilder<MediaResource> builder) => builder.Property(p => p.Order)
                .HasColumnName("Order")
                .IsRequired();

    private static void ConfigureAltText(EntityTypeBuilder<MediaResource> builder) => builder.Property(p => p.AltText)
                .HasMaxLength(150);

    private static void ConfigureMimeType(EntityTypeBuilder<MediaResource> builder) => builder.Property(p => p.MimeType)
                .HasMaxLength(50);
}
