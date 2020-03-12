namespace MyCalisthenicApp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ProductsEnumChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sort",
                table: "ProductCategories");

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "ProductCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
