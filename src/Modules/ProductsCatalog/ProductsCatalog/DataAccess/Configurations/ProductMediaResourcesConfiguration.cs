using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductsCatalog.DataAccess.Configurations;

public class ProductMediaResourcesConfiguration : IEntityTypeConfiguration<MediaResource>
{
    public void Configure(EntityTypeBuilder<MediaResource> builder)
    {
        ConfigureId(builder);

        builder.OwnsOne(p => p.Url)
            .
    }

    private static void ConfigureId(EntityTypeBuilder<MediaResource> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever();
    }
}
