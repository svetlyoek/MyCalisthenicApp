namespace MyCalisthenicApp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AnotherEnumAddedToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Products");
        }
    }
}
