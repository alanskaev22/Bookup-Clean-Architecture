using ProductsCatalog.Products.Domain;
using Shared.Constants;

namespace ProductsCatalog.DataAccess.Seed;

public static class InitialData
{
    private static readonly Guid _tenantId = Guid.NewGuid();

    public static IEnumerable<Product> Products => [
        Product.Create(
            _tenantId,
            ProductId.Create(Guid.NewGuid().ToString()).Value,
            "COMODEX CLEAN & CLEAR CLEANSER 250ML",
            "Christina",
            "Anti Bacterial Soap, Removes Dirty and Makeup Residue, Leaves The Skin Calm. Benefits: 1) Balances sebum secretion and excretion. 2) Anti bacterial, prevents recurrence of comedones. 3) Soothes irritation and redness. Skin Types: Combination, Normal, Oily. Age: Teens - 50s+.  Directions: Apply a small amount onto wet skin and massage with circular motions. Rinse with lukewarm water. Size: 250 ml",
            Money.Create(125, Currency.Create(CurrencyConstants.USD).Value).Value,
            [ Category.Create(_tenantId, "Facial Cleansers").Value,Category.Create(_tenantId, "Skin Care").Value],
            [ MediaResource.Create(_tenantId, Url.Create("https://example.com/image1.jpg").Value, MediaResourceType.Image, 1, "Image", "png").Value ]
        ).Value,
        Product.Create(
            _tenantId,
            ProductId.Create(Guid.NewGuid().ToString()).Value,
            "Facial Moisturizing C-Vit Liposomal Serum 30ML",
            "Sesderma",
            "Brightens and revitalizes the skin. Lightens and evens out the complexion. Fights the signs of fatigue and prevents the appearance of wrinkles. Increases skin smoothness, turgor, and elasticity (collagen synthesis). Prevents the action of free radicals thanks to its antioxidant action. Directions: Cleanse and balance your skin. Next, apply 4 drops of C-VIT Liposomal serum evenly with a gentle massage to face, neck, and décolleté. Follow with your daily moisturizer.",
            Money.Create(65.59M, Currency.Create(CurrencyConstants.USD).Value).Value,
            [ Category.Create(_tenantId, "Cosmetics").Value, Category.Create(_tenantId, "Skin Care").Value],
            [ MediaResource.Create(_tenantId, Url.Create("https://example.com/image2.jpg").Value, MediaResourceType.Image, 1, "Image", "png").Value ]
        ).Value,
        ];
}
