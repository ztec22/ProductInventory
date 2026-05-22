using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductInventory.Migrations
{
    /// <inheritdoc />
    public partial class AddProductData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "Brand", "Category", "Name", "Price", "Vendor" },
                values: new object[,]
                {
                    { 1, 1, "Brand 1", "Electronics", "Mouse", 6.5, "Vendor 1" },
                    { 2, 1, "Brand 2", "Electronics", "Keyboard", 9.5, "Vendor 2" },
                    { 3, 1, "Brand 3", "Electronics", "Screen", 120.59999999999999, "Vendor 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
