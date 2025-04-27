using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsCatalog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ProductsCatalog");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "ProductsCatalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LastModifiedby = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => new { x.TenantId, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "ProductsCatalog",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Brand = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    SellingPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LastModifiedby = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => new { x.TenantId, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                schema: "ProductsCatalog",
                columns: table => new
                {
                    CategoriesTenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoriesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductsTenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductsId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesTenantId, x.CategoriesId, x.ProductsTenantId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesTenantId_CategoriesId",
                        columns: x => new { x.CategoriesTenantId, x.CategoriesId },
                        principalSchema: "ProductsCatalog",
                        principalTable: "Categories",
                        principalColumns: new[] { "TenantId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsTenantId_ProductsId",
                        columns: x => new { x.ProductsTenantId, x.ProductsId },
                        principalSchema: "ProductsCatalog",
                        principalTable: "Products",
                        principalColumns: new[] { "TenantId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductMediaResources",
                schema: "ProductsCatalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    AltText = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    MimeType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ProductId = table.Column<string>(type: "text", nullable: true),
                    ProductTenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    Tenantid = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LastModifiedby = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMediaResources", x => new { x.TenantId, x.Id });
                    table.ForeignKey(
                        name: "FK_ProductMediaResources_Products_ProductTenantId_ProductId",
                        columns: x => new { x.ProductTenantId, x.ProductId },
                        principalSchema: "ProductsCatalog",
                        principalTable: "Products",
                        principalColumns: new[] { "TenantId", "Id" });
                    table.ForeignKey(
                        name: "FK_ProductMediaResources_Products_Tenantid_ProductId",
                        columns: x => new { x.Tenantid, x.ProductId },
                        principalSchema: "ProductsCatalog",
                        principalTable: "Products",
                        principalColumns: new[] { "TenantId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                schema: "ProductsCatalog",
                table: "Categories",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsTenantId_ProductsId",
                schema: "ProductsCatalog",
                table: "CategoryProduct",
                columns: new[] { "ProductsTenantId", "ProductsId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductMediaResources_ProductTenantId_ProductId",
                schema: "ProductsCatalog",
                table: "ProductMediaResources",
                columns: new[] { "ProductTenantId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductMediaResources_Tenantid_ProductId",
                schema: "ProductsCatalog",
                table: "ProductMediaResources",
                columns: new[] { "Tenantid", "ProductId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct",
                schema: "ProductsCatalog");

            migrationBuilder.DropTable(
                name: "ProductMediaResources",
                schema: "ProductsCatalog");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "ProductsCatalog");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "ProductsCatalog");
        }
    }
}
